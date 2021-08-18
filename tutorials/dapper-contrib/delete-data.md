---
PermaID: 100006
Name: Delete Data
---

# Delete Data

Deleting an entity is the easiest because it only requires a unique `Id` to identify the entity being deleted. The **Dapper.Contrib** library provides `Delete` and `DeleteAll` extension methods to delete existing data from the database.

The following example deletes a single record using the `Delete` method.

```csharp
private static void DeleteSingleBook()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Delete<Book>(new Book { Id = 7 });
    }
}
```

You can also use the `Delete` method to delete multiple records by passing the list as an argument to the `Delete` method.

```csharp
private static void DeleteMultipleBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        List<Book> books = new List<Book>()
        {
            new Book { Id = 8 },
            new Book { Id = 9 }
        };

        db.Delete<List<Book>>(books);
    }
}
```

If you retrieve all the books from the database, you will see that the above records of specified ids are no longer available.

```csharp
private static void GetAllBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        List<Book> books = db.GetAll<Book>().ToList();

        foreach (var book in books)
        {
            Console.WriteLine("Title: {0} \t Category: {1}", book.Title, book.Category);
        }
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
Title: Introduction to AI        Category: Software
Title: Introduction to Algorithm        Category: Software
Title: Basics of Statistics      Category: Education
Title: Calculus II       Category: Education
Title: Trigonometry Basics       Category: Education
Title: Rich Dad, Poor Dad        Category: Economics
```

If you want to delete all the records from a particular table, you can use the `DeleteAll` method.

```csharp
private static void DeleteAllBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.DeleteAll<Book>();
    }
}
```
