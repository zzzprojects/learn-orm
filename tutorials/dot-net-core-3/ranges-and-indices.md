---
PermaID: 100018
Name: Ranges and Indices
---

# Ranges and Indices

Indices and ranges provide a succinct syntax for accessing single elements or ranges in a sequence. In C# 8.0, the following two new types are added.

 - [Range](#range)
 - [Index](#index)

You can use these structs to index or slice collections at runtime.

## Range

The `System.Range` struct represents a range that has start and end indexes.

 - It represents a sub-range of a sequence.
 - The range operator `..`, which specifies the start and end of a range as its operands.
 - The start of the range is inclusive, but the end of the range is exclusive, meaning the start is included in the range, but the end isn't.
 - The range `[0..^0]` represents the entire range, just as `[0..nameOfMonths.Length]` represents the entire range.

Let's consider the same array, which contains all the names of months. The following code creates a subrange with the months "March", "April", and "May". It includes `nameOfMonths[2]` through `nameOfMonths[5]`. The element `nameOfMonths[5]` isn't in the range.

```csharp
var names = nameOfMonths[2..5];

foreach (var name in names)
{
    Console.WriteLine(name);
}
```

You can also declare ranges as variables.

```csharp
Range phrase = 1..3;
```

The following code creates a subrange with "November" and "December". It includes `nameOfMonths[^2]` and `nameOfMonths[^1]`. The end index `nameOfMonths[^0]` isn't included.

```csharp
Range phrase = ^2..^0;
var names = nameOfMonths[phrase];

foreach (var name in names)
{
    Console.WriteLine(name);
}
```

The following code shows the ranges that are open-ended for the start, end, or both.

```csharp
var allMonths = nameOfMonths[..];       // contains all names.
var firstTwoMonths = nameOfMonths[..2]; // contains first two names i.e. January and February.
var lastThreeMonths = nameOfMonths[9..];     // contains the last three names.
```

## Index

The `System.Index` struct represents a type that can index a collection either from the start or the end. 

 - It represents an index in an array or sequence.
 - The `^` operator specifies the relative index from the end of an array.

Let's consider an array `nameOfMonths` which contains all the names of months. 

```csharp
string[] nameOfMonths = { 
                          // index from start    index from end
    "January",            // 0                   ^12
    "February",           // 1                   ^11
    "March",              // 2                   ^10
    "April",              // 3                   ^9
    "May",                // 4                   ^8
    "June",               // 5                   ^7
    "July",               // 6                   ^6
    "August",             // 7                   ^5
    "September",          // 8                   ^4
    "October",            // 9                   ^3
    "November",           // 10                  ^2
    "December"            // 11                  ^1
                          // 12 (nameOfMonths.Length)  ^0
};
```

 - The 0 index means the first element of `nameOfMonths[0]`. 
 - The `^0` index is the same as `nameOfMonths[nameOfMonths.Length]`. 
 - The expression `nameOfMonths[^0]` does throw an exception, just as `nameOfMonths[nameOfMonths.Length]` does. 
 - For any number `n`, the index `^n` is the same as `nameOfMonths[nameOfMonths.Length-n]`.

You can retrieve the last month with the `^1` index. 

```csharp
Console.WriteLine("The last month is {0}", nameOfMonths[^1]);
```
