---
PermaID: 100002
Name: Validation Constraints
---

# Validation Constraints

The .NET provides various built-in validation attributes, which allow you to use certain constraints on properties. Typically, these attributes are used by web frameworks such as ASP.NET to validate data provided by users but `EFCore.CheckConstraints` allows you to enforce them in the database as well.

Let's say we have the following `Author` class.

```csharp
public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
```

When you use the code-first approach, EF Core will generate the following table against the `Author` class.

```csharp
CREATE TABLE [dbo].[Authors] (
    [AuthorId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Age]      INT            NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([AuthorId] ASC)
);
```

Now we have to add some attributes as shown below.

```csharp
public class Author
{
    public int AuthorId { get; set; }
    [MinLength(3)]
    public string Name { get; set; }
    [Range(18, 100)]
    public int Age { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
```

To register the contraints, we need to call the `UseValidationCheckConstraints()` method.

```csharp
public class BookStore : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;")
            .UseValidationCheckConstraints();
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

Let's execute your code again so that EF regenerates the tables again.

```csharp
CREATE TABLE [dbo].[Authors] (
    [AuthorId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Age]      INT            NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([AuthorId] ASC),
    CONSTRAINT [CK_Authors_Age_Range] CHECK ([Age]>=(18) AND [Age]<=(100)),
    CONSTRAINT [CK_Authors_Name_MinLength] CHECK (len([Name])>=(3))
);
```

As you can see that EF now defines the constraints on the table as well.
