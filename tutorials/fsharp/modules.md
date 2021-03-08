---
PermaID: 100043
Name: Modules
---

# Modules

In F#, a module is a grouping of F# code, such as values, types, and function values. Grouping code in modules helps keep related code together and helps avoid name conflicts in your program.

 - It is implemented as a common language runtime (CLR) class that has only static members.
 - No code is required to define a module.  
 - If a code file does not contain a leading namespace or module declaration, F# code will implicitly place the code in a module, where the name of the module is the same as the file name with the first letter capitalized.
 - To access code in another module use `.` notation.

The basic syntax to define a module is as follows.

```csharp
// Top-level module declaration.
module [accessibility-modifier] [qualified-namespace.]module-name
    declarations

// Local module declaration.
module [accessibility-modifier] module-name =
    declarations
```

There are two types of module declarations, depending on whether the whole file is included in the module: 

 - A top-level module declaration and a local module declaration. 
 - A top-level module declaration includes the whole file in the module. 
 - A top-level module declaration can appear only as of the first declaration in a file.

The following code example shows a top-level module that contains all the code up to the end of the file.

```csharp
module Calculator =   
    let Add a b = a+b  
    let Subtract a b = a-b  
    let Multiply a b = a*b  
    let Division a b = a/b  
```

To use this code from another file in the same project, you either use qualified names or open the module before using the functions, as shown in the following examples.

```csharp
module test = 
    Console.WriteLine(Calculator.Add 8 2)
    Console.WriteLine(Calculator.Subtract 8 2)
    Console.WriteLine(Calculator.Multiply 8 2)
    Console.WriteLine(Calculator.Division 8 2)
```

## Nested Modules

You can nest modules, inner modules must be indented as far as outer module declarations to indicate that they are inner modules, not new modules. 

The following example shows nested modules.

```csharp
module A =
    let aa = 1

    module B =
        let bb = 5
```

But in the following example; `module A` is a sibling to `module B`, as shown below.

```csharp
module A =
    let aa = 1

module B =
    let bb = 5
```
