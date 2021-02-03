---
PermaID: 100015
Name: Operators
---

# Operators

In a programming language, operators are special symbols such as `+`, `-`, `^`, etc. that perform some action on operands.

 - Operators allow the processing of primitive data types and objects. 
 - They take as an input one or more operands and return some value as a result. 
 
For example, operators are the signs for adding, subtracting, multiplication, and division like `+`, `-`, `*`, `/`, and the operations they perform on the integers and the real numbers.

## Types

Below is a list of the different types of operators.

| Type                                           | Description                                                          |
|:-----------------------------------------------|:-------------------------------------------------------------------|
| [Arithmetic](#arithmetic)                      | Perform familiar calculations on numeric values, including shifting their bit patterns. |
| [Logical](#logical)                            | Compare Boolean expressions and return a `Boolean` result. |
| [Bitwise](#bitwise)                            | Evaluate two integral values in binary (base 2) form. |
| [Comparison](#comparison)                      | Compare two expressions and return a Boolean value representing the result of the comparison. |
| [String Concatenation](#string-concatenation)  | Join multiple strings into a single string.                                                                |

### Arithmetic

Arithmetic operators are used for performing many of the familiar arithmetic operations that involve the calculation of numeric values represented by literals, variables, other expressions, function and property calls, and constants. 

Here are some examples of arithmetic operators and their effects.

```csharp
Dim a As Integer = 10
Dim b As Integer = 20

Console.WriteLine("a + b = {0}", a + b)
Console.WriteLine("a - b = {0}", a - b)
Console.WriteLine("a * b = {0}", a * b)
```

Let's run the above code and you will see the following output.

```csharp
a + b = 30
a - b = -10
a * b = 200
```

The division operator `/` has a different effect on integer and real numbers. When we divide an integer by an integer (like int, long, and sbyte) the returned value is an integer. Such division is called an integer division. 

Here are some examples of division operators and their effect when using integer division.

```csharp
Dim squarePerimeter As Integer = 17
Dim squareSideInt As Integer = squarePerimeter / 4
Console.WriteLine(squareSideInt)
Dim squareSideDouble As Double = squarePerimeter / 4.0
Console.WriteLine(squareSideDouble)
```

Let's run the above code and you will see the following output.

```csharp
4
4.25
```

### Logical

Logical operators or you can say Boolean operators take Boolean values and return a Boolean result (`true` or `false`). The basic Boolean operators are `&&` (and), `||` (or), `^` (exclusive OR) and `!` (logical negation).

The following table contains the logical operators in C# and the operations that they perform.

| A        | B         | Not A         | A AndAlso B         | A OrElse B       | A Xor B             |
|:---------|:----------|:--------------|:--------------------|:-----------------|:--------------------|
| true     | true      | false         | true                | true             | false               |
| true     | false     | false         | false               | true             | true                |
| false    | true      | true          | false               | true             | true                |
| false    | false     | true          | false               | false            | false               |

Let's consider the following simple examples of logical operators.


```csharp
Dim a As Boolean = True
Dim b As Boolean = False

Console.WriteLine(a AndAlso b)
Console.WriteLine(a OrElse b)
Console.WriteLine(Not b)
Console.WriteLine(b OrElse True)
Console.WriteLine((5 > 7) Xor (a = b))
``` 

### Bitwise

A bitwise operator is an operator that acts on the binary representation of numeric types. 

 - In computers, all the data and particularly numerical data are represented as a series of ones and zeros. 
 - For example, number 55 in the binary numeral system is represented as 00110111.

Here is an example of using bitwise operators. The binary representation of the numbers and the results of the bitwise operators are shown in the comments.

```csharp
Dim a As Byte = 3
Dim b As Byte = 5
Console.WriteLine(a Or b)
Console.WriteLine(a And b)
Console.WriteLine(a Xor b)
Console.WriteLine(Not a And b)
```

### Comparison

Comparison operators are used to comparing two or more operands. C# supports the following comparison operators.

- greater than (`>`)
- less than (`<`)
- greater than or equal to (`>=`)
- less than or equal to (`<=`)
- equality (`=`)
- difference (`<>`)

The following example shows the usage of comparison operators.

```csharp
Dim x As Integer = 10
Dim y As Integer = 5
Console.WriteLine("x > y : " & (x > y))
Console.WriteLine("x < y : " & (x < y))
Console.WriteLine("x >= y : " & (x >= y))
Console.WriteLine("x <= y : " & (x <= y))
Console.WriteLine("x = y : " & (x = y))
Console.WriteLine("x != y : " & (x <> y))
```

### String Concatenation 

Concatenation operators join multiple strings into a single string. There are two concatenation operators, `+` and `&`. Both carry out the basic concatenation operation, as the following example shows.

```csharp
Dim vbnet As String = "VB.NET "
Dim tutorial As String = "Tutorial."
Dim vbnetTutorial As String = vbnet & tutorial
Console.WriteLine(vbnetTutorial)
Dim csharp8 As String = vbnet + "15"
Console.WriteLine(csharp8)
```
