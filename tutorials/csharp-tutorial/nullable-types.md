---
PermaID: 100010
Name: Nullable Types
---

# Nullable Types

Nullable types are specific wrappers around the value types that allow storing data with a null value. A type is said to be nullable if it can be assigned a value or can be assigned null. In C#, you can mark a value type as nullable by the following two different ways.

```csharp
Nullable<int> i = null;
int? j = 4;
```
Both declarations are equivalent and the easiest way to perform this operation is to add a question mark (`?`) after the type such as `int?` or `bool?`.

A nullable of type `int` is the same as an ordinary `int` plus a flag that says whether the `int` has a value or not.

 - A nullable value type `T?` represents all values of its underlying value type `T` and additional null value. 
 - For example, you can assign any of the following three values to a `bool?` variable: `true`, `false`, or `null`. 
 - An underlying value type `T` cannot be a nullable value type itself.
 - The Nullable<T> structure supports using only a value type as a nullable type because reference types are nullable by design.

The value of the Nullable type can't be accessed directly, you need to use the `GetValueOrDefault()` method to get the assigned value or the default value if it is null. The default value for null is 0.

```csharp
Nullable<int> i = null;
int? j = 4;

Console.WriteLine(i.GetValueOrDefault());     // It will print 0
Console.WriteLine(j.GetValueOrDefault());     // It will print 4
```

## Nullable Type Properties

The two fundamental members of the `Nullable<T>` structure are the `HasValue` and `Value` properties. 

 - If the `HasValue` property is true, the value of the object can be accessed with the `Value` property. 
 - If the `HasValue` property is false, the value of the object is undefined and an attempt to access the `Value` property throws an `InvalidOperationException`.

```csharp
Nullable<int> i = null;

if (i.HasValue)
    Console.WriteLine(i.Value); // or Console.WriteLine(i)
else
    Console.WriteLine("Null");
```

## ?? Operator

If you want to assign a value of a nullable value type to a non-nullable value type variable, you might need to specify the value to be assigned in place of null. You can use the `??` (null-coalescing operator) to assign a nullable type to a non-nullable type.

```csharp
int? a = null;
int? b = 40;

int c = a ?? -1;
int d = b ?? -1;

Console.WriteLine($"c is {c}");  // output: c is -1
Console.WriteLine($"d is {d}");  // output: d is 40
```

You can also explicitly cast a nullable value type to a non-nullable type as shown below.

```csharp
int? num = null;
int n2 = (int)num;
```

The above example will throw an exception if `num` is null.
