---
PermaID: 100012
Name: Stored Procedures
---

# Stored Procedures

The Entity Framework Core allows you to use stored procedures to perform predefined logic on database tables. To execute a stored procedure, you can use raw SQL queries in the following methods. 

 - `DbSet<TEntity>.FromSqlRaw()`
 - `DbContext.Database.ExecuteSqlRaw()`

## Limitations

In EF Core, there are some limitations when using raw SQL queries.

 - The return type of a stored procedure must be an entity type, and a stored procedure must return all the columns of the corresponding table of an entity.
 - Related data must not be the part of the result, and a stored procedure cannot perform JOINs to formulate the result.
 - The column names in the result set must match the column names that properties are mapped to. 

## Create Stored Procedure

To execute a stored procedure in EF Core, we need to create our stored procedure in our database. Here is a script of a simple stored procedure, it will return all the records from the `Authors` table when executed.

```csharp
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = 
   OBJECT_ID(N'[dbo].[GetAllAuthors]') AND type in (N'P', N'PC'))

BEGIN

   EXEC dbo.sp_executesql @statement = N'
   CREATE PROCEDURE [dbo].[GetAllAuthors]
   AS
   SELECT * FROM dbo.Authors
   '
END
GO
```

You can also pass parameters when executing stored procedures.

```csharp
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = 
   OBJECT_ID(N'[dbo].[GetAuthor]') AND type in (N'P', N'PC'))

BEGIN

   EXEC dbo.sp_executesql @statement = N'
   CREATE PROCEDURE [dbo].[GetAuthor]
   @AuthorId int
   AS
   SELECT * FROM dbo.Authors 
   WHERE AuthorId = @AuthorId
   '
END
GO
```

The following stored procedure will insert a new author to the `Authors` table when executed.

```csharp
CREATE PROCEDURE CreateAuthor
    @FirstName Varchar(50),
    @LastName Varchar(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT into dbo.Authors(
           [FirstName]
           ,[LastName]
           )
 VALUES (@FirstName, @LastName)
END
GO
```

## Execute Stored Procedure Using FromSqlRaw

In EF Core, you can execute stored procedures using the `FromSqlRaw()` method. The following code will return all the authors from the `Authors` table


```csharp
using (var context = new EntityContext())
{
    var authors = context.Authors
        .FromSqlRaw("EXECUTE dbo.GetAllAuthors")
        .ToList();
}
```

The following example returns a specific record from the `Authors` table based on `AuthorId` passed as a parameter.


```csharp
using (var context = new EntityContext())
{
    var author = context.Authors
        .FromSqlRaw("EXECUTE dbo.GetAuthor 1")
        .ToList();
}
```

You can also pass a parameter value using C# string interpolation.


```csharp
using (var context = new EntityContext())
{
    int authorId = 1;
    var author1 = context.Authors
        .FromSqlRaw($"EXECUTE dbo.GetAuthor {authorId}")
        .ToList();
}
```

## Execute Stored Procedure Using ExecuteSqlRaw

The `ExecuteSqlRaw` method is used to execute the given SQL against the database and returns the number of rows affected. The following example will add a new author entity to the `Authors` table.

```csharp
using (var context = new EntityContext())
{
    context.Database.ExecuteSqlRaw("CreateAuthor @p0, @p1", parameters: new[] { "Mark", "Twain" });
}
```