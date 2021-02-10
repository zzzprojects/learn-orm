---
PermaID: 1000011
Name: SQLite Limitations
---

# SQLite Limitations

The SQLite provider has several migration limitations and most of these limitations are a result of limitations in the underlying SQLite database engine and are not specific to EF.

## Modeling Limitations

The common relational library (shared by Entity Framework relational database providers) defines APIs for modeling concepts that are common to most relational database engines. A couple of these concepts are not supported by the SQLite provider.

 - Schemas
 - Sequences

## Query Limitations

SQLite doesn't natively support the following data types. EF Core can read and write values of these types, and querying for equality (`where e.Property == value`) is also supported. Other operations, however, like comparison and ordering will require evaluation on the client.

 - DateTimeOffset
 - Decimal
 - TimeSpan
 - UInt64

Instead of `DateTimeOffset`, it is recommended to use `DateTime` values. 

 - When handling multiple time zones, It is recommended to convert the values to UTC before saving and then converting back to the appropriate time zone.
 - The `Decimal` type provides a high level of precision. If you don't need that level of precision, however, it is recommended to use `double` instead. 
 - You can use a value converter to continue using decimal in your classes.

```csharp
modelBuilder.Entity<MyEntity>()
    .Property(e => e.DecimalProperty)
    .HasConversion<double>();
```

## Migrations limitations

The SQLite database engine does not support many schema operations that are supported by the majority of other relational databases. 

 - If you attempt to apply one of the unsupported operations to an SQLite database then a `NotSupportedException` will be thrown.
 - A rebuild will be attempted to perform certain operations.
 - The SQLite provider does not support schemas and Sequences.

The SQLite database engine does not support the following schema operations that are supported by the majority of other relational databases.

 - AddCheckConstraint
 - AddForeignKey
 - AddPrimaryKey
 - AddUniqueConstraint
 - AlterColumn
 - DropCheckConstraint
 - DropColumn
 - DropForeignKey
 - DropPrimaryKey
 - DropUniqueConstraint
 - RenameIndex
 - EnsureSchema
 - DropSchema

Rebuilds are only possible for database artifacts that are part of your EF Core model.

## Migrations Limitations Workaround

You can work around some of these limitations by manually writing code in your migrations to perform a rebuild. 

 - Table rebuilds involve creating a new table, copying data to the new table, dropping the old table, renaming the new table. 
 - You will need to use the Sql(string) method to perform some of these steps.

