---
PermaID: 100023
Name: Discriminated Unions
---

# Discriminated Unions

Discriminated unions provide support for values that can be one of several named cases, possibly each with different values and types. Discriminated unions are useful for heterogeneous data; 

 - Data that can have special cases, including valid and error cases. 
 - Data that varies in type from one instance to another; 
 - An alternative for small object hierarchies. 
 - Besides, recursive discriminated unions are used to represent tree data structures.

Discriminated unions allow you to build up complex data structures representing a well-defined set of choices. For example, you need to build an implementation of a choice variable, which has two values yes and no. Using the Union's tool, you can design this.

```csharp
[ attributes ]
type [accessibility-modifier] type-name =
    | case-identifier1 [of [ fieldname1 : ] type1 [ * [ fieldname2 : ] type2 ...]
    | case-identifier2 [of [fieldname3 : ]type3 [ * [ fieldname4 : ]type4 ...]

    [ member-list ]
```

The following example declares a `Shape` type.

```csharp
type Shape =
    | Rectangle of width : float * length : float
    | Circle of radius : float
    | Prism of width : float * float * height : float
```

The above code declares a discriminated union Shape, which can have values of three cases: Rectangle, Circle, and Prism. Each case has a different set of fields. 

 - The Rectangle case has two named fields, width, and length and both have type float. 
 - The Circle case has just one named field, radius. 
 - The Prism case has three fields, two of which (width and height) are named fields. Unnamed fields are referred to as anonymous fields.

You construct objects by providing values for the named and anonymous fields, as shown below.

```csharp
let rect = Rectangle( width = 6.0, length = 10.0)
let circ = Circle (2.5)
let prism = Prism(3.75, 4.0, height = 5.0)
```

 - It allows you to either use the field name when calling or just passing the value as we did in the `Circle` case code. 
 - If you use a field name, you don't need to maintain the order of field, but if you are passing only values, you must ensure the order of field before passing value.

Now let's see how to call and set values for these cases.

```csharp
type Shape =
    | Rectangle of width : float * length : float
    | Circle of radius : float
    | Prism of width : float * float * height : float

let compute vall =  
   match vall with  
     | Rectangle (val1, val2) -> val1*val2  
     | Circle (val1)->val1*val1*3.1415       
     | Prism (val1, val2, val3)->val1*val2*val3  

let rect = compute (Rectangle( width = 6.0, length = 10.0))
let circ = compute (Circle (2.5))
let prism = compute (Prism(3.75, 4.0, height = 5.0))

Console.WriteLine(rect)
Console.WriteLine(circ)
Console.WriteLine(prism)

```
