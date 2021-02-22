---
PermaID: 100006
Name: Variables
---

# Variables

A variable is a section of the computer's memory used to temporarily hold a value. Declaring a variable means that the variable has been reserved a portion of memory. 

## Variable Declaration Without Type

The `let` keyword is used for variable declaration. The type of a value is inferred from the definition. For a primitive type, such as an integral or floating-point number, the type is determined from the literal type. 

```csharp
let a = 17
let b = 10.5
let str = "text"

Console.WriteLine(a)
Console.WriteLine(b)
Console.WriteLine(str)
```

In the above example, the compiler infers the type of `a` to be an `int`, the type of `b` to be a `double`, whereas the compiler infers the type of `str` to be a `string`. 

### Immutable

By default, Variables in F# are immutable, which means once a variable is bound to a value, it can't be changed. 

They are compiled as static read-only properties. Let's consider the following example.

```csharp
let a = 17
let b = 10.5
let str = "text"

Console.WriteLine("a: {0}", a)
Console.WriteLine("b: {0}", b)
Console.WriteLine("str: {0}", str)

b <- 12.5
Console.WriteLine("b: {0}", b)
```

You will now see the following error.

```csharp
Error FS0027:	This value is not mutable. Consider using the mutable keyword, e.g. 'let mutable b = expression'.	
```

## Variable Declaration With Type

A variable definition tells the compiler where and how much storage for the variable should be created. A variable definition may specify a data type and contains a list of one or more variables of that type, as shown in the following example.

```csharp
let a:int32 = 17
let b:double = 10.5
let str:string = "text"

Console.WriteLine("a: {0}", a)
Console.WriteLine("b: {0}", b)
Console.WriteLine("str: {0}", str)
```

## Mutable Variables

The variable can be changed if you provide the `mutable` keyword for that variable. 

 - Mutable variables in F# should generally have a limited scope, either as a field of a type or as a local value. 
 - Mutable variables with the limited scope are easier to control and are less likely to be modified in incorrect ways.

You can assign an initial value to a mutable variable, by using the `let` keyword in the same way as you would define a value. However, the difference is that you can subsequently assign new values to mutable variables by using the `<-` operator, as in the following example.

```csharp
let a = 17
let mutable b = 10.5
let str = "text"

Console.WriteLine("a: {0}", a)
Console.WriteLine("b: {0}", b)
Console.WriteLine("str: {0}", str)

b <- 12.5
Console.WriteLine("b: {0}", b)
```

When you execute the above code you will see the following output.

```csharp
a: 17
b: 10.5
str: text
b: 12.5
```
