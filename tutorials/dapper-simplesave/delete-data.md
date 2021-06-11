---
PermaID: 100006
Name: Delete Data
---

# Delete Data

Deleting an entity is the easiest because it only requires a unique `Id` to identify the entity being deleted. The **Dapper.SimpleSave** library provides `Delete` and `DeleteAll` extension methods to delete existing data from the database.

The following example deletes a single new record using the `Delete` method.

```csharp
private static void DeleteSingleBook()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Open();

        db.Delete<Book>(new Book { Id = 7 });

        db.Close();
    }
}
```

You can also use the `DeleteAll` method to delete multiple records by passing the list as an argument to the `DeleteAll` method.

```csharp
private static void DeleteMultipleBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Open();

        List<Book> books = new List<Book>()
        {
            new Book { Id = 8 },
            new Book { Id = 9 }
        };

        db.DeleteAll<Book>(books);

        db.Close();
    }
}
```

If you retrieve all the books from the database, you will see that the above records are no longer available.

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

Let's execute the above code, and you will see the following output.

```csharp
Id: 1    Title: Introduction to AI        Category: Computer Science
Id: 2    Title: Introduction to Computing         Category: Computer Science
Id: 3    Title: Romeo and Juliet          Category: Entertainment
Id: 4    Title: The Tempest       Category: Fiction
Id: 5    Title: The Winter's Tale : Third Series          Category: Fiction
Id: 6    Title: Rich Dad, Poor Dad        Category: Economics
```
