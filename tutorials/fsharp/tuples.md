---
PermaID: 100017
Name: Tuples
---

# Tuples

A tuple is a grouping of unnamed but ordered values, possibly of different types. Tuples can either be reference types or structs.

The basic syntax of tuples in F# is as follows.

```csharp
(element, ... , element)
struct(element, ... ,element )
```

Tuples include pairs, triples, and so on, of the same or different types. The following examples show different types of tuples.

```csharp
// Tuple of two strings.
let tuple1 = ( "Hello", "World" )

// Triple of double.
let tuple2 = ( 1.1, 2.2, 3.3 )

// Tuple of unknown types.
let a = 2
let b = 4
let tuple3 = ( a, b )

// Tuple that has mixed types.
let tuple4 = ( "F#", 1, 2.0 )

// Tuple of integer expressions.
let tuple5 = ( a * 4, b + 7)

// Struct Tuple of floats
let tuple6 = struct (1.025f, 1.5f)
```

You can also deconstruct a tuple via pattern matching using `let` binding.

```csharp
let (x, y) = (33, 27)
Console.WriteLine("x = {0}, y = {1}", x, y)

// Or as a struct
let struct (c, d) = struct (14, 29)
Console.WriteLine("c = {0}, d = {1}", c, d)
```

You can copy elements from a reference tuple into a struct tuple as shown below.

```csharp
// Create a reference tuple
let (a, b) = (31, 52)

// Construct a struct tuple from it
let struct (c, d) = struct (a, b)
```

If you need only one element of the tuple, the wildcard character (the underscore) can be used to avoid creating a new name for a value that you do not need.

```csharp
let (name, _) = ("Mark", 25)
```

The functions `fst` and `snd` (reference tuples only) return the first and second elements of a tuple, respectively.

```csharp
let c = fst (13, 27)
let d = snd (13, 27)
```
