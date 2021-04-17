---
PermaID: 100003
Name: Insert Data
---

# Insert Data

Inserting data into the database is one of the CRUD operations that act on an individual row by inserting a row. 

The **Dapper.SimpleSave** library provides `Create` and `CreateAll` extension methods to insert data into the database.

The following example inserts a single new record.

```csharp
private static void InsertSingleAuthor()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Open();
        Author author = new Author()
        {
            FirstName = "Cokie",
            LastName = "Roberts"
        };

        db.Create<Author>(author);
        db.Close();
    }
}
```

You can also use the `CreateAll` method to insert multiple records.

```csharp
private static void InsertMultipleBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Open();
        List<Book> books = new List<Book>()
        {
            new Book {Title = "From This Day Forward", Category = "Humor & Entertainment", AuthorId = 4},
            new Book {Title = "Founding Mothers: The Women Who Raised Our Nation", Category = "History", AuthorId = 4},
            new Book {Title = "Records of Our National Life : The National Archives", Category = "History", AuthorId = 4}
        };

        db.CreateAll<Book>(books);

        db.Close();
    }
}
```

If you retrieve all the authors and books from the database, you will see that the above records are inserted at the end.

<img src="images/insert-data-1.png" alt="Database data">