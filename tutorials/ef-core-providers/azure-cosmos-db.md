---
PermaID: 1000021
Name: Azure Cosmos DB
---

# Azure Cosmos DB Provider

Azure Cosmos DB is Microsoft's proprietary globally-distributed, multi-model database service launched in May 2017. It is schema-agnostic, horizontally scalable, and generally classified as a NoSQL database.

 - It is a fully managed NoSQL database for modern app development. 
 - Single-digit millisecond response times, and automatic and instant scalability, guarantee the speed at any scale.

## Install Entity Framework Core

Let's create a new application using the **Console App (.NET Core)** template and install the following NuGet package. 

In the **Package Manager Console** window, enter the following command.

```csharp
PM> Install-Package Microsoft.EntityFrameworkCore
```

You can also install this NuGet package by right-clicking on your project in Solution Explorer and select **Manage Nuget Packages...**. 

<img src="images/cosmos-1.png">

Search for **Microsoft.EntityFrameworkCore** and install the latest version by pressing the install button.

## Register EF Core Provider

For Azure Cosmos DB, first, we need to install [Microsoft.EntityFrameworkCore.Cosmos](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Cosmos) in your project using **Package Manager Console** window. It will get all the packages required for EF Core.

```csharp
PM> Install-Package Microsoft.EntityFrameworkCore.Cosmos
```

Now, you are ready to start your application.

## Create Data Model
 
Model is a collection of classes to interact with the database.

 - A model stores data that is retrieved according to the commands from the Controller and displayed in the View.
 - It can also be used to manipulate the data to implement the business logic.

To create a data model for our application, we will start with the following two entities.

```csharp
public class Author
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Book> Books { get; set; }
}

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public Author Author { get; set; }
}
```

There's a one-to-many relationship between `Author` and `Book` entities. In other words, an author can write any number of books, and a book can be written by only one author.

## Create Database Context

The database context class provides the main functionality to coordinate Entity Framework with a given data model. 

 - You create this class by deriving from the `System.Data.Entity.DbContext` class. 
 - In your code, you specify which entities are included in the data model. 
 - You can also customize certain Entity Framework behaviors. 

So, let's add a new `BookStore` class which will inherit the `DbContext` class.

```csharp
public class BookStore : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var accountEndpoint = "https://cosmosdbname.documents.azure.com:443/";
        var accountKey = "uMb2G6V1yaQl96iLsdM05ctSVVUgTix5IyIBJhKALiPg10ZtdeTNxhsyJhNv9jQrlTlb6KEYKdDZcEs5HRoZKQ==";
        var databaseName = "BookStoreDb";

        optionsBuilder.UseCosmos(accountEndpoint, accountKey, databaseName);
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```
In EF Core, the DbContext has a virtual method called `OnConfiguring` which will get called internally by EF Core. 

 - It will pass in an `optionsBuilder` instance which can be used to configure options for the `DbContext`.
 - The `optionsBuilder` has the `UseOracle` method which expects a `accountEndpoint`, and `accountKey` and database name as a parameter. 

## Create Database

Now to create a database using migrations from your model, install the following packages

```csharp
PM> Install-Package Microsoft.EntityFrameworkCore.Tools
PM> Install-Package Microsoft.EntityFrameworkCore.Design
```

Once these packages are installed, run the following command in **Package Manager Console**.

```csharp
Add-Migration Initial
```

This command scaffold a migration to create the initial set of tables for your model. When it is executed successfully, then run the following command.

```csharp
Update-Database
```

This command applies the new migration to the database and creates the database before applying migrations.

Now, we are done with the required classes and database creation, let's add some authors and book records to the database and then retrieve it.

```csharp
using (var context = new BookStore())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    var authors = new List<Author>
    {
        new Author
        {
            AuthorId = 1,
            FirstName ="Carson",
            LastName ="Alexander",
            BirthDate = DateTime.Parse("1985-09-01"),
            Books = new List<Book>()
            {
                new Book { BookId = 1, Title = "Introduction to Machine Learning", AuthorId = 1},
                new Book { BookId = 2, Title = "Advanced Topics on Machine Learning", AuthorId = 1},
                new Book { BookId = 3, Title = "Introduction to Computing", AuthorId = 1}
            }
        },
        new Author
        {
            AuthorId = 2,
            FirstName ="Meredith",
            LastName ="Alonso",
            BirthDate = DateTime.Parse("1970-09-01"),
            Books = new List<Book>()
            {
                new Book { BookId = 4, Title = "Introduction to Microeconomics", AuthorId = 2}
            }
        },
        new Author
        {
            AuthorId = 3,
            FirstName ="Arturo",
            LastName ="Anand",
            BirthDate = DateTime.Parse("1963-09-01"),
            Books = new List<Book>()
            {
                new Book { BookId = 5, Title = "Calculus I", AuthorId = 3},
                new Book { BookId = 6, Title = "Calculus II", AuthorId = 3}
            }
        }
    };

    context.Authors.AddRange(authors);
    context.SaveChanges();
}

using (var context = new BookStore())
{
    var authors = context.Authors.ToList();
    var books = context.Books.ToList();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);

        foreach (var book in books)
        {
            if (author.AuthorId == book.AuthorId)
                Console.WriteLine("\t" + book.Title);
        }
    }
}
```

If you run the application, you will see that authors and books are successfully inserted into the database and also printed on the console.

```csharp
Carson Alexander
        Introduction to Machine Learning
        Advanced Topics on Machine Learning
        Introduction to Computing
Meredith Alonso
        Introduction to Microeconomics
Arturo Anand
        Calculus I
        Calculus II
```