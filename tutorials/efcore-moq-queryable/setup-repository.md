---
PermaID: 100002
Name: Setup Repository
---

# Setup Repository

With **MockQueryable.EntityFrameworkCore**, you can use any of the following packages. 

 - [MockQueryable.Moq](https://www.nuget.org/packages/MockQueryable.Moq) 
 - [MockQueryable.NSubstitute](https://www.nuget.org/packages/MockQueryable.NSubstitute)
 - [MockQueryable.FakeItEasy](https://www.nuget.org/packages/MockQueryable.FakeItEasy)

So let's install the following packages from the **Package Manager Console**.

```csharp
PM> Install-Package MockQueryable.Moq
PM> Install-Package MockQueryable.NSubstitute
PM> Install-Package MockQueryable.FakeItEasy
```

Once these packages are installed, first we need to create an `IAuthorRepository` interface.

```csharp
public interface IAuthorRepository
{
    IQueryable<Author> GetQueryable();

    void CreateAuthor(Author author);

    List<Author> GetAll();
}
```

It contains three simple methods, and we need to implement these methods in a class as shown below.

```csharp
public class TestDbSetRepository : IAuthorRepository
{
    private readonly DbSet<Author> _dbSet;

    public TestDbSetRepository(DbSet<Author> dbSet)
    {
        _dbSet = dbSet;
    }
    public IQueryable<Author> GetQueryable()
    {
        return _dbSet;
    }

    public void CreateAuthor(Author author)
    {
        _dbSet.Add(author);
    }

    public List<Author> GetAll()
    {
        return _dbSet.AsQueryable().ToList();
    }
}
```
