---
PermaID: 10007
Name: Async Operations
---

# Async Operations

Typically, async operations are used when you are working with outside systems, like making calls to an external database, web API, etc. to optimize your code while waiting for these external systems to respond, especially if they take more than a few milliseconds. 

So far, we have performed all synchronous operations, but **Dapper.Rainbow** also fully supports async versions of all of the primary methods.

The following is the async version of the `GetAllAuthors` method.

```csharp
private async static Task<List<Author>> GetAllAuthorsAsync()
{
    using (DbConnection connection = new SqlConnection(ConnectionString))
    {
        var db = RainbowDatabase.Init(connection, commandTimeout: 2);

        IEnumerable<Author> results = await db.Authors.AllAsync();
        return results.ToList();
    }
}
```

You can see that we are using the `AllAsync` method of **Dapper.Rainbow**. Now to call the async method, we need to call it from an async `Main` method. 

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

The following example deletes a single author asynchronously using `DeleteAsync`

```csharp
private static async Task DeleteSingleAuthorAsync(int id)
{
    using (DbConnection connection = new SqlConnection(ConnectionString))
    {
        var db = RainbowDatabase.Init(connection, commandTimeout: 2);
        await db.Authors.DeleteAsync(id);
    }
}
```

Let's run your application and you will see we are getting the same results. It is just that behind the scenes, this time we did it asynchronously. 

 - The async in **Dapper.Rainbow** is as seamless as the non-async versions. 
 - You can use whichever version you prefer.
