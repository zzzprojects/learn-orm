---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Dapper.SimpleSave** is a small NuGet library that extends the `IDbConnection` interface which adds the basic CRUD operations to Dapper. 

 - Dapper easily retrieve data from the database when a single object is involved, but when you are dealing with complex hierarchies, then dapper is not very helpfull.
 - **Dapper.SimpleSave** makes it easy to save complex object hierarchies to a relational database.

The following is the list of extension methods that are provided in **Dapper.SimpleSave**.

| Method                | Description                                                 |
| :---------------------| :-----------------------------------------------------------|
| Create                | Insert a single record                                      |
| CreateAll             | Insert a list of records                                    |
| Update                | Update a single record                                      |
| UpdateAll             | Update a list of records                                    |
| Delete                | Delete a record based on primary key or typed entity        |
| DeleteAll             | Delete a list of records based on the typed entities        |
| SoftDelete            | Soft delete a record based on primary key or typed entity        |
| SoftDeleteAll         | Soft delete a list of records based on the typed entities        |  

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package Dapper.SimpleSave
```

## Limitations

The following are the currently known limitations.

 - Convention based mapping are not supported, and you will need to decorate your domain classes with attributes.
 - Only `int`, `long`, and `GUID` primary keys are supported.
 - In all your domain classes, a primary key property should be marked with a [PrimaryKey] attribute.