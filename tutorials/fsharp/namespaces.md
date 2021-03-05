---
PermaID: 100044
Name: Namespaces
---

# Namespaces

A namespace lets you organize code into areas of related functionality by enabling you to attach a name to a grouping of F# program elements. 

 - A namespace is a hierarchical categorization of modules, classes, and other namespaces.
 - Namespaces cannot directly contain values and functions. 
 - Instead, values and functions must be included in modules, and modules are included in namespaces. 
 - Namespaces can be declared explicitly with the namespace keyword, or implicitly when declaring a module. To declare a namespace explicitly, use the namespace keyword followed by the namespace name.

The basic syntax of the namespace is as follows.

```csharp
namespace [rec] [parent-namespaces.]identifier
```

The following example shows a code file that declares a namespace `Calculator` containing two modules.

```csharp
namespace Calculator

module Arthimetic =
    let Add a b = a+b  
    let Subtract a b = a-b  
    let Multiply a b = a*b  
    let Division a b = a/b   

module test = 
    System.Console.WriteLine(Arthimetic.Add 8 2)
    System.Console.WriteLine(Arthimetic.Subtract 8 2)
    System.Console.WriteLine(Arthimetic.Multiply 8 2)
    System.Console.WriteLine(Arthimetic.Division 8 2)
```

If the entire contents of the file are in one module, you can also declare namespaces implicitly by using the `module` keyword and providing the new namespace name as the fully qualified module name. 

The following example shows a code file that declares a namespace `Calculator` and a module `Arthimetic`, which contains a function.

```csharp
module Calculator.Arithmetic 

let Add a b = a+b  
let Subtract a b = a-b  
let Multiply a b = a*b  
let Division a b = a/b 
```

The above example is equivalent to the following code.

```csharp
namespace Calculator

module Arithmetic =
    let Add a b = a+b  
    let Subtract a b = a-b  
    let Multiply a b = a*b  
    let Division a b = a/b   
```

## Nested Namespaces

When you create a nested namespace, you must fully qualify it. Otherwise, you create a new top-level namespace. Indentation is ignored in namespace declarations.

The following example shows how to declare a nested namespace.

```csharp
namespace Outer

    // Full name: Outer.A
    type A() =
       member this.X(x) = x + 1

// Fully qualify any nested namespaces.
namespace Outer.Inner

    // Full name: Outer.Inner.B
    type B() =
       member this.Y = "y"
```

