---
PermaID: 100003
Name: Memory-Optimized Tables
---

# Memory-Optimized Tables

Memory-Optimized Tables are a feature of SQL Server where the entire table resides in memory. 

 - A second copy of the table data is maintained on disk, but only for durability purposes. 
 - Data in memory-optimized tables is only read from disk during database recovery, such as after a server restart.

## Configuration

You can specify that the table that is mapped to an entity is memory-optimized. When using EF Core to create and maintain a database based on your model, either with migrations or `EnsureCreated`, a memory-optimized table will be created for these entities.

```csharp
public class BookStore : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().IsMemoryOptimized();
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```
