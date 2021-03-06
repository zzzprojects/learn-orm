---
PermaID: 100009
Name: Supported Operators
---

# Supported Operators

In a programming language, operators are special symbols such as `+`, `-`, `^`, etc., that perform some action on operands. The **Z.Expressions.Eval** library manages almost all C# operators and it also respects the C# precedence rules of operators.

 - Operators allow the processing of primitive data types, and objects. 
 - They take as an input one or more operands and return some value as a result. 
 
For example, operators are the signs for adding, subtracting, multiplication, and division like `+`, `-`, `*`, `/`, and the operations they perform on the integers and the real numbers.

## Types

Below is a list of the different types of operators which are most commonly used. 

| Type                                           | Operators                                                          |
|:-----------------------------------------------|:-------------------------------------------------------------------|
| [Arithmetic](#arithmetic)                      | `-`, `+`, `*`, `/`, `%`                              |
| [Logical](#logical)                            | `&&`, `||`, `!`, `^`                                               |
| [Bitwise](#bitwise)                            | `&`, `|`, `^`, `~`, `<<`, `>>`                                     |
| [Comparison](#comparison)                      | `==`,`!=`, `>`, `<`, `>=`, `<=`                                    |
| [Assignment](#assignment)                      | `=`, `+=`, `-=`, `*=`, `/=`, `%=`, `&=`, `\|=`, `^=`, `<<=`, `>>=`  |
| [String Concatenation](#string-concatenation)  | `+`                                                                |
| [Type Conversion](#type-conversion)            | `(type)`, `is`, `typeof`, `sizeof`                           |
| [Others](#others)                              | `.`, `new`, `()`, `[]`, `?:`, `??`, `??=`                          |

### Arithmetical

In C#, the arithmetical operators are `+`, `-`, `*`, etc., and they perform mathematical operations such as addition, subtraction, and multiplication respectively on numerical values, and the result is also a numerical value.

Here are some examples of arithmetic operators and their effects.


```csharp
public static void Example1()
{
    List<string> expressions = new List<string>()
    {
        "a + b",
        "a - b",
        "a * b",
        "a / b",
        "a % b",
    };

    foreach (var expression in expressions)
    {
        var result = Eval.Execute<int>(expression, new { a = 10, b = 5 });
        Console.WriteLine("{0}: {1}", expression, result);
    }
}
```

Let's run the above code and you will see the following output.

```csharp
a + b: 16
a - b: 4
a * b: 60
a / b: 1
a % b: 4
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
    List<string> expressions = new List<string>()
    {
        "a && b",
        "a || b",
        "a ^ b",
        "!b",
        "true || b",
        "(5 > 7) ^ (a == b)"
    };

    foreach (var expression in expressions)
    {
        var result = Eval.Execute<bool>(expression, new { a = true, b = false });
        Console.WriteLine("{0}: {1}", expression, result);
    }
}
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
public static void Example3()
{
    List<string> expressions = new List<string>()
    {
        "a > b",
        "a < b",
        "a == b",
        "a != b",
        "a >= b",
        "a <= b"
    };

    foreach (var expression in expressions)
    {
        var result = Eval.Execute<bool>(expression, new { a = 10, b = 6 });
        Console.WriteLine("{0}: {1}", expression, result);
    }
}
```

