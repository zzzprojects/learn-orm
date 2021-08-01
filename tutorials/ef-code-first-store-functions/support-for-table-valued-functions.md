---
PermaID: 100002
Name: Support for Table-Valued Functions
---

# Support for Table-Valued Functions

A table-valued function is a user-defined function that returns data of a table type. The return type of a table-valued function is a table, therefore, you can use the table-valued function just like you would use a table.

So let's consider we want the following TVF in our database.

```csharp
CREATE FUNCTION [dbo].[AuthorsByCountry](@Country nchar(50)) 
RETURNS TABLE 
RETURN SELECT [AuthorId], [Name], [Country] 
FROM [dbo].[Authors] 
WHERE [Country] = @Country
```

So, we need to map the method to this store function and to do so, we will have to meet some specific requirements imposed by the Entity Framework. 

The following are the requirements for methods mapped to table-valued functions.

 - The return type must be an `IQueryable<T>`.
 - The method parameters must be of scalar such as primitive or enum types mappable to EF types.
 - Decorate the methods with `DbFunctionAttribute` where the first argument is typically your `DbContext` and the second argument is the function name.
 - Make sure the name of the method, the value of the `DbFunction.FunctionName`, and the queryString name passed to the `CreateQuery` call must all be the same.

So, let's add the following method to your context class which is mapped to the TVF.

```csharp
[DbFunction("BookStore", "AuthorsByCountry")]
public IQueryable<Author> AuthorsByCountry(string country)
{
    var countryParameter = country != null ?
        new ObjectParameter("Country", country) :
        new ObjectParameter("Country", typeof(string));

    string queryString = string.Format("[{0}].{1}", GetType().Name, "[AuthorsByCountry](@Country)");

    return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Author>(queryString, countryParameter);
}
```

Let's update the context class by adding the `OnModelCreating` method.

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

        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Author>(queryString, countryParameter);
    }
}
```

As you saw in the previous article, we have added a custom initializer to initialize the database. The initializer also populates the database with some data in the `Seed` method. Let's create a table-valued function by executing the SQL in the `ExecuteSqlCommand` method inside `InitializeDatabase()` as shown below.

```csharp
public class BookStoreInitializer : DropCreateDatabaseAlways<BookStore>
{
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
    }

    protected override void Seed(BookStore context)
    {
        var authors = new List<Author>
        {
            new Author { Name="Carson Alexander", Country = "US" },
            new Author { Name="Meredith Alonso", Country = "UK" },
            new Author { Name="Arturo Anand", Country = "Canada" },
            new Author { Name="Gytis Barzdukas", Country = "UK"},
            new Author { Name="Yan Li", Country = "Japan" },
        };

        authors.ForEach(a => context.Authors.Add(a));
        context.SaveChanges();

        var books = new List<Book>
        {
            new Book { Title = "Introduction to Machine Learning", NoOfPages = 530, Category = "AI", AuthorId = 1 },
            new Book { Title = "Advanced Topics in Machine Learning", NoOfPages = 380, Category = "AI", AuthorId = 1 },
            new Book { Title = "Introduction to Computing", NoOfPages = 1171, Category = "Computer", AuthorId = 1 },
            new Book { Title = "Introduction to Microeconomics", NoOfPages = 437, Category = "Math", AuthorId = 2 },
            new Book { Title = "Calculus I", NoOfPages = 1477, Category = "Math", AuthorId = 3 },
            new Book { Title = "Calculus II", NoOfPages = 1571, Category = "Math", AuthorId = 3 },
            new Book { Title = "Trigonometry Basics", NoOfPages = 540, Category = "Math", AuthorId = 4 },
            new Book { Title = "Special Topics in Trigonometry", NoOfPages = 490, Category = "Math", AuthorId = 4 },
            new Book { Title = "Advanced Topics in Mathematics", NoOfPages = 895, Category = "Math", AuthorId = 4 },
            new Book { Title = "Introduction to AI", NoOfPages = 530, Category = "AI", AuthorId = 4 },
        };

        books.ForEach(b => context.Books.Add(b));
        context.SaveChanges();
    }
}
```

The following example retrieves all the authors from the "UK" using TVF.

```csharp
public static void Example1()
{
    using (var context = new BookStore())
    {
        const string country = "UK";
        var authorsFromUK = context.AuthorsByCountry(country);

        foreach (var author in authorsFromUK)
        {
            Console.WriteLine(author.Name);
        }
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
Meredith Alonso
Gytis Barzdukas
```
