---
PermaID: 100005
Name: Load Value To List
---

# Load Value To List

When working with CSV files, sometimes you will see multiple values in one column and you will need to load these multiple values to the list.

Let's consider the following sample CSV file that contains an additional `Categories` column and in this column, you can see multiple values.

```csharp
BookId,Title,Pages,Categories
1,Introduction to Machine Learning,530,"Software,Education,AI"
2,Advanced Topics in Machine Learning,380,"Software,Education,AI"
3,Introduction to Computing,1171,"Software,Education"
```

Here is the class we want to load this data into it.

```csharp
public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
    public List<string> Categories { get; set; }
}

public sealed class BookMap : ClassMap<Book>
{
    public BookMap()
    {
        Map(m => m.BookId).Index(0);
        Map(m => m.Title).Index(1);
        Map(m => m.NoOfPages).Index(2);
        Map(m => m.Categories).Index(3);
    }
}
```

If we tried to load this column to the list as shown below.

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
            Console.WriteLine("Title: {0}, Categories Count: {1}", book.Title, book.Categories.Count);
        }
    }
}
```

When you execute the above example, you will see the following output.

```csharp
Title: Introduction to Machine Learning, Categories Count: 1
Title: Advanced Topics in Machine Learning, Categories Count: 1
Title: Introduction to Computing, Categories Count: 1
```

As you can see the multiple categories values are loaded as a single value, but what we want is that it should be loaded as multiple values in the categories list. To do so, we need to change the mapping as shown below.

```csharp
public sealed class BookMap : ClassMap<Book>
{
    public BookMap()
    {
        Map(m => m.BookId).Index(0);
        Map(m => m.Title).Index(1);
        Map(m => m.NoOfPages).Index(2);
        Map(m => m.Categories).Convert(args =>
        {
            var columnValue = args.Row.GetField<string>("Categories");
            return columnValue?.Split(',')?.ToList() ?? new List<string>();
        });
    }
}
```

The `Convert` method lets you specify an expression to be used to convert data in the row to the member as you need.

Let's execute your code again and you will see that this time all the values in the `Categories` column are loaded in the list separately instead of a single value.

```csharp
Title: Introduction to Machine Learning, Categories Count: 3
Title: Advanced Topics in Machine Learning, Categories Count: 3
Title: Introduction to Computing, Categories Count: 2
```
 