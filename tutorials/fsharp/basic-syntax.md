---
PermaID: 100004
Name: Basic Syntax
---

# Basic Syntax

F# is the latest addition to the Microsoft Visual Studio language family. There are many exciting reasons to learn F# such as, clean syntax, powerful multi-threading capabilities and its interoperability with other Microsoft .NET Framework languages. 

 - F# is not designed to be an academic language, its syntax allows you to use functional techniques to solve problems in new and better ways while still supporting the object-oriented and imperative styles that you are accustomed to as a .NET developer.
 - Unlike other .NET languages, F#'s multi-paradigm structure allows you to choose the best style of programming for the problem that you are trying to solve. 
 - Functional programming in F# is about writing concise, powerful code to solve practical software problems. 
 - It is about using techniques like higher order functions and function composition to create powerful and easy to understand behaviors. 
 - It is also about making your code easier to understand, test and parallelize by removing hidden complexities.

## F# vs C-Style Languages 

The two major differences between F# syntax and a standard C-like syntax are:

 - Curly braces are not used to delimit blocks of code, instead, indentation is used.
 - Whitespace is used to separate parameters rather than commas.

Some developers think that the F# syntax is very clear and straightforward when you get used to it and in many ways, it is simpler than the C# syntax, with fewer keywords and special cases.

Let's consider the following lines of code.

```csharp
let myInt = 5
let myFloat = 3.14
let myString = "hello"
```

The `let` keyword defines an immutable value. The `let` keyword also defines a named function as shown below.

```csharp
let square a = a * a
square 5
```

## Comments in F#

F# provides two types of comments.

 - One line comment starts with `//` symbol.
 - Multi line comment starts with `(*` and ends with `*)`.

The following example shows a single line and multi-line comments

```csharp
open System

// It is a single line comment
let message = "Welcome to F# Tutorial."

(* This is a comment line
another comment line
Sample program using F# *)

[<EntryPoint>]
let main argv =
    Console.WriteLine(message)
    0 // return an integer exit code

```
