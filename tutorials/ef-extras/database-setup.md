---
PermaID: 100002
Name: Database Setup
---

# Database Setup

## Create Data Model

Model is a collection of classes to interact with the database. We will create a simple class called `Student` and add the following code.

```csharp
public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Salary { get; set; }
}
```

## Create Database Context

The database context class provides the main functionality to coordinate Entity Framework with a given data model. 

 - You can create this class by deriving from the `Microsoft.EntityFrameworkCore.DbContext` class. 
 - In your code, you can specify which entities are included in the data model. 
 - You can also customize certain Entity Framework behavior. 

So let's add a new class `EmployeeContext`, and replace the following code.

```csharp
public class EmployeeContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=EmployeeContextDb;");
    }

    public DbSet<Employee> Employees { get; set; }
}
```

This code creates a `DbSet` property for each entity set. In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table.

### Initialize Database

The Entity Framework will create an empty database for you. So we need to write a method that's called after the database is created to populate it with test data.

```csharp
public static void Initialize()
{
    using (EmployeeContext context = new EmployeeContext())
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var employees = new List<Employee>
        {
            new Employee { Name="Carson Alexander", Age = 32, Salary = 10000 },
            new Employee { Name="Meredith Alonso", Age = 55, Salary = 30000 },
            new Employee { Name="Arturo Anand", Age = 42, Salary = 23000 },
            new Employee { Name="Gytis Barzdukas", Age = 31, Salary = 10500 },
            new Employee { Name="Yan Li", Age = 33, Salary = 18000 },
        };

        employees.ForEach(a => context.Employees.Add(a));
        context.SaveChanges();
    }
}
```

 - The above code creates a database when needed and loads test data into the new database.
 - It also checks if there are any authors in the database, and if not, it assumes the database is new and needs to be seeded with test data. 

In the `Main` method, replace the following code.

```csharp
static void Main(string[] args)
{
    Initialize();
    using (EmployeeContext context = new EmployeeContext())
    {
        int employees = context.Employees.Count();

        Console.WriteLine("Total Employees: {0}", employees);
    }
}
```

Now when you run your application for the first time, the database will be created and seeded with test data and you will see the following output.

```csharp
Total Employees: 5
```
