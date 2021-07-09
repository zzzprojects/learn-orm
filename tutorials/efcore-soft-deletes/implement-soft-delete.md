---
PermaID: 100002
Name: Implement Soft Delete
---

# Implement Soft Delete

To implement soft delete in your application, we need to inherit our db context class from `SoftDeletes.Core.DbContext`.

```csharp
public class BookStore : SoftDeletes.Core.DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BookStoreDb;");
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
```

In entities you want to add soft delete support, implement `SoftDeletes.ModelTools.ISoftDelete` or `ModelExtenstion` abstract class that implements `ITimestamps` and `ISoftDelete` interfaces.

So let's inherit both `Author` and `Book` entities from `ModelExtenstion` abstract class and implement the `abstract` methods.

```csharp
public class Author : ModelExtension
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }

    public override async Task OnSoftDeleteAsync(SoftDeletes.Core.DbContext context, CancellationToken cancellationToken = default)
    {
        var taskList = new List<Task> 
        {
            context.RemoveRangeAsync(Books,cancellationToken)
        };

        await Task.WhenAll(taskList);
    }

    public override void OnSoftDelete(SoftDeletes.Core.DbContext context)
    {
        context.RemoveRange(Books);
    }

    public override async Task LoadRelationsAsync(SoftDeletes.Core.DbContext context, CancellationToken cancellationToken = default)
    {
        var taskList = new List<Task> 
        {
            context.Entry(this)
                .Collection(a => a.Books)
                .LoadAsync()
        };

        await Task.WhenAll(taskList);
    }

    public override void LoadRelations(SoftDeletes.Core.DbContext context)
    {
        context.Entry(this)
            .Collection(a => a.Books)
            .Load();
    }
}

public class Book : ModelExtension
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NoOfPages { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public override Task OnSoftDeleteAsync(SoftDeletes.Core.DbContext context,
        CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public override void OnSoftDelete(SoftDeletes.Core.DbContext context)
    {
    }

    public override Task LoadRelationsAsync(SoftDeletes.Core.DbContext context,
        CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public override void LoadRelations(SoftDeletes.Core.DbContext context)
    {
    }
}
```

It will add column named `DeletedAt` to your entity so you need to add a migration and update the database tables or delete the database and create a new one.

 - In `LoadRelationsAsync` and `LoadRelations` methods, load relations you want to delete in soft deleting the entity. 
 - in `OnSoftDeleteAsync` and `OnSoftDelete` methods, delete relations you want to delete in soft deleting the entity.
 - For soft deleting an entity use `Remove` and `RemoveAsync` methods. 
 - These methods will soft delete an `ISoftDelete` implemented entity and force delete an not implemented entity.
 - For force deleting any entity use `ForceRemove` method.

Let's configure the relationship in `OnModelCreating` method as shown below.
  
```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // For Author
    modelBuilder.Entity<Author>()
        .HasQueryFilter(a => a.DeletedAt == null);

    // For Book
    modelBuilder.Entity<Book>()
        .HasQueryFilter(b => b.DeletedAt == null);
    modelBuilder.Entity<Book>()
        .HasOne(b => b.Author)
        .WithMany(a => a.Books)
        .HasForeignKey(b => b.AuthorId);
}
```
