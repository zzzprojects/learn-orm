---
PermaID: 100002
Name: Use HierarchyId
---

# Use HierarchyId

`EntityFrameworkCore.SqlServer.HierarchyId` provides the support for hierarchyid to the SQL Server EF Core provider. To use hierarchyid in your application, let's change the `Author` class as shown below.

```csharp
public class Author
{
    public HierarchyId AuthorId { get; set; }
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; }
}
```

You also need to enable hierarchyid support by calling `UseHierarchyId` inside the `UseSqlServer` method. 

```csharp
public class BookStore : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;", 
            x => x.UseHierarchyId());
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

The `UseSqlServer`  is typically called inside `Startup.ConfigureServices` or `OnConfiguring` method of your `DbContext` type.

You can add the hierarchyid in your primary key as shown below.

```csharp
using (BookStore context = new BookStore())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    var authors = new List<Author>
    {
        new Author { AuthorId = HierarchyId.GetRoot() , Name="Carson Alexander" },
        new Author {  AuthorId = HierarchyId.Parse("/1/"), Name="Meredith Alonso" },
        new Author {  AuthorId = HierarchyId.Parse("/1/1/"), Name="Arturo Anand" },
        new Author {  AuthorId = HierarchyId.Parse("/1/2/"), Name="Gytis Barzdukas"},
        new Author {  AuthorId = HierarchyId.Parse("/1/1/1/"), Name="Yan Li" },
    };

    authors.ForEach(a => context.Authors.Add(a));
    context.SaveChanges();
}
```

The following example retrieves all authors from the level 2 hierarchyid.

```csharp
using (BookStore context = new BookStore())
{
    var authors = context.Authors.Where(a => a.AuthorId.GetLevel() == 2).ToList();

    foreach (var author in authors)
    {
        Console.WriteLine("{0}, {1}", author.AuthorId, author.Name);
    }
}
```

Let's run your application, and you will see the following output.

```csharp
/1/1/, Arturo Anand
/1/2/, Gytis Barzdukas
```
