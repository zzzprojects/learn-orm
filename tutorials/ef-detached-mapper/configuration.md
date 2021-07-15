---
PermaID: 100003
Name: Configuration
---

# Configuration

## Aggregations and Compositions

### Aggregations

Aggregation implies a relationship where the child can exist independently of the parent. Aggregations are weak relations because B and A are independent and it is also known as "Has a" relationship. 

### Compositions

Composition implies a relationship where the child cannot exist independent of the parent. Compositions are strong because B cannot exist without A, and is also known as the "Owns a" relationship.

You can configure the Aggregations and Compositions using the `[Aggregation]` and `[Composition]` attributes on the corresponding properties. 

```csharp
public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    [Composition]
    public virtual ICollection<Book> Books { get; set; }
}
```

Associations must be configured as aggregations or compositions, so Detached can choose how to load and map them. You can also configure it using fluent API by using `MappingOptions` when calling `UseDetached` to configure it as shown below. 

```csharp
public class BookStore : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;")
            .UseDetached(options => {
                options.Configure<Author>().Member(a => a.Books).Composition();
            });
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

 - It will only modify the root entity and all the related entities marked as compositions. 
 - Associations are just attached and marked as `Unmodified`. 
 - It also helps to reduce the amount of data loaded for the comparison.
