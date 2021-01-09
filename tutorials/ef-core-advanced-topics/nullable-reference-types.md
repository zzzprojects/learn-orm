---
PermaID: 100002
Name: Nullable Reference Types
---

# Nullable Reference Types

C# 8 introduced a new feature called nullable reference types, allowing reference types to be annotated, indicating whether it is valid for them to contain null or not. 

## Required and optional properties

A property is considered optional if it is valid for it to contain null. If null is not a valid value to be assigned to a property then it is considered to be a required property. When mapping to a relational database schema, the required properties are created as non-nullable columns, and optional properties are created as nullable columns.

 - By convention, a property whose .NET type can contain null will be configured as optional, whereas properties whose .NET type cannot contain null will be configured as required. 
 - For example, all properties with .NET value types (`int`, `decimal`, `bool`, etc.) are configured as required, and all properties with nullable .NET value types (`int?`, `decimal?`, `bool?`, etc.) are configured as optional.

This feature is disabled by default, and if enabled, it modifies EF Core's behavior in the following way:

 - If nullable reference types are disabled (the default), all properties with .NET reference types are configured as optional by convention (for example, string).
 - If nullable reference types are enabled, properties will be configured based on the C# nullability of their .NET type: string? will be configured as optional, but the string will be configured as required.

The following example shows an entity type with required and optional properties, with the nullable reference feature disabled (the default).

 ```csharp
 public class AuthorWithoutNullableReferenceTypes
 {
     public int Id { get; set; }
     [Required]                               // Data annotations needed to configure as required
     public string FirstName { get; set; }
     [Required]
     public string LastName { get; set; }     // Data annotations needed to configure as required
     public string MiddleName { get; set; }   // Optional by convention
 }
 ```

The following example shows an entity type with required and optional properties, with the nullable reference feature enabled.

 ```csharp
 public class Author
 {
     public int Id { get; set; }
     public string FirstName { get; set; }    // Required by convention
     public string LastName { get; set; }     // Required by convention
     public string? MiddleName { get; set; }  // Optional by convention
 
     public Author(string firstName, string lastName, string? middleName = null)
     {
         FirstName = firstName;
         LastName = lastName;
         MiddleName = middleName;
     }
 }
 ```

Using nullable reference types is recommended since it flows the nullability expressed in C# code to EF Core's model and the database, and remove the use of the Fluent API or Data Annotations to express the same concept twice.

## DbContext and DbSet

When nullable reference types are enabled, the C# compiler emits warnings for any uninitialized non-nullable property, as these would contain null. As a result, the common practice of having uninitialized DbSet properties on a context type will now generate a warning. To fix this, make your DbSet properties read-only and initialize them as follows:

```csharp
public class NullableReferenceTypesContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
}
```

## Non-nullable properties and initialization

Compiler warnings for uninitialized non-nullable reference types are also a problem for regular properties on your entity types. 

 - We avoided these warnings by using constructor binding, a feature that works perfectly with non-nullable properties, ensuring they are always initialized. 
 - However, in some scenarios constructor binding isn't an option, for example, navigation properties cannot be initialized in this way.
 - Required navigation properties present an additional difficulty, although a dependent will always exist for a given principal, it may or may not be loaded by a particular query, depending on the needs at that point in the program. 
 - At the same time, it is undesirable to make these properties nullable, since that would force all access to them to check for null, even if they are required.

One way to deal with these scenarios is to have a non-nullable property with a nullable backing field.

```csharp
private Address? _address;

public Address Address
{
    set => _address = value;
    get => _address ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Address));
}
```

 - The navigation property is non-nullable, required navigation is configured and as long as the navigation is properly loaded, the dependent will be accessible via the property. 
 - If, however, the property is accessed without first properly loading the related entity, an `InvalidOperationException`. 
 - EF must be configured to always access the backing field and not the property, as it relies on being able to read the value even when unset.

As a terser alternative, it is possible to simply initialize the property to null with the help of the null-forgiving operator (!):

```csharp
public Address Address { get; set; } = null!;
```

## Navigating and including nullable relationships

When dealing with optional relationships, it's possible to encounter compiler warnings where an actual null reference exception would be impossible. 

 - When translating and executing your LINQ queries, EF Core guarantees that if an optional related entity does not exist, any navigation to it will simply be ignored, rather than throwing. 
 - However, the compiler is unaware of this EF Core guarantee and produces warnings as if the LINQ query were executed in memory, with LINQ to Objects. 
 - As a result, it is necessary to use the null-forgiving operator (!) to inform the compiler that an actual null value isn't possible.

 ```cdsharp
 Console.WriteLine(author.OptionalInfo!.ExtraAdditionalInfo!.SomeExtraAdditionalInfo);
 ```
A similar issue occurs when including multiple levels of relationships across optional navigations.

 ```cdsharp
 var author = context.Authors
    .Include(o => o.OptionalInfo!)
        .ThenInclude(op => op.ExtraAdditionalInfo)
    .FirstOrDefault();
 ```
 
 - If you find yourself doing this a lot, and the entity types in question are predominantly (or exclusively) used in EF Core queries, consider making the navigation properties non-nullable, and to configure them as optional via the Fluent API or Data Annotations. 
 - This will remove all compiler warnings while keeping the relationship optional; however, if your entities are traversed outside of EF Core, you may observe null values although the properties are annotated as non-nullable.