---
PermaID: 100001
Name: Generated Values
---

# Generated Values

A generated property is a property whose value is generated (either by EF or the database) when the entity is added and/or updated. Three value generation patterns can be used for properties.

 - No value generation
 - The value generated on add
 - The value generated on add or update

## No value generation

No value generation means that you will always supply a valid value to be saved to the database. This valid value must be assigned to new entities before they are added to the context.

Disabling value generation on a property is typically necessary if a convention configures it for value generation. For example, if you have a primary key of type int, it will be implicitly set configured as the value generated on add. 

### Data Annotations

You can disable value generation using data annotation, as shown below.

```csharp
public class Author
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int AuthorId { get; set; }
    public string Name { get; set; }
}
```

### Fluent API

You can also disable value generation using fluent API, as shown below.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .Property(a => a.AuthorId)
        .ValueGeneratedNever();
}
```

## Value Generated on Add

The value generated on add means that a value is generated when new entities are inserted. How the value is generated for added entities will depend on the database provider being used. 

 - Database providers may automatically setup value generation for some property types, but others may require you to set up how the value is generated manually.
 - By convention, when entities are added, non-composite primary keys of type short, int, long, or Guid are set up to have values generated if the application doesn't provide a value.
 - All the necessary configurations are handled by the database provider. For example, a numeric primary key in SQL Server is automatically set up as an `IDENTITY` column.

### Data Annotations

You can configure any property to have its value generated for inserted entities using data annotation, as shown below.

```csharp
public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Created { get; set; }
}
```

### Fluent API

You can configure any property to have its value generated for inserted entities using fluent API, as shown below.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .Property(a => a.Created)
        .ValueGeneratedOnAdd();
}
```

### Default values

In relational databases, you can configure a column with a default value. If a row is added and no value is specified for that column, then the default value will be used.

You can configure a default value on a property.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Book>()
        .Property(a => a.Rating)
        .HasDefaultValue(3.00);
}
```

You can also specify a SQL fragment that is used to calculate the default value.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .Property(a => a.Created)
        .HasDefaultValueSql("getdate()");
}
```

When you specify a default value, it will implicitly configure the property as the value generated on add.

## Value Generated on Add or Update

The value generated on add or update means that a new value is generated every time the record is either inserted or updated. Like value generated on add, if you specify a value for the property on a newly added instance of an entity, that value will be inserted rather than a value being generated. It is also possible to set an explicit value when updating. 

### Data Annotations

You can configure any property to have its value generated for inserted or updated entities using data annotation, as shown below.

```csharp
public class Author
{
    public int AuthorId { get; set; }
    public string Url { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime LastUpdated { get; set; }
}
```

### Fluent API

You can configure any property to have its value generated for inserted or updated entities using fluent API, as shown below.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .Property(a => a.LastUpdated)
        .ValueGeneratedOnAddOrUpdate();
}
```

### Computed Columns

In some relational databases, you can configure a column in a way that its value is computed in the database.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .Property(a => a.DisplayName)
        .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
}
```

In some cases, the column's value is computed every time it is fetched, and in others, it is computed on every update of the row and stored.
