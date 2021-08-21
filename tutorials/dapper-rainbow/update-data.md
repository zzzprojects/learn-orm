---
PermaID: 100005
Name: Update Data
---

# Update Data

The **Dapper.Rainbow** library provides an `Update` extension method to update existing data into the database. Updating an existing entity is similar to inserting a new one.

The following example updates a single record.

```csharp
private static void UpdateSingleBook()
{
    using (DbConnection connection = new SqlConnection(ConnectionString))
    {
        var db = RainbowDatabase.Init(connection, commandTimeout: 2);

        Book book = new Book { Id = 1, Title = "Introduction to AI", Category = "Software", AuthorId = 1 };
        db.Books.Update(1,book);
    }
}
```

If you retrieve all the books from the database, you will see that the above-mentioned books are updated.

```csharp
private static List<Book> GetAllBooks()
{
    using (DbConnection connection = new SqlConnection(ConnectionString))
    {
        var db = RainbowDatabase.Init(connection, commandTimeout: 2);

        List<Book> books = db.Books.All().ToList();

        return books;
    }
}

static void Main(string[] args)
{
    UpdateSingleBook();

    List<Book> books = GetAllBooks();
    foreach (var book in books)
    {
        Console.WriteLine("Title: {0} \t Category: {1}", book.Title, book.Category);
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
Title: Introduction to AI        Category: Software
Title: Introduction to Computing         Category: Software
Title: Romeo and Juliet          Category: Humor & Entertainment
Title: The Tempest       Category: Fiction
Title: The Winter's Tale : Third Series          Category: Fiction
Title: Rich Dad, Poor Dad        Category: Economics
```
