---
PermaID: 100003
Name: Custom AutoHistory
---

# Custom AutoHistory

**Microsoft.EntityFrameworkCore.AutoHistory** allows you to use a custom auto history entity by extending the `Microsoft.EntityFrameworkCore.AutoHistory` class.

```csharp
class MyCustomAutoHistory : AutoHistory
{
    public String MyCustomField { get; set; }
}
```

Once you add your custom auto history class, you need to register it within your context class. Let's update the `OnModelCreating` to register your auto history class, as shown below.

```csharp
public class BookStore : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.EnableAutoHistory<MyCustomAutoHistory>(o => { });
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

Now when you call an `EnsureAutoHistory`, then you provide a custom history entity. 

```csharp
public static void Example1()
{
    using (var context = new BookStore())
    {
        var author = context.Authors.FirstOrDefault();
        author.Name = "Jones";

        context.EnsureAutoHistory(() => new MyCustomAutoHistory()
        {
            MyCustomField = "You custom value"
        });
        context.SaveChanges();
    }
}
```

