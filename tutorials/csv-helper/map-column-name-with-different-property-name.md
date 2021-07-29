---
PermaID: 100004
Name: Map Column Name With Different Property Name
---

# Map Column Name With Different Property Name

Most of the time when you are communicating with databases or other table formats, you will see that your property name is different from the column name and the same issue can happen with the CSV file.

Let's consider we have the following CSV data.

```csharp
BookId,Title,Pages
1,Introduction to Machine Learning,530
2,Advanced Topics in Machine Learning,380
3,Introduction to Computing,1171
4,Introduction to Microeconomics,437
5,Calculus I,1477
6,Calculus II,1571
7,Trigonometry Basics,540
8,Special Topics in Trigonometry,490
9,Advanced Topics in Mathematics,895
10,Introduction to AI,530
```

The following is the class defined to load the above data.

```csharp
private class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
}
```

As you can see the `Id` and `NoOfPages` are not similar in the CSV file and you also don't want to change to match the property names. To solve this issue, you can define the mappings by adding a new class called `BookMap` as shown below.

```csharp
public sealed class BookMap : ClassMap<Book>
{
    public BookMap()
    {
        Map(m => m.Id).Name("BookId");
        Map(m => m.Title);
        Map(m => m.NoOfPages).Name("Pages");
    }
}
```

In the above `BookMap` class, the `Id` property is mapped to the `BookId` column, and the `NoOfPages` property is mapped to the `Pages` column in the CSV file.

Ònce the mapping is defined, we will need to register the mapping by calling the `RegisterClassMap` method as shown below.

```csharp
csv.Context.RegisterClassMap<BookMap>();
``` 

The following example reads all the data and loads it to the list of `Book` objects.

```csharp
public static void Example1()
{
    using (var reader = new StreamReader(@"D:\mycsvfile.csv"))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        csv.Context.RegisterClassMap<BookMap>();
        var books = csv.GetRecords<Book>();

        foreach (var book in books)
        {
            Console.WriteLine("Id: {0}, Title: {1}, Pages: {2}", book.Id, book.Title, book.NoOfPages);
        }
    }
}
```

When you execute the above example, you will see the following output.

```csharp
Id: 1, Title: Introduction to Machine Learning, Pages: 530
Id: 2, Title: Advanced Topics in Machine Learning, Pages: 380
Id: 3, Title: Introduction to Computing, Pages: 1171
Id: 4, Title: Introduction to Microeconomics, Pages: 437
Id: 5, Title: Calculus I, Pages: 1477
Id: 6, Title: Calculus II, Pages: 1571
Id: 7, Title: Trigonometry Basics, Pages: 540
Id: 8, Title: Special Topics in Trigonometry, Pages: 490
Id: 9, Title: Advanced Topics in Mathematics, Pages: 895
Id: 10, Title: Introduction to AI, Pages: 530
```