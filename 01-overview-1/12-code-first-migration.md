---
PermaID: 100011
Name: Code First Migration
---

# Code First Migration

Entity Framework allows you to incrementally evolve the database schema as your model changes over time. In the past EF releases, developers were required to manually update the database or drop and recreate it when your model changed.

* Before EF 4.3, you would lose all the data and other DB objects in your database when dropping the entire database and recreate it. 
* But now with migration, you can automatically update the database schema with changes in your model without losing any existing data or other database objects.

In this example we have two basic classes `Author` and `Book` and the context class `BookStore`.

```csharp
public class Author
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}

public class BookStore : DbContext
{
    public BookStore() : base("BookStoreContext")
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

## Why We Need Migration

When you develop a new application, your data model changes frequently, and each time the model changes, it gets out of sync with the database.

* We have configured the Entity Framework to automatically drop and re-create the database each time we change the data model. 
* When we add, remove, or change entity classes or change our `DbContext` class, the next time we run the application it automatically deletes our existing database, creates a new one that matches the model, and seeds it with test data.

Let's disable the initializer that we set up the previous article by commenting out or deleting the `contexts` element that we added to the application Web.config file.

```csharp
<entityFramework>
  <!--<contexts>
    <context type="MvcWithEF6Demo.DAL.BookStore, MvcWithEF6Demo">
      <databaseInitializer type="MvcWithEF6Demo.DAL.BookStoreInitializer, MvcWithEF6Demo" />
    </context>
  </contexts>-->
  <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
  <providers>
    <provider 
      invariantName="System.Data.SqlClient" 
      type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
  </providers>
</entityFramework>
```

As for the best practices, change the name of the database in the connection string as well.

```csharp
<connectionStrings>
  <add 
    name="BookStoreContext" 
    connectionString="Data Source=(localdb)\ProjectsV13;Initial Catalog=NewBookStoreDb;Integrated Security=True;" 
    providerName="System.Data.SqlClient" />
</connectionStrings>
```

## Kinds

There are two kinds of Migration

* Automated Migration
* Code based Migration

### Automated Migration

In Entity Framework 4.3, automated Migration was introduced so that you don't need to process database migration manually in the code file, but just to run a command in `Package Manager Console` to get done this.

The first step is to enable automated migration by running the following command in `Package Manager Console`.

```csharp
PM> enable-migrations -EnableAutomaticMigrations:$true
```

![](https://raw.githubusercontent.com/zzzprojects/learn-orm/master/mvc-with-entity-framework-6/images/code-first-migration-1.png)

After executing `enable-migrations` command successfully, a folder named Migrations will be created in your project which contains `Configuration` class.

```csharp
namespace MvcWithEF6Demo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcWithEF6Demo.DAL.BookStore>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MvcWithEF6Demo.DAL.BookStore";
        }

        protected override void Seed(MvcWithEF6Demo.DAL.BookStore context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
```

Now we need to set the database initializer in the context class with the new DB initialization strategy `MigrateDatabaseToLatestVersion`.

```csharp
using MvcWithEF6Demo.Models;
using System.Data.Entity;

namespace MvcWithEF6Demo.DAL
{
    public class BookStore : DbContext
    {
        public BookStore() : base("BookStoreContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStore,
                MvcWithEF6Demo.Migrations.Configuration>("BookStoreContext"));
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
```

Now when we execute our application, and there is a change in the model then it will automatically take care of the migration.

## Code Based Migration

The code-based migration provides more control on the migration and allows you to configure additional things such as setting a default value of a column, configure a computed column, etc.

To enable migration, run the following commands in `Package Manager Console`.

```csharp
enable-migrations
add-migration InitialCreate
```

The `enable-migrations` command creates a Migrations folder in our project, and it contains a `Configuration` file that we can edit to configure Migrations.

```csharp
namespace MvcWithEF6Demo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcWithEF6Demo.DAL.BookStore>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcWithEF6Demo.DAL.BookStore context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
```

The `Configuration` class includes a Seed method and its purpose is to enable you to insert or update test data after Code First creates or updates the database.

Replace the following code in `Configuration` class, which loads test data into the new database.

```csharp
namespace MvcWithEF6Demo.Migrations
{
    using MvcWithEF6Demo.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcWithEF6Demo.DAL.BookStore>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcWithEF6Demo.DAL.BookStore context)
        {
            var authors = new List<Author>
            {
                new Author { FirstName="Carson", LastName="Alexander", BirthDate = DateTime.Parse("1985-09-01")},
                new Author { FirstName="Meredith", LastName="Alonso", BirthDate = DateTime.Parse("1970-09-01")},
                new Author { FirstName="Arturo", LastName="Anand", BirthDate = DateTime.Parse("1963-09-01")},
                new Author { FirstName="Gytis", LastName="Barzdukas", BirthDate = DateTime.Parse("1988-09-01")},
                new Author { FirstName="Yan", LastName="Li", BirthDate = DateTime.Parse("2000-09-01")},
            };

            authors.ForEach(a => context.Authors.AddOrUpdate(p => p.LastName, a));
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

            books.ForEach(b => context.Books.AddOrUpdate(p => p.Title, b));
            context.SaveChanges();
        }
    }
}
```

The `Seed` method takes the database context object as an input parameter, and the code in the method uses that object to add new entities to the database.

* The `AddOrUpdate` method is used to perform an "upsert" operation, because the `Seed` method runs every time we execute the `update-database` command. 
* After each migration, we can't just insert data, because the rows you are trying to add will already be there after the first migration that creates the database. 

When the `add-migration` command is executed, it generated the code in the `Migrations` folder, in the file named `<timestamp>_InitialCreate.cs` that would create the database from scratch.

```csharp
namespace MvcWithEF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorId);

            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
```

The `Up` method of the `InitialCreate` class creates the database tables that correspond to the data model entity sets, and the `Down` method deletes them.

* Migrations call the `Up` method to implement the data model changes for a migration. 
* When you enter a command to roll back the update, Migrations calls the `Down` method.
* This is the initial migration that was created when you entered the `add-migration InitialCreate` command. 

Let's run the following command to update the database in the **Package Manager Console** window.

```csharp
update-database
```

The `update-database` command runs the `Up` method to create the database and then it runs the `Seed` method to populate the database.

