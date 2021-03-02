---
PermaID: 100036
Name: Static 
---

# Static

In F#, a `static` keyword is used to make a static field or static method. Static is not the part of an object. It has its own memory space to store static data. It is used to share common properties among objects.

There are two types of static bindings.

 - [`static let` Binding](#static-let-binding)
 - [`static do` Binding](#static-do-binding)

## `static let` Binding

The `static let` bindings are part of the static initializer for the class, which is guaranteed to execute before the type is first used.

The following example shows simple `static let` bindings.

```csharp
type Point(a: int, b: int) =
    // A static let binding.
    static let mutable count = 0

    do
       count <- count + 1

    member this.X = a
    member this.Y = b
    member this.CreatedCount = count

let point1 = Point(10, 52)
let point2 = Point(10, 52)

printfn "%d %d %d" (point1.X) (point1.Y) (point1.CreatedCount)
printfn "%d %d %d" (point2.X) (point2.Y) (point2.CreatedCount)
```

## `static do` Binding

The `static do` bindings can reference static members or fields of the enclosing class but not instance members or fields. The `static do` bindings become part of the static initializer for the class, which is guaranteed to execute before the class is first used.

The following example shows how to use `static do` bindings.

```csharp
type MyType(a:int, b:int) as this =
    inherit Object()

    do printfn "Initializing object %d %d" (this.X) (this.Y)
    static do printfn "Initializing MyType."
    member this.X = a
    member this.Y = b

let obj1 = new MyType(1, 2)
```
