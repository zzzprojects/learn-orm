---
PermaID: 100002
Name: Query Builder
---

# Query Builder

**Dapper Query Builder** library allows you to build your SQL queries dynamically. In **Dapper**, you can get all the records from any table as shown in the below example.

```csharp
private static List<Author> GetAuthors()
{
    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        var authors = connection.Query<Author>("SELECT * FROM Authors;").ToList();
        
        return authors;
    }
}
```

Now the following example builds a simple `SELECT` query to retrieve all the authors from the database using the **Dapper Query Builder**.

```csharp
private static List<Author> GetAuthors()
{
    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        var builder = connection.QueryBuilder($@"SELECT * FROM Authors;");

        var authors = builder.Query<Author>().ToList();
        return authors;
    }
}
```

You can also build the SQL query containing the `WHERE` clause, as shown below.

```csharp
private static Author GetAuthor(int id)
{
    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        var builder = connection.QueryBuilder($@"SELECT * FROM Authors WHERE Id = {id};");

        var author = builder.Query<Author>().FirstOrDefault();

        return author;
    }
}
```


