---
PermaID: 100008
Name: Operators
---

# Operators

In a programming language, operators are special symbols such as `+`, `-`, `^`, etc., that perform some action on operands. The **Dynamic Expresso** library manages a large set of C# operators, and it also respects the C# precedence rules of operators.

 - Operators allow the processing of primitive data types and objects. 
 - They take as an input one or more operands and return some value as a result. 
 
For example, operators are the signs for adding, subtracting, multiplication, and division like `+`, `-`, `*`, `/`, and their operations on the integers and the real numbers.

## Types

Below is a list of the different types of operators

| Type                                           | Operators                                                          |
|:-----------------------------------------------|:-------------------------------------------------------------------|
| [Arithmetic](#arithmetic)                      | `-`, `+`, `*`, `/`, `%`                                          |
| [Logical](#logical)                            | `&&`, `\|\|`, `!`, `^`                                               |
| [Comparison](#comparison)                      | `==`,`!=`, `>`, `<`, `>=`, `<=`                                    |
| [Assignment](#assignment)                      | `=`,                                                               |
| [String Concatenation](#string-concatenation)  | `+`                                                                |
| [Others](#others)                              | `.`, `new`, `()`, `[]`, `?:`, `??`, `typeof`                          |

### Arithmetical

In C#, the arithmetical operators are `+`, `-`, `*`, etc. They perform mathematical operations such as addition, subtraction, and multiplication respectively on numerical values. The result is also a numerical value.

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

    Interpreter interpreter = new Interpreter();

    interpreter.SetVariable("a", 10);
    interpreter.SetVariable("b", 5);            

    foreach (var expression in expressions)
    {
        var result = interpreter.Eval(expression);

        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```

Let's run the above code and you will see the following output.

```csharp
a + b = 15
a - b = 5
a * b = 50
a / b = 2
a % b = 0
```

### Logical

Logical operators or you can say Boolean operators take Boolean values and return a Boolean result (`true` or `false`).

The following table contains the logical operators in C# and the operations that they perform.

| A        | B         | !A            | A && B              | A \|\| B         | A ^ B               |
|:---------|:----------|:--------------|:--------------------|:-----------------|:--------------------|
| true     | true      | false         | true                | true             | false               |
| true     | false     | false         | false               | true             | true                |
| false    | true      | true          | false               | true             | true                |
| false    | false     | true          | false               | false            | false               |

Let's consider the following simple examples of logical operators.

```csharp
public static void Example2()
{
    List<string> expressions = new List<string>()
    {
        "a && b",
        "a || b",
        "!b",
        "true || b",
        "(5 > 7) ^ (a == b)",
    };

    Interpreter interpreter = new Interpreter();

    interpreter.SetVariable("a", true);
    interpreter.SetVariable("b", false);

    foreach (var expression in expressions)
    {
        var result = interpreter.Eval(expression);

        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```

Let's run the above code and you will see the following output.

```csharp
a && b = False
a || b = True
!b = True
true || b = True
(5 > 7) ^ (a == b) = False
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
        "a <= b",
    };

    Interpreter interpreter = new Interpreter();

    interpreter.SetVariable("a", 10);
    interpreter.SetVariable("b", 5);

    Console.WriteLine("a: {0} \t b: {1}\n", 10, 5);

    foreach (var expression in expressions)
    {
        var result = interpreter.Eval(expression);

        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```

Let's run the above code, and you will see the following output.

```csharp
a: 10    b: 5

a > b = True
a < b = False
a == b = False
a != b = True
a >= b = True
a <= b = False
```
