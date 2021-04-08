---
PermaID: 100011
Name: Dynamic Objects
---

# Dynamic Objects

Dynamic objects were added in C# 4 and are useful in many dynamic scenarios when dealing with JSON objects. They can also be useful when you don't want to write an entire C# class just to match your database table structure. Let's consider the following example, which we previously implemented.

```csharp
private static List<Author> GetAuthors(params int[] ids)
{
    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        connection.Open();

        using (var transaction = connection.BeginTransaction())
        {
            List<Author> authors = 
                transaction.Query<Author>("SELECT * FROM Authors WHERE Id IN @Ids", new { Ids = ids })
                .ToList();

            return authors;
        }
    }
}
```

Let's implement the same functionality using dynamic objects instead of using the concrete `Author` class.

```csharp
private static List<dynamic> GetDynamicAuthors(params int[] ids)
{
    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        connection.Open();

        using (var transaction = connection.BeginTransaction())
        {
            List<dynamic> authors = 
                transaction.Query("SELECT * FROM Authors WHERE Id IN @Ids", new { Ids = ids })
                .ToList();

            return authors;
        }
    }
}
```

You can see that we specified `dynamic` instead of `Author` as the generic type, and also, there is no need, to specify the generic type of the `Query` method.
 
You will notice when you started typing `author.`, you won't get IntelliSense because it's a dynamic object. Let's call this new method and execute the application, and you will see that everything is still working exactly the same. 
