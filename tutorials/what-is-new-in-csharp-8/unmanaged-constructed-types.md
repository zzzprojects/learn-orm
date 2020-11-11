---
PermaID: 100009
Name: Unmanaged Constructed Types
---

# Unmanaged Constructed Types

## What is Unmanaged Type?

A type is called `unmanaged` when it can be used in an `unsafe` context. The following are the unmanaged types.

 - `sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`, `float`, `double`, `decimal`, or `bool`
 - Any `enum` type
 - Any pointer type
 - Any user-defined `struct` type that contains fields of `unmanaged` types only
 
## What is Constructed Types?

A type is called `constructed` if it is generic and the type parameter is already defined, such as `List<string>`,  List<int>, etc.

Before C# 8.0, a constructed type or a type that includes at least one type argument can't be an unmanaged type, but in C# 8.0, a constructed value type is `unmanaged` if it contains fields of unmanaged types only.

Let's consider the following example of an unmanaged constructed type that it was not possible to declare before C# 8.0.

```csharp
public struct Point3D<T>
{
    public T X;
    public T Y;
    public T Z;
}
```

The above example defines the generic `Point3D<T>` type. The `Point3D<double>` type is an unmanaged type and for any unmanaged type, you can create a pointer to a variable of this type or allocate a block of memory on the stack for instances of this type as shown below.

```csharp
Span<Point3D<double>> points = stackalloc[] 
{ 
    new Point3D<double> { X = 0.0, Y = 0.0, Z = 0.0 }, 
    new Point3D<double> { X = 0.0, Y = 3.0, Z = 0.0 }, 
    new Point3D<double> { X = 4.0, Y = 0.0, Z = 0.0 } 
};

foreach (var point in points)
{
    Console.WriteLine("X: {0}, Y: {1}, Z: {2}", point.X, point.Y, point.Z);
}
```

A generic struct may be the source of both unmanaged and not unmanaged constructed types. The above example defines a generic struct `Point3D<T>` and presents the examples of unmanaged constructed types.
