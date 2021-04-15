---
PermaID: 100004
Name: Convention Based Mapping
---

# Convention Based Mapping

Sometimes, it is very difficult to create manual mapping classes especially when you have a lot of entity types. If your column names adhere to some kind of naming convention, you might be better off configuring a mapping convention.

You can create a convention by creating a class that derives from the `Convention` class and then in the constructor, you can configure the property conventions as shown below.

```csharp
using Dapper.FluentMap.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperFluentMapDemo
{
    public class MyConventionMap : Convention
    {
        public MyConventionMap()
        {
            Properties<string>()
            .Configure(c => c.HasPrefix("str"));
        }
    }
}
```

In the above code, we have configured to prefix all properties of type string with 'str' when mapping to column names.

Now make sure to initialize and configure all the entities on which a convention applies as shown below.

```csharp
FluentMapper.Initialize(config =>
{
    // Configure entities explicitly.
    config.AddConvention<MyConventionMap>()
        .ForEntity<Author>()
        .ForEntity<Book>();
    
});
```

We can now perform any database operations using Dapper as shown below.

```csharp
static void Main(string[] args)
{
    FluentMapper.Initialize(config =>
    {
        config.AddMap(new AuthorMap());
        config.AddMap(new BookMap());
    });

    Author author = GetAuthorAndTheirBooks(2);

    Console.WriteLine("{0} ({1})", author.FullName, author.Country);

    foreach (var book in author.Books)
    {
        Console.WriteLine("\t Title: {0} \t  Category: {1}", book.Title, book.Category);
    }
}

private static Author GetAuthorAndTheirBooks(int id)
{
    string sql =
        "SELECT * FROM Authors WHERE Id = @Id;" +
        "SELECT * FROM Books WHERE AuthorId = @Id;";

    using (IDbConnection db = new SqlConnection(ConnectionString))
    {
        using (var results = db.QueryMultiple(sql, new { Id = id }))
        {
            var author = results.Read<Author>().SingleOrDefault();
            var books = results.Read<Book>().ToList();

            if (author != null && books != null)
            {
                author.Books = books;
            }

            return author;
        }
    }
}
```

Let's execute the above code and you will see the following output.

```csharp
William Shakespeare (UK)
         Title: Romeo and Juliet          Category: Humor & Entertainment
         Title: The Tempest       Category: Fiction
         Title: The Winter's Tale : Third Series          Category: Fiction
```
