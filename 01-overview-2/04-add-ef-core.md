---
PermaID: 100003
Name: Add Entity Framework Core Functionality
---

# Add EF Core

Entity Framework is a lightweight ORM and simplifies mappings between your .NET objects and the tables and columns in your relational database. It is widely used and well known for the following features.

* Rich mapping capabilities and has support for one-to-one, one-to-many, and many-to-many relationships.
* Support for inheritance, complex types as well as stored procedures.
* A possibility of using only code, the so-called “Code-First” approach \(including setting up the database and interacting with tables and columns only through code\).
* It offers a visual designer for creating entity models.
* It offers excellent integration with ASP.NET Framework.
* Support for eager, lazy, and explicit loading.

## Get Started with Entity Framework Core

The other project in your Solution with the same name as your Solution is a **Class Library \(.NET Standard\)**. The .NET Standard is a formal specification of the .NET APIs that are intended to be available on all .NET runtimes. This library is where we’ll place all our shared application code, including our Entity Framework Core logic.

### Install EF Core

To install EF Core, right-click on the **EFWithXamarin** project in Solution Explorer, and select **Manage NuGet Packages…**, and install the following packages.

* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Sqlite

We are ready to start writing some Entity Framework code.

### Create a Model

The model plays a significant part in the Entity Framework. It contains configurations, mapping properties, relationships, and defines which objects map to which tables. Let’s create a new **Models** folder and add a **Customer** class in **..Model\Customer.cs** file.

```csharp
using System;
using System.Collections.ObjectModel;

namespace EFWithXamarin.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean IsActive { get; set; }
        public ObservableCollection<PhoneContact> PhoneContacts { get; set; }
        public Customer()
        {
            PhoneContacts = new ObservableCollection<PhoneContact>();
        }
    }
}
```

Now add another class in the **Models** and call it **PhoneContact**.

```csharp
using System;

namespace EFWithXamarin.Models
{
    public class PhoneContact
    {
        public int PhoneContactID { get; set; }
        public string PhoneNumber { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
```

### Define the DbContext

If you have used Entity Framework before, you will know how to define a **DbContext** and the underlying **Models** that define a database schema. We have already created a simple model that has **Customer** and **PhoneContact** classes, now let’s ensure that these classes are part of the **DbContext** by defining a new context called **EntityContext**.

So first we will create a new folder called **Data** and add an **EntityContext** class in that folder.

```csharp
using EFWithXamarin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace EFWithXamarin.Data
{
    public class EntityContext : DbContext
    {
        public string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mydatabase2.db");
        public EntityContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<PhoneContact> PhoneContacts { get; set; }
    }
}
```

To make things simple, we will add another service class in which we will all the CRUD operations.

```csharp
using EFWithXamarin.Data;
using EFWithXamarin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFWithXamarin.Services
{
    public class EntityFrameworkService
    {
        private EntityContext _context;

        public EntityFrameworkService()
        {
            _context = new EntityContext();
        }

        public IList<Customer> GetAll()
        {
            _context = new EntityContext();
            return _context.Customers
                .Include(p => p.PhoneContacts)
                .ToList();
        }

        public void InsertOrUpdate(Customer customer)
        {
            var item = _context.Customers
                .Where(c => c.CustomerID == customer.CustomerID)
                .Include(p => p.PhoneContacts)
                .FirstOrDefault();

            if (item == null)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                item.CustomerID = customer.CustomerID;
                item.Name = customer.Name;
                item.Description = customer.Description;
                item.PhoneContacts = customer.PhoneContacts;

                _context.Customers.Update(item);
            }

            _context.SaveChanges();
        }

        public void Remove(Customer item)
        {
            _context.Customers.Remove(item);
            _context.SaveChanges();
        }
    }
}
```

Once you are done with context class, let’s build the class library project.

