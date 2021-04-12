---
PermaID: 100013
Name: Async Operations
---

# Async Operations

When working with outside systems, like making calls to an external database, web API, etc., we typically use async operations to optimize our code while waiting for these external systems to respond, especially if they take more than a few milliseconds. So far, we performed all synchronous operations, but **Dapper.Transaction** also fully supports async versions of all of the primary methods.

The following is the async version of the `GetAllAuthors` method.

```csharp
private async static Task<List<Author>> GetAllAuthorsAsync()
{
    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        connection.Open();

        using (var transaction = connection.BeginTransaction())
        {
            IEnumerable<Author> results = await transaction.QueryAsync<Author>("SELECT * FROM Authors");
            return results.ToList();
        }
    }
}
```

Here you can see that we are using the `QueryAsync` method. Now to call this async method, we need to call it from an async `Main` method. 

```csharp
static async Task Main(string[] args)
{
    var authors = await GetAllAuthorsAsync();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}
```

The following example inserts a single author asynchronously using `ExecuteAsync`

```csharp
private static async void InsertSingleAuthorAsync()
{
    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        connection.Open();

        using (var transaction = connection.BeginTransaction())
        {
            Author author = new Author()
            {
                FirstName = "William",
                LastName = "Shakespeare"
            };

            string sqlQuery = "INSERT INTO Authors (FirstName, LastName) VALUES(@FirstName, @LastName)";

            int rowsAffected = await db.ExecuteAsync(sqlQuery, author);
        }
    }
}
```

Let's run your application, and you will see we are getting the same result. This time we did it asynchronously. 

 - Using async in Dapper is as seamless as the non-async versions. 
 - Feel free to use whichever version you prefer.
