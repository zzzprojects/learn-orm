---
PermaID: 100016
Name: Generics
---

# Generics

Generic functions and types enable you to write code that works with a variety of types without repeating the code for each type.

 - In F#, function values, methods, properties, and aggregate types such as classes, records, and discriminated unions can be generic. 
 - Generic constructs contain at least one type parameter, which is usually supplied by the user of the generic construct.
 - Generics allow you to delay the specification of the data type of programming elements in a class or a method until it is used in the program.

## Implicitly Generic Constructs

You can make a function generic by using the single quotation (`'`) mark in a type annotation to indicate that a parameter type is a generic type parameter as shown below. 

```csharp
let func1 (x: 'a) (y: 'a) =
    Console.WriteLine("{0}, {1}", x, y)
```

In the above example, `func1` is generic because its parameters are declared using a single quotation (`'`), as type parameters. You can call this function by passing different types of parameters as shown below.

```csharp
func1 7 5
func1 22.2 3.1
func1 "hello" "world"
```

## Explicitly Generic Constructs

You can also make a function generic by explicitly declaring its type parameters in angle brackets (`<type-parameter>`). 

The following example shows the explicitly generic constructs.

```csharp
let func2<'T> x y =
    Console.WriteLine("{0}, {1}", x, y)

func2<int> 7 5
```

