---
PermaID: 100037
Name: Structures 
---

# Structures

A structure is a compact object type that can be more efficient than a class for types with a small amount of data and simple behavior.

 - Structures are value types, which means that they are stored directly on the stack. 
 - Unlike classes and records, structures have pass-by-value semantics. 
 - So it means that they are useful primarily for small aggregates of data that are accessed and copied frequently.

You can define structures in two different ways, as shown below.

```csharp
[ attributes ]
type [accessibility-modifier] type-name =
    struct
        type-definition-elements-and-members
    end
// or
[ attributes ]
[<StructAttribute>]
type [accessibility-modifier] type-name =
    type-definition-elements-and-members
```
 
 - The first syntax is not the lightweight syntax, but it is nevertheless frequently used because, when you use the struct and end keywords, you can omit the `StructAttribute` attribute, which appears in the second form. 
 - You can abbreviate `StructAttribute` to just Struct.
 - Structures can have constructors and mutable and immutable fields, and they can declare members and interface implementations. 

The following example demonstrates the usage of a structure.

```csharp
type Rectangle =
    struct
        val Height: float
        val Width: float
        new(x: float, y: float) = 
            { Height = x; Width = y }

        member this.GetArea() = this.Height * this.Width
    end


let rectangle = new Rectangle(3.0, 5.0)
Console.WriteLine("Area: {0}", rectangle.GetArea())
```

When you execute the above code, it will display the following output on the console.

```csharp
Area: 15
```
