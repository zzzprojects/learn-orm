---
PermaID: 100002
Name: Configure Mapper
---

# Configure Mapper

**AutoMapper.Collection.EntityFrameworkCore** allows you to configure the mapper and persist the detached entities to the entities already available in the database. 

So first, we need to configure the mapper and we also need to define the DTOs for our model classes.

Now let's define a DTO for an author and book entities which we will map to the `Author` and `Book` entities respectively.

```csharp
public class BookDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
    public int AuthorId { get; set; }
    public AuthorDTO Author { get; set; }
}

public class AuthorDTO
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
```

**AutoMapper.Collection.EntityFrameworkCore** provides a `CreateMap` and `ReverseMap` methods that create a type mapping from the destination to the source type, with validation disabled.

```csharp
var mapper = new Mapper(new MapperConfiguration(x =>
{
    x.AddCollectionMappers();
    x.CreateMap<AuthorDTO, Author>().ReverseMap();
    x.CreateMap<BookDTO, Book>().ReverseMap();
    x.UseEntityFrameworkCoreModel<BookStore>();
}));
```

This allows for two-way mapping. Let's consider the following simple example in which we will update the author entity using author DTO as shown below.

```csharp
using (var context = new BookStore())
{
    var existingAuthor = context.Authors
        .FirstOrDefault();

    context.Authors.Persist(mapper)
        .InsertOrUpdate(new AuthorDTO { AuthorId = existingAuthor.AuthorId, Name = "James", Books = existingAuthor.Books });
    
    var authors = context.Authors.ToList();

    foreach (var author in authors)
    {
        Console.WriteLine(author.Name);
    }
}
```

The `Persist(mapper).InsertOrUpdate` method will check if the entity is already in the database then it will update the entity, otherwise, it will be added as a new entity.

Let's execute the above code and you will see that the book title is updated.

```csharp
James
Meredith Alonso
Arturo Anand
Gytis Barzdukas
Yan Li
```

You can remove the existing entity by calling the `Persist<mapper>().Delete` method as shown below.

```csharp
using (var context = new BookStore())
{
    var existingAuthor = context.Authors
        .FirstOrDefault();

    context.Authors.Persist(mapper)
        .Remove(new AuthorDTO { AuthorId = existingAuthor.AuthorId, Name = existingAuthor.Name });

    var count = context.ChangeTracker.Entries<Author>().Count(x => x.State == EntityState.Deleted);

    Console.WriteLine("{0} author will be deleted.", count);
}
```

Let's execute the above code and you will see that the book title is updated.

```csharp
1 author will be deleted.
```