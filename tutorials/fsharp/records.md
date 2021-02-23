---
PermaID: 100018
Name: Records
---

# Records

Records represent simple aggregates of named values, optionally with members. They can either be structs or reference types. They are reference types by default.

```csharp
[ attributes ]
type [accessibility-modifier] typename =
    { [ mutable ] label1 : type1;
      [ mutable ] label2 : type2;
      ... }
    [ member-list ]
```

 - **typename:** It is the name of the record type.
 - **label1, label2:** These are names of values, referred to as labels.
 - **type1, type2:** There are the types of these values. 
 - **member-list:** It is the optional list of members for the type. 
 - You can use the `[<Struct>]` attribute to create a struct record rather than a record that is a reference type.

The following example defines a record containing **Labels** defined on the same line separated by semicolons.

```csharp
type Point3D = { X: float; Y: float; Z: float; }
```

You can define labels on separate lines with or without a semicolon.

```csharp
type Author = 
    { FirstName: string
      LastName: string;
      Age: uint32 }
```

When each label is on a separate line, the semicolon is optional. The following code shows how to define a struct record.

```csharp
[<Struct>]
type StructPoint = 
    { X: float
      Y: float
      Z: float }
```

## Creating Records by Using Record Expressions

You can initialize records by using the labels that are defined in the record. 

 - An expression that does this is referred to as a record expression. 
 - Use braces to enclose the record expression and use the semicolon as a delimiter.

The following example shows how to create a record.

```csharp
type Point3D = { X: float; Y: float; Z: float; }

let point = { X = 1.1; Y = 3.3; Z = 5.5; }

Console.WriteLine(point)
```

 - The semicolons after the last field in the record expression and the type definition are optional, regardless of whether the fields are all in one line.
 - When you create a record, you must supply values for each field. 
 - You cannot refer to the values of other fields in the initialization expression for any field.

You can also specify the type name explicitly.

```csharp
let point1 = { Point3D.X = 2.2; Point3D.Y = 4.4; Point3D.Z = 6.6; }
```

You can copy an existing record and also change some of the field values as shown below.

```csharp
let author1 = {FirstName = "Mark"; LastName = "Upston"; Age = 33u;}
let author2 = { author1 with Age = 43u}
```

This form of the record expression is called the copy and update record expression.
