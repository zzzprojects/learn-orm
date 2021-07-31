---
PermaID: 100007
Name: Load CSV Data to DataTable
---

# Load CSV Data to DataTable

**CsvHelper** allows you to load all the data from a CSV file to the `DataTable` by using the `CsvDataReader`. By default, a table will be loaded with all columns populated as strings.

Let's consider the following sample CSV file.

```csharp
AuthorId,Name
1,Carson Alexander
2,Meredith Alonso
3,Arturo Anand
4,Gytis Barzdukas
5,Yan Li
```

The following example loads all the data into a data table.

```csharp
public static void Example1()
{
    using (var reader = new StreamReader(@"D:\mycsvfile.csv"))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        using (var dr = new CsvDataReader(csv))
        {
            var dt = new DataTable();
            dt.Load(dr);

            Console.WriteLine("Total Columns: {0}", dt.Columns.Count);
            Console.WriteLine("Total Rows: {0}", dt.Rows.Count);
        }
    }
}
```

Let's execute the above code and you will see the following output.

```csharp
Total Columns: 2
Total Rows: 5
```

You can also specify the columns and column types, and it will automatically convert the data types accordingly when data table is loaded.

```csharp
public static void Example2()
{
    using (var reader = new StreamReader(@"D:\mycsvfile.csv"))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        using (var dr = new CsvDataReader(csv))
        {
            var dt = new DataTable();
            dt.Columns.Add("AuthorId", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            dt.Load(dr);

            Console.WriteLine("Total Columns: {0}", dt.Columns.Count);
            Console.WriteLine("Total Rows: {0}", dt.Rows.Count);
        }
    }
}
```

