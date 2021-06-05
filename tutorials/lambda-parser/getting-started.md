---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**LambdaParser** is a NuGet library that works as a runtime parser for string expressions.

 - It builds a dynamic LINQ expression tree and compiles it to the lambda delegate. 
 - Types are resolved at run-time just like in dynamic languages.
 - It supports parsing of formulas, method calls, properties, fields, arrays accessors, etc.
 
## Features

 - It is a PCL (Portable) library and you can use it with any .NET target such as .NET Framework, and .NET Standards 1.3 (.NET Core apps).
 - You can define any number of variables using a dictionary or by callback delegate.
 - It supports various kinds of operators including arithmetic operations (`+`, `-`, `*`, `/`, `%`), comparisons (`==`, `!=`, `>`, `<`, `>=`, `<=`), conditionals including (ternary) operator ( `?:` ), etc.
 - You can access object properties, call methods and indexers, invoke delegates.
 - It also supports dynamically typed variables that can perform automatic type conversions to match method signature or arithmetic operations
 - You can easily create arrays and dictionaries with simplified syntax: new dictionary{ {"a", 1}, {"b", 2} } , new []{ 1, 2, 3}

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package NReco.LambdaParser
```

