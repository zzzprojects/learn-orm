---
PermaID: 100042
Name: Object Expressions
---

# Object Expressions

An object expression is an expression that creates a new instance of a dynamically created, anonymous object type that is based on an existing base type, interface, or set of interfaces.

The following is the basic syntax of an object expression.

```csharp
// When typename is a class:
{ new typename [type-params]arguments with
    member-definitions
    [ additional-interface-definitions ]
}
// When typename is not a class:
{ new typename [generic-type-args] with
    member-definitions
    [ additional-interface-definitions ]
}
```

 - **`typename`:** Represents an existing class type or interface type. 
 - **`type-params`:** Describes the optional generic type parameters. 
 - **`arguments`:** Used only for class types, which require constructor parameters. 
 - **`member-definitions`:** Overrides of base class methods or implementations of abstract methods from either a base class or an interface.

Let's consider the following several different types of object expressions.

The following object expression specifies a `System.Object` but overrides the `ToString` method.

```csharp
let obj1 = 
    { 
        new System.Object() with member x.ToString() = "This is F# Tutorial." 
    }
Console.WriteLine(obj1)
```

The following object expression implements the `IDisplay` interface.

```csharp
type IDisplay =
    abstract member Print : unit -> unit

let Point3D(x: float, y: float, z: float) =
    { new IDisplay with
        member this.Print() = printfn "X: %f, Y: %f, Z: %f" x y z }

let point1 = Point3D(1.1, 2.2, 3.3)
point1.Print()
```

The following object expression implements both interfaces.

```csharp
type IFirst =
  abstract F : unit -> unit
  abstract G : unit -> unit

type ISecond =
  inherit IFirst
  abstract H : unit -> unit
  abstract J : unit -> unit

let implementer() =
    { new ISecond with
        member this.H() = ()
        member this.J() = ()
      interface IFirst with
        member this.F() = ()
        member this.G() = () }
```

## Advantages of Object Expressions

 - You can use object expressions when you want to avoid the extra code and overhead required to create a new, named type. 
 - If you use object expressions to minimize the number of types created in a program, you can reduce the number of lines of code and prevent the unnecessary rapid increase of types. 
 - Instead of creating many types to handle specific situations, you can use an object expression that customizes an existing type or provides an appropriate implementation of an interface for the specific case at hand.

