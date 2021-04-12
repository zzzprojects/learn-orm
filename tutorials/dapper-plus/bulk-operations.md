---
PermaID: 100003
Name: Bulk Operations
---

# Bulk Operations

The **Dapper Plus** library provides various extension methods such as `BulkInsert`, `BulkUpdate`, `BulkDelete`, `BulkMerge`, `BulkSynchronize` to perform different kinds of bulk operations on large amounts of data. 

The `BulkInsert` method allows you to insert a large number of entities in your database.

```csharp
private static void InsertBooks()
{
    using (IDbConnection connection = new SqlConnection(ConnectionString))
    {
        connection.Open();

        using (var transaction = connection.BeginTransaction())
        {
            transaction.BulkInsert(new List<Book>()
            {
                new Book {Title = "From This Day Forward", Category = "Humor & Entertainment", AuthorId = 4},
                new Book {Title = "Founding Mothers: The Women Who Raised Our Nation", Category = "History", AuthorId = 4},
                new Book {Title = "Records of Our National Life : The National Archives", Category = "History", AuthorId = 4}
            });

            transaction.Commit();
        }
    }
}
```

You can also insert related entities using the `BulkInsert` method.

```csharp
private static void InsertAuthorAndRelatedBooks()
{
    Author author = new Author()
    {
        FirstName = "Cokie",
        LastName = "Roberts",
        Books = new List<Book>()
        {
            new Book {Title = "From This Day Forward", Category = "Humor & Entertainment", AuthorId = 4},
            new Book {Title = "Founding Mothers: The Women Who Raised Our Nation", Category = "History", AuthorId = 4},
            new Book {Title = "Records of Our National Life : The National Archives", Category = "History", AuthorId = 4}
        }
    };

    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        db.BulkInsert(author, author => author.Books);
    }
}
```

For more information about **Dapper Plus** library, click [here](https://dapper-plus.net/overview).
