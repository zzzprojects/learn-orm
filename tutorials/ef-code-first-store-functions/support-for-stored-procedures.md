---
PermaID: 100003
Name: Support for Stored Procedures
---

# Support for Stored Procedures

A stored procedure in SQL Server is a group of one or more Transact-SQL statements that you can save and reuse over and over again. If you have a query that you are writing over and over again in your application, you can save it as a stored procedure, and then just call it to execute it.

So let's consider we want the following stored procedure in our database.

```csharp
CREATE PROCEDURE [dbo].[GetBooksByCategory] 
    @Category nvarchar(max) 
AS 
    SELECT [Id], [Title], [NoOfPages], [Category], [AuthorId] 
    FROM [dbo].[Books] 
    WHERE [Category] LIKE (@Category)
```

So, we need to map the method to this store procedure, and to do so, we will have to meet some specific requirements imposed by the Entity Framework. 

The following are the requirements for methods mapped to stored procedures.

 - The return type must be an `ObjectResult<T>`.
 - You can also specify the name of the database schema if it is different from the default name by setting the DatabaseSchema property of the DbFunctionDetailsAttribute.

So, let's add the following method to your context class which is mapped to the stored procedure.

```csharp
public ObjectResult<Book> GetBooksByCategory(string category)
{
    var categoryParameter = category != null ?
        new ObjectParameter("Category", category) :
        new ObjectParameter("Category", typeof(string));

    return ((IObjectContextAdapter)this).ObjectContext.
        ExecuteFunction<Book>("GetBooksByCategory", categoryParameter);
}
```

Here is the updated context class after adding the above method.

```csharp
public class BookStore : DbContext
{
    public BookStore()
    {
        Database.SetInitializer(new BookStoreInitializer());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Add(new FunctionsConvention<BookStore>("dbo"));
    }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    [DbFunction("BookStore", "AuthorsByCountry")]
    public IQueryable<Author> AuthorsByCountry(string country)
    {
        var countryParameter = country != null ?
            new ObjectParameter("Country", country) :
            new ObjectParameter("Country", typeof(string));

        string queryString = string.Format("[{0}].{1}", GetType().Name, "[AuthorsByCountry](@Country)");

        return ((IObjectContextAdapter)this).ObjectContext
            .CreateQuery<Author>(queryString, countryParameter);
    }

    public ObjectResult<Book> GetBooksByCategory(string category)
    {
        var categoryParameter = category != null ?
            new ObjectParameter("Category", category) :
            new ObjectParameter("Category", typeof(string));

        return ((IObjectContextAdapter)this).ObjectContext.
            ExecuteFunction<Book>("GetBooksByCategory", categoryParameter);
    }
}
```

Now we must also update our custom initializer so that the stored procedure is also created when the database is created.

```csharp
public override void InitializeDatabase(BookStore context)
{
    base.InitializeDatabase(context);

    context.Database.ExecuteSqlCommand(
        "CREATE FUNCTION [dbo].[AuthorsByCountry](@Country nchar(50)) " +
        "RETURNS TABLE " +
        "RETURN " +
        "SELECT [AuthorId], [Name], [Country] " +
        "FROM [dbo].[Authors] " +
        "WHERE [Country] = @Country");

    context.Database.ExecuteSqlCommand(
        "CREATE PROCEDURE [dbo].[GetBooksByCategory] @Category nvarchar(max) AS " +
        "SELECT [Id], [Title], [NoOfPages], [Category], [AuthorId] " +
        "FROM [dbo].[Books] " +
        "WHERE [Category] LIKE (@Category)");
}
```

The following example retrieves all the books which belong to the "AI" category using stored procedure.

```csharp
public static void Example1()
{
    using (var context = new BookStore())
    {
        const string category = "AI";
        var aiBooks = context.GetBooksByCategory(category);

        foreach (var book in aiBooks)
        {
            Console.WriteLine(book.Title);
        }
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
Introduction to Machine Learning
Advanced Topics in Machine Learning
Introduction to AI
```
