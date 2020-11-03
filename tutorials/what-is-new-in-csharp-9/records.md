---
PermaID: 100000
Name: Records
---

# Records

In C# 9.0, a new `record` type is introduced which is a reference type that provides synthesized methods to provide value semantics for equality.

 - It is largely classified as reference types including classes and anonymous types and value types including structs and tuples. 
 - Records cannot inherit from classes unless the class is an object, and classes cannot inherit from records, records can inherit from other records.
 - The `record` type immutable by default and make it easy to create immutable reference types in .NET. 
 - The immutable value types are recommended, mutable value types don't often introduce errors.

The `record` keyword makes an object immutable and behaves like a value type.

```csharp
public record Customer
{
    public string LastName { get; }
    public string FirstName { get; }

    public Customer(string first, string last) => (FirstName, LastName) = (first, last);
}
```

 - One of the key differences between regular classes and records is that records are intended to be immutable and their state never changes. 
 - Therefore, each record represents the state of an object at a specific point in time.
 - Whenever the object's state changes, it will create a copy of the record, updating the members that have changed, rather than changing the original record directly. 

You can also make the whole object immutable using the `init` keyword on each property if you are using an implicit parameterless constructor.

```csharp
public record Customer
{
    public string LastName { get; init; }
    public string FirstName { get; init; }
}
```

The important point about the record is that members are public by default. If you do not specify the `public` keyword then it won't affect anything and will behave similarly to the above declaration.

```csharp
public record Customer
{
    string LastName { get; init; }
    string FirstName { get; init; }
}
```

## Equality

By default, regular classes are considered equal when they share the same underlying reference. 

 - If you create two instances of the same class, holding the exact same values, they will not be considered equal.
 - When you declare your class as a record and compare two instances of the record it will not compare the object's references, records are compared by value. 
 - It means that two different objects holding the same values will be considered equal