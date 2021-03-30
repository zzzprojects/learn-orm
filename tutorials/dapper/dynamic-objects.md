---
PermaID: 100012
Name: Dynamic Objects
---

# Dynamic Objects

Dynamic objects were added in C# 4 and are useful in many dynamic scenarios when dealing with JSON objects. They can also be useful when you don't want to write an entire C# class just to match your database table structure. Let's consider the following example which we have implemented previously.

```csharp
private static void GetAuthors(params int[] ids)
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        List<Author> authors = 
            db.Query<Author>("SELECT * FROM Authors WHERE Id IN @Ids", new { Ids = ids })
            .ToList();

        foreach (var author in authors)
        {
            Console.WriteLine(author.FirstName + " " + author.LastName);
        }
    }
}
```

Let's implement the same functionality using dynamic objects instead of using the concrete `Author` class.

```csharp
private static void GetDynamicAuthors(params int[] ids)
{
    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        List<dynamic> authors =
            db.Query("SELECT * FROM Authors WHERE Id IN @Ids", new { Ids = ids })
            .ToList();

        foreach (var author in authors)
        {
            Console.WriteLine(author.FirstName + " " + author.LastName);
        }
    }
}
```

You can we that we specified `dynamic` instead of `Author` as the generic type and also we don't need to specify the generic type of the `Query` method.
 
You will also notice when you started typing `author.`, you will not get IntelliSense on that because it's a dynamic object. Let's call this new method and execute the application and you will see that everything is still working exactly the same. 
