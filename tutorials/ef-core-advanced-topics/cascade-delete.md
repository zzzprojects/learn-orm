---
PermaID: 100014
Name: Cascade Delete
---

# Cascade Delete

Cascade delete allows the deletion of a row to trigger the deletion of related rows automatically. 

 - EF Core covers a closely related concept and implements several different delete behaviors and allows for the configuration of the delete behaviors of individual relationships. 
 - In Entity Framework Core, the `OnDelete` Fluent API method is used to specify the delete behavior for a dependent entity when the principal is deleted.

The `OnDelete` method takes a `DeleteBehavior` enum as a parameter.

 - **Cascade:** Child/dependent entity should be deleted.
 - **Restrict:** Dependents are unaffected.
 - **SetNull:** The foreign key values in dependent rows should update to `NULL`.

Setting a foreign key value to null is not valid if the foreign key is not nullable. The following example set a foreign key field to null when the principal is deleted.

```csharp
using (var context = new EntityContext())
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
```

The following example configures the relationship as required and specifies that dependant rows are deleted when the principal is deleted.

```csharp
using (var context = new EntityContext())
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
```

## Delete Behaviors

There are four delete behaviors. 

### Optional Relationships (nullable foreign key)

It is possible to save a null foreign key value, which results in the following effects.

|Behavior Name    |Effect on dependent/child in memory    |Effect on dependent/child in database |
|:--------------- |:------------------------------------- |:------------------------------------ |
|Cascade          |Entities are deleted                   |Entities are deleted                  |
|ClientSetNull (Default)      |Foreign key properties are set to null| None                      |
|SetNull          |Foreign key properties are set to null |Foreign key properties are set to null|
|Restrict         |None                                   |None                                  |

### Required Relationships (non-nullable foreign key) 

It is not possible to save a null foreign key value, which results in the following effects.

|Behavior Name    |Effect on dependent/child in memory    |Effect on dependent/child in database |
|:--------------- |:------------------------------------- |:------------------------------------ |
|Cascade (Default)|Entities are deleted                   |Entities are deleted                  |
|ClientSetNull    |SaveChanges throws                     |None                                  |
|SetNull          |SaveChanges throws                     |SaveChanges throws                    |
|Restrict         |None                                   |None                                  |

## Usage

### Cascade

 - The `Cascade` option is used when you have entities that cannot exist without a parent, and you want EF to take care of deleting the children automatically.
 - It is the default option for entities that cannot exist without a parent usually make use of required relationships.

### ClientSetNull

 - The `ClientSetNull` is used when you have entities that may or may not have a parent, and you want EF to take care of nulling out the foreign key for you. 
 - It is the default option for entities that can exist without a parent usually make use of optional relationships.

### SetNull 

 - The `SetNull` option is used when you want the database to also try to propagate `null` values to child foreign keys even when the child entity is not loaded. 
 - However, note that the database must support this, and configuring the database like this can result in other restrictions, which in practice often makes this option impractical. This is why `SetNull` is not the default.

### Restrict

 - The `Restrict` option is used when you don't want EF Core to ever delete an entity automatically or null out the foreign key automatically. 
 - It requires that your code keep child entities and their foreign key values in sync manually, otherwise constraint exceptions will be thrown.