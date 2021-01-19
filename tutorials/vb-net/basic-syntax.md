---
PermaID: 100003
Name: Basic Syntax
---

# Basic Syntax

Visual Basic has a very simple programming syntax. The language is not case-sensitive and it is easy even for beginners to start coding.

 - It is an object-oriented programming language and is based on .NET Framework.
 - It is more easy, simple, and powerful than C or C++, and we also don't need to add semicolons after each statement. 

VB.Net program is defined as a collection of objects that communicate via invoking each other's methods. 

 - **Object:** Objects have states and behaviors. Example: A dog has states - color, name, breed as well as behaviors - wagging, barking, eating, etc. An object is an instance of a class.
 - **Class:** A class can be defined as a template/blueprint that describes the behaviors/states that objects of its type support.
 - **Methods:** A method is behavior and a class can contain many methods. It is in methods where the logic is written, data is manipulated and all the actions are executed.
 - **Instance Variables:** Each object has its unique set of instance variables. An object's state is created by the values assigned to these instance variables.

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

## Method syntax

The `Sub Main` indicates the entry point of the VB.Net program.

```csharp
Sub Main(args As String())
    Console.WriteLine("Welcome to VB.NET Tutorial.")
End Sub
```

The following procedure activates the second window in the active document.

```csharp
Sub MakeActive() 
    Windows(2).Activate 
End Sub
```

## Comments

In VB.NET, single-line comments start with an apostrophe (`'`). 
 
 - There are no block comments in VB.NET.
 - XML comments start with three apostrophes that are useful for documentation purposes.

## Option Compare Statement


In the Option Compare statement syntax, the braces and vertical bar indicate a mandatory choice between three items. 

```csharp
Option Compare { Binary | Text | Database }
```

The following statement specifies that within the module, strings will be compared in a sort order that is not case-sensitive.

```csharp
Option Compare Text
```

## Dim Statement syntax

In the Dim statement syntax, the word `Dim` is a required keyword. The only required element is `varname` (the variable name).

The following statement creates three variables, `myVar1`, `myVar2`, and `myVar3`. 

```csharp
Dim myVar1, myVar2, myVar3 
```

These are automatically declared as **Variant** variables.

The following example declares a variable as a `String`.

```csharp
Dim myStr As String 
```

To declare several variables in one statement, include the data type for each variable.

```csharp
Dim x As Integer, y As Integer, z As Integer 
```
Variables declared without a data type are automatically declared as **Variant**.

In the following statement, `x` and `y` are assigned the **Variant** data type. Only `z` is assigned the `Integer` data type.

```csharp
Dim x, y, z As Integer
```
