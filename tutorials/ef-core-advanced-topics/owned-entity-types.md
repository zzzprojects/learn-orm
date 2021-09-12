---
PermaID: 100008
Name: Owned Entity Types
---

# Owned Entity Types

The owned entity was first introduced in EF Core 2.0, the same .NET type can be shared among different entities. Owned entities do not contain a key or identity property of their own, but would always be a navigational property of another entity.

 - EF Core allows you to model entity types that can only ever appear on the navigation properties of other entity types. 
 - The entity containing an owned entity type is its owner.
 - Owned entities are essentially a part of the owner and cannot exist without it, they are conceptually similar to aggregates. 
 - This means that the owned entity is by definition on the dependent side of the relationship with the owner.

## Configuration

By convention, EF Core never includes owned entity types in the model. You can annotate the type with the `[Owned]` attribute or use the `OwnsOne` method in `OnModelCreating` to configure the type as an owned type.

### Data Annotation

In the following example, `Address` is a type with no identity property. It is used as a property of the `Author` type to specify the address of a particular author.

```csharp
public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
}

[Owned]
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
}
```

Here `[Owned]` attribute is used to treat `Address` as an owned entity when referenced from another entity type.

### Fluent API

It is also possible to use the `OwnsOne` method in `OnModelCreating` to specify that the `Address` property is an `Owned` Entity of the `Author` entity type.

```csharp
modelBuilder.Entity<Order>().OwnsOne(p => p.Address);
```
If the `Address` property is private in the `Author` type, you can use the string version of the `OwnsOne` method:

```csharp
modelBuilder.Entity<Order>().OwnsOne(typeof(Address), "Address");
```

## Implicit Keys

Owned types configured with `OwnsOne` or discovered through reference navigation always have a one-to-one relationship with the owner, therefore they don't need their key values as the foreign key values are unique. 

 - In the above example, the `Address` type does not need to define a key property.
 - EF Core tracks these objects by creating a primary key as a shadow property for the owned type. 
 - The value of the key of an instance of the owned type will be the same as the value of the key of the owner instance.

## Collections of Owned Types

When owned types are defined through a collection, it isn't enough to just create a shadow property to act as both the foreign key into the owner and the primary key of the owned instance, because there can be multiple owned type instances for each owner.

You can use `OwnsMany` in `OnModelCreating` to configure a collection of owned types. Owned types need a primary key, if there are no good candidates properties on the .NET type, EF Core can try to create one. 

We have the two most straightforward solutions.

### Solution 1

 - Defining a surrogate primary key on a new property independent of the foreign key that points to the owner. 
 - The contained values would need to be unique across all owners (e.g. if Parent {1} has Child {1}, then Parent {2} cannot have Child {1}), so the value doesn't have any inherent meaning. 
 - Since the foreign key is not part of the primary key its values can be changed, so you could move a child from one parent to another one, however, this usually goes against aggregate semantics.

### Solution 2

 - Using the foreign key and an additional property as a composite key, the additional property value now only needs to be unique for a given parent (so if Parent {1} has Child {1,1} then Parent {2} can still have Child {2,1}). 
 - By default, EF Core makes the foreign key part of the primary key the relationship between the owner and the owned entity becomes immutable and reflects aggregate semantics better.

In this example, we will use the `Distributor` class.

```csharp
public class Distributor
{
    public int Id { get; set; }
    public ICollection<Address> ShippingCenters { get; set; }
}
```
    
By default, the primary key used for the owned type referenced through the `ShippingCenters` navigation property will be ("DistributorId", "Id") where `DistributorId` is the FK and `Id` is a unique `int` value.

To configure a different primary key, you can call `HasKey`.

```csharp
modelBuilder.Entity<Distributor>().OwnsMany(p => p.ShippingCenters, a =>
{
    a.WithOwner().HasForeignKey("OwnerId");
    a.Property<int>("Id");
    a.HasKey("Id");
});
```