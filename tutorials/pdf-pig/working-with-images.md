---
PermaID: 100006
Name: Working with Images
---

# Working with Images

As a developer, you will see that working with images can be quite a complex topic in PDF format. A wide variety of manipulations with images awaits the user when he is faced with the work of PDF documents. PDF files can contain the following types of images.

 - Inline: Images appear inline in the page's content stream and these are generally used for small images.
 - XObjects: Images defined outside the content stream and referenced from the content stream by name using an operator.
 
**PdfPig** provides `InlineImage` and `XObjectImage` to handle both types, and both of the classes implements `IPdfImage`.

You can access all the images on a page by calling the `Page.GetImages()` method that returns the set of images on the page.

```csharp
public static void Example1()
{
    using (PdfDocument document = PdfDocument.Open(@"D:\my_pdf_file1.pdf"))
    {
        foreach (Page page in document.GetPages())
        {
            IEnumerable<IPdfImage> images = page.GetImages();

            Console.WriteLine("Total Images: {0}", images.Count());
        }
    }
}
```

The actual content of the image bytes is either:

 - A PDF format bitmap based on the `ColorSpace`.
 - A JPEG file is directly embedded in the file.

Let's consider another example that extracts the images from a PDF file.

```csharp
public static void Example2()
{
    using (PdfDocument document = PdfDocument.Open(@"D:\my_pdf_file1.pdf"))
    {
        foreach (Page page in document.GetPages())
        {
            foreach (var image in page.GetImages())
            {
                if (!image.TryGetBytes(out var b))
                {
                    b = image.RawBytes;
                }

                var type = string.Empty;
                switch (image)
                {
                    case XObjectImage ximg:
                        type = "XObject";
                        break;
                    case InlineImage inline:
                        type = "Inline";
                        break;
                }

                Console.WriteLine("Image with {0} bytes of type '{1}' on page {2}. Location: {3}.", b.Count, type, page.Number, image.Bounds);
            }
        }
    }
}
```

Where the image is a JPEG decoding the bytes are not supported directly and `IPdfImage.TryGetBytes(out var bytes)` will return false. 

 - The `IPdfImage.RawBytes` is a valid JPEG file. 
 - When the image is in PDF format the `RawBytes` are usually the bitmap with one or more PDF filters applied. 
 - `IPdfImage.TryGetBytes(out var bytes)` will return the bytes after reversing these filters in PDF format. 
 - The actual bytes are then subject to interpretation based on the `ColorSpace`.
