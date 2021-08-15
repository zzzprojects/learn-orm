---
PermaID: 100011
Name: Working with Tables
---

# Working with Tables

A table is made up of rows and columns and the intersection of a row and column is known as a cell. 

 - Tables are often used to organize and present information, but they have a variety of other uses as well. 
 - You can use tables to align numbers in columns, and then sort and perform calculations on them. 
 - You can also use tables to create interesting page layouts.

**DocX** allows you to insert a table in a word document, and populate the tables with data as shown in the following example.

```csharp
public static void Example1()
{
    // Create a document.
    using (var document = DocX.Create(@"D:\Table.docx"))
    {
        // Add a title
        document.InsertParagraph("Create a simple table").FontSize(15d).SpacingAfter(50d).Alignment = Alignment.center;

        // Create a table.
        var table = document.AddTable(2, 3);

        // Set the table's values.
        table.Rows[0].Cells[0].Paragraphs[0].Append("First");
        table.Rows[0].Cells[1].Paragraphs[0].Append("Second");
        table.Rows[0].Cells[2].Paragraphs[0].Append("Third");
        table.Rows[1].Cells[0].Paragraphs[0].Append("Fourth");
        table.Rows[1].Cells[1].Paragraphs[0].Append("Fifth");
        table.Rows[1].Cells[2].Paragraphs[0].Append("Sixth");

        // Set the table's column width.
        table.SetWidths(new float[] { 200, 300, 100 });

        // Add the table into the document.
        document.InsertTable(table);

        document.Save();
    }
}
```

When you execute the above example, you will see that a table is inserted in a word document.

<img src="images/word-16.png" alt="table inserted"> 