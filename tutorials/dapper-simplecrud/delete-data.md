---
PermaID: 100006
Name: Delete Data
---

# Delete Data

Deleting an entity is the easiest because it only requires a unique `Id` to identify the deleted entity. The **Dapper.SimpleCRUD** library provides `Delete` and `DeleteList` extension methods to delete existing data from the database.

The following example deletes a single new record using the `Delete` method.

```csharp
private static void DeleteSingleAuthor()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Delete<Author>(new Author { Id = 4 });
    }
}
```

You can also delete multiple records with where options.

```csharp
private static void DeleteMultipleBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.DeleteList<Book>("where Id > 6");
    }
}
```

You can also delete multiple records with where conditions.

```csharp
private static void DeleteMultipleBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.DeleteList<Book>("where Id > 6");
    }
}
```

Let's retrieve all the authors and books from the database, as shown below.

```csharp
static void Main(string[] args)
{
    DeleteSingleAuthor();
    List<Author> authors = GetAllAuthors();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }

    DeleteMultipleBooks();
    List<Book> books = GetAllBooks();
    foreach (var book in books)
    {
        Console.WriteLine("Title: {0} \t Category: {1}", book.Title, book.Category);
    }
}
```

Let's execute the above code, and you will see that they are no longer available.
