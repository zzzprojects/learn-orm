---
PermaID: 100002
Name: Exceptions Handling
---

# Exceptions Handling

**EntityFrameworkCore.Exceptions.SqlServer** simplifies exceptions by handling all the database-specific details and throwing different exceptions. 

 - You have to configure the `DbContext` by calling `UseExceptionProcessor` in the `OnConfiguring` method and handle the exceptions. 
 - You can use `UniqueConstraintException`, `CannotInsertNullException`, `MaxLengthExceededException`, `NumericOverflowException`, `ReferenceConstraintException` as per your requirement.

So first, we need to update our context class, as shown below.

```csharp
public class BookStore : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;")
            .UseExceptionProcessor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Author>().HasIndex(a => a.Name).IsUnique();
        builder.Entity<Author>().Property(a => a.Name).IsRequired().HasMaxLength(15);
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

You will now start getting a different exception for the different database errors. Let's consider the following example when a unique constraint fails, you will get the `UniqueConstraintException` exception as shown below.

```csharp
using (BookStore context = new BookStore())
{
    try
    {
        var authors = new List<Author>
        {
            new Author { Name="Jones" },
            new Author { Name="Jones" }
        };

        authors.ForEach(a => context.Authors.Add(a));
        context.SaveChanges();
    }
    catch (UniqueConstraintException e)
    {
        Console.WriteLine(e.Message);
    }
}
```

When you execute the above code, you will see the following output.

```csharp
Unique constraint violation
```

Let's consider another example where we have passed null for the `Name` property.
 
```csharp
using (BookStore context = new BookStore())
{
    try
    {
        var author = new Author ();

        context.Authors.Add(author);
        context.SaveChanges();
    }
    catch (CannotInsertNullException e)
    {
        Console.WriteLine(e.Message);
    }
}
```

When you execute the above code, you will see the following output.

```csharp
Cannot insert null
```

