---
PermaID: 100010
Name: IN Operator Support
---

# IN Operator Support

**Dapper.Transaction** also supports few extended scenarios, such as using an array as the values for an `IN` operator in a `WHERE` clause. 

In the previous examples, we implemented various methods which retrieve either all records from the table or only one based on the `Id` we passed as a parameter. 

Now let's say we want to retrieve a list of records based on ids which we will pass as parameters. 

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

It is pretty simple and almost identical to the examples we have implemented previously.

 - You can see that the `GetAuthors` method is taking an array of integers as the inputs. 
 - If you look at the `SELECT` statement, we are specifying the list of IDs as the typical anonymous type that we often see. 
 - The difference here is that Dapper is smart enough to convert those with the correct formatting that the `IN` operator needs for the `WHERE` clause. 

You can call this method as shown below.

```csharp
static void Main(string[] args)
{
    List<Author> authors = GetAuthors(1, 2);

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
```
