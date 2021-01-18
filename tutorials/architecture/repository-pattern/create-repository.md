---
PermaID: 100005
Name: Create Repository
---

# Create Repository

There are many ways to implement the repository and unit of work patterns. You can use repository classes with or without a unit of work class. 

 - You can implement a single repository for all entity types, or one for each type. 
 - If you implement one for each type, you can use separate classes, a generic base class and derived classes, or an abstract base class and derived classes. 
 - You can include business logic in your repository or restrict it to data access logic. 
 - You can also build an abstraction layer into your database context class using `IDbSet` interfaces instead of `DbSet` types for your entity sets.
 - The approach to implementing an abstraction layer shown in this tutorial is one option for you to consider, not a recommendation for all scenarios and environments.

## Create Author Repository Class

In the **DAL** folder, create an interface file named `IAuthorRepository.cs` and replace the following code.

```csharp
using RepositoryPatternDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternDemo.DAL
{
    public interface IAuthorRepository : IDisposable
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthorById(int authorId);
        void InsertAuthor(Author author);
        void DeleteAuthor(int authorId);
        void UpdateAuthor(Author author);
        void Save();
    }
}
```

The above code declares a typical set of CRUD methods, including two read methods one that returns all author entities, and one that finds a single author entity by `id`.

In the **DAL** folder, create a class file named `AuthorRepository.cs` file. Replace the following code, which implements the `IAuthorRepository` interface.

```csharp
using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternDemo.DAL
{
    public class AuthorRepository : IAuthorRepository
    {
        private BookStore _context;

        public AuthorRepository(BookStore context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthorById(int authorId)
        {
            return _context.Authors.Find(authorId);
        }

        public void InsertAuthor(Author author)
        {
            _context.Authors.Add(author);
        }

        public void DeleteAuthor(int authorId)
        {
            Author author = _context.Authors.Find(authorId);
            _context.Authors.Remove(author);
        }

        public void UpdateAuthor(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
```

The database context is defined in a class variable, and the constructor expects the calling object to pass in an instance of the context.

```csharp
private BookStore _context;
public AuthorRepository(BookStore context)
{
    _context = context;
}
```

You could instantiate a new context in the repository, but then if you used multiple repositories in one controller, each would end up with a separate context. 

The repository implements `IDisposable` and disposes the database context as you saw earlier in the controller. Its CRUD methods make calls to the database context in the same way that you saw earlier.
