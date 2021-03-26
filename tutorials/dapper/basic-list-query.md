---
PermaID: 100003
Name: Basic List Query
---

# Basic List Query

The basic operation that most of the applications would perform is to retrieve data from the database and display the results. In this article, we will explain the basic list query using Dapper which gets the data into the list from the database.

As you that we have two tables in the database that contains the following data.

<img src="images/database-setup.png" alt="Database data">

To retrieve the data from the database using Dapper, let's create two classes called `Author` and `Book`.

Here is the implementation of the `Author` class.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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

namespace DapperDemo
{
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int AuthorId { get; set; }
    }
}
```

In the `Main` method, we will create a member of type `IDbConnection` with the `SqlConnection` by passing the connection string and then retrieve the data from the `Authors` table using the `Query` method.

The `Query` extension method in Dapper enables you to retrieve data from the database and populate data in your object model.

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

Let's execute the above code and you will see the following output.

```csharp
Cardinal Tom B. Erichsen
Meredith Alonso
Robert T. Kiyosaki
```
