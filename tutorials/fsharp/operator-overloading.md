---
PermaID: 100038
Name: Operator Overloading 
---

# Operator Overloading

Operator overloading allows programmers to provide new behavior for the default operators in F#. In practice, programmers overload operators to provide a simplified syntax for objects which can be combined mathematically.

You have already used different operators such as arithmetical operators (`+`, `-`, `*`, `/`, `%`, `**`, etc.), and they perform mathematical operations such as addition, subtraction, and multiplication respectively on numerical values. The result is also a numerical value.

```csharp
let a = 10
let b = 20
let c = 3.0

Console.WriteLine("a + b = {0}", a + b)
Console.WriteLine("a - b = {0}", a - b)
Console.WriteLine("a * b = {0}", a * b)
Console.WriteLine("a / 2 = {0}", a / 2)
Console.WriteLine("c ** 2.0 = {0}", c ** 2.0)
```

Operators are functions with special names enclosed in brackets. They must be defined as static class members. 

The following example declares a vector class with just two operators, one for unary minus and one for multiplication by a scalar.

```csharp
type Vector(x: float, y : float) =
   member this.x = x
   member this.y = y
   static member (~-) (v : Vector) =
     Vector(-1.0 * v.x, -1.0 * v.y)
   static member (*) (v : Vector, a) =
     Vector(a * v.x, a * v.y)
   static member (*) (a, v: Vector) =
     Vector(a * v.x, a * v.y)
   override this.ToString() =
     this.x.ToString() + " " + this.y.ToString()

let v1 = Vector(1.0, 2.0)

let v2 = v1 * 2.0
let v3 = 2.0 * v1

let v4 = - v2

printfn "%s" (v1.ToString())
printfn "%s" (v2.ToString())
printfn "%s" (v3.ToString())
printfn "%s" (v4.ToString())
```
