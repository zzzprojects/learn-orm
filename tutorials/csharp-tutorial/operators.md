---
PermaID: 100026
Name: Operators
---

# Operators

In a programming language, operators are special symbols such as `+`, `-`, `^`, etc. that perform some action on operands.

 - Operators allow the processing of primitive data types and objects. 
 - They take as an input one or more operands and return some value as a result. 
 
For example, operators are the signs for adding, subtracting, multiplication, and division like `+`, `-`, `*`, `/`, and the operations they perform on the integers and the real numbers.

## Types

Below is a list of the different types of operators

| Type                                           | Operators                                                          |
|:-----------------------------------------------|:-------------------------------------------------------------------|
| [Arithmetic](#arithmetic)                      | `-`, `+`, `*`, `/`, `%`, `++`, `--`                                |
| [Logical](#logical)                            | `&&`, `\|\|`, `!`, `^`                                               |
| [Bitwise](#bitwise)                            | `&`, `\|`, `^`, `~`, `<<`, `>>`                                     |
| [Comparison](#comparison)                      | `==`,`!=`, `>`, `<`, `>=`, `<=`                                    |
| [Assignment](#assignment)                      | `=`, `+=`, `-=`, `*=`, `/=`, `%=`, `&=`, `\|=`, `^=`, `<<=`, `>>=`  |
| [String Concatenation](#string-concatenation)  | `+`                                                                |
| [Type Conversion](#type-conversion)            | `(type)`, `as`, `is`, `typeof`, `sizeof`                           |
| [Others](#others)                              | `.`, `new`, `()`, `[]`, `?:`, `??`, `??=`                          |

### Arithmetical

In C#, the arithmetical operators are `+`, `-`, `*`, etc.  and they perform mathematical operations such as addition, subtraction, and multiplication respectively on numerical values and the result is also a numerical value.

Here are some examples of arithmetic operators and their effects.

```csharp
int a = 10;
int b = 20;

Console.WriteLine("a + b = {0}", a + b);
Console.WriteLine("a - b = {0}", a - b);
Console.WriteLine("a * b = {0}", a * b);

Console.WriteLine("a + (b++) = {0}", a + (b++));
Console.WriteLine("a + b = {0}", a + b);

Console.WriteLine("a + (++b) = {0}", a + (++b));
Console.WriteLine("a + b = {0}", a + b);
```

Let's run the above code and you will see the following output.

```csharp
a + b = 30
a - b = -10
a * b = 200
a + (b++) = 30
a + b = 31
a + (++b) = 32
a + b = 32
```

The division operator `/` has a different effect on integer and real numbers. When we divide an integer by an integer (like int, long, and sbyte) the returned value is an integer. Such division is called an integer division. 

Here are some examples of division operators and their effect when using integer division.

```csharp
int squarePerimeter = 17;
int squareSideInt = squarePerimeter / 4;
Console.WriteLine(squareSideInt);

double squareSideDouble = squarePerimeter / 4.0;
Console.WriteLine(squareSideDouble);         
```

Let's run the above code and you will see the following output.

```csharp
4
4.25
```
Integer division by `0` is not allowed and causes a runtime `DivideByZeroException` exception. 

The remainder of the integer division of integers can be obtained by the operator `%`. For example, 


```csharp
7 % 3 = 1
–10 % 2 = 0
```

When dividing two real numbers or two numbers, one of which is real (e.g. float, double, etc.), a real division is done (not integer), and a result is a real number with a whole and a fractional part. For example: 

```csharp
5.0 / 2 = 2.5
```

In the division of real numbers, it is allowed to divide by `0.0` and respectively the result is `∞` (Infinity), `-∞` (-Infinity) or `NaN` (invalid value).

### Logical

Logical operators or you can say Boolean operators take Boolean values and return a Boolean result (`true` or `false`). The basic Boolean operators are `&&` (and), `||` (or), `^` (exclusive OR) and `!` (logical negation).

The following table contains the logical operators in C# and the operations that they perform.

| A        | B         | !A            | A && B              | A \|\| B         | A ^ B               |
|:---------|:----------|:--------------|:--------------------|:-----------------|:--------------------|
| true     | true      | false         | true                | true             | false               |
| true     | false     | false         | false               | true             | true                |
| false    | true      | true          | false               | true             | true                |
| false    | false     | true          | false               | false            | false               |

Let's consider the following simple examples of logical operators.

```csharp
bool a = true;
bool b = false;

Console.WriteLine(a && b);             // False
Console.WriteLine(a || b);             // True
Console.WriteLine(!b);                 // True
Console.WriteLine(b || true);          // True
Console.WriteLine((5 > 7) ^ (a == b)); // False
```

### Bitwise

A bitwise operator is an operator that acts on the binary representation of numeric types. 

 - In computers, all the data and particularly numerical data is represented as a series of ones and zeros. 
 - For example, number 55 in the binary numeral system is represented as 00110111.

Here is an example of using bitwise operators. The binary representation of the numbers, and the results of the bitwise operators are shown in the comments.

```csharp
byte a = 3;                // 0000 0011 = 3 
byte b = 5;                // 0000 0101 = 5 

Console.WriteLine(a | b);  // 0000 0111 = 7 
Console.WriteLine(a & b);  // 0000 0001 = 1 
Console.WriteLine(a ^ b);  // 0000 0110 = 6 
Console.WriteLine(~a & b); // 0000 0100 = 4 
Console.WriteLine(a << 1); // 0000 0110 = 6 
Console.WriteLine(a << 2); // 0000 1100 = 12 
Console.WriteLine(a >> 1); // 0000 0001 = 1
```

### Comparison Operators

Comparison operators are used to comparing two or more operands. C# supports the following comparison operators.

- greater than (>)
- less than (<)
- greater than or equal to (>=)
- less than or equal to (<=)
- equality (==)
- difference (!=)

The following example shows the usage of comparison operators.

```csharp
int x = 10; 
int y = 5; 

Console.WriteLine("x > y : " + (x > y));   // True 
Console.WriteLine("x < y : " + (x < y));   // False 
Console.WriteLine("x >= y : " + (x >= y)); // True 
Console.WriteLine("x <= y : " + (x <= y)); // False 
Console.WriteLine("x == y : " + (x == y)); // False 
Console.WriteLine("x != y : " + (x != y)); // True
```

### Assignment

The assignment operator `=` assigns its right-hand value to its left-hand variable, property, or indexer. 

Here is an example to show the usage of the assignment operator.

```csharp
int x = 6;
string helloString = "Hello string.";
int y = x + 3;

Console.WriteLine(x);            // 6       
Console.WriteLine(helloString);  // Hello string.
Console.WriteLine(y);            // 9
```

Besides the assignment operator, there are also compound assignment operators such as, `+=`, `-=`, `*=` and `/=` etc. They help to reduce the volume of the code by typing two operations together with an operator.

```csharp
int x = 2; 
int y = 4; 

x *= y; // Same as x = x * y; 

Console.WriteLine(x); // 8
```

### String Concatenation 

The operator `+` is used to join strings. It concatenates two or more strings and returns the result as a new string. 

```csharp
string csharp = "C# "; 
string tutorial = "Tutorial."; 

string csharpTutorial = csharp + tutorial; 
Console.WriteLine(csharpTutorial);    // C# Tutorial.

string csharp8 = csharp + " " + 8; 
Console.WriteLine(csharp8);           // C# 8
```

If at least one of the arguments in the expression is of type string, and there are other operands of a type different from a string, they will be automatically converted to type string, which allows successful string concatenation.

### Type Conversion

Generally, operators work with the same data type, in some cases, you might have different data types and you will need to perform some operations. To perform some operation on variables of two different data types we need to convert both to the same data type. Type conversion (typecasting) can be implicit and explicit.

#### Implicit Type Conversion

Implicit type conversion is possible when converting from a lower range type to a larger range, and there is no risk of data loss during the conversion. For example, converting data from `int` to `long`.

Here is an example of implicit type conversion.

```csharp
int myInt = 7; 
Console.WriteLine(myInt); // 7 

long myLong = myInt; 
Console.WriteLine(myLong); // 7

Console.WriteLine(myLong + myInt); // 14
```

#### Explicit Type Conversion

Explicit type conversion is used whenever there is a possibility of data loss. When converting floating-point type to integer type there is always a loss of data coming from the elimination of the fractional part, and an explicit conversion is obligatory (e.g. double too long). 

 - To make such a conversion it is necessary to use the operator for data conversion (type). 
 - There may also be data loss when converting a type with a wider range to a type with a narrower one (double to float or long to int).

The following example illustrates the use of explicit type conversion, and data loss that may occur in some cases.

```csharp
double myDouble = 5.1d; 
Console.WriteLine(myDouble);     // 5.1 

long myLong = (long)myDouble; 
Console.WriteLine(myLong);       // 5 

myDouble = 5e9d;                 // 5 * 10^9 
Console.WriteLine(myDouble);     // 5000000000 
int myInt = (int)myDouble; 
Console.WriteLine(myInt);        // -2147483648 
Console.WriteLine(int.MinValue); // -2147483648
```

### Others

So far we have examined arithmetic, logical, and bitwise operators, the operator for concatenating strings, and type conversion operators, etc. Besides them, in C # there are several other operators worth mentioning.

| Operator         | Description                                                    |
|:-----------------|:---------------------------------------------------------------|
| `.` (dot)        | The access operator "." (dot) is used to access the member fields or methods of a class or object. |
| `[]` (Square brackets) |  Used to access elements of an array by index, they are the so-called indexer. Indexers are also used for accessing characters in a string. |
| `()` (brackets)  | used to override the priority of execution of expressions and operators. |
| `new`            | It is used to create and initialize new objects. |
| `is`             | It is used to check whether an object is compatible with a given type. |
| `??`             | It is similar to the conditional operator ?:. The difference is that it is placed between two operands and returns the left operand only if its value is not null. Otherwise, it returns the right operand. |
| `??=`            | Assigns the value of its right-hand operand to its left-hand operand only if the left-hand operand evaluates to null. The ??= operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null. |

All the examples related to the operators are available in the `Operators.cs` file of the source code. Download the source code and try out all the examples for better understanding.
