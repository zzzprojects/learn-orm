---
PermaID: 100007
Name: Casting
---

# Casting

Conversion is a process of converting type of a value to the other required type. It can be primitive or object type. F# provides conversion operators for arithmetic conversions between various primitive types, such as between integer and floating-point types. 

The integral and char conversion operators have checked and unchecked forms; 

 - The floating-point operators and the enum conversion operator do not. 
 - The unchecked forms are defined in the `Microsoft.FSharp.Core.Operators` and the checked forms are defined in the `Microsoft.FSharp.Core.Operators.Checked`. 
 - The checked forms check for overflow and generate a runtime exception if the resulting value exceeds the limits of the target type.

Let's consider the following example in which the `int` is cast to the `byte`.

```csharp
let x : int = 17
let y : byte = byte x

Console.WriteLine("x: {0}", x)
Console.WriteLine("y: {0}", y)
```

Each of these operators has the same name as the name of the destination type. For example, in the above code, in which the types are explicitly annotated, `byte` appears with two different meanings. The first occurrence is the type and the second is the conversion operator. 

## Casting Object Types

Conversion between types in an object hierarchy is fundamental to object-oriented programming. There are two basic types of conversions: 

 - Upcasting
 - Downcasting

### Upcasting

Upcasting means casting from a derived object reference to a base object reference. Such a cast is guaranteed to work as long as the base class is in the inheritance hierarchy of the derived class. 

### Downcasting

Downcasting means casting from a base object reference to a derived object reference, succeeds only if the object is an instance of the correct destination (derived) type or a type derived from the destination type.

F# provides operators for these types of conversions. The `:>` operator casts up the hierarchy, and the `:?>` operator casts down the hierarchy.

```csharp
let value = 34
printfn "%A" value

// Upcast
let valueObj = value :> obj
printfn "%A" valueObj

// Downcast
let valueInt = valueObj :?> int
printfn "%A" valueInt
```

You can also use the `upcast` and `downcast` operators to perform such a conversion as shown below.

```csharp
type Shape() =  
    class  
     member this.Print()=  
       printfn "Shape"  
    end  
     
type Circle() =   
    class  
     inherit Shape()  
     member this.Print()=  
      printfn "Circle"  
    end  
     
let shape = new Shape()              
let circle : Circle = new Circle()  
shape.Print()      
circle.Print()

let castIntoShape = upcast circle : Shape                 // upcasting   
castIntoShape.Print()  

let castIntoCircle = downcast castIntoShape : Circle      // downcasting  
castIntoCircle.Print()  
```