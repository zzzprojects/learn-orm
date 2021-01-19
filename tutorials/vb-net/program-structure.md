---
PermaID: 100002
Name: Program Structure
---

# Program Structure

A Visual Basic program is built up from standard building blocks. A solution comprises one or more projects. 

 - A project in turn can contain one or more assemblies. 
 - Each assembly is compiled from one or more source files. 
 - A source file provides the definition and implementation of classes, structures, modules, and interfaces, which ultimately contain all your code.

## Programming Elements

When you create a project or file, you will see that some code is available in a particular order. Any code that you write should follow the following sequence.

 - Option statements
 - Imports statements
 - Namespace statements and namespace-level elements

If you enter statements in a different order you will get a compilation error.

A program can also contain conditional compilation statements. You can intersperse these in the source file among the statements of the preceding sequence.

### Option Statements

Option statements establish ground rules for subsequent code, helping prevent syntax and logic errors. 

 - The Option Explicit Statement ensures that all variables are declared and spelled correctly, which reduces debugging time. 
 - The Option Strict Statement helps to minimize logic errors and data loss that can occur when you work between variables of different data types. 
 - The Option Compare Statement specifies the way strings are compared to each other, based on either their `Binary` or `Text` values.

### Imports Statements

You can include an Imports Statement (.NET Namespace and Type) to import names defined outside your project. 

 - An Imports statement allows your code to refer to classes and other types defined within the imported namespace, without having to qualify them. 
 - You can use as many Imports statements as appropriate.

### Namespace Statements

 - Namespaces help you organize and classify your programming elements for ease of grouping and accessing. 
 - You use the `Namespace` statement to classify the following statements within a particular namespace. 

### Conditional Compilation Statements

Conditional compilation statements can appear almost anywhere in your source file. 

 - They cause parts of your code to be included or excluded at compile time depending on certain conditions. 
 - You can also use them for debugging your application because conditional code runs in debugging mode only.

## Namespace-Level Programming Elements

Classes, structures, and modules contain all the code in your source file. They are namespace-level elements, which can appear within a namespace or at the source file level. 

 - They hold the declarations of all other programming elements. 
 - Interfaces, which define element signatures but provide no implementation, also appear at the module level. For more information on the module-level elements, see the following:
 - Data elements at the namespace level are enumerations and delegates.

## Module-Level Programming Elements

Procedures, operators, properties, and events are the only programming elements that can hold executable code (statements that perform actions at run time). 

The following module-level elements of your program. 

 - Function Statement
 - Sub Statement
 - Declare Statement
 - Operator Statement
 - Property Statement
 - Event Statement

Data elements at the module level are variables, constants, enumerations, and delegates.

## Procedure-Level Programming Elements

Most of the contents of procedure-level elements are executable statements, which constitute the run-time code of your program. 

 - All executable code must be in some procedure (`Function`, `Sub`, `Operator`, `Get`, `Set`, `AddHandler`, `RemoveHandler`, `RaiseEvent`).
 - Data elements at the procedure level are limited to local variables and constants.

## The Main Procedure

The Main procedure is the first code to run when your application has been loaded. Main serves as the starting point and overall control for your application. 

There are four variations of the `Main`

```csharp
Sub Main()

Sub Main(ByVal cmdArgs() As String)

Function Main() As Integer

Function Main(ByVal cmdArgs() As String) As Integer
```

The most common variety of this procedure is `Sub Main()`.

## VB.Net Hello World Example

Let's have a look at a simple code that would print the string ***"Welcome to VB.NET Tutorial."***

```csharp
Imports System

Module Program
    'It will display a string on the console 
    Sub Main(args As String())
        Console.WriteLine("Welcome to VB.NET Tutorial.")
    End Sub
End Module
```

Let's discuss various parts of the above program.

 - The first line of the program `Imports System` is used to include the `System` namespace in the program.
 - The next line has a `Module` declaration, the module `Program`. 
 - VB.Net is completely object-oriented, so every program must contain a module of a class that contains the data and procedures that your program uses.
 - Classes or Modules generally would contain more than one procedure. 
 - Procedures contain the executable code, or in other words, they define the behavior of the class. 
 - The next line starts with `'` will be ignored by the compiler because it a comment.
 - The next line defines the `Main` procedure, which is the entry point for all VB.Net programs. 
 - The `Main` procedure states what the module or class will do when executed.
 - The `Console.WriteLine("Welcome to VB.NET Tutorial.")` in the `Main` procedure print the string on the screen.

