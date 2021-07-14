---
PermaID: 100002
Name: Use Triggers
---

# Use Triggers

To use triggers on your entities, the simple way is to inherit your context class from `DbContextWithTriggers`.

So first, we need to update our context class by inheriting it from the `DbContextWithTriggers` class, as shown below.

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
    public class BookStore : DbContextWithTriggers
    {
        public BookStore(DbContextOptions<BookStore> options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
```

Let's define an abstract class that contains two properties, and we will also enable automatic insert and update stamps for any entity that inherits this class.

```csharp
using EntityFrameworkCore.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTriggersDemo.Models
{
	public abstract class Trackable
	{
		public DateTime Inserted { get; private set; }
		public DateTime Updated { get; private set; }

		static Trackable()
		{
			Triggers<Trackable>.Inserting += entry => entry.Entity.Inserted = entry.Entity.Updated = DateTime.UtcNow;
			Triggers<Trackable>.Updating += entry => entry.Entity.Updated = DateTime.UtcNow;
		}
	}
}
```

Events are raised from the base class, up to the events specified on the entity class being used. Now we will update the `Author` class by inheriting it from the `Trackable` class.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTriggersDemo.Models
{
    public class Author : Trackable
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
```

Now execute your application again and open the `Authors` table.

<img src="images/data-1.png" alt="Data created">
