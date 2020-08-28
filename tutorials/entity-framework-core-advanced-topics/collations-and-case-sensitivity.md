---
PermaID: 110003
Name: Collations and Case Sensitivity
---

# Collations and Case Sensitivity

A collation and case sensitivity are introduced in EF Core 5.0 which is a set of rules determining how text values are ordered and compared for equality. For example, while a case-insensitive collation disregards differences between upper and lower-case letters for equality comparison, a case-sensitive collation does not. 

 - Case-sensitivity is culture-sensitive, e.g. i and I represent a different letter in Turkish, there exist multiple case-insensitive collations, each with its own set of rules. 
 - The scope of collations also extends beyond case-sensitivity, to other aspects of character data, for example, in German, it is sometimes (but not always) desirable to treat ä and ae as identical. 
 - Collations also define how text values are ordered, for example, German places ä after a, while Swedish places it at the end of the alphabet. 
 - All text operations in a database use a collation whether explicitly or implicitly to determine how the operation compares and orders strings. 

## Database Collation

The collations naming schemes are database-specific, but the database does generally allow a default collation to be defined at the database or column level, and to explicitly specify which collation should be used for specific operations in a query.

 - In most database systems, a default collation is defined at the database level; unless overridden that collation implicitly applies to all text operations occurring within that database. 
 - The database collation is typically set at database creation time, and if not specified, defaults to some server-level value determined at setup time. For example, the default server-level collation in SQL Server is `SQL_Latin1_General_CP1_CI_AS`, which is a case-insensitive, accent-sensitive collation. 
 - Although database systems usually do permit altering the collation of an existing database, which can lead to complications; it is recommended to pick a collation before database creation.

When using EF Core migrations to manage your database schema, the following in your model's OnModelCreating method configures an SQL Server database to use a case-sensitive collation.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
}
```

## Column collation

Collations can also be defined on text columns, overriding the database default. This can be useful if certain columns need to be case-insensitive, while the rest of the database needs to be case-sensitive.

The following code configures the column for the `Name` property to be case-insensitive in a database that is otherwise configured to be case-sensitive.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

    modelBuilder.Entity<Author>().Property(a => a.Name)
        .UseCollation("SQL_Latin1_General_CP1_CI_AS");
}
```

## Explicit collation in a query

In some cases, the same column needs to be queried using different collations by different queries. For example, one query may need to perform a case-sensitive comparison on a column, while another may need to perform a case-insensitive comparison on the same column. This can be accomplished by explicitly specifying a collation within the query itself.

```csharp
var authors = context.Authors
    .Where(c => EF.Functions.Collate(c.Name, "SQL_Latin1_General_CP1_CS_AS") == "John")
    .ToList();
```
It generates a `COLLATE` clause in the SQL query, which applies a case-sensitive collation regardless of the collation defined at the column or database level:

```csharp
SELECT [c].[Id], [c].[Name]
FROM [Authors] AS [c]
WHERE [c].[Name] COLLATE SQL_Latin1_General_CP1_CS_AS = N'John'
```
