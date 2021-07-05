---
PermaID: 100004
Name: Discriminator Constraints
---

# Discriminator Constraints

In EF Core, TPH inheritance uses one database table to maintain data for all of the entity types in an inheritance hierarchy. It allows you to map a .NET type hierarchy to a single database table. 

 - A discriminator column is added to your table in this mapping pattern, which determines which entity type is represented by the particular row when reading query results from the database.
 - EF will materialize different .NET types in the hierarchy based on this value.
 - In the typical case, your hierarchy will have a closed set of .NET types; but as with enums, the database discriminator column can contain anything. 
 - If EF encounters an unknown discriminator value when reading query results, the query will fail. 

The **EFCore.CheckConstraints** allows you to create check constraints to make sure that only valid value is stored in the discriminator column. The following is a simple model that contains inheritance.

```csharp
public abstract class Person
{
    public int Id { get; set; }
    public string FullName { get; set; }
}

public class Student : Person
{
    public DateTime EnrollmentDate { get; set; }
}

public class Teacher : Person
{
    public DateTime HireDate { get; set; }
}
```

To activate discriminator check constraints, we need to call the `UseDiscriminatorCheckConstraints()` method.

```csharp
public class EntityContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder opBuilder)
    {
        opBuilder
            .UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=PeopleContextDb;")
            .UseDiscriminatorCheckConstraints();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>().HasBaseType<Person>();
        modelBuilder.Entity<Student>().HasBaseType<Person>();
    }

    public DbSet<Person> People { get; set; }
}
```

Now let's execute your application and you will see the following table is created for you.

```csharp
CREATE TABLE [dbo].[People] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [FullName]       NVARCHAR (MAX) NULL,
    [Discriminator]  NVARCHAR (MAX) NOT NULL,
    [EnrollmentDate] DATETIME2 (7)  NULL,
    [HireDate]       DATETIME2 (7)  NULL,
    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_People_Discriminator] CHECK ([Discriminator]=N'Teacher' OR [Discriminator]=N'Student' OR [Discriminator]=N'Person')
);
```
