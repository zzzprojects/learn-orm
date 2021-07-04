---
PermaID: 100002
Name: Use Extension Methods
---

# Use Extension Methods

## Extension Methods

Extension methods allow you to add methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type. Extension methods are `static` methods, but they are called as if they were instance methods on the extended type.

Let's consider the following two extension methods, one is for the `Author` type and the other is for `Book` type.

```csharp
public static partial class Extensions
{
    public static bool IsOver50(this Author author)
        => author.Age > 50;

    public static bool IsOver1000Pages(this Book book)
        => book.NoOfPages > 1000;
}
```

Now if you want to use these extension methods in your LINQ queries, you can use them only inmemory rather than in the database which is not very efficient as shown below.

```csharp
using (BookStore context = new BookStore())
{
    int over50Authors = context.Authors.ToList().Where(a => a.IsOver50()).Count();
    int over1000PagesBooks = context.Books.ToList().Where(b => b.IsOver1000Pages()).Count();

    Console.WriteLine("Total Authors: {0}", over50Authors);
    Console.WriteLine("Total Books: {0}", over1000PagesBooks);
}
```

Here what **Clave.Expressionify** plays an important role, with just two additional lines of code you can get Entity Framework to understand how to translate your extension method to SQL.

Let's decorate your extension method with the `[Expressionify]` attribute as shown below.

```csharp
public static partial class Extensions
{
    [Expressionify]
    public static bool IsOver50(this Author author)
        => author.Age > 50;

    [Expressionify]
    public static bool IsOver1000Pages(this Book book)
        => book.NoOfPages > 1000;
}
```

After using the `[Expressionify]` attribute on your extension methods, make sure to call the `.Expressionify()` method before using any extension method.

```csharp
using (BookStore context = new BookStore())
{
    var over50Authors = context.Authors
        .Expressionify()
        .Where(a => a.IsOver50())
        .ToList();

    var over1000PagesBooks = context.Books
        .Expressionify()
        .Where(b => b.IsOver1000Pages())
        .ToList();

    Console.WriteLine("Total Authors: {0}", over50Authors);
    Console.WriteLine("Total Books: {0}", over1000PagesBooks);
}
```

## Limitations

**Clave.Expressionify** uses the Roslyn code analyzer and generator to look for static methods with expression bodies tagged with the `[Expressionify]` attribute in `partial` classes.