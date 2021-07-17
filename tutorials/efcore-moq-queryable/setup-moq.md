---
PermaID: 100002
Name: Setup Moq
---

# Setup Moq

In this tutorial, we will be using **Moq**, so the first step is to install [MockQueryable.Moq](https://www.nuget.org/packages/MockQueryable.Moq) from the package manager console.

```csharp
PM> Install-Package MockQueryable.Moq
```

Once it is installed, let's create an author repository interface.

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
