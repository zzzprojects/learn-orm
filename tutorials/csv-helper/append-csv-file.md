---
PermaID: 100006
Name: Append CSV File
---

# Append CSV File

When you are working with CSV files or any other file format, you will notice that you don't always write data to the new file, sometimes, you will need to append the data to the existing file.

Let's consider, we have an existing CSV file that contains the following data.

```csharp
AuthorId,Name
1,Carson Alexander
2,Meredith Alonso
```

Now we want to add some more data to the existing file, to do so, we need to configure our writer to not write the header when writing the CSV data from the class objects. 

```csharp
var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    // Don't write the header again.
    HasHeaderRecord = false,
};
```

Another step is to open the existing CSV file in `Appen` mode and also pass the above configuration settings to the `CsvWriter`.

```csharp
using (var stream = File.Open(@"D:\mycsvfile.csv"
using (var writer = new StreamWriter(stream))
using (var csv = new CsvWriter(writer, config))
```

Here is the complete code.

```csharp
public static void Example1()
{
    var authors = new List<Author>
    {
        new Author { AuthorId = 3, Name="Arturo Anand" },
        new Author { AuthorId = 4, Name="Gytis Barzdukas"},
        new Author { AuthorId = 5, Name="Yan Li" },
    };

    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        // Don't write the header again.
        HasHeaderRecord = false,
    };

    using (var stream = File.Open(@"D:\mycsvfile.csv", FileMode.Append))
    using (var writer = new StreamWriter(stream))
    using (var csv = new CsvWriter(writer, config))
    {
        csv.WriteRecords(authors);
    }
}
```

When you execute the above example, you will see that the CSV file is updated and appended the following data.

```csharp
AuthorId,Name
1,Carson Alexander
2,Meredith Alonso
3,Arturo Anand
4,Gytis Barzdukas
5,Yan Li
```
 