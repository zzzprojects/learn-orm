---
PermaID: 100005
Name: Nested Expressions
---

# Nested Expressions

**LinqKit.Microsoft.EntityFrameworkCore** allows you to use the `AsExpandable` wrapper for writing expressions that can call other expressions. You just need to call the `Invoke` extension method that will call the inner expression, and calling the `Expand` extension method will give you the final result.

Let's consider the following simple example.

```csharp
public static void Example1()
{
    Expression<Func<Book, bool>> criteria1 = b => b.NoOfPages > 1000;
    Expression<Func<Book, bool>> criteria2 = b => b.Title.Contains("Introduction") || criteria1.Invoke(b);

    Console.WriteLine(criteria2.Expand().ToString());
}
```

Let's run the above code and you will see the following output.

```csharp
b => (b.Title.Contains("Introduction") OrElse (b.NoOfPages > 1000))
```

The following example uses the nested expression criteria while retrieving the book's data.

```csharp
public static void Example2()
{
    Expression<Func<Book, bool>> criteria1 = b => b.NoOfPages > 1000;
    Expression<Func<Book, bool>> criteria2 = b => b.Title.Contains("Introduction") || criteria1.Invoke(b);

    using (var context = new BookStore())
    {
        var books = context.Books.Where(criteria2.Expand()).ToList();

        foreach (var book in books)
        {
            Console.WriteLine("Title: {0} \t Total Pages: {1}", book.Title, book.NoOfPages);
        }
    }
}
```

You can also call the `AsExpandable` method on the table and skip the call to the `Expand` method because `AsExpandable` automatically calls `Expand` on expressions as shown below.

```csharp
public static void Example3()
{
    Expression<Func<Book, bool>> criteria1 = b => b.NoOfPages > 1000;
    Expression<Func<Book, bool>> criteria2 = b => b.Title.Contains("Introduction") || criteria1.Invoke(b);

    using (var context = new BookStore())
    {
        var books = context.Books.AsExpandable().Where(criteria2).ToList();

        foreach (var book in books)
        {
            Console.WriteLine("Title: {0} \t Total Pages: {1}", book.Title, book.NoOfPages);
        }
    }
}
```

Let's run the above code, and you will see the following output.

```csharp
Title: Calculus I        Total Pages: 1477
Title: Introduction to Microeconomics    Total Pages: 437
Title: Introduction to Computing         Total Pages: 1171
Title: Introduction to Machine Learning          Total Pages: 530
Title: Calculus II       Total Pages: 1571
Title: Introduction to AI        Total Pages: 530
```
