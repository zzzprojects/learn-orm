---
PermaID: 100003
Name: Use Triggers without DbContextWithTriggers
---

# Use Triggers without DbContextWithTriggers

If you can't change your `DbContext` inheritance chain, you simply need to override your `SaveChanges` method and call the `SaveChangesWithTriggers` extension method.

So first we need to update our context class by inheriting it from the `DbContext` class again and also override the `SaveChanges` method as shown below.

```csharp
using EFTriggersDemo.Models;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTriggersDemo.DAL
{
    public class BookStore : DbContext
    {
        public BookStore(DbContextOptions<BookStore> options) : base(options)
        {
        }

        public override Int32 SaveChanges()
        {
            return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess: true);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
```

Alternatively, you can call `SaveChangesWithTriggers` directly instead of `SaveChanges`, but it is not recommended.

```csharp
var authors = new List<Author>
{
    new Author { FirstName="Carson", LastName="Alexander", BirthDate = DateTime.Parse("1985-09-01")},
    new Author { FirstName="Meredith", LastName="Alonso", BirthDate = DateTime.Parse("1970-09-01")},
    new Author { FirstName="Arturo", LastName="Anand", BirthDate = DateTime.Parse("1963-09-01")},
    new Author { FirstName="Gytis", LastName="Barzdukas", BirthDate = DateTime.Parse("1988-09-01")},
    new Author { FirstName="Yan", LastName="Li", BirthDate = DateTime.Parse("2000-09-01")},
};

authors.ForEach(a => context.Authors.Add(a));
context.SaveChangesWithTriggers(context.SaveChanges);
```
