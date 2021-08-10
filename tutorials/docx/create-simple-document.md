---
PermaID: 100001
Name: Create Simple Document
---

# Create Simple Document

**DocX** is an open-source library that allows you to create a Word document from scratch. It provides various methods and properties that help you to add paragraphs, formatting text, style, images, tables, etc.

The following example first creates and writes some text to that word file using the `DocX` class.

```csharp
public static void Example1()
{
    using (DocX document = DocX.Create(@"D:\my_word_document.docx"))
    {
        // Add a new Paragraph to the document.
        Paragraph p = document.InsertParagraph();

        // set font
        p.Font("Arial Black");

        // Append some text.
        p.Append("This is a sample text paragraph.");

        // Save the document.
        document.Save();
    }
}
```

As you can see that the document is created by calling the `DocX.Create` method. 

 - Once the document is created, you can add a paragraph by calling the `document.InsertParagraph()` method.
 - You can set font by calling the `Paragraph.Font()` method and pass the font name as a parameter. 
 - The `Paragraph.Append()` method add the specified text to the paragraph.
 - Once you are done with the document, call the `Save` method to save the document.

When you execute the above example, you will see that the word document is created that contains the following data.

<img src="images/word-1.png" alt="data written in word file">

The output is a 1-page word document with the text "This is a sample text paragraph." in **Arial Black** font.

