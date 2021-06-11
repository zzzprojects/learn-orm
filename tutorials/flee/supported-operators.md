---
PermaID: 100007
Name: Supported Operators
---

# Supported Operators

In a programming language, operators are special symbols such as `+`, `-`, `*`, etc., that perform some action on operands. The **Flee** library manages a large set of C# operators, and it also respects the C# precedence rules of operators.

 - Operators allow the processing of primitive data types, and objects. 
 - They take as an input one or more operands and return some value as a result. 
 
For example, operators are the signs for adding, subtracting, multiplication, and division like `+`, `-`, `*`, `/`, and their operations on the integers and the real numbers.

## Types

Below is a list of the different types of operators

| Type                                           | Operators                                                          |
|:-----------------------------------------------|:-------------------------------------------------------------------|
| [Arithmetic](#arithmetic)                      | `-`, `+`, `*`, `/`, `%`                                |
| [Logical](#logical)                            | `And`, `Or`, `Not`, `Xor`                                               |
| [Comparison](#comparison)                      | `=`,`<>`, `>`, `<`, `>=`, `<=`                                    |
| [String Concatenation](#string-concatenation)  | `+`                                                                |

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
        "b / a",
        "a % b"
    };

    ExpressionContext context = new ExpressionContext();

    context.Variables["a"] = 6.5;
    context.Variables["b"] = 10.0;

    foreach (var expression in expressions)
    {
        IDynamicExpression eDynamic = context.CompileDynamic(expression);
        Object result = eDynamic.Evaluate();
        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```

Let's run the above code and you will see the following output.

```csharp
a + b = 16.5
a - b = -3.5
a * b = 65
b / a = 1.5384615384615385
a % b = 6.5
```    

### Logical

Logical operators or you can say Boolean operators take Boolean values and return a Boolean result (`true` or `false`).

The following table contains the logical operators in C# and the operations that they perform.

| A        | B         | A And B             | A Or B           | A Xor B             |
|:---------|:----------|:--------------------|:-----------------|:--------------------|
| true     | true      | true                | true             | false               |
| true     | false     | false               | true             | true                |
| false    | true      | false               | true             | true                |
| false    | false     | false               | false            | false               |

Let's consider the following simple examples of logical operators.

```csharp
a And b = False
a Or b = True
Not b = True
true Or b = True
a Xor b = True
```

### Comparison Operators

Comparison operators are used to comparing two or more operands. C# supports the following comparison operators.

- greater than (`>`)
- less than (`<`)
- greater than or equal to (`>=`)
- less than or equal to (`<=`)
- equality (`=`)
- difference (`<>`)

The following example shows the usage of comparison operators.

```csharp
public static void Example3()
{
    List<string> expressions = new List<string>()
    {
        "a > b",
        "a < b",
        "a = b",
        "a >= b",
        "a <= b",
        "a <> b",
    };

    ExpressionContext context = new ExpressionContext();

    context.Variables["a"] = 6.5;
    context.Variables["b"] = 10.0;

    foreach (var expression in expressions)
    {
        IDynamicExpression eDynamic = context.CompileDynamic(expression);
        Object result = eDynamic.Evaluate();
        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```
