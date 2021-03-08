---
PermaID: 100040
Name: Interfaces
---

# Interfaces

Interfaces specify sets of related members that other classes implement. Interface declarations resemble class declarations except that no members are implemented. 

 - Instead, all the members are abstract, as indicated by the keyword `abstract`. 
 - You do not provide a method body for abstract methods, but you can provide a default implementation by also including a separate definition of the member as a method together with the `default` keyword. 
 - It is similar to creating a virtual method in a base class in other .NET languages.

The basic syntax to define an interface is as follows.

```csharp
type type-name = 
   interface
       inherits-decl 
       member-defns 
   end
```

The following example shows a very simple interface declaration.
 
```csharp
type IDisplay =
    abstract member Print : format:string -> unit
```

In the above code, an `IDisplay` interface contains the `Print` method and has a single parameter of the type `string` with the name `format`.

There are two ways to implement interfaces.

 - [Class Types](#class-types)
 - [Object Expressions](#object-expressions)

## Class Types

You can implement one or more interfaces in a class type using the `interface` keyword, the name of the interface, and the `with` keyword, followed by the interface member definitions, as shown in the following code.

```csharp
type IDisplay =
    abstract member Print : unit -> unit

type Point3D(x: float, y: float, z: float) =
   interface IDisplay with
      override this.Print() = printfn "X: %f, Y: %f, Z: %f" x y z
```

Interface methods can be called only through the interface, not through any object of the type that implements the interface. 

You might have to upcast the interface type by using the `:>` operator or the `upcast` operator to call these methods.

```csharp
let point = new Point3D(1.1, 2.2, 3.3)
(point :> IDisplay).Print()
```

## Object Expressions

Object expressions provide a short way to implement an interface. It is useful when you do not have to create a named type, and you want an object that supports the interface methods without any additional methods. 

The following example shows the usage of an object expression.

```csharp
type IDisplay =
    abstract member Print : unit -> unit

let Point3D(x: float, y: float, z: float) =
    { new IDisplay with
        member this.Print() = printfn "X: %f, Y: %f, Z: %f" x y z }

let point1 = Point3D(1.1, 2.2, 3.3)
point1.Print()
```

## Interface Inheritance

Interfaces can inherit from one or more base interfaces, as shown in the below example.

```csharp
type Interface1 =
    abstract member Method1 : int -> int

type Interface2 =
    abstract member Method2 : int -> int

type Interface3 =
    inherit Interface1
    inherit Interface2
    abstract member Method3 : int -> int

type MyClass() =
    interface Interface3 with
        member this.Method1(n) = n * 10
        member this.Method2(n) = n + 100
        member this.Method3(n) = n*n / 10
```
