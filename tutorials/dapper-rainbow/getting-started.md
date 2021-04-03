---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Dapper.Rainbow** is a small NuGet library that offers an abstract class that you may use as a base class on your Dapper classes. 

 - It provides CRUD operations, such as inserting, deleting, updating, and getting records.
 - It is a wrapper for database interactions and could create SQL primarily based totally on property names and type constraints.

**Dapper.Rainbow** provides the following strategies which make it smooth to apply for any database operations.

 - Get
 - Insert
 - Update
 - Delete
 - All


## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package Dapper.Rainbow
```

## Limitations

 - Composite key mapping is not supported.
 - Identity column name for all tables must be called Id.
