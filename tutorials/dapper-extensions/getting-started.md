---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Dapper Extensions** is a small NuGet library that extends the `IDbConnection` for **Dapper** by adding basic CRUD operations (Get, Insert, Update, Delete) for your domain classes. 

 - **Dapper Extensions** provides a predicate system for more advanced querying scenarios. 
 - This library aims to keep your classes pure by not requiring any attributes or base class inheritance.

The following is the list of extension methods that are provided in **Dapper Extensions**.

| Method                | Description                                                 |
| :---------------------| :-----------------------------------------------------------|
| Get                   | Retrieve a record based on the primary key.                 |
| GetList               | Retrieve a list of records from a table.                    |
| Insert                | Inserts a row into the database.                            |
| Update                | Update a record in the database.                            |
| Delete                | Delete a record based on primary key                        |
| Count                 | Counts all the records in a table or a range of records if a conditional clause was set up in the statement options.   |  

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package DapperExtensions
```

## Features

 - There is no need for any configuration out of the box.
 - Automatic mapping of POCOs for `Get`, `Insert`, `Update`, and `Delete` operations.
 - For more advanced scenarios, it also provides `GetList` and `Count` methods.
 - You can use the `GetPage` method for returning paged result sets.
 - Guid and Integer primary keys are supported automatically, and you can include support for other key types manually.
 - You can customize the entity-table mapping using `ClassMapper`.
 - It also has support for the composite primary key.
 - By default, a singular table name is supported, but you can also use the pluralized table name.
 - For more advanced scenarios, it also provides the Predicate System.
