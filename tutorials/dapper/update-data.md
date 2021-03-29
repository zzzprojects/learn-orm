---
PermaID: 100006
Name: Update Data
---

# Update Data

Updating an existing entity is similar to inserting a new one. All we need is a SQL statement containing an `UPDATE` statement that sets the appropriate columns. We also want to make sure we include a `WHERE` clause limiting the update only to the row with the specified `Id`.

You can easily update a single row by writing an `UPDATE` statement with parameters for each column you want to update.

```csharp
private static void UpdateSingleBook()
{
    string sql = "UPDATE Books SET Category = @Category WHERE Id = @Id;";

    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        int rowsAffected = db.Execute(sql, new { Id = 3, Category = "Education" });
    }
}
```

It a simple SQL `UPDATE` statement on the `Books` table. There are the columns and their values corresponding to parameters. 

The `Execute` extension method of Dapper is used to update a record. You can also use the `Execute` method to update multiple books.

```csharp
private static void UpdateMultipleBooks()
{
    string sql = "UPDATE Books SET Category = @Category WHERE Id = @Id;";

    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        int rowsAffected = db.Execute(sql,
            new[]
            {
                new { Id = 4, Category = "Education" },
                new { Id = 5, Category = "Education" },
            }
        );
    }
}
```

If you retrieve all the authors from the database, you will see that a new record is already added at the end.

```csharp
private static void GetAllBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        List<Book> books = db.Query<Book>("SELECT * FROM Books").ToList();

        foreach (var book in books)
        {
            Console.WriteLine("Id: {0} \t Title: {1} \t  Category: {2}", book.Id, book.Title, book.Category);
        }
    }
}
```
