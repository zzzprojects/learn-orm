---
PermaID: 100006
Name: Delete Data
---

# Delete Data

Deleting an entity is the easiest because it only requires a unique `Id` to identify the deleted entity. All we need is a SQL statement containing a `DELETE` statement with a `WHERE` clause on the `Id` column.

```csharp
private static void DeleteSingleAuthor()
{
    string sql = "DELETE FROM Authors WHERE Id = @Id;";

    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        connection.Open();

        using (var transaction = connection.BeginTransaction())
        {
            int rowsAffected = transaction.Execute(sql, new { Id = 4 });
            transaction.Commit();
        }
    }
}
```

It is a simple SQL `DELETE` statement on the `Authors` table. The `Execute` extension method of Dapper is used to delete a record. You can also use the `Execute` method to delete multiple authors.

```csharp
private static void DeleteMultipleBooks()
{
    string sql = "DELETE FROM Books WHERE Id = @Id;";

    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        connection.Open();

        using (var transaction = connection.BeginTransaction())
        {
            int rowsAffected = transaction.Execute(sql,
                new[]
                {
                    new { Id = 7 },
                    new { Id = 8 },
                    new { Id = 9 }
                }
            );
        }
    }
}
```

Let's execute the above code, and if you retrieve all the authors and books from the database, you will see that the above-mentioned author and books are no longer available in the database.

<img src="images/delete-data-1.png" alt="Retrieve data">

