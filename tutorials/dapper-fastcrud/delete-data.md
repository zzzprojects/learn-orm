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

Let's call the above method and retrieve all the authors from the database, as shown below.

```csharp
static void Main(string[] args)
{
    DeleteSingleAuthor();
    List<Author> authors = GetAllAuthors();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}
```

Let's execute the above code, and you will see that the record which has `Id = 4` is no longer available.

```csharp
Cardinal Tom B. Erichsen
William Shakespeare
Robert T. Kiyosaki
```
