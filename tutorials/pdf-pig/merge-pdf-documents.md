---
PermaID: 100004
Name: Merge PDF Documents
---

# Merge PDF Documents

In most software applications sometimes you need to export a report with PDF or any other format and you may also need to merge multiple exported documents into a single document as per requirements.

**PdfPig** provides a `PdfMerger` class that allows you to merge two or more existing PDF files.

Let's consider we have multiple PDF files and we need to merge them into a single PDF document.

```csharp
public static void Example1()
{
    string filePath1 = @"D:\my_pdf_file.pdf";
    string filePath2 = @"D:\my_new_pdf_file.pdf";
    string filePath3 = @"D:\my_pdf_file1.pdf";
    string outputFile = @"D:\output_pdf.pdf";

    var fileBytes = new[] { filePath1, filePath2, filePath3 }
        .Select(File.ReadAllBytes).ToList();

    var resultFileBytes = PdfMerger.Merge(fileBytes);

    try
    {
        File.WriteAllBytes(outputFile, resultFileBytes);
        Console.WriteLine("File output to: {0}", outputFile);

        using (var doc = PdfDocument.Open(resultFileBytes))
        {
            Console.WriteLine("Generated document with {0} pages.", doc.NumberOfPages);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Failed to write output to file due to error: {0}.", ex);
    }
}
```

```csharp
File output to: D:\output_pdf.pdf
Generated document with 3 pages.
```
