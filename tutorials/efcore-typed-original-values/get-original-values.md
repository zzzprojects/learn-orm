---
PermaID: 100002
Name: Get Original Values
---

# Get Original Values

**EntityFrameworkCore.TypedOriginalValues** allows you to get typed access to the original values of your entity properties when you update it. It provides the `GetOriginal` extension method to retrieve the original values of an entity.

Let's consider the following simple example where we have retrieved an author and update his name.
 
```csharp
using (var context = new BookStore())
{
    var author = context.Authors.Where(a => a.Name == "Yan Li").FirstOrDefault();
    author.Name = "Mark Upston";

    var oldValue = context.GetOriginal(author).Name;

    Console.WriteLine("\"{0}\" is replaced with \"{1}\"", oldValue, author.Name);

    context.SaveChanges();
}
```

When you call the `context.GetOriginal(author).Name`, you will get the previous value which is replaced with the new value. Let's execute the above code, and you will see the following output.

```csharp
"Yan Li" is replaced with "Mark Upston"
```
 
