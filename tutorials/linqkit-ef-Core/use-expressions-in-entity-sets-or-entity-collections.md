---
PermaID: 100003
Name: Use Expressions in EntitySets or EntityCollections
---

# Use Expressions in EntitySets or EntityCollections

By default, `EntitySet<>` or `EntityCollection<>` does not implements `IQueryable<>`. It means that we can't call methods that accept an `Expression<Func<>>` such as, Queryable's `Any` and our query won't compile.

So, let's suppose we want to retrieve all those authors' names that had written books of more than 1000 pages or you can say that we will write a method and pass the page criteria predicate as a parameter as shown below.

```csharp
public static List<string> GetAuthorsExample1(Expression<Func<Book, bool>> pageCriteria)
{
    using (var context = new BookStore())
    {
        var query = context.Authors
            //.Where(a => a.Books.Any(pageCriteria)) // not compiling
            .Select(a => a.Name);

        return query.ToList();
    }
}
```

Now to make it works, **LinqKit.Microsoft.EntityFrameworkCore** allows you to call `AsExpandable()` on the `Table<>` object and also call `Compile()` on the expression variable, when used on an `EntitySet` or `EntityCollection` as shown below.

```csharp
public static List<string> GetAuthorsExample2(Expression<Func<Book, bool>> pageCriteria)
{
    using (var context = new BookStore())
    {
        var query = context.Authors.AsExpandable()
            .Include(a => a.Books)
            .Where(a => a.Books.Any(pageCriteria.Compile()))
            .Select(a => a.Name);

        return query.ToList();
    }
}
```

You can call the above method and pass the page criteria as shown below.

```csharp
var authors = ExpressionsInEntitySetsOrEntityCollections.GetAuthorsExample2(b => b.NoOfPages > 1000);
foreach (var author in authors)
{
    Console.WriteLine(author);
}
```

Let's run the above code and you will see the following output.

```csharp
Carson Alexander
Arturo Anand
```
