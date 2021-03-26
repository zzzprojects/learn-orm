---
PermaID: 100005
Name: Insert Data
---

# Insert Data

Inserting data into the database is one of the CRUD operations that act on an individual row by inserting a row. There are various ways to insert new records into the database using Dapper ORM.

You can easily insert a single new record by writing an `INSERT` statement with parameters for each column that we want to set.


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

        string sqlQuery = "INSERT INTO Authors (FirstName, LastName) VALUES(@FirstName, @LastName)";

        int rowsAffected = db.Execute(sqlQuery, author);
    }
}
```

It a simple SQL insert statement on the `Authors` table, there are the columns and their values corresponding to parameters. 

The `Execute` extension method of Dapper is used to insert a record. You can also use the `Execute` method to insert multiple authors.

```csharp
private static void InsertMultipleAuthors()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        string sqlQuery = "INSERT INTO Authors (FirstName, LastName) VALUES(@FirstName, @LastName)";

        int rowsAffected = db.Execute(sqlQuery,
            new[]
            {
                new {FirstName = "Emily", LastName = "Dickinson"},
                new {FirstName = "Leo", LastName = "Tolstoy"},
                new {FirstName = "Rabindranath", LastName = "Tagore"}
            }
        );
    }
}
```

Now if you retrieve all the authors from the database, you will see that a new record is already added at the end.

```csharp
private static void GetAllAuthors()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        List<Author> authors = db.Query<Author>("SELECT * FROM Authors").ToList();

        foreach (var author in authors)
        {
            Console.WriteLine(author.FirstName + " " + author.LastName);
        }
    }
}
```

Let's execute the above code and you will see the following output.

```csharp
Cardinal Tom B. Erichsen
Meredith Alonso
Robert T. Kiyosaki
William Shakespeare
```