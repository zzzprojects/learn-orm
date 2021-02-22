---
PermaID: 100013
Name: Type Inference
---

# Type Inference

The type inference means is that you do not have to specify the types of values or variables except when the compiler cannot conclusively deduce the type. 

 - Omitting explicit type information does not mean that F# is a dynamically typed language or that values in F# are weakly typed. 
 - F# is a statically typed language, which means that the compiler deduces an exact type for each construct during compilation. 
 - If there is not enough information for the compiler to deduce the types of each construct, you must supply additional type information, typically by adding explicit type annotations somewhere in the code.

Let's consider the following lines of code.

```csharp
let myInt = 5
let myFloat = 3.14
let myString = "hello"
```

## Parameter and Return Types

In a parameter list, you do not have to specify the type of each parameter.

 - The compiler infers the type based on the context for those types that you do not specify explicitly.
 - If the type is not otherwise specified, it is inferred to be generic. 
 - If the code uses a value inconsistently so that there is no single inferred type that satisfies all the uses of a value, the compiler reports an error.
 - The return type of a function is determined by the type of the last expression in the function.

In the following example, the parameter types `x` and `y` and the return type are all inferred to be `int` because the literal `3` is of type `int`.

```csharp
let myFunc1 x y = 
    x*y + 3

let val1 = myFunc1 3 7
let val2 = myFunc1 9 2

Console.WriteLine(val1)
Console.WriteLine(val2)
```

You can influence type inference by changing the literals. 

 - If you make the `3` a `uint32` by appending the suffix `u`, the types of `x`, `y`, and the return value are inferred to be `uint32`.
 - You can also influence type inference by using other constructs that imply restrictions on the type, such as functions and methods that work with only a particular type.

```csharp
let myFunc2 x y = 
    x*y + 3u

let val1 = myFunc2 3u 7u
let val2 = myFunc2 9u 2u

Console.WriteLine(val1)
Console.WriteLine(val2)
```

You can also explicitly specify the return value of a function by providing a type annotation after all the parameters.

```csharp
let add x y : uint32 =
   x + y
```

A common case where a type annotation is useful on a parameter is when the parameter is an object type, and you want to use a member.

```csharp
let replace(str: string) =
    str.Replace("A", "a")
```
