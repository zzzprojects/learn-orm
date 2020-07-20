---
PermaID: 100008
Name: Migrations
---

# Migrations

Entity Framework allows you to incrementally evolve the database schema as your model changes over time. In the past EF releases, developers were required to manually update the database or drop and recreate it when your model changed.

 - Before EF 4.3, you would lose all the data and other DB objects in your database when dropping the entire database and recreate it. 
 - But now with migration, you can automatically update the database schema with changes in your model without losing any existing data or other database objects.

In this example, we have two basic classes `Author` and `Book` and the context class `BookStore`.

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
    public BookStore(DbContextOptions<BookStore> options) : base(options)
    {
    }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

## Why We Need Migration

When you develop a new application, your data model changes frequently, and each time the model changes, it gets out of sync with the database. 

 - We have configured the Entity Framework to automatically drop and re-create the database each time we change the data model. 
 - When we add, remove, or change entity classes or change our `DbContext` class, the next time we run the application it automatically deletes our existing database, creates a new one that matches the model, and seeds it with test data.

## Install Tools

As for the best practices, in the appsettings.json file, change the name of the database in the connection string.

```csharp
<connectionStrings>
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\ProjectsV13;Initial Catalog=NewBookStore;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*"
}
</connectionStrings>
```

## Code Based Migration

The code-based migration provides more control over the migration and allows you to configure additional things such as setting a default value of a column, configure a computed column, etc.

Run the following commands in `Package Manager Console`.

```csharp
PM> Add-Migration InitialCreate
```

 - The migration name parameter ("InitialCreate" in the example) is used for the file name and can be whatever you want. 
 - It's best to choose a word or phrase that summarizes what is being done in the migration.

The `Add-Migration` command generates the code in the `Migrations` folder, in the file named `<timestamp>_InitialCreate.cs` that would create the database from scratch. 

```csharp
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcWithEFCoreDemo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
```

The `Up` method of the `InitialCreate` class creates the database tables that correspond to the data model entity sets, and the `Down` method deletes them.

 - Migrations call the `Up` method to implement the data model changes for a migration. 
 - When you enter a command to roll back the update, Migrations calls the `Down` method.
 - This is the initial migration that was created when you entered the `add-migration InitialCreate` command. 

Let's run the following command to update the database in the **Package Manager Console** window.

```csharp
update-database
```

The `update-database` command runs the `Up` method to create the database. 