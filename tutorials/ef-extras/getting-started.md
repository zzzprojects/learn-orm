---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**EntityFrameworkExtras.EFCore** is a NuGet library that provides some useful additions to Entity Framework such as executing Stored Procedures with User-Defined Table Types and Output Parameters.

 - Many times you need to pass a group of records in stored procedure using user-defined table type. 
 - But Entity framework does not support user-defined type by default. 
 - This library supports user-defined type in entity framework.

## User Defined Types

 - The User-Defined Table Types (UDTTs) and Table-Valued Parameters (TVPs) were first introduced in SQL Server 2008.
 - Before SQL Server 2008, it was not possible to pass a table variable in a stored procedure as a parameter.
 - Now we can pass a Table-Valued Parameter to send multiple rows of data to a stored procedure or a function without creating a temporary table or passing so many parameters.

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package Audit.EntityFramework.Core
```
