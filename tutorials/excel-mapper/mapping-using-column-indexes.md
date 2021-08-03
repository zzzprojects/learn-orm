---
PermaID: 100004
Name: Mapping Using Column Indexes
---

# Mapping Using Column Indexes

When you work with excel files, you will see sometimes that there are some extra columns that you don't need to read or you will see few empty columns which don't have any data. Let's consider the following excel file which contains some books related data.

<img src="images/excel-5.png" alt="books data in excel file">

Now there are some columns that we don't want to import data from, such as, `Description`, because it is empty and `AuthId` which we don't need. Here is the class where we will store the imported information.

```csharp
private class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
    public double Price { get; set; }
    public bool IsOffer { get; set; }
}
```

Now you can see that in the above `Book` class we don't have `Description` and `AuthorId` properties, because we don't need them. Now to map the right column to the right property, **ExcelMapper** allows you to specify the column index in the `Column` attribute as shown below.
 
```csharp
private class Book
{
    [Column(1)]
    public int BookId { get; set; }
    [Column(2)]
    public string Title { get; set; }
    [Column(4)]
    public int NoOfPages { get; set; }
    [Column(6)]
    public double Price { get; set; }
    [Column(7)]
    public bool IsOffer { get; set; }
}
```

 - The column indexes don't need to be consecutive. 
 - When mapping to column indexes, every property needs to be explicitly mapped through the `Column` attribute.

You can also specify the letter used for the column in the excel file.

```csharp
private class Book
{
    [Column(Letter = "A")]
    public int BookId { get; set; }
    [Column(Letter = "B")]
    public string Title { get; set; }
    [Column(Letter = "D")]
    public int NoOfPages { get; set; }
    [Column(Letter = "F")]
    public double Price { get; set; }
    [Column(Letter = "G")]
    public bool IsOffer { get; set; }
}
```

The following example reads all the data and loads each column to the right property specified using the column attribute.

```csharp
public static void Example1()
{
    var excelMapper = new ExcelMapper(@"D:\myexcelfile.xlsx");
    var books = excelMapper.Fetch<Book>();

    foreach (var book in books)
    {
        Console.WriteLine("Id: {0}, Title: {1}, Pages: {2}, Price: {3}", book.BookId, book.Title, book.NoOfPages, book.Price);
    }
}
```

When you execute the above example, you will see the following output.

```csharp
Id: 1, Title: Introduction to Machine Learning, Pages: 530, Price: 11.99
Id: 2, Title: Advanced Topics in Machine Learning, Pages: 380, Price: 20.99
Id: 3, Title: Introduction to Computing, Pages: 1171, Price: 5.5
Id: 4, Title: Introduction to Microeconomics, Pages: 437, Price: 5.99
Id: 5, Title: Calculus I, Pages: 1477, Price: 9.25
Id: 6, Title: Calculus II, Pages: 1571, Price: 6.5
Id: 7, Title: Trigonometry Basics, Pages: 540, Price: 3.9
Id: 8, Title: Special Topics in Trigonometry, Pages: 490, Price: 15.75
Id: 9, Title: Advanced Topics in Mathematics, Pages: 895, Price: 10.99
Id: 10, Title: Introduction to AI, Pages: 530, Price: 25
```