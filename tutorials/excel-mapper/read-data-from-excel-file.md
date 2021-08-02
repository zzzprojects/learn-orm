---
PermaID: 100001
Name: Read Data from Excel File
---

# Read Data from Excel File

As a developer, reading data from an excel file is not difficult, but **ExcelMapper** makes it easier to read data from the excel file as you need.

Let's consider the following simple excel file called **myexcelfile.xlsx** which contains the following data.

<img src="images/excel-1.png" alt="data in excel file">

**ExcelMapper** allows you to read all the data into class objects directly if the column names are exactly matching with class properties, so first we need to define a class that can store the excel file.

```csharp
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
    public int AuthorId { get; set; }
}
```

The following example reads all the data from an excel file and stores it in the `Book` class objects.

```csharp
public static void Example1()
{
    var excelMapper = new ExcelMapper(@"D:\myexcelfile.xlsx");
    var books = excelMapper.Fetch<Book>();

    foreach (var book in books)
    {
        Console.WriteLine("Id: {0}, Title: {1}, Pages: {2}, AuthorId: {3}", book.Id, book.Title, book.NoOfPages, book.AuthorId);
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
Id: 1, Title: Introduction to Machine Learning, Pages: 530, AuthorId: 1
Id: 2, Title: Advanced Topics in Machine Learning, Pages: 380, AuthorId: 1
Id: 3, Title: Introduction to Computing, Pages: 1171, AuthorId: 2
Id: 4, Title: Introduction to Microeconomics, Pages: 437, AuthorId: 2
Id: 5, Title: Calculus I, Pages: 1477, AuthorId: 3
Id: 6, Title: Calculus II, Pages: 1571, AuthorId: 3
Id: 7, Title: Trigonometry Basics, Pages: 540, AuthorId: 4
Id: 8, Title: Special Topics in Trigonometry, Pages: 490, AuthorId: 4
Id: 9, Title: Advanced Topics in Mathematics, Pages: 895, AuthorId: 4
Id: 10, Title: Introduction to AI, Pages: 530, AuthorId: 1
``` 

**ExcelMapper** also allows you to use dynamic objects instead of using concrete class when reading data from the excel file.

```csharp
public static void Example2()
{
    var excelMapper = new ExcelMapper(@"D:\myexcelfile.xlsx");
    var books = excelMapper.Fetch();

    foreach (var book in books)
    {
        Console.WriteLine("Id: {0}, Title: {1}, Pages: {2}, AuthorId: {3}", book.Id, book.Title, book.NoOfPages, book.AuthorId);
    }
}
```

As you can see that this time we have called the non-generic version of the `Fetch` method which loads all the data from excel to `IEnumerable<dynamic>`.

