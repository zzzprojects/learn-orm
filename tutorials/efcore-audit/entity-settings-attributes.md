---
PermaID: 100005
Name: Entity Settings Attributes
---

# Entity Settings Attributes

You can configure the following settings per entity type.

## Ignore Entities

You can ignore specific entities on the audit by decorating your entity classes with the `AuditIgnore` attribute as shown below.

```csharp
[AuditIgnore]
public class AuthorDetail
{
    public int AuthorDetailId { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }
}
```

## Include Entities

You can include specific entities in the audit by using the `AuditInclude` attribute.

```csharp
[AuditInclude]
public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
```

## Exclude Properties

You can ignore any specific property to indicate that its value should not be included on the audit logs by using the `AuditIgnore` attribute. 

```csharp
public class User
{
    public int Id { get; set; }
    [AuditIgnore]
    public string Password { get; set; }
    ...
}
```

## Override Properties

You can override a column value with a constant value by using the `AuditOverride` attribute. The following code overrides the password values with a `NULL` value.

```csharp
public class User
{
    [AuditOverride(null)]
    public string Password { get; set; }
    ...
}
```
