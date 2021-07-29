---
PermaID: 100003
Name: Read Multiple Type of CSV Data from a Single File
---

# Read Multiple Type of CSV Data from a Single File

When you are working with a CSV file, sometimes, you see a single file that contains multiple and different types of CSV data. Let's consider the following file that contains both and `Author` and `Book` related data in a single file.

```csharp
AuthorId,Name
1,Carson Alexander
2,Meredith Alonso
3,Arturo Anand
4,Gytis Barzdukas
5,Yan Li

BookId,Title,NoOfPages
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

So first we need to define the classes for both types of data that can store the CSV file data.

```csharp
private class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
}

private class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
}
```

The following example reads all the from the CSV file and stores them in the respective list of objects.

```csharp
public static void Example1()
{
    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        IgnoreBlankLines = false,
    };

    var authors = new List<Author>();
    var books = new List<Book>();

    using (var reader = new StreamReader(@"D:\mycsvfile.csv"))
    using (var csv = new CsvReader(reader, config))
    {
        var isHeader = true;
        while (csv.Read())
        {
            if (isHeader)
            {
                csv.ReadHeader();
                isHeader = false;
                continue;
            }

            if (string.IsNullOrEmpty(csv.GetField(0)))
            {
                isHeader = true;
                continue;
            }

            switch (csv.HeaderRecord[0])
            {
                case "AuthorId":
                    authors.Add(csv.GetRecord<Author>());
                    break;
                case "BookId":
                    books.Add(csv.GetRecord<Book>());
                    break;
                default:
                    throw new InvalidOperationException("Unknown record type.");
            }
        }
    }

    Console.WriteLine("Total Authors: {0}", authors.Count);
    Console.WriteLine("Total Books: {0}", books.Count);
}
```

When you execute the above example, you will see the following output.

```csharp
Total Authors: 5
Total Books: 10
``` 