---
PermaID: 100016
Name: Use Stored Procedure
---

# Use Stored Procedure

In this article, we will discuss how to call Stored Procedure using Entity Framework in ASP.Net MVC 5 Razor. Most of the developers and DBAs prefer to use stored procedures for database access. 

 - In earlier versions of Entity Framework, you can't instruct EF to use stored procedures for update operations. 
 - You can only retrieve data using a stored procedure by executing a raw SQL query. 
 - In EF 6 it's easy to configure Code First to use stored procedures.

In `BookStore` which is a context class, let's override the `OnModelCreating` method.

```csharp
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Book>().MapToStoredProcedures();
}
```

The above code tells EF to use stored procedures for insert, update, and delete operations on the `Book` entity. Now run the following command in **Package Manager Console** window.

```csharp
add-migration spBook
```

In Migrations folder, you will see `<timestamp>_spBook.cs` file is created which contains the code that creates Insert, Update, and Delete stored procedures for Book entity.

```csharp
namespace MvcWithEF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spBook : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Book_Insert",
                p => new
                    {
                        Title = p.String(),
                        AuthorId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Books]([Title], [AuthorId])
                      VALUES (@Title, @AuthorId)
                      
                      DECLARE @BookId int
                      SELECT @BookId = [BookId]
                      FROM [dbo].[Books]
                      WHERE @@ROWCOUNT > 0 AND [BookId] = scope_identity()
                      
                      SELECT t0.[BookId]
                      FROM [dbo].[Books] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[BookId] = @BookId"
            );
            
            CreateStoredProcedure(
                "dbo.Book_Update",
                p => new
                    {
                        BookId = p.Int(),
                        Title = p.String(),
                        AuthorId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Books]
                      SET [Title] = @Title, [AuthorId] = @AuthorId
                      WHERE ([BookId] = @BookId)"
            );
            
            CreateStoredProcedure(
                "dbo.Book_Delete",
                p => new
                    {
                        BookId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Books]
                      WHERE ([BookId] = @BookId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Book_Delete");
            DropStoredProcedure("dbo.Book_Update");
            DropStoredProcedure("dbo.Book_Insert");
        }
    }
}
```

To update the database, run the `Update` command in Package Manager Console window.

```csharp
update-database
```

Let's run your application in debug mode, and then click the **Books** tab and then try to delete any of the available books by clicking on the Delete link.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/mvc-with-entity-framework-6/images/use-stored-procedures-1.png">

Now if you look at the **Output** window, you will see that a stored procedure `Book_Delete` is used to delete the `Book` row.