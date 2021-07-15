---
PermaID: 100002
Name: Map Detached Entities
---

# Map Detached Entities

**Detached.Mappers.EntityFramework** simplifies the mapping of detached entities to the entities already available in the database. It can handle DTO-Entity, DTO-DTO, and Entity-Entity mapping.
  
 - When mapping, detached will only modify the root entity (the one passed as a parameter) and all the related entities marked as compositions. 
 - Associations are just attached and marked as Unmodified. Assuming that associations exist, also helps to reduce the amount of data loaded for the comparison.

So first, we need to update our context class, as shown below.

```csharp
public class BookStore : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;")
            .UseDetached();
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

To load the current status of the entities, **Detached.Mappers.EntityFramework** needs a QueryProvider instance to save and a Mapper instance that copies the given DTO/Entity state over the current entities. You can add these services by calling `UseDetached` on `DbContextBuilderOptions`.

Now let's define a DTO for an author and book entities which we will map to the `Author` and `Book` entities respectively.

```csharp
public class AuthorDTO
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<BookDTO> Books { get; set; }
}

public class BookDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
```

**Detached.Mappers.EntityFramework** provides a `Map` extension method that can load the current state and copy DTO values. It returns the persisted entity (that comes from the DB) with the updated values. No updates are persisted until you can the `SaveChanges()` method.

Let's consider the following simple example in which we will update the book entity using book DTO as shown below.

```csharp
public static void Example1()
{
    using (var context = new BookStore())
    {
        Book attachedBook = context.Map<Book>(
            new BookDTO 
            { 
                Id = 1, 
                Title = "New Title", 
                NoOfPages = 530, 
                AuthorId = 1 
            });

        context.SaveChanges();

        var books = context.Books.ToList();

        foreach (var book in books)
        {
            Console.WriteLine(book.Title);
        }
    }
}
```

Let's execute the above code and you will see that the book title is updated.

```csharp
New Title
Introduction to Microeconomics
Introduction to Computing
Advanced Topics in Machine Learning
Introduction to Machine Learning
Calculus II
Trigonometry Basics
Special Topics in Trigonometry
Advanced Topics in Mathematics
Introduction to AI
```
