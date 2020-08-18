---
PermaID: 110004
Name: Indexes
---

# Indexes

Indexes are a common concept across many data stores and data is stored in the form of records. Every record has a key field, which helps it to be recognized uniquely.

 - Indexing is a way to optimize the performance of a database by minimizing the number of disk accesses required when a query is processed. 
 - It is a data structure technique that is used to quickly locate and access the data in a database.

## Indexing in EF Core

By convention, an index is created in each property (or set of properties) that are used as a foreign key.

 - EF Core only supports one index per distinct set of properties. 
 - If you use the Fluent API to configure an index on a set of properties that already have an index defined, either by convention or previous configuration, then you will be changing the definition of that index. 
 - This is useful if you want to further configure an index that was created by convention.

Indexes cannot be created using data annotations, instead, you can use the Fluent API to specify an index on one or more columns.

You can also specify an index on a single column:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .HasIndex(a => a.Name);
}
```

You can also specify an index over more than one column:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .HasIndex(a => new { a.FirstName, a.LastName });
}
```

### Index uniqueness

By default, indexes aren't unique: multiple rows are allowed to have the same value(s) for the index's column set. You can make an index unique as follows:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .HasIndex(a => a.Name)
        .IsUnique();
}

```

Attempting to insert more than one entity with the same values for the index's column set will cause an exception to be thrown.

### Index name
By convention, indexes created in a relational database are named IX_<type name>_<property name>. For composite indexes, <property name> becomes an underscore separated list of property names.

You can use the Fluent API to set the name of the index created in the database:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .HasIndex(a => a.Name)
        .HasName("Index_Name");
}
```

### Index filter

In some relational databases, you can specify a filtered or partial index to index only a subset of a column's values, reducing the index's size and improving both performance and disk space usage. 

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .HasIndex(a => a.Name)
        .HasFilter("[Url] IS NOT NULL");
}
```

In SQL Server provider EF adds an 'IS NOT NULL' filter for all nullable columns that are part of a unique index. To override this convention you can supply a null value.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .HasIndex(a => a.Name)
        .IsUnique()
        .HasFilter(null);
}
```

### Included columns

In some relational databases, you can configure a set of columns to include in the index, but aren't part of its "key". When all columns in the query are included in the index can significantly improve query performance.

In this example, the `Url` column is part of the index key, so any query filtering on `Url` can use the index. But also, queries accessing only the `Title` and `PublishedOn` columns will not need to access the table and will run more efficiently:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Book>()
        .HasIndex(b => b.Url)
        .IncludeProperties(b => new
        {
            b.Title,
            b.PublishedOn
        });
}
```