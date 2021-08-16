---
PermaID: 100003
Name: Basic List Query
---

# Basic List Query

Most of the applications would perform the basic operation to retrieve data from the database and display the results. This article will explain the basic list query using Dapper, which gets the data into the list from the database.

**Dapper** provides a `Query` extension method that enables you to retrieve data from the database and populate data in your object model.

Let's consider, we have two tables in the database that contains the following data.

<img src="images/database-setup.png" alt="Database data">

To retrieve the data from the database using **Dapper**, we need to create two classes called `Author` and `Book`.

```csharp
class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Book> Books { get; set; }
}

class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public int AuthorId { get; set; }
}
```

In the `Main` method, create a member of type `IDbConnection` with the `SqlConnection` by passing the connection string.

```csharp
static void Main(string[] args)
{
    IDbConnection db = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreContext;Integrated Security=True;");

    List<Author> authors = db.Query<Author>("SELECT * FROM Authors").ToList();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}
```

As you can see that the `Query` method is used to retrieve the data from the `Authors` table.

When you execute the above code, and you will see the following output.

```csharp
Cardinal Tom B. Erichsen
Meredith Alonso
Robert T. Kiyosaki
```
