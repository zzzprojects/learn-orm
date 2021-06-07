---
PermaID: 100004
Name: Operators
---

# Operators

In a programming language, operators are special symbols such as `+`, `-`, `^`, etc., that perform some action on operands. The **NReco.LambdaParser** library manages a large set of C# operators and it also respects the C# precedence rules of operators.

 - Operators allow the processing of primitive data types, and objects. 
 - They take as an input one or more operands and return some value as a result. 
 
For example, operators are the signs for adding, subtracting, multiplication, and division like `+`, `-`, `*`, `/`, and the operations they perform on the integers and the real numbers.

## Types

Below is a list of the different types of operators

| Type                                           | Operators                                                          |
|:-----------------------------------------------|:-------------------------------------------------------------------|
| [Arithmetic](#arithmetic)                      | `-`, `+`, `*`, `/`, `%`                                           |
| [Logical](#logical)                            | `&&`, `\|\|`, `!`                                                 |
| [Comparison](#comparison)                      | `==`,`!=`, `>`, `<`, `>=`, `<=`                                  |
| [String Concatenation](#string-concatenation)  | `+`                                                                |

### Arithmetical

In C#, the arithmetical operators are `+`, `-`, `*`, etc., and they perform mathematical operations such as addition, subtraction, and multiplication respectively on numerical values, and the result is also a numerical value.

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

| A        | B         | A && B              | A \|\| B         |
|:---------|:----------|:--------------------|:-----------------|
| true     | true      | true                | true             |
| true     | false     | false               | true             |
| false    | true      | false               | true             |
| false    | false     | false               | false            |

Let's consider the following simple examples of logical operators.

```csharp
public static void Example2()
{
    var varContext = new Dictionary<string, object>()
    {
        { "a", true },
        { "b", false },
    };

    List<string> expressions = new List<string>()
    {
        "a || b",
        "a && b",
        "!b",
        "true || b",
    };

    var lambdaParser = new NReco.Linq.LambdaParser();

    foreach (var expression in expressions)
    {
        var result = lambdaParser.Eval(expression, varContext);
        Console.WriteLine("{0} = {1}", expression, result);
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
    var varContext = new Dictionary<string, object>()
    {
        { "a", 10 },
        { "b", 6 },
    };

    List<string> expressions = new List<string>()
    {
        "a > b",
        "a < b",
        "a == b",
        "a != b",
        "a >= b",
        "a <= b",
    };

    var lambdaParser = new NReco.Linq.LambdaParser();

    foreach (var expression in expressions)
    {
        var result = lambdaParser.Eval(expression, varContext);
        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```
