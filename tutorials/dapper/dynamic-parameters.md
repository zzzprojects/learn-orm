---
PermaID: 100010
Name: Dynamic Parameters
---

# Dynamic Parameters

The dynamic parameters allow you to specify parameters when you need to send parameters into a stored procedure or an SQL Statment. You can also use the anonymous type method that we have used in the previous articles. 

Let's consider the following simple example which retrieves the author data including books using the anonymous type method.

```csharp
private static void GetAuthorAndTheirBooksSP(int id)
{
    string sql = "GetAuthor";

    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        using (var results = db.QueryMultiple(sql, new { Id = id }, commandType: CommandType.StoredProcedure ))
        {
            var author = results.Read<Author>().SingleOrDefault();
            var books = results.Read<Book>().ToList();

            if (author != null && books != null)
            {
                author.Books = books;

                Console.WriteLine(author.FirstName + " " + author.LastName);

                foreach (var book in author.Books)
                {
                    Console.WriteLine("\t Title: {0} \t  Category: {1}", book.Title, book.Category);
                }
            }
        }
    }
}
```

The `DynamicParameters` class allows you to specify very explicit parameters. 

```csharp
private static void GetAuthorAndTheirBooksSPUsingDynamicParameters(int id)
{
    string sql = "GetAuthor";

    DynamicParameters parameter = new DynamicParameters();
    parameter.Add("@Id", id);

    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        using (var results = db.QueryMultiple(sql, parameter, commandType: CommandType.StoredProcedure))
        {
            var author = results.Read<Author>().SingleOrDefault();
            var books = results.Read<Book>().ToList();

            if (author != null && books != null)
            {
                author.Books = books;

                Console.WriteLine(author.FirstName + " " + author.LastName);

                foreach (var book in author.Books)
                {
                    Console.WriteLine("\t Title: {0} \t  Category: {1}", book.Title, book.Category);
                }
            }
        }
    }
}
```

It is almost like a generic list where you can just call. Let's have a look into another example that inserts an author into the database using dynamic parameters.

```csharp
private static void InsertSingleAuthorUsingDynamicParameters()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        DynamicParameters parameter = new DynamicParameters();

        parameter.Add("@FirstName", "William");
        parameter.Add("@LastName", "Shakespeare");

        string sqlQuery = "INSERT INTO Authors (FirstName, LastName) VALUES(@FirstName, @LastName)";

        int rowsAffected = db.Execute(sqlQuery, parameter);
    }
}
```
