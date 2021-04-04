---
PermaID: 100004
Name: Insert Data
---

# Insert Data

Inserting data into the database is one of the CRUD operations that act on an individual row by inserting a row. 

The **Dapper.Rainbow** library provides `Insert` extension method to insert data into the database.

The following example inserts a single new record.

```csharp
private static void InsertSingleAuthor()
{
    using (DbConnection connection = new SqlConnection(ConnectionString))
    {
        var db = RainbowDatabase.Init(connection, commandTimeout: 2); 
        
        Author author = new Author()
        {
            FirstName = "Mindy",
            LastName = "Kaling"
        };

        db.Authors.Insert(author);
    }
}
```

If you retrieve all the authors from the database, you will see that the above author added at the end.

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

Let's execute the above code, and you will see the following output.

```csharp
Cardinal Tom B. Erichsen
William Shakespeare
Robert T. Kiyosaki
Mindy Kaling
```
