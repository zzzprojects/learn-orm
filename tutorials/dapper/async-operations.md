---
PermaID: 100014
Name: Async Operations
---

# Async Operations

When we are working with outside systems, like making calls to an external database, web API, etc., typically we use async operations so that we can optimize our code while waiting for these external systems to respond, especially if they take more than a few milliseconds. So far, we have performed all synchronous operations, but dapper also fully supports async versions of all of the primary methods.

The following is the async version of the `GetAllAuthors` method.

```csharp
private async static Task<List<Author>> GetAllAuthorsAsync()
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        IEnumerable<Author> results = await db.QueryAsync<Author>("SELECT * FROM Authors");
        return results.ToList();
    }
}
```

Here you can see that we are using the `QueryAsync` method of Dapper. Now to call this async method, we need to call it from an async `Main` method. 

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
    using (IDbConnection db = new SqlConnection(ConnectionString))
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
```

Let's run your application and you will see we are getting the same result. It is just that behind the scenes, this time we did it asynchronously. 

 - Using async in Dapper is as seamless as the non-async versions. 
 - Feel free to use whichever version you prefer.
