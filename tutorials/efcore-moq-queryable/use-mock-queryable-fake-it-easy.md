---
PermaID: 100005
Name: Use MockQueryable.FakeItEasy
---

# Use MockQueryable.FakeItEasy

A `DbSet` represents the collection of all entities in the context, or that can be queried from the database, of a given type. The `DbSet` objects are created from a `DbContext` using the `DbContext.Set` method.

The **MockQueryable.FakeItEasy** provides `BuildMockDbSet` extension method that creates a mock of type `DbSet`.

Let's consider the following simple example which mocks the `DbSet` as shown below.

```csharp
public static void Example1()
{
    var authors = new List<Author>
    {
        new Author { Name="Carson Alexander" },
        new Author { Name="Meredith Alonso" },
        new Author { Name="Arturo Anand" },
        new Author { Name="Gytis Barzdukas"},
        new Author { Name="Yan Li" },
    };

    var mock = authors.AsQueryable().BuildMockDbSet();
    var userRepository = new TestDbSetRepository(mock);

    var result = userRepository.GetAll();

    foreach (var author in result)
    {
        Console.WriteLine(author.Name);
    }
}
```

Let's execute the above example, and you will see the following output.

```csharp
Carson Alexander
Meredith Alonso
Arturo Anand
Gytis Barzdukas
Yan Li
```
