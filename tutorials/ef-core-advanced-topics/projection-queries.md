---
PermaID: 100011
Name: Projection Queries
---

# Projection Queries

Projection is a way of translating a full entity into a C# class with a subset of those properties. It is used to create a query that selects from a set of entities in your model but returns results that are of a different type.

 - Projection queries improve the efficiency of your application because only specific fields are retrieved from your database.
 - When you have the data, you can project or filter it as you want the data before output.
 - You can use the `Select()` LINQ method for projection to create a query that selects specific columns from a set of entities.
 
## Anonymous Type

Anonymous types provide an easy way to create a new type without initializing them. Projection queries load the data into this Anonymous Type.

```csharp
var author = context.Authors
    .Select(a => new
    {
        Id = a.AuthorId,
        FullName = a.FirstName + a.LastName,
        BookList = a.Books
    }).ToList();
```

In this example, the author data is projected to anonymous type which contains `Id`, `FullName`, and `BookList`.

## Concrete Type

You can also write a Projection query to return a Concrete Type, and to do so we will have to create a custom class first, and it must have all properties, which we want to return from the table.

```csharp
public class AuthorData
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<Book> BookList { get; set; }
}
```

Now change the select clause in the query to map the result to the `AuthorData`.

```csharp
List<AuthorData> authors = context.Authors
    .Select(a => new AuthorData
    {
        Id = a.AuthorId,
        FullName = a.FirstName + a.LastName,
        BookList = a.Books
    }).ToList();
```