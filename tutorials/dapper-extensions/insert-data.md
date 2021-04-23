---
PermaID: 100004
Name: Insert Data
---

# Insert Data

Inserting data into the database is one of the CRUD operations that act on an individual row by inserting a row. 

The **Dapper Extensions** library provides `Insert` extension method to insert data into the database.

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

        db.Insert<Author>(author);

        db.Close();
    }
}
```

If you retrieve all the authors from the database, you will see that the above record is inserted at the end.

```csharp
private static List<Author> GetAllAuthors()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.Open();
        List<Author> authors = db.GetList<Author>().ToList();
        db.Close();

        return authors;
    }
}
```

The following code calls the `InsertSingleAuthor` method and then retrieves all the authors from the database and prints them on the console.

```csharp
static void Main(string[] args)
{
    InsertSingleAuthor();
    List<Author> authors = GetAllAuthors();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}
```

Let's execute the above code, and if you retrieve all the authors and books from the database, you will see that the new records are added at the end.

```csharp
Cardinal Tom B. Erichsen
William Shakespeare
Robert T. Kiyosaki
Cokie Roberts
```