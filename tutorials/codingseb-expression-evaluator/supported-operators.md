---
PermaID: 100009
Name: Supported Operators and Keywords
---

# Supported Operators and Keywords

In a programming language, operators are special symbols such as `+`, `-`, `^`, etc. that perform some action on operands. The **CodingSeb.ExpressionEvaluator** library manages a large set of C# operators and it also respects the C# precedence rules of operators.

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
| [Type Conversion](#type-conversion)            | `(type)`, `is`, `typeof`, `sizeof`                           |
| [Others](#others)                              | `.`, `new`, `()`, `[]`, `?:`, `??`, `??=`                          |

### Arithmetical

In C#, the arithmetical operators are `+`, `-`, `*`, etc. and they perform mathematical operations such as addition, subtraction, and multiplication respectively on numerical values and the result is also a numerical value.

Here are some examples of arithmetic operators and their effects.


```csharp
public static void Example1()
{
    string script = @"
        int a = 10;
        int b = 20;
        
        Console.WriteLine(""a + b = {0} "", a + b);
        Console.WriteLine(""a - b = {0}"", a - b);
        Console.WriteLine(""a * b = {0}"", a * b);
                          
        Console.WriteLine(""a + b = {0}"", a + b);
                          
        Console.WriteLine(""a + b = {0}"", a + b);
    ";

    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.ScriptEvaluate(script));
}
```

Let's run the above code and you will see the following output.

```csharp
a + b = 30
a - b = -10
a * b = 200
a + b = 30
a + b = 30
```    

### Logical

Logical operators or you can say Boolean operators take Boolean values and return a Boolean result (`true` or `false`).

The following table contains the logical operators in C# and the operations that they perform.

| A        | B         | A && B              | A \|\| B         | A ^ B               |
|:---------|:----------|:--------------------|:-----------------|:--------------------|
| true     | true      | true                | true             | false               |
| true     | false     | false               | true             | true                |
| false    | true      | false               | true             | true                |
| false    | false     | false               | false            | false               |

Let's consider the following simple examples of logical operators.

```csharp
public static void Example2()
{
    string script = @"
        bool a = true;
        bool b = false;
        
        Console.WriteLine(a && b);             
        Console.WriteLine(a || b);             
        Console.WriteLine(!b);                 
        Console.WriteLine(b || true);          
        Console.WriteLine((5 > 7) ^ (a == b)); 
    ";

    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.ScriptEvaluate(script));
}
```

### Bitwise

A bitwise operator is an operator that acts on the binary representation of numeric types. 

 - In computers, all the data and particularly numerical data is represented as a series of ones and zeros. 
 - For example, number 55 in the binary numeral system is represented as 00110111.

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
public static void Example3()
{
    string script = @"
        int x = 10; 
        int y = 5; 
        
        Console.WriteLine(""x > y : "" + (x > y));  
        Console.WriteLine(""x < y : "" + (x < y));  
        Console.WriteLine(""x >= y : "" + (x >= y));
        Console.WriteLine(""x <= y : "" + (x <= y));
        Console.WriteLine(""x == y : "" + (x == y));
        Console.WriteLine(""x != y : "" + (x != y));
    ";

    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.ScriptEvaluate(script));
}
```


### Others

So far we have examined arithmetic, logical, and bitwise operators, the operator for concatenating strings, and type conversion operators, etc. Besides them, in C # there are several other operators worth mentioning.

| Operator         | Description                                                    |
|:-----------------|:---------------------------------------------------------------|
| `.` (dot)        | The access operator "." (dot) is used to access the member fields or methods of a class or object. |
| `[]` (Square brackets) |  Used to access elements of an array by index, they are the so-called indexer. Indexers are also used for accessing characters in a string. |
| `new`            | It is used to create and initialize new objects. |
| `is`             | It is used to check whether an object is compatible with a given type. |
| `??`             | It is similar to the conditional operator ?:. The difference is that it is placed between two operands and returns the left operand only if its value is not null. Otherwise, it returns the right operand. |
