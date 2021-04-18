---
PermaID: 100005
Name: Update Data
---

# Update Data

Updating an existing entity is similar to inserting a new one. The **Dapper.SimpleSave** library provides an `Update` and `UpdateAll` extension methods to update existing data into the database.

The following example updates a single record.

```csharp
private static void UpdateSingleBook()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Open();
        Book oldBook = GetBook(1);
        Book newBook = new Book { Id = 1, Title = "Introduction to AI", Category = "Computer Science", AuthorId = 1 };
        db.Update<Book>(oldBook, newBook);

        db.Close();
    }
}

private static Book GetBook(int id)
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        Book book = db.Query<Book>("SELECT * FROM Books WHERE Id = " + id).FirstOrDefault();

        return book;
    }
}
```

You can use the `UpdateAll` method to update multiple records by passing the list as an argument.

```csharp
private static void UpdateMultipleBooks()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Open();
        Book oldBook1 = GetBook(2);
        Book oldBook2 = GetBook(3);
        Book oldBook3 = GetBook(7);

        Book newBook1 = new Book(oldBook1);
        newBook1.Category = "Computer Science";

        Book newBook2 = new Book(oldBook2);
        newBook2.Category = "Entertainment";
        
        Book newBook3 = new Book(oldBook3);
        newBook3.Category = "Entertainment";

        List<Book> oldBooks = new List<Book>
        {
            oldBook1,
            oldBook2,
            oldBook3
        };

        List<Book> newBooks = new List<Book>
        {
            newBook1,
            newBook2,
            newBook3
        };

        db.UpdateAll<Book>(oldBooks, newBooks);

        db.Close();
    }
}
```

If you retrieve all the books from the database, you will see that the above-mentioned books are updated.

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
Id: 7    Title: From This Day Forward     Category: Entertainment
Id: 8    Title: Founding Mothers: The Women Who Raised Our Nation         Category: History
Id: 9    Title: Records of Our National Life : The National Archives      Category: History
```
