---
PermaID: 100002
Name: Use Computed Properties in LINQ
---

# Use Computed Properties in LINQ

**DelegateDecompiler.EntityFrameworkCore** enables you to use computed properties in LINQ. Let's add a computed property `FullName` to the `Author` class.

```csharp
public class Author
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Computed]
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }
    public virtual ICollection<Book> Books { get; set; }
}
```

Now you can use the computed property `FullName` in your LINQ queries, but make sure to call the `Decompile()` method as shown below.

```csharp
using (var context = new BookStore())
{
    var author = context.Authors
        .Where(a => a.FullName == "Yan Li")
        .Decompile()
        .FirstOrDefault();
}
```

The `Decompile()` method decompiles your computed properties to their underlying representation and the query will become similar to the following query.

```csharp
using (var context = new BookStore())
{
    var author = context.Authors
        .Where(a => (a.FirstName + " " + a.LastName) == "Yan Li")
        .FirstOrDefault();
}
```

If you have not used the `[Computed]` attribute on your computed property, you can use the `Computed()` extension method.

```csharp
using (var context = new BookStore())
{
    var author = context.Authors
        .Where(a => a.FullName.Computed() == "Yan Li")
        .Decompile()
        .FirstOrDefault();
}
```
