---
PermaID: 100004
Name: Expression in Subqueries
---

# Expression in Subqueries

By default, LINQ to SQL cannot handle references to expressions within subqueries. Let's consider the following example where C# generates a subquery when it translates the `let` clause into lambda/method syntax.

```csharp
public static List<string> GetAuthorsExample1(Expression<Func<Book, bool>> pageCriteria)
{
    using (var context = new BookStore())
    {
        var query = from a in context.Authors
                    let books = context.Books.Where(b => b.AuthorId == a.AuthorId)
                    where books.Any(pageCriteria)
                    select a.Name;


        return query.ToList();
    }
}
```

Now to make it works, **LinqKit.Microsoft.EntityFrameworkCore** allows you to call `AsExpandable()` on the first table in the query, as shown below.

```csharp
public static List<string> GetAuthorsExample2(Expression<Func<Book, bool>> pageCriteria)
{
    using (var context = new BookStore())
    {
        var query = from a in context.Authors.AsExpandable<Author>()
                    let books = context.Books.Where(b => b.AuthorId == a.AuthorId)
                    where books.Any(pageCriteria)
                    select a.Name;


        return query.ToList();
    }
}
```

Nothing else needs to be changed. The wrapper that `AsExpandable` generates looks specifically for references to expressions and substitutes the expression in place of the reference.
