---
PermaID: 100002
Name: Write CSV File
---

# Write CSV File

**CsvHelper** allows you to write data to the file in a CSV format very easily. First, we need to create a list of class objects that we want to write to a CSV file. To do so, let's create a new class `Author`.

```csharp
public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
}
```

The following example first creates a list of authors and then writes all the authors' data to the CSV file.

```csharp
public static void Example1()
{
    var authors = new List<Author>
    {
        new Author { AuthorId = 1, Name="Carson Alexander" },
        new Author { AuthorId = 2, Name="Meredith Alonso" },
        new Author { AuthorId = 3, Name="Arturo Anand" },
        new Author { AuthorId = 4, Name="Gytis Barzdukas"},
        new Author { AuthorId = 5, Name="Yan Li" },
    };

    using (var writer = new StreamWriter(@"D:\mycsvfile.csv"))
    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
    {
        csv.WriteRecords(authors);
    }
}
```

When you execute the above example, you will see that the CSV file is created which contains the following data.

```csharp
AuthorId,Name
1,Carson Alexander
2,Meredith Alonso
3,Arturo Anand
4,Gytis Barzdukas
5,Yan Li
``` 

**CsvHelper** allows you to write all the data from dynamic objects instead of using concrete class objects.

```csharp
public static void Example2()
{
    dynamic author1 = new ExpandoObject();
    author1.AuthorId = 1;
    author1.Name = "Carson Alexander";

    dynamic author2 = new ExpandoObject();
    author2.AuthorId = 2;
    author2.Name = "Meredith Alonso";

    dynamic author3 = new ExpandoObject();
    author3.AuthorId = 3;
    author3.Name = "Arturo Anand";

    var authors = new List<dynamic>()
    {
        author1,
        author2,
        author3
    };

    using (var writer = new StreamWriter(@"D:\mycsvfile.csv"))
    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
    {
        csv.WriteRecords(authors);
    }
}
```

You can also write CSV rows from anonymous-type objects as shown below.

```csharp
public static void Example3()
{
    var authors = new List<object>
    {
        new { AuthorId = 1, Name="Carson Alexander" },
        new { AuthorId = 2, Name="Meredith Alonso" },
        new { AuthorId = 3, Name="Arturo Anand" },
        new { AuthorId = 4, Name="Gytis Barzdukas"},
        new { AuthorId = 5, Name="Yan Li" },
    };

    using (var writer = new StreamWriter(@"D:\mycsvfile.csv"))
    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
    {
        csv.WriteRecords(authors);
    }
}
```

