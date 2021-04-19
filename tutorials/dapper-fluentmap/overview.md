---
PermaID: 100000
Name: Overview
---

# Overview

**Dapper.FluentMap** is a small NuGet library that is a nice Dapper extension that takes care of mapping configuration, also offering a lot of customization options.

 - It allows you to fluently configure the mapping between your class properties and database columns. 
 - It keeps your classes clean of mapping attributes, and this functionality is similar to Entity Framework Fluent API.

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package Dapper.FluentMap
```

## APIs

There are two types of mapping supported in **Dapper.FluentMap**

 - Manual mapping
 - Convention based mapping
