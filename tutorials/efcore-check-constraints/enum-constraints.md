---
PermaID: 100003
Name: Enum Constraints
---

# Enum Constraints

When you map a .NET enum to the database, by default that's done by storing the enum's underlying `int` in a plain old database `int` column. Although the .NET enum has a constrained set of values that you have defined, on the database side there's nothing stopping anyone from inserting any value, including ones that are out of range.

Let's say we have the following `Book` class.

```csharp
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
    public int Rating { get; set; }
    public Category Category { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}

public enum Category
{
    Education,
    Sports,
    Art
}
```

When you use the code-first approach, EF Core will generate the following table against the `Book` class.

```csharp
CREATE TABLE [dbo].[Books] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (MAX) NULL,
    [NoOfPages] INT            NOT NULL,
    [Rating]    INT            NOT NULL,
    [Category]  INT            NOT NULL,
    [AuthorId]  INT            NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([AuthorId]) ON DELETE CASCADE
);
```

Now we have to add some attributes as shown below.

```csharp
public class Book
{
    public int Id { get; set; }
    [StringLength(100, MinimumLength = 1)]
    public string Title { get; set; }
    public int NoOfPages { get; set; }
    [Range(1, 5)]
    public int Rating { get; set; }
    public Category Category { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
```

To activate enum check constraints, we need to call the `UseEnumCheckConstraints()` method.

```csharp
public class BookStore : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;")
            .UseValidationCheckConstraints()
            .UseEnumCheckConstraints();
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

Let's execute your code again so that EF regenerates the tables again.

```csharp
CREATE TABLE [dbo].[Books] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (100) NULL,
    [NoOfPages] INT            NOT NULL,
    [Rating]    INT            NOT NULL,
    [Category]  INT            NOT NULL,
    [AuthorId]  INT            NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([AuthorId]) ON DELETE CASCADE,
    CONSTRAINT [CK_Books_Category_Enum] CHECK ([Category]=(2) OR [Category]=(1) OR [Category]=(0)),
    CONSTRAINT [CK_Books_Rating_Range] CHECK ([Rating]>=(1) AND [Rating]<=(5)),
    CONSTRAINT [CK_Books_Title_MinLength] CHECK (len([Title])>=(1))
);
```

As you can see that EF now defines the constraints for enum and the added `CHECK` constraint allows only 0, 1, and 2 to be stored in the column, ensuring better data integrity.
