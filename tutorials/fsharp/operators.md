---
PermaID: 100008
Name: Operators
---

# Operators

In a programming language, operators are special symbols such as `+`, `-`, `^`, etc. that perform some action on operands.

 - Operators allow the processing of primitive data types and objects. 
 - They take as an input one or more operands and return some value as a result. 
 
For example, operators are the signs for adding, subtracting, multiplication, and division like `+`, `-`, `*`, `/`, and the operations they perform on the integers and the real numbers.

## Types

Below is a list of the different types of operators.

 - [Arithmetic](#arithmetic)                   
 - [Boolean](#boolean)                          
 - [Bitwise](#bitwise)                          
 - [Comparison](#comparison)                    
                         
### Arithmetic 

In F#, the arithmetical operators are `+`, `-`, `*`, `/`, `%`, `**`, etc. and they perform mathematical operations such as addition, subtraction, and multiplication respectively on numerical values, and the result is also a numerical value.

Here are some examples of arithmetic operators and their effects.

```csharp
let a = 10
let b = 20
let c = 3.0

Console.WriteLine("a + b = {0}", a + b)
Console.WriteLine("a - b = {0}", a - b)
Console.WriteLine("a * b = {0}", a * b)
Console.WriteLine("a / 2 = {0}", a / 2)
Console.WriteLine("c ** 2.0 = {0}", c ** 2.0)
```

### Boolean

The following table summarizes the Boolean operators that are available in the F# language. The only type supported by these operators is the bool type.

| Operator   | Description                    |
| :----------| :------------------------------|
| `not`     | Boolean negation               |
| `||`      | Boolean OR                     |
| `&&`      | Boolean AND                    |

 - The Boolean `&&` and `||` operators evaluate the expression on the operator's right only when it is necessary to determine the overall result of the expression. 
 - The second expression of the `&&` operator is evaluated only if the first expression evaluates to `true`
 - The second expression of the `||` operator is evaluated only if the first expression evaluates to `false`.

### Bitwise

The following table describes the bitwise operators supported for unboxed integral types in the F# language.

| Operator   | Description                    |
| :----------| :------------------------------|
| `&&&`     | Bitwise AND operator. Bits in the result have the value 1 if and only if the corresponding bits in both source operands are 1. |
| `|||`     | Bitwise OR operator. Bits in the result have the value 1 if either of the corresponding bits in the source operands is 1. |
| `^^^`     | Bitwise exclusive OR operator. Bits in the result have the value 1 if and only if bits in the source operands have unequal values. |
| `~~~`     | Bitwise negation operator. This is a unary operator and produces a result in which all 0 bits in the source operand are converted to 1 bit, and all 1 bits are converted to 0 bits. |
| `<<<`     | Bitwise left-shift operator. The result is the first operand with bits shifted left by the number of bits in the second operand. Bits shifted off the most significant position are not rotated into the least significant position. The least significant bits are padded with zeros. The type of the second argument is `int32`. |
| `>>>`     | Bitwise right-shift operator. The result is the first operand with bits shifted right by the number of bits in the second operand. Bits shifted off the least significant position are not rotated into the most significant position. For unsigned types, the most significant bits are padded with zeros. For signed types with negative values, the most significant bits are padded with ones. The type of the second argument is `int32`. |

The following types can be used with bitwise operators: 

 - `byte`
 - `sbyte`
 - `int16`
 - `uint16`
 - `int32`
 - `uint32`
 - `int64`
 - `uint64`
 - `nativeint`
 - `unativeint`

### Comparison

Comparison operators are used to comparing two or more operands. F# supports the following comparison operators.

- greater than (>)
- less than (<)
- greater than or equal to (>=)
- less than or equal to (<=)
- equality (=)
- difference (<>)

The following table shows all the comparison operators supported by F# language. These binary comparison operators are available for integral and floating-point types, and they return values of type `bool`.

| Operator   | Description                    |
| :----------| :------------------------------|
| =          | Checks if the values of two operands are equal or not. If yes, then the condition becomes true. |
| <>         | Checks if the values of two operands are equal or not. If values are not equal, then the condition becomes true. |
| >          | Checks if the value of the left operand is greater than the value of the right operand. If yes, then the condition becomes true. |
| <          | Checks if the value of the left operand is less than the value of the right operand. If yes, then the condition becomes true. |
| >=         | Checks if the value of the left operand is greater than or equal to the value of the right operand. If yes, then the condition becomes true. |
| <=         | Checks if the value of the left operand is less than or equal to the value of the right operand. If yes, then the condition becomes true. |

The following example shows the usage of comparison operators.

```csharp
let x = 10
let y = 5 

Console.WriteLine("x > y : {0}", (x > y))    // True 
Console.WriteLine("x < y : {0}", (x < y));   // False 
Console.WriteLine("x >= y : {0}", (x >= y)); // True 
Console.WriteLine("x <= y : {0}", (x <= y)); // False 
Console.WriteLine("x = y : {0}", (x = y));   // False 
Console.WriteLine("x <> y : {0}", (x <> y)); // True
```
