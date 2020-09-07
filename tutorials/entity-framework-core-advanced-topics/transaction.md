---
PermaID: 110015
Name: Transaction
---

# Transaction

When you call `SaveChanges` to insert, delete, or update data to the database, then entity framework core will wrap that operation in a transaction.

 - Transactions allow several database operations to be processed in an atomic manner. 
 - If the transaction is committed, all of the operations are successfully applied to the database. 
 - If the transaction is rolled back, none of the operations are applied to the database.

## Default transaction behavior

 - By default, all changes in a single call to `SaveChanges` are applied in a transaction. If any of the changes fail, then the transaction is rolled back and none of the changes are applied to the database. 
 - It means that `SaveChanges` is guaranteed to either completely succeed, or leave the database unmodified if an error occurs.
 - For most applications, this default behavior is sufficient. You should only manually control transactions if your application requirements deem it necessary.

In EF Core, you can use multiple `SaveChanges` within a single transaction. You can use the `DbContext.Database` API to begin, commit, and rollback transactions. The following example shows two `SaveChanges` operations and a LINQ query being executed in a single transaction.


```csharp
using (var context = new EntityContext())
{
    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            var author = context.Authors.Where(c => c.AuthorId == 1).FirstOrDefault();

            author.Address = "43 rue St. Laurent";

            context.SaveChanges();

            context.Authors.Add(new Author
            {
                FirstName = "Elizabeth",
                LastName = "Lincoln",
                Address = "23 Tsawassen Blvd."
            });

            context.SaveChanges();

            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
        }
    }
}
```

## Cross-context Transaction

You can share a transaction across multiple context instances, but it is only available when using a relational database provider because it requires the use of `DbTransaction` and `DbConnection`, which are specific to relational databases.

To share a transaction, the contexts must share both a `DbConnection` and a `DbTransaction`.

### Provide Connection Externally

To a share a `DbConnection`, we need to pass a connection into a context when constructing it. The easiest way to allow `DbConnection` to be externally provided, is to stop using the `OnConfiguring` method to configure the context and externally create `DbContextOptions` and pass them to the context constructor.

```csharp
class EntityContext : DbContext
{
    public EntityContext(DbContextOptions<EntityContext> options) : base(options)
    { 
    }
    
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

### Share Connection and Transaction

You can create multiple context instances that share the same connection by using the `DbContext.Database.UseTransaction(DbTransaction)` API to enlist both contexts in the same transaction.

```csharp
using (var context1 = new EntityContext(options))
{
    context1.Database.EnsureCreated();
    using (var transaction = context1.Database.BeginTransaction())
    {
        try
        {
            context1.Authors.Add(new Author { FirstName = "Mark", LastName = "Henry", Address = "rue St. Laurent" });
            context1.SaveChanges();

            using (var context2 = new EntityContext(options))
            {
                context2.Database.UseTransaction(transaction.GetDbTransaction());

                var author = context2.Authors
                    .Where(c => c.AuthorId == 1)
                    .FirstOrDefault();

                author.Address = "43 rue St. Laurent";
            }

            transaction.Commit();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
```
