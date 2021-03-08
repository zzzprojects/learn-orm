---
PermaID: 100035
Name: Self Identifiers
---

# Self Identifiers

A self-identifier is a name that represents the current instance. It resembles the `this` keyword in C# or C++ or `Me` in Visual Basic. 

 - You can define a self-identifier in two different ways, depending on whether you want the self-identifier to be in scope for the whole class definition or just for an individual method.
 - To define a self-identifier for the whole class, use the `as` keyword after the closing parentheses of the constructor parameter list and specify the identifier name.
 - To define a self-identifier for just one method, provide the `self` identifier in the member declaration, just before the method name and a period (`.`) as a separator.

The following example shows two ways to create a self-identifier. 

```csharp
type Point3D(x: int, y: int, z: int) as self =
    let X = x
    let Y = y
    let Z = z
    do
        self.Print()
    member this.Print() =
        printf "%d %d %d" x y z

let point = new Point3D(1, 2, 3)
```

In the first line, the `as` keyword is used to define the self-identifier. In the seventh line, the identifier `this` is used to define a self-identifier whose scope is restricted to the method `Print`.

 - Unlike in other .NET languages, you can name the self identifier as you want, and you are not restricted to names such as `self`, `Me`, or `this`.
 - The self-identifier that is declared with the `as` keyword is not initialized until after the base constructor. 
 - You can use the self identifier freely after the base constructor, such as in `let` bindings or `do` bindings.

When a self identifier is used before or inside the base constructor, the following exception will be raised during runtime.

```csharp
System.InvalidOperationException: The initialization of an object or value resulted in an object or value being accessed recursively before it was fully initialized.
```

