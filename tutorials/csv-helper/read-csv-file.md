---
PermaID: 100001
Name: Read CSV File
---

# Read CSV File

You can read data from a CSV file in many ways, but **CsvHelper** is extremely efficient, flexible, and very easy to use as you need.

Let's consider we have a simple CSV file called **mycsvfile.csv** which contains the following data.

```csharp
Id,Title,NoOfPages
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

**CsvHelper** allows you to read all the data into class objects, so first we need to define a class that can store the CSV file data.

```csharp
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
}
```

The following example reads all the data from a CSV file and stores it in the `Book` class objects.

```csharp
public static void Example1()
{
    using (var reader = new StreamReader(@"C:\Users\Muhammad Waqas\Desktop\mycsvfile.csv"))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        var books = csv.GetRecords<Book>();

        foreach (var book in books)
        {
            Console.WriteLine("Id: {0}, Title: {1}, Pages: {2}", book.Id, book.Title, book.NoOfPages);
        }
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
Id: 1, Title:  Introduction to Machine Learning, Pages: 530
Id: 2, Title:  Advanced Topics in Machine Learning, Pages: 380
Id: 3, Title:  Introduction to Computing, Pages: 1171
Id: 4, Title:  Introduction to Microeconomics, Pages: 437
Id: 5, Title:  Calculus I, Pages: 1477
Id: 6, Title:  Calculus II, Pages: 1571
Id: 7, Title:  Trigonometry Basics, Pages: 540
Id: 8, Title:  Special Topics in Trigonometry, Pages: 490
Id: 9, Title:  Advanced Topics in Mathematics, Pages: 895
Id: 10, Title:  Introduction to AI, Pages: 530
``` 

**CsvHelper** allows you to load all the data into dynamic objects.

```csharp
public static void Example2()
{
    using (var reader = new StreamReader(@"C:\Users\Muhammad Waqas\Desktop\mycsvfile.csv"))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        var books = csv.GetRecords<dynamic>();

        foreach (var book in books)
        {
            Console.WriteLine("Id: {0}, Title: {1}, Pages: {2}", book.Id, book.Title, book.NoOfPages);
        }
    }
}
```

You can also load CSV rows into anonymous type objects by passing the anonymous type as a parameter to the `GetRecords` method.

```csharp
public static void Example3()
{
    using (var reader = new StreamReader(@"C:\Users\Muhammad Waqas\Desktop\mycsvfile.csv"))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        var books = csv.GetRecords(new
        {
            Id = default(int),
            Title = string.Empty,
            NoOfPages = default(int)
        });

        foreach (var book in books)
        {
            Console.WriteLine("Id: {0}, Title: {1}, Pages: {2}", book.Id, book.Title, book.NoOfPages);
        }
    }
}
```
