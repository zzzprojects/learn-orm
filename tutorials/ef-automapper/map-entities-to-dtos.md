---
PermaID: 100002
Name: Map Entities to DTOs
---

# Map Entities to DTOs

In multi-layered architectures like client-server applications, data is usually represented differently at each layer. In such architectures, communicating between layers may become cumbersome. 

 - You can avoid this and simplifies the communication by using the DTO pattern, which involves defining simple classes to transfer data between layers. 
 - DTOs are exactly what they sound like, a construct designed to pass data from one system to another, nothing more and nothing less.

The main issue that comes with this approach is that it requires writing a large amount of mapping code, which is an error-prone and tedious task.

Now let's define a DTO for an author and book entities which we will map to the `Author` and `Book` entities respectively.

```csharp
public class AuthorDTO
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public virtual ICollection<BookDTO> Books { get; set; }
}

public class BookDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
    public string Category { get; set; }
    public int AuthorId { get; set; }
    public AuthorDTO Author { get; set; }
}
```

**AutoMapper** provides a `MapperConfiguration` where you can specify the mappings between entities and their DTOs.

```csharp
var config = new MapperConfiguration(cfg => {
    cfg.CreateMap<Author, AuthorDTO>();
    cfg.CreateMap<Book, BookDTO>();
});
```

**AutoMapper.EF6** provides a set of extension methods that perform the conversion very easily.
 
Let's consider the following simple example in which the author entities are returned as DTOs as shown below.

```csharp
using (var context = new BookStore())
{
    var config = new MapperConfiguration(cfg => {
        cfg.CreateMap<Author, AuthorDTO>();
        cfg.CreateMap<Book, BookDTO>();
    });

    var authors = context.Authors.ProjectToList<AuthorDTO>(config);

    Console.WriteLine("Total Authors: {0}", authors.Count);
}
```
