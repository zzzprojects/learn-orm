---
PermaID: 100012
Name: Functions
---

# Functions

Functions are the fundamental unit of program execution in any programming language. 

 - Function has a name, can have parameters and take arguments, and has a body. 
 - F# also supports functional programming constructs such as treating functions as values, using unnamed functions in expressions, the composition of functions to form new functions, curried functions, and the implicit definition of functions by way of the partial application of function arguments.

You define functions by using the `let` keyword, or, if the function is recursive, the `let rec` keyword combination. The basic syntax of a function is as follows.

```csharp
let [inline] function-name parameter-list [ : return-type ] = function-body

// Recursive function definition.
let rec function-name parameter-list = recursive-function-body
```

 - The `function-name` is an identifier that represents the function. 
 - The `parameter-list` consists of successive parameters that are separated by spaces. 
 - If you do not specify a specific argument type, the compiler attempts to infer the function body's type. 
 - The `function-body` consists of an expression that makes up the function body is typically a compound expression consisting of many expressions that culminate in a final expression that is the return value. 
 - The `return-type` is a colon followed by a type and is optional. 
 - If you do not explicitly specify the return value, the compiler determines the return type from the final expression.

The following is the simple function definition.

```csharp
let myFunc x = x + 1
```

In the above example, `myFunc` is the function name, `x` is the argument that has type `int`, `x + 1` is the function body, and the return value is of type `int`.

You can specify a type for a parameter, as shown in the following example.

```csharp
let myFunc (x : int) = x + 1
```

If you omit the type for the parameter, the parameter type is inferred by the compiler.

## Function Body

A function body can contain definitions of local variables and functions. Such variables and functions are in scope in the body of the current function but not outside it. 

```csharp
let myFunc1 x y = 
    let z = 3
    x*y + z
```

You can call a function by specifying the function name followed by a space and then any arguments separated by spaces.

```csharp
let val1 = myFunc1 3 7
let val2 = myFunc1 9 2

Console.WriteLine(val1)
Console.WriteLine(val2)
```

## Recursive Functions

Recursive functions are functions that call themselves. You define a recursive using the `let rec` keyword combination.

The following recursive function computes the nth Fibonacci number. 

```csharp
let rec fib n = 
    if n < 2 then 1 
    else fib (n - 1) + fib (n - 2)
```

