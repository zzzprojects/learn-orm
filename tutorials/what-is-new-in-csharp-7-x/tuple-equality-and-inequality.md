---
PermaID: 100019
Name: Tuple Equality and Inequality
---

# Tuple Equality and Inequality

A tuple provides a syntax that allows you to combine the assignment of multiple variables, of varying types, in a single statement. For more information, see the [Tuples](tuples.md) article.

 - Starting with C# 7.3, tuple types support equality (`==`) and inequality (`!=`) operators. 
 - It compares the member of the left-hand operand with the corresponding member of the right-hand operand following the order of tuple elements.

Let's consider the following simple example.

```csharp
(int a, short b) tuple1 = (9, 13);
(long a, int b) tuple2 = (9, 13);
(long a, double b) tuple3 = (9, 13.0);
Console.WriteLine(tuple1 == tuple2);  // output: True
Console.WriteLine(tuple1 != tuple2);  // output: False
Console.WriteLine(tuple1 != tuple3);  // output: False
Console.WriteLine(tuple3 == tuple2);  // output: True
```

The equality (`==`) and inequality (`!=`) operations don't consider the tuple field names as shown below.

```csharp
(int a, short b) tuple1 = (9, 13);
(long c, int d) tuple2 = (9, 13);
var tuple3 = (e: 9, f: 13.0);
Console.WriteLine(tuple1 == tuple2);  // output: True
Console.WriteLine(tuple1 != tuple2);  // output: False
Console.WriteLine(tuple1 != tuple3);  // output: False
Console.WriteLine(tuple3 == tuple2);  // output: True
```

You can compare two tuples with the following conditions.

 - Both tuples have the same number of elements. For example, t1 != t2 doesn't compile if t1 and t2 have different numbers of elements.
 - For each tuple position, the corresponding elements from the left-hand and right-hand tuple operands are comparable with the equality (`==`) and inequality (`!=`) operators. For example, `(1, (2, 3)) == ((1, 2), 3)` doesn't compile because `1` is not comparable with `(1, 2)`.

The equality (`==`) and inequality (`!=`) operators compare tuples in a short-circuiting way. That is, an operation stops as soon as it meets a pair of non-equal elements or reaches the ends of tuples. However, before any comparison, all tuple elements are evaluated as shown below.

```csharp
int Print(int number)
{
    Console.WriteLine(number);
    return number;
}

Console.WriteLine((Print(10), Print(20)) == (Print(30), Print(40)));
```

You will see the following output when you execute the above example.

```csharp
10
20
30
40
False
```

