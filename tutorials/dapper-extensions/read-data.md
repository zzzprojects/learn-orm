---
PermaID: 100003
Name: Read Data
---

# Read Data

Most of the applications would perform the basic operation to retrieve data from the database and display the results. We have two tables in the database that contains the following data.

<img src="images/database-setup.png" alt="Database data">

To retrieve the data from the database using **Dapper Extensions**, let's create two classes called `Author` and `Book`.

Here is the implementation of the `Author` class.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensionsDemo
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; }
    }
}
```

The following is the implementation of the `Book` class.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensionsDemo
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int AuthorId { get; set; }
    }
}
```

In the `Program` class, define the static variable, which contains the connection string of the database.

```csharp
static string ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;Integrated Security=True;";
```

The first step is to create a member of type `IDbConnection` with the `SqlConnection` by passing the connection string.

```csharp
private static List<Author> GetAllAuthors()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Open();
        List<Author> authors = db.GetList<Author>().ToList();
        db.Close();

        return authors;
    }
}
```

The `GetList` extension method enables you to retrieve data from the database and populate data in your object model.

It also provides a `Get` method to retrieve a single record as shown below.

```csharp
private static Author GetAuthor(int id)
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Open();
        Author author = db.Get<Author>(id);
        db.Close();

        return author;
    }
}
```

Now call the above methods from the `Main` method.

```csharp
static void Main(string[] args)
{
    Author author1 = GetAuthor(2);

    Console.WriteLine(author1.FirstName + " " + author1.LastName);

    List<Author> authors = GetAllAuthors();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
William Shakespeare
Cardinal Tom B. Erichsen
William Shakespeare
Robert T. Kiyosakiy 
```
