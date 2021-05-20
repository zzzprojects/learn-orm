---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**Flee** stands for Fast Lightweight Expression Evaluator. It is a lightweight NuGet library that works as an expression parser and evaluator for the .NET framework. 

 - It allows you to compute the value of string expressions at runtime. 
 - It uses a custom compiler, strongly-typed expression language, and lightweight codegen to compile expressions directly to IL. 
 - This means that expression evaluation is extremely fast and efficient.

## Features

 - Fast and efficient expression evaluation
 - Small, lightweight library
 - Compiles expressions to IL using a custom compiler, lightweight codegen, and the `DynamicMethod` class
 - Expressions and the IL generated for expressions are garbage-collected when no longer used
 - Does not create any dynamic assemblies that stay in memory
 - Backed by a comprehensive suite of unit tests
 - Culture-sensitive decimal point
 - Fine-grained control of what types an expression can use
 - Supports all arithmetic operations including the power (^) operator
 - Supports string, char, boolean, and floating-point literals
 - Supports 32/64 bit, signed/unsigned, and hex integer literals
 - Features a true conditional operator
 - Supports short-circuited logical operations
 - Supports arithmetic, comparison, implicit, and explicit overloaded operators
 - Variables of any type can be dynamically defined and used in expressions
 - CalculationEngine: Reference other expressions in an expression and recalculate in natural order
 - Expressions can index arrays and collections, access fields and properties, and call functions on various types
 - Generated IL can be saved to an assembly and viewed with a disassembler

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package Flee
```
