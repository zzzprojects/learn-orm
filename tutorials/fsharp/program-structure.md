---
PermaID: 100003
Name: Program Structure
---

# Program Structure

In F#, functions work like data types. You can declare and use a function in the same way as any other variable.

You can define a simple F# program that prints text on the console in the following different ways.

## Without Entry Point

An F# application does not have any specific entry point. The compiler executes all top-level statements in the file from top to bottom. 

You can use `printfn` to print a text message on a console without using any entry point as shown below.

```csharp
printfn "Welcome to F# Tutorial."
```

### Using Console.WriteLine

You can also print a text message on the console using `Console.WriteLine` by including the `System` namespace.

```csharp
open System;

Console.WriteLine("Welcome to F# Tutorial.")  
```

### Inside Class

You can also call the `printfn` inside a class as shown in the below example.

```csharp
type Program() =   
 class  
  do printfn "Welcome to F# Tutorial."  
 end  
new Program()  
```

### Using Function

The `printfn` can be used inside a function as shown in the below example.

```csharp
let myFunc = printfn "Welcome to F# Tutorial."  
  
myFunc 
```

## Top Level Entry Point

To follow procedural programming style, many applications keep a single top-level statement that calls the main loop as shown below.

```csharp
open System

let message = "Welcome to F# Tutorial."

[<EntryPoint>]
let main argv =
    Console.WriteLine(message)
    0 // return an integer exit code
```

 - An F# code file might begin with several `open` statements that are used to import namespaces.
 - The body of the files includes other functions that implement the business logic of the application.
 - The main loop contains the top executable statements.

