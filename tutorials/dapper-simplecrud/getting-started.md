---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Dapper.SimpleCRUD** is a small NuGet library that extends the `IDbConnection` interface which adds the basic CRUD operations to Dapper. It adds some generic utility methods to Dapper, and particularly CRUD operations become much simpler with **Dapper.SimpleCRUD**.

 - It uses smart defaults without using attributes is your classes, but you can also overrides the defaults as per your requirements. 
 - By default, the `Id` property is used as a primary key, but you can use other property as a primary key by specifying an attribute.
 - By default, the table name is matching the class name, but you can use another table name by specifying an attribute.
 - Similarly, by default, the column name is matching the property name, but you can use another column name by specifying an attribute.

The following is the list of extension methods that are provided in **Dapper.SimpleCRUD**.

| Method                | Description                                                 |
| :---------------------| :-----------------------------------------------------------|
| Get                   | Get a record based on the primary key                       |
| GetList               | Get a list of records from a table                          |
| GetListPaged          | Get a paged list of all records matching the conditions     |
| Insert                | Insert a record and returns the new primary key             |
| Update                | Update a record                                             |
| Delete                | Delete a record based on primary key or typed entity        |
| DeleteList            | Delete all records matching the conditions                  |
| RecordCount           | Get count of all records matching the conditions            |  

For projects targeting .NET 4.5 or later, you can also use the async versions of all the above methods.

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package Dapper.SimpleCRUD
```
