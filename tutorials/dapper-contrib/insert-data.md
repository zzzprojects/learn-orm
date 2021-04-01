---
PermaID: 100004
Name: Insert Data
---

# Insert Data

Inserting data into the database is one of the CRUD operations that act on an individual row by inserting a row. There are various ways to insert new records into the database using Dapper ORM.

The **Dapper.Contrib** library provides `Insert` extension method to insert data into the database.

The following example inserts a single new record.

```csharp
private static void InsertSingleAuthor()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        Author author = new Author()
        {
            FirstName = "William",
            LastName = "Shakespeare"
        };

        db.Insert<Author>(author);
    }
}
```

You can also use the `Insert` method to insert multiple authors.

```csharp
private static void InsertMultipleBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        List<Book> books = new List<Book>()
        {
            new Book {Title = "Romeo and Juliet", Category = "Humor & Entertainment", AuthorId = 4},
            new Book {Title = "The Tempest", Category = "Fiction", AuthorId = 4},
            new Book {Title = "The Winter's Tale : Third Series", Category = "Fiction", AuthorId = 4}
        };
        db.Insert<List<Book>>(books);
    }
}
```

If you retrieve all the books from the database, you will see that the above three books are already added at the end.

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
Title: Introduction to Machine Learning          Category: Software
Title: Introduction to Computing         Category: Software
Title: Calculus I        Category: Education
Title: Calculus II       Category: Education
Title: Trigonometry Basics       Category: Education
Title: Rich Dad, Poor Dad        Category: Economics
Title: Romeo and Juliet          Category: Humor & Entertainment
Title: The Tempest       Category: Fiction
Title: The Winter's Tale : Third Series          Category: Fiction
```
