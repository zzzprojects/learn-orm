---
PermaID: 100006
Name: Predicate Builder
---

# Predicate Builder

**LinqKit.Microsoft.EntityFrameworkCore** allows you to construct a lambda expression tree dynamically that performs an **or-based** or **and-based** predicate. The need for dynamic predicates is the most common in a typical business application.

Let's consider the following example that implements a keyword-style search where we want to match all of the specified keywords in a book title or, in other words, the book title contains all the given keywords. 

```csharp
public static void Example2()
{
    using (var context = new BookStore())
    {
        string[] keywords = { "Introduction", "Machine Learning" };

        var predicate = PredicateBuilder.New<Book>(true);

        foreach (string keyword in keywords)
        {
            string temp = keyword;
            predicate = predicate.And(b => b.Title.Contains(temp));
        }

        var query = context.Books.Where(predicate);

        foreach (var book in query.ToList())
        {
            Console.WriteLine(book.Title);
        }
    }
}
```

The `PredicateBuilder.New()` creates an object called `ExpressionStarter`, which acts for all intents and purposes as an `Expression<Func<T, bool>>` object.

Let's run the above code, and you will see the following output.

```csharp
Introduction to Machine Learning
```

Now consider another example where we want to get all those books that contain some or all of a given set of keywords.

```csharp
public static void Example3()
{
    using (var context = new BookStore())
    {
        string[] keywords = { "Introduction", "Machine Learning" };

        var predicate = PredicateBuilder.New<Book>(true);

        foreach (string keyword in keywords)
        {
            string temp = keyword;
            predicate = predicate.Or(b => b.Title.Contains(temp));
        }

        var query = context.Books.Where(predicate);

        foreach (var book in query.ToList())
        {
            Console.WriteLine(book.Title);
        }
    }
}
```

Let's run the above code, and you will see the following output.

```csharp
Introduction to Microeconomics
Introduction to Computing
Advanced Topics in Machine Learning
Introduction to Machine Learning
Introduction to AI
```
