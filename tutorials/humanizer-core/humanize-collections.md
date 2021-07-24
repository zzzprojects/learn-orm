---
PermaID: 100006
Name: Humanize Collections
---

# Humanize Collections

**Humanizer.Core** provides a `Humanize()` extension method on any `IEnumerable` to get a nicely formatted string representing the objects in the collection. By default `ToString()` will be called on each item to get its representation.

```csharp
class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
    public override string ToString()
    {
        return Title + " (" + NoOfPages + ")";
    }
}

public static void Example1()
{
    List<Book> books = new List<Book>
    {
        new Book { Title = "Introduction to Machine Learning", NoOfPages = 530 },
        new Book { Title = "Advanced Topics in Machine Learning", NoOfPages = 380},
        new Book { Title = "Introduction to Computing", NoOfPages = 1171},
        new Book { Title = "Introduction to Microeconomics", NoOfPages = 437}
    };

    Console.WriteLine(books.Humanize());
}
```

Let's execute the above example and you will see the following output.

```csharp
Introduction to Machine Learning (530), Advanced Topics in Machine Learning (380), Introduction to Computing (1171), and Introduction to Microeconomics (437)
```

You can also pass a formatting function to the `Humanize` method. 

```csharp
public static void Example2()
{
    List<Book> books = new List<Book>
    {
        new Book { Title = "Introduction to Machine Learning", NoOfPages = 530 },
        new Book { Title = "Advanced Topics in Machine Learning", NoOfPages = 380},
        new Book { Title = "Introduction to Computing", NoOfPages = 1171},
        new Book { Title = "Introduction to Microeconomics", NoOfPages = 437}
    };

    Console.WriteLine(books.Humanize(b => string.Format("{0} has {1} pages", b.Title, b.NoOfPages)));
}
```

Let's execute the above example and you will see the following output.

```csharp
Introduction to Machine Learning has 530 pages, Advanced Topics in Machine Learning has 380 pages, Introduction to Computing has 1171 pages, and Introduction to Microeconomics has 437 pages
```

You can see that a default separator is provided ("and" in English), but a different separator may be passed into the `Humanize` method as well.

```csharp
books.Humanize("or");
```