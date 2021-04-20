---
PermaID: 100005
Name: Update Data
---

# Update Data

Updating an existing entity is similar to inserting a new one. The **Dapper.FastCrud** library provides an `Update` extension method to update existing data into the database.

The following example updates a single new record.

```csharp
private static void UpdateSingleBook()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        Book book = new Book { Id = 1, Title = "Introduction to AI", Category = "Computer Science", AuthorId = 1 };
        db.Update<Book>(book);
    }
}
```

If you retrieve all the books from the database, you will see that the above-mentioned book title is updated.

```csharp
private static List<Book> GetAllBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        List<Book> books = db.Find<Book>().ToList();

        return books;
    }
}
```

The following code calls the `UpdateSingleBook` method and then retrieves all the books from the database and prints them on the console.

```csharp
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
Title: Introduction to AI        Category: Computer Science
Title: Introduction to Computing         Category: Software
Title: Romeo and Juliet          Category: Humor & Entertainment
Title: The Tempest       Category: Fiction
Title: The Winter's Tale : Third Series          Category: Fiction
Title: Rich Dad, Poor Dad        Category: Economics
```
