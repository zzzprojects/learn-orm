---
PermaID: 100012
Name: Unconstrained Type Parameter Annotations
---

# Unconstrained Type Parameter Annotations

C# 9.0 allows nullable annotations for type parameters that are not constrained to value types or reference types such as, `T?`.

 - In C# 8.0, the nullable (`?`) annotations could only be applied to type parameters that were explicitly constrained to value types or reference types. 
 - In C# 9.0, it can be applied to any type of parameter, regardless of constraints.
 - Unless a type parameter is explicitly constrained to value types, annotations can only be applied within a `#nullable enable` context.

If a type parameter `T` is substituted with a reference type, then `T?` represents a nullable instance of that reference type. If `T` is substituted with a value type, then `T?` represents an instance of `T`.

```
var s1 = new string[2] { "str1", "str2" };  // string? s1
var s2 = new string?[2] { "str3", "str4" }; // string? s2

var i1 = new int[2] { 1, 2 };  // int i1
var i2 = new int?[2] { 3, 4 }; // int? i2
```

If `T` is substituted with an annotated type `U?`, then `T?` represents the annotated type `U?` rather than `U??`.

```csharp
var u1 = new U[0].FirstOrDefault();  // U? u1
var u2 = new U?[0].FirstOrDefault(); // U? u2
```

If `T` is substituted with a type `U`, then `T?` represents `U?`, even within a `#nullable disable` context.

## Default Constraint

For compatibility with existing code were overridden and explicitly implemented generic methods could not include explicit constraint clauses, `T?` in an overridden or explicitly implemented method is treated as `Nullable<T>` where T is a value type.

To allow annotations for type parameters constrained to reference types, C#8 allowed explicit `where T : class` and `where T : struct` constraints on the overridden or explicitly implemented method.

```csharp
class A1
{
    public virtual void F1<T>(T? t) where T : struct { }
    public virtual void F1<T>(T? t) where T : class { }
}

class B1 : A1
{
    public override void F1<T>(T? t) /*where T : struct*/ { }
    public override void F1<T>(T? t) where T : class { }
}
```

To allow annotations for type parameters that are not constrained to reference types or value types, C#9 allows a new `where T : default` constraint.

```csharp
class A2
{
    public virtual void F2<T>(T? t) where T : struct { }
    public virtual void F2<T>(T? t) { }
}

class B2 : A2
{
    public override void F2<T>(T? t) /*where T : struct*/ { }
    public override void F2<T>(T? t) where T : default { }
}
```

It is an error to use a `default` constraint in the following scenarios.

 - Other than on a method override or explicit implementation. 
 - When the corresponding type parameter in the overridden or interface method is constrained to a reference type or value type.