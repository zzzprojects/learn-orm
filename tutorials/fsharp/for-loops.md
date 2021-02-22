---
PermaID: 100010
Name: For Loops
---

# For Loops

A for loop is a repetition control structure that allows you to efficiently write a loop that needs to execute a specific number of times. It allows you to execute an expression or group of expressions multiple times. There are two types of for loop.

 - **`for...to`** 
 - **`for...in`**
 
## `for...to` Expression

The `for...to` loop is used to iterate in a loop over a range of values of a loop variable. It is more like a traditional statement in an imperative programming language.

The basic syntax of the `for...to` loop is as follows.

```csharp
for identifier = start [ to | downto ] finish do
    body-expression
```

The type of the identifier is inferred from the type of the `start` and `finish` expressions. Types for these expressions must be 32-bit integers.

The following examples show various uses of the `for...to` expression.

```csharp
// Print from 1 to 5
for i = 1 to 5 do
    Console.WriteLine("Counter: {0}", i);

// Print in reverse from 5 to 1
for i = 5 downto 1 do
    Console.WriteLine("Counter: {0}", i);
```

## `for...in` Expression

The `for...in` loop is used to iterate over a pattern's matches in an enumerable collection such as a range expression, sequence, list, array, or other constructs that supports enumeration.

 - The `for...in` expression can be compared to the `for each` statement in other .NET languages because it is used to loop over the values in an enumerable collection. 
 - The `for...in` also supports pattern matching over the collection instead of just iteration over the whole collection.

The basic syntax of the `for...in` loop is as follows.

```csharp
for pattern in enumerable-expression do
    body-expression
```

The following example shows how to use the `for...in` expression.

```csharp
let list = [ 100; 500; 1000; 2000; 9000 ]
for i in list do
   Console.WriteLine(i)
```
