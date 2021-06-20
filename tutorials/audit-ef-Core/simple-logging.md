---
PermaID: 100003
Name: Simple Logging
---

# Simple Logging

`Audit.EntityFramework` provides the infrastructure to log various kinds of operations with the EF `DbContext`. It allows you to store detailed information about Insert, Update and Delete operations in your database.

To use logging in your application, you need to change your context class to inherit from `AuditDbContext` instead of `DbContext` as shown below.

```csharp
public class BookStore : AuditDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;");
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

Now we need to use data annotations to decorate the context class with the `AuditDbContext` attribute as shown below.

```csharp
[AuditDbContext(Mode = AuditOptionMode.OptOut, IncludeEntityObjects = true, AuditEventType = "{BookStoreDb}_{BookStore}")]
public class BookStore : AuditDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;");
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

The following example logs an insert operation in the json format.

```csharp
public static void Example1()
{
    var evs = new List<EntityFrameworkEvent>();

    Audit.Core.Configuration.Setup().UseDynamicProvider(_ => _.OnInsert(ev =>
    {
        evs.Add(ev.GetEntityFrameworkEvent());
    }));

    using (BookStore context = new BookStore())
    {

        Author newAuthor = new Author() { Name = "James" };
        context.Authors.Add(newAuthor);
        context.SaveChanges();
    }

    foreach (var ev in evs)
    {
        Console.WriteLine(ev.ToJson());
    }
    
}
```

Let's run the above code and you will see the following output.

```csharp
{"Database":"BookStoreDb","Entries":[{"Table":"Authors","Name":"Author","Action":"Insert","PrimaryKey":{"AuthorId":13},"Entity":{"AuthorId":13,"Name":"James"},"ColumnValues":{"AuthorId":13,"Name":"James"},"Valid":true}],"Result":1,"Success":true}

```
