---
PermaID: 100001
Name: Connection Resiliency
---

# Connection Resiliency

Connection resiliency is the ability to automatically retry certain transient errors when attempting to connect to the database. In most applications, a database connection is always vulnerable to connection breaks due to back-end failures and network instability.

 - With the rise of cloud-based database servers such as Windows Azure and connections over less reliable networks, it is now more common for connection breaks to occur.
 - The feature can be used with any database by supplying an "execution strategy", which encapsulates the logic necessary to detect failures and retry commands.
 - EF Core providers can supply execution strategies tailored to their specific database failure conditions and optimal retry policies.

The SQL Server provider includes an execution strategy that is specifically tailored to SQL Server including SQL Azure. It is aware of the exception types that can be retried and has sensible defaults for maximum retries, the delay between retries, etc. An execution strategy is specified in the `OnConfiguring` method of your context class.

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder
        .UseSqlServer(
            @"Data Source=(localdb)\ProjectsV13;Initial Catalog=NewBookStore;Trusted_Connection=True;MultipleActiveResultSets=true",
            options => options.EnableRetryOnFailure());
}
```

In the ASP.NET Core application, you can also specify an execution strategy in `Startup.cs`.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<PicnicContext>(
        options => options.UseSqlServer(
            @"Data Source=(localdb)\ProjectsV13;Initial Catalog=NewBookStore;Trusted_Connection=True;MultipleActiveResultSets=true",
            providerOptions => providerOptions.EnableRetryOnFailure()));
}
```

## Custom Execution Strategy

You can register a custom execution strategy of your own if you wish to change any of the defaults.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<PicnicContext>(
        options => options.UseSqlServer(
            @"Data Source=(localdb)\ProjectsV13;Initial Catalog=NewBookStore;Trusted_Connection=True;MultipleActiveResultSets=true",
            options => options.ExecutionStrategy(...));
}
```

## Execution Strategies and Transactions

An execution strategy that automatically retries on failures needs to be able to playback each operation in a retry block that fails. 

 - When retries are enabled, each operation you perform via EF Core becomes its retriable operation. 
 - Each query and each call to `SaveChanges()` will be retried as a unit if a transient failure occurs.

However, if your code initiates a transaction using `BeginTransaction()`, you are defining your group of operations that need to be treated as a unit, and everything inside the transaction would need to be played back shall a failure occur. You will receive an exception like the following if you attempt to do this when using an execution strategy:

> InvalidOperationException: The configured execution strategy 'SqlServerRetryingExecutionStrategy' does not support user-initiated transactions. Use the execution strategy returned by 'DbContext.Database.CreateExecutionStrategy()' to execute all the operations in the transaction as a retriable unit.

The solution is to manually invoke the execution strategy with a delegate representing everything that needs to be executed. If a transient failure occurs, the execution strategy will invoke the delegate again.

```csharp
using (var db = new EntityContext())
{
    var strategy = db.Database.CreateExecutionStrategy();

    strategy.Execute(() =>
    {
        using (var context = new EntityContext())
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Authors.Add(new Author { FirstName = "Carson", LastName = "Alexander", BirthDate = DateTime.Parse("1985-09-01") });
                context.SaveChanges();

                context.Authors.Add(new Author { FirstName = "Meredith", LastName = "Alonso", BirthDate = DateTime.Parse("1970-09-01") });
                context.SaveChanges();

                transaction.Commit();
            }
        }
    });
}
```

You can also use the ambient transactions approach. 

```csharp
using (var context1 = new EntityContext())
{
    context1.Authors.Add(new Author { FirstName = "Carson", LastName = "Alexander", BirthDate = DateTime.Parse("1985-09-01") });

    var strategy = context1.Database.CreateExecutionStrategy();

    strategy.Execute(() =>
    {
        using (var context2 = new EntityContext())
        {
            using (var transaction = new TransactionScope())
            {
                context2.Authors.Add(new Author { FirstName = "Meredith", LastName = "Alonso", BirthDate = DateTime.Parse("1970-09-01") });
                context2.SaveChanges();

                context1.SaveChanges();

                transaction.Complete();
            }
        }
    });
}
```

## Transaction Commit Failure and the Idempotency Issue

In general, when there is a connection failure the current transaction is rolled back. However, if the connection is dropped while the transaction is being committed the resulting state of the transaction is unknown.

By default, the execution strategy will retry the operation as if the transaction were rolled back, but if it's not the case this will result in an exception if the new database state is incompatible or could lead to data corruption if the operation does not rely on a particular state, for example when inserting a new row with auto-generated key values.

There are several ways to deal with this.

### Do (almost) Nothing

The likelihood of a connection failure during transaction commit is low so it may be acceptable for your application to just fail if this condition occurs.

 - You need to avoid using store-generated keys to ensure that an exception is thrown instead of adding a duplicate row. 
 - Consider using a client-generated GUID value or a client-side value generator.

### Rebuild Application State

 - Discard the current `DbContext`.
 - Create a new `DbContext` and restore the state of your application from the database.
 - Inform the user that the last operation might not have been completed successfully.

### Add State Verification

EF provides an extension method `IExecutionStrategy.ExecuteInTransaction` to add code that checks whether it succeeded or not for most of the operations that change the database state.

This method begins and commits a transaction and also accepts a function in the `verifySucceeded` parameter that is invoked when a transient error occurs during the transaction commit.

```csharp
using (var db = new EntityContext())
{
    var strategy = db.Database.CreateExecutionStrategy();

    var authorToAdd = new Author { FirstName = "Carson", LastName = "Alexander", BirthDate = DateTime.Parse("1985-09-01") };
    db.Authors.Add(authorToAdd);

    strategy.ExecuteInTransaction(db,
        operation: context =>
        {
            context.SaveChanges(acceptAllChangesOnSuccess: false);
        },
        verifySucceeded: context => context.Authors.AsNoTracking().Any(a => a.AuthorId == authorToAdd.AuthorId));

    db.ChangeTracker.AcceptAllChanges();
}
```

In the above code, `SaveChanges` is invoked with `acceptAllChangesOnSuccess` set to `false` to avoid changing the state of the `Author` entity to `Unchanged` if `SaveChanges` succeeds. This allows you to retry the same operation if the commit fails and the transaction is rolled back.

### Manually Track the Transaction

If you need to use store-generated keys or need a generic way of handling commit failures that don't depend on the operation performed each transaction could be assigned an `ID` that is checked when the commit fails.

 1. Add a table to the database used to track the status of the transactions.
 2. Insert a row into the table at the beginning of each transaction.
 3. If the connection fails during the commit, check for the presence of the corresponding row in the database.
 4. If the commit is successful, delete the corresponding row to avoid the growth of the table.

```csharp
using (var db = new EntityContext())
{
    var strategy = db.Database.CreateExecutionStrategy();

    db.Authors.Add(new Author { FirstName = "Carson", LastName = "Alexander", BirthDate = DateTime.Parse("1985-09-01") });

    var transaction = new TransactionRow { Id = Guid.NewGuid() };
    db.Transactions.Add(transaction);

    strategy.ExecuteInTransaction(db,
        operation: context =>
        {
            context.SaveChanges(acceptAllChangesOnSuccess: false);
        },
        verifySucceeded: context => context.Transactions.AsNoTracking().Any(t => t.Id == transaction.Id));

    db.ChangeTracker.AcceptAllChanges();
    db.Transactions.Remove(transaction);
    db.SaveChanges();
}
```
