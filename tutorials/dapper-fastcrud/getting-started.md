---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Dapper.FastCrud** is a small NuGet library that extends the `IDbConnection` for Dapper and is based on C# 6 and VB 14 essential features that have finally raised the simplicity of raw SQL constructs to acceptable maintenance levels.

The following is the list of extension methods that are provided in **Dapper.FastCrud**.

| Method                | Description                                                 |
| :---------------------| :-----------------------------------------------------------|
| Get                   | Retrieve a record based on the primary key.                 |
| Find                  | Retrieve a list of records from a table.                    |
| Insert                | Inserts a row into the database.                            |
| Update                | Update a record in the database.                            |
| BulkUpdate            | Updates a list of records in the database.                |
| Delete                | Delete a record based on primary key                        |
| BulkDelete            | Deletes all the records in the table or a range of records if a conditional clause was set up in the statement options.|
| Count                 | Counts all the records in a table or a range of records if a conditional clause was set up in the statement options.   |  

For projects targeting .NET 4.5 or later, you can also use the async versions of all the above methods.

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package Dapper.FastCrud
```

## Features

 - It supports LocalDb, MS SQL Server, MySql, SQLite, PostgreSQL
 - Composite primary keys are supported.
 - Multiple entity mappings that are useful for partial queries in large denormalized tables and data migrations between different database types.
 - It also accepts a transaction, a command timeout, and a custom entity mapping in all the CRUD methods.
 - It computes entity queries very fast.
 - It is also compatible with component model data annotations.
 - A useful SQL builder and statement formatter are provided which you can use even if you don't need the CRUD features of this library.
 - A generic T4 template for C# is also provided for convenience in the NuGet package `Dapper.FastCrud.ModelGenerator`. 
 - Code first entities are also supported which can either be decorated with attributes, have their mappings programmatically set, or using your custom convention.

