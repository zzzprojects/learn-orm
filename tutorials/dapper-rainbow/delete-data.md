---
PermaID: 100006
Name: Delete Data
---

# Delete Data

The **Dapper.Rainbow** library provides `Delete` extension method to delete existing data from the database. Deleting an entity is the easiest because it only requires a unique `Id` to identify the entity being deleted.

The following example deletes a single new record using the `Delete` method.

```csharp
private static void DeleteSingleAuthor(int id)
{
    using (DbConnection connection = new SqlConnection(ConnectionString))
    {
        var db = RainbowDatabase.Init(connection, commandTimeout: 2);
        db.Authors.Delete(id);
    }
}
```

Let's retrieve all the authors from the database as shown below.

```csharp
static void Main(string[] args)
{
    DeleteSingleAuthor(4);
    List<Author> authors = GetAllAuthors();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}

private static List<Author> GetAllAuthors()
{
    using (DbConnection connection = new SqlConnection(ConnectionString))
    {
        var db = RainbowDatabase.Init(connection, commandTimeout: 2);

        List<Author> authors = db.Authors.All().ToList();

        return authors;
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
Cardinal Tom B. Erichsen
William Shakespeare
Robert T. Kiyosaki
```
