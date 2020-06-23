---
PermaID: 100004
Name: Create Data Model
---

# Create Model

Model is a collection of classes to interact with the database.

* A model stores data that is retrieved according to the commands from the Controller and displayed in the View.
* It can also be used to manipulate the data to implement the business logic.

To create a data model for our application, we will start with the following two entities.

* Book
* Author

There's a one-to-many relationship between `Author` and `Book` entities. In other words, an author can write any number of books, and a book can be written by only one author.

## Create Author Entity

In Solution Explorer, right click on the Models folder and choose **Add &gt; Class**. Enter a class file name **Author.cs** and add the following code.

```csharp
using System;
using System.Collections.Generic;

namespace MvcWithEF6Demo.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
```

The `AuthorId` property will become the primary key column of the database table that corresponds to this class. By default, Entity Framework interprets a property that's named `Id` or `<classname>Id` as the primary key.

* The `Books` property is a navigation property, navigation properties hold other entities that are related to this entity. 
* In this case, the `Books` property of an `Auth` entity will hold all of the `Book` entities that are related to that `Author` entity. 
* In other words, if a given `Author` row in the database has two related `Book` rows, that `Author` entity's `Books` navigation property will contain those two `Book` entities.

## Create Book Entity

Now let's add another entity class `Book` and replace the following code.

```csharp
using System;
using System.Collections.Generic;

namespace MvcWithEF6Demo.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
```

* The `Id` property will be the primary key; this entity uses the `Id` pattern instead of `<classname>Id` by itself as you saw in the `Author` entity. 
* Usually, you would choose one pattern and use it throughout your data model. 
* Here, the variation illustrates that you can use either pattern. 

## Create Database Context

The database context class provides the main functionality to coordinate Entity Framework with a given data model.

* You create this class by deriving from the `System.Data.Entity.DbContext` class. 
* In your code, you specify which entities are included in the data model. 
* You can also customize certain Entity Framework behavior. 

So let's create a folder in your project by right-clicking on your project in Solution Explorer and click **Add &gt; New Folder**. Name the folder DAL \(Data Access Layer\). In that folder, create a new class file named **BookStore.cs**, and replace the following code.

```csharp
using MvcWithEF6Demo.Models;
using System.Data.Entity;

namespace MvcWithEF6Demo.DAL
{
    public class BookStore : DbContext
    {
        public BookStore() : base("BookStoreContext")
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
```

This code creates a `DbSet` property for each entity set. In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table.

## Setup Database

The name of the connection string is passed into the constructor of context class.

```csharp
public BookStore() : base("BookStoreContext")
{
}
```

If you don't specify a connection string or the name of one explicitly, Entity Framework assumes that the connection string name is the same as the class name. The default connection string name in this example would then be `BookStore`, the same as what you're specifying explicitly.

### Connectionn String

In this tutorial, we will be using `LocalDB`, so let's open the application Web.config file and add a connectionStrings element.

```csharp
<connectionStrings>
  <add name="BookStoreContext" connectionString="Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;Integrated Security=True;" providerName="System.Data.SqlClient"/>
</connectionStrings>
```

The above connection string specifies that Entity Framework will use a `LocalDB` database named `BookStoreDb.mdf`.

### Initialize Database

The default behavior is to create a database only if it doesn't exist and throw an exception if the model has changed and the database already exists.

* In this example, we will specify that the database should be dropped and re-created whenever the model changes.
* Dropping the database causes the loss of all your data. 
* In a development environment, it is okay to drop and recreate the database, but in production, you generally don't want to lose all your data every time you need to change the database schema. 
* You can write a Seed method that Entity Framework automatically calls after creating the database in order to populate it with test data.

In the DAL folder, add a new class `BookStoreInitializer` and replace the following code, which causes a database to be created when needed and loads test data into the new database.

```csharp
using System;
using System.Data.Entity;
using MvcWithEF6Demo.Models;
using System.Collections.Generic;

namespace MvcWithEF6Demo.DAL
{
    public class BookStoreInitializer : DropCreateDatabaseIfModelChanges<BookStore>
    {
        protected override void Seed(BookStore context)
        {
            var authors = new List<Author>
            {
                new Author { FirstName="Carson", LastName="Alexander", BirthDate = DateTime.Parse("1985-09-01")},
                new Author { FirstName="Meredith", LastName="Alonso", BirthDate = DateTime.Parse("1970-09-01")},
                new Author { FirstName="Arturo", LastName="Anand", BirthDate = DateTime.Parse("1963-09-01")},
                new Author { FirstName="Gytis", LastName="Barzdukas", BirthDate = DateTime.Parse("1988-09-01")},
                new Author { FirstName="Yan", LastName="Li", BirthDate = DateTime.Parse("2000-09-01")},
            };

            authors.ForEach(a => context.Authors.Add(a));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book { Title = "Introduction to Machine Learning", AuthorId = 1 },
                new Book { Title = "Advanced Topics in Machine Learning", AuthorId = 1 },
                new Book { Title = "Introduction to Computing", AuthorId = 1 },
                new Book { Title = "Introduction to Microeconomics", AuthorId = 2 },
                new Book { Title = "Calculus I", AuthorId = 3 },
                new Book { Title = "Calculus II", AuthorId = 3 },
                new Book { Title = "Trigonometry Basics", AuthorId = 4 },
                new Book { Title = "Special Topics in Trigonometry", AuthorId = 4 },
                new Book { Title = "Advanced Topics in Mathematics", AuthorId = 4 },
                new Book { Title = "Introduction to AI", AuthorId = 4 },
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }
    }
}
```

The `Seed` method takes the database context object as an input parameter, and the code in the method uses that object to add new entities to the database.

To use your initializer class, add the `contexts` element to the `entityFramework` element in the application Web.config file.

```csharp
<entityFramework>
  <contexts>
    <context type="MvcWithEF6Demo.DAL.BookStore, MvcWithEF6Demo">
      <databaseInitializer type="MvcWithEF6Demo.DAL.BookStoreInitializer, MvcWithEF6Demo" />
    </context>
  </contexts>
  <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
  <providers>
    <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
  </providers>
</entityFramework>
```

The `context type` specifies the fully qualified context class name and its assembly, and the `databaseinitializer type` specifies the fully qualified name of the initializer class and its assembly.

