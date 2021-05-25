---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Dynamic Expresso** is an interpreter for simple C# statements written in .NET Standard 2.0. 

 - It embeds its parsing logic, interprets C# statements by converting them to .NET lambda expressions or delegates.
 - It allows you to create scriptable applications, execute .NET code without compilation or create dynamic LINQ statements.
 - Global variables or parameters can be injected and used inside expressions. It doesn't generate assembly but it creates an expression tree on the fly.

## Features

 - Expressions can be written using a subset of C# syntax
 - Support for variables and parameters
 - Can generate delegates or lambda expression
 - Good performance compared to other similar projects
 - Partial support of generic, params array, and extension methods
 - Partial support of `ExpandoObject` forget properties, method invocation, and indexes
 - Case insensitive expressions
 - Ability to discover identifiers such as variables, types, parameters of a given expression
 - Small footprint, generated expressions are managed classes, can be unloaded, and can be executed in a single app domain
 - Easy to use and deploy, it is all contained in a single assembly without other external dependencies

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package DynamicExpresso.Core
```
