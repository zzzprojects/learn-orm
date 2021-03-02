---
PermaID: 100030
Name: Enums
---

# Enums

Enumerations, also known as enums, are integral types where labels are assigned to a subset of the values. You can use them in place of literals to make code more readable and maintainable.

```csharp
type enum-name =
| value1 = integer-literal1
| value2 = integer-literal2
...
```

The following code shows the declaration of an enumeration.

```csharp
type Category =
   | Sports = 0
   | Arts = 1
   | Clothing = 2
   | Electronics = 3
   | HealthCare = 4
```

An enumeration looks much like a discriminated union that has simple values, except that the values can be specified. The values are typically integers that start at 0 or 1, or integers that represent bit positions.

When you refer to the named values, you must use the name of the enumeration type itself as a qualifier, that is, `enum-name.value1`, not just `value1`. 

```csharp
let electronicsCat = Category.Electronics
Console.WriteLine(electronicsCat)
```

You can easily convert enumerations to the underlying type using the appropriate operator, as shown in the following code.

```csharp
let electronicsCat = Category.Electronics
let intValue = int electronicsCat
Console.WriteLine("{0}: {1}",electronicsCat, intValue)
```

 - Enumerated types can have one of the following underlying types: `sbyte`, `byte`, `int16`, `uint16`, `int32`, `uint32`, `int64`, `uint16`, `uint64`, and `char`. 
 - Enumeration types are represented in the .NET Framework as types that are inherited from `System.Enum`, which in turn is inherited from `System.ValueType`.

The `enum` function in the F# library can be used to generate an enumeration value, even a value other than one of the predefined, named values. 

You use the `enum` function as follows.

```csharp
let cat4 = enum<Category>(4)
Console.WriteLine("{0}: {1}",cat4, 4)
```

The default enum function works with type `int32`. Therefore, it cannot be used with enumeration types that have other underlying types.

You can use the `Microsoft.FSharp.Core.LanguagePrimitives.EnumOfValue` method if you are other than `int32`.

```csharp
type uCategory =
   | Sports = 0u
   | Arts = 1u
   | Clothing = 2u
   | Electronics = 3u
   | HealthCare = 4u

let cat2 = Microsoft.FSharp.Core.LanguagePrimitives.EnumOfValue<uint32, uCategory>(2u)
Console.WriteLine("{0}: {1}",cat2, 2u)
```
