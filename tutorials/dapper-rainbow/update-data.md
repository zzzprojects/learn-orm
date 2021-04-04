---
PermaID: 100005
Name: Update Data
---

# Update Data

Updating an existing entity is similar to inserting a new one. The **Dapper.Contrib** library provides an `Update` extension method to update existing data into the database.

The following example updates a single new record.

```csharp
private static void UpdateSingleBook()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        Book book = new Book { Id = 1, Title = "Introduction to AI", Category = "Software", AuthorId = 1 };
        db.Update<Book>(book);
    }
}
```

You can also use the `Update` method to update multiple records by passing the list as an argument.

```csharp
private static void UpdateMultipleBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        List<Book> books = new List<Book>()
        {
            new Book { Id = 2, Title = "Introduction to Algorithm", Category = "Software", AuthorId = 1 },
            new Book { Id = 3, Title = "Basics of Statistics", Category = "Education", AuthorId = 2 },
        };
        db.Update<List<Book>>(books);
    }
}
```

If you retrieve all the books from the database, you will see that the above-mentioned books are updated.

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
Title: Romeo and Juliet          Category: Humor & Entertainment
Title: The Tempest       Category: Fiction
Title: The Winter's Tale : Third Series          Category: Fiction
```
