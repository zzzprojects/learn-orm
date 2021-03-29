---
PermaID: 100007
Name: Delete Data
---

# Delete Data

Deleting an entity is the easiest because it only requires a unique `Id` to identify the entity being deleted. All we need is a SQL statement containing a `DELETE` statement with a `WHERE` clause on the `Id` column.

```csharp
private static void DeleteSingleAuthor()
{
    string sql = "DELETE FROM Authors WHERE Id = @Id;";

    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        int rowsAffected = db.Execute(sql, new { Id = 4 });
    }
}
```

It a simple SQL `DELETE` statement on the `Authors` table. The `Execute` extension method of Dapper is used to delete a record. You can also use the `Execute` method to delete multiple authors.

```csharp
private static void DeleteMultipleAuthors()
{
    string sql = "DELETE FROM Authors WHERE Id = @Id;";

    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        int rowsAffected = db.Execute(sql,
            new[]
            {
                new { Id = 5 },
                new { Id = 6 },
                new { Id = 7 }
            }
        );
    }
}
```

If you retrieve all the authors from the database, you will see only three records.

```csharp
private static void GetAllAuthors()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        List<Author> authors = db.Query<Author>("SELECT * FROM Authors").ToList();

        foreach (var author in authors)
        {
            Console.WriteLine(author.FirstName + " " + author.LastName);
        }
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
Cardinal Tom B. Erichsen
Meredith Alonso
Robert T. Kiyosaki
```
