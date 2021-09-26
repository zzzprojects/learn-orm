---
PermaID: 100002
Name: Use Temporal Queries
---

# Use Temporal Queries

`Dabble.EntityFrameworkCore.Temporal.Query` provides the support for temporal queries in the SQL Server. To use temporal queries in your application, we need to configure the entity.

In the `OnModelCreating` method, use the `HasTemporalTable()` extension method to mark your desired entities as candidates for the `FOR SYSTEM TIME` syntax. 

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>(a => {
        a.HasTemporalTable();
    });
}
```

We also need to call the `EnableTemporalTableQueries()` extension method in `OnConfiguring` to replace the necessary EF pipeline services responsible for generating the SQL syntax at runtime.

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder
        .UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;")
        .EnableTemporalTableQueries();
}
```

In the previous articles, we have set up the database, which contains two tables, `Authors` and `Books`. The problem is the tables created by EF Core are not a system-versioned temporal table. 

Let's run the following script by updating the `Initialize` method to make the `Authors` table a system-versioned temporal table.  

```csharp
public static void Initialize()
{
    using (BookStore context = new BookStore())
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        string script = @"
ALTER TABLE Authors   
   ADD   
      SysStartTime datetime2(0) GENERATED ALWAYS AS ROW START HIDDEN,   
      SysEndTime datetime2(0) GENERATED ALWAYS AS ROW END HIDDEN,
      PERIOD FOR SYSTEM_TIME (SysStartTime, SysEndTime);   
";

        context.Database.ExecuteSqlRaw(script);

        script = @"ALTER TABLE Authors SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.AuthorsHistory));";

        context.Database.ExecuteSqlRaw(script);

        var authors = new List<Author>
        {
            new Author { Name="Carson Alexander" },
            new Author { Name="Meredith Alonso" },
            new Author { Name="Arturo Anand" },
            new Author { Name="Gytis Barzdukas"},
            new Author { Name="Yan Li" },
        };

        authors.ForEach(a => context.Authors.Add(a));
        context.SaveChanges();

        var books = new List<Book>
        {
            new Book { Title = "Introduction to Machine Learning", NoOfPages = 530, AuthorId = 1 },
            new Book { Title = "Advanced Topics in Machine Learning", NoOfPages = 380, AuthorId = 1 },
            new Book { Title = "Introduction to Computing", NoOfPages = 1171, AuthorId = 1 },
            new Book { Title = "Introduction to Microeconomics", NoOfPages = 437, AuthorId = 2 },
            new Book { Title = "Calculus I", NoOfPages = 1477, AuthorId = 3 },
            new Book { Title = "Calculus II", NoOfPages = 1571, AuthorId = 3 },
            new Book { Title = "Trigonometry Basics", NoOfPages = 540, AuthorId = 4 },
            new Book { Title = "Special Topics in Trigonometry", NoOfPages = 490, AuthorId = 4 },
            new Book { Title = "Advanced Topics in Mathematics", NoOfPages = 895, AuthorId = 4 },
            new Book { Title = "Introduction to AI", NoOfPages = 530, AuthorId = 4 },
        };

        books.ForEach(b => context.Books.Add(b));
        context.SaveChanges();
    }
}
```

Now you can use the `IQueryable<T>.AsOf(DateTime)` extension method to specialize a LINQ expression to a particular point in time.

The following example queries an author records from a temporal table at a specific time.

```csharp
using (BookStore context = new BookStore())
{
    var authorRecords = context.Authors
        .AsOf(DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(30)))
        .ToList();
}
```
