---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Dapper.Contrib** is a NuGet library that extends the `IDbConnection` interface. It adds some generic utility methods to the Dapper and particularly CRUD operations become much simpler with **Dapper.Contrib**.

 - It is one of the most popular add-on libraries for enhancing Dapper. 
 - It provides methods that enable you to write less code for the basic CRUD operations. 
 - It also enables you to perform CRUD operations without writing SQL explicitly.

The following is the list of extension methods that are provided in **Dapper.Contrib**.

```csharp
T Get<T>(id);
IEnumerable<T> GetAll<T>();
int Insert<T>(T obj);
int Insert<T>(Enumerable<T> list);
bool Update<T>(T obj);
bool Update<T>(Enumerable<T> list);
bool Delete<T>(T obj);
bool Delete<T>(Enumerable<T> list);
bool DeleteAll<T>();
```

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package Dapper.Contrib
```
