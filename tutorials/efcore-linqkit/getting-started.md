---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**LinqKit.Microsoft.EntityFrameworkCore** is a NuGet library that contains extensions for LINQ to SQL and EntityFrameworkCore.

## Features

 - It contains an extensible implementation of `AsExpandable()`.
 - Provides an `ExpressionVisitor` class which is a public expression visitor base class.
 - It also provides a `PredicateBuilder` class which helps you create a predicate. 
 - You can use the `Linq.Expr` and `Linq.Func` shortcut methods.
 - You can easily plug an expression into `EntitySets` and `EntityCollections`.
 - It allows you to use expression variables in subqueries.
 - It also allows you to combine expressions like calling one expression from another expression.
 - You can also build predicates dynamically. 
 - You can also leverage `AsExpandable` to add your extensions.

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package LinqKit.Microsoft.EntityFrameworkCore
```
