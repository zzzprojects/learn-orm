---
PermaID: 100016
Name: Backing Field
---

# Backing Field

EF Core introduced support for backing fields, that allows you to encapsulate properties of your classes. The encapsulation lets you more easily control interaction with your classes and APIs to ensure they are not misused intentionally or accidentally.

EF6 only maps to properties, not to fields, but it allows you to protect the value of a property by using a private setter. 
Because EF uses reflection to materialize query results, it can set the value of the property. But the property itself needed to be public.

```csharp
public string Name {get; private set;}
```

It covers many cases, but not if you wanted the property to be private. 

 - A common use case might be the key property, EF needs to interact with it, but you may not want developers to read it directly or even use it in queries.
 - With this feature, you can map to backing fields whether you explicitly define it or rely on inferred backing fields to comprehend properties. 
 - This allows EF Core to recognize even private properties when creating migrations, as well as to populate them when materializing query results. 

```csharp
private int _authorId;
private int AuthorId => _authorId;
```

If the property is private, but you don't declare a backing field, EF Core will infer it for you when building the data model. In the specific case, if the key property is defined private as shown below.

```csharp
public class Author
{
    private int _authorId;
    private int AuthorId => _authorId;
    public string Name { get; set; }
}
```

The `ModelBuilder` will not be able to see the private property, so you will need to tell EF Core that it's the key.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>().HasKey("AuthorId");
}
```

EF Core can see that there's a backing field `_authorId` related to the property so it can materialize results to that field, which will then feed the property. 

## Basic configuration

By convention, the following fields will be discovered as backing fields for a given property \(listed in precedence order\).

* `_<camel-cased property name>`
* `_<property name>`
* `m_<camel-cased property name>`
* `m_<property name>`

In the following sample, the `Name` property is configured to have `_name` as its backing field.

```csharp
class EntityContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
}

public class Author
{
    private string _name;

    public int AuthorId { get; set; }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}
```

The backing fields are only discovered for properties that are included in the model. 

You can also configure backing fields by using a Data Annotation \(available in EFCore 5.0\) or the Fluent API, e.g. if the field name doesn't correspond to the above conventions:

### Data Annotations

```csharp
public class Author
{
    private string _validatedName;

    public int AuthorId { get; set; }

    [BackingField(nameof(_validatedName))]
    public string Name
    {
        get { return _validatedName; }
    }

    public void SetName(string name)
    {
        // put your validation code here

        _validatedName = name;
    }
}
```

### Fluent API

```csharp
class EntityContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .Property(b => b.Name)
            .HasField("_validatedName");
    }
}

public class Author
{
    private string _validatedName;

    public int AuthorId { get; set; }

    public string Name
    {
        get { return _validatedName; }
    }

    public void SetName(string name)
    {
        using (var client = new HttpClient())
        {
            var response = client.GetAsync(name).Result;
            response.EnsureSuccessStatusCode();
        }

        _validatedName = name;
    }
}
```

## Field and Property Access

By default, EF will always read and write to the backing field. It will assume that one has been properly configured and will never use the property. However, EF also supports other access patterns. For example, the following sample instructs EF to write to the backing field only while materializing and to use the property in all other cases.

```csharp
class EntityContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .Property(b => b.Name)
            .HasField("_validatedName")
            .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
    }
}

public class Author
{
    private string _validatedName;

    public int AuthorId { get; set; }

    public string Name
    {
        get { return _validatedName; }
    }

    public void SetName(string name)
    {
        using (var client = new HttpClient())
        {
            var response = client.GetAsync(name).Result;
            response.EnsureSuccessStatusCode();
        }

        _validatedName = name;
    }
}
```

## Field-only Properties

You can also create a conceptual property in your model that does not have a corresponding CLR property in the entity class but instead uses a field to store the data in the entity. This is different from Shadow Properties, where the data is stored in the change tracker, rather than in the entity's CLR type. Field-only properties are commonly used when the entity class uses methods instead of properties to get/set values, or in cases where fields shouldn't be exposed at all in the domain model \(e.g. primary keys\).

You can configure a field-only property by providing a name in the `Property(...)` API.

```csharp
class EntityContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .Property("_validatedName");
    }
}

public class Author
{
    private string _validatedName;

    public int AuthorId { get; set; }

    public string GetName()
    {
        return _validatedName;
    }

    public void SetName(string name)
    {
        using (var client = new HttpClient())
        {
            var response = client.GetAsync(name).Result;
            response.EnsureSuccessStatusCode();
        }

        _validatedName = name;
    }
}
```

EF will attempt to find a CLR property with the given name, or a field if a property isn't found. If neither a property nor a field is found, a shadow property will be set up instead.

You may need to refer to a field-only property from LINQ queries, but such fields are typically private. You can use `EF.Property(...)` method in a LINQ query to refer to the field.

```csharp
var authors = db.Authors.OrderBy(a => EF.Property<string>(a, "_validatedName"));
```
