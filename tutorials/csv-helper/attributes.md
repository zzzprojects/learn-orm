---
PermaID: 100008
Name: Attributes
---

# Attributes

Data Annotations are attributes which are applied to the class or members that specify validation rules, specify how the data is displayed, etc .

**CsvHelper** allows you to configure most of the configuration which we have done using class maps can also be done using data annotations attributes.

Let's consider the following class maps.

```csharp
private class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
}

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

Now using the data annotation attributes, you can achieve the above configuration as shown below.

```csharp
private class Book
{
    [Name("BookId")]
    public int Id { get; set; }
    public string Title { get; set; }

    [Name("Pages")]
    public int NoOfPages { get; set; }
}
```


The following example shows some more attributes.

```csharp
public class Book
{
    [Index(0)]
    public int Id { get; set; }

    [Index(1)]
    public string Title { get; set; }

    [BooleanTrueValues("yes")]
    [BooleanFalseValues("no")]
    public bool IsFree { get; set; }

    [Optional]
    public string Description { get; set; }

    [Ignore]
    public string TOC { get; set; }
}
```
