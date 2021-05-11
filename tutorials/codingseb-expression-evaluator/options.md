---
PermaID: 100014
Name: Options
---

# Options

The **CodingSeb.ExpressionEvaluator** provides various options that can modify the way the evaluation is performed.

## Case Sensitive Evaluation

The code evaluation is case sensitive by default, let's way you want to evaluate the following different expressions.

```csharp
public static void Example1()
{
    ExpressionEvaluator evaluator = new ExpressionEvaluator();

    List<string> expressions = new List<string>()
    {
        "ABS(-3.2d);",
        "acos(-0.5d);",
        "avg(1, 2.5, -4, 6.2);",
        "Floor(4.23d);",
        "IeeeRemainder(9, 8);",
        "log10(1000d);",
    };

    foreach (var expr in expressions)
    {
        try
        {
            var result = evaluator.ScriptEvaluate(expr);
            Console.WriteLine($"{expr}\t {result}\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
```

When you execute the above code you will get the exceptions for those expressions which are not in the camel case. 

```csharp
Function [ABS] unknown in expression : [ABS(-3.2d)]
Function [acos] unknown in expression : [acos(-0.5d)]
Function [avg] unknown in expression : [avg(1, 2.5, -4, 6.2)]
Floor(4.23d);    4

Function [IeeeRemainder] unknown in expression : [IeeeRemainder(9, 8)]
Function [log10] unknown in expression : [log10(1000d)]
```

Now to make the code evaluation case insensitive, we need to set the `evaluator.OptionCaseSensitiveEvaluationActive = false`

```csharp
public static void Example2()
{
    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    evaluator.OptionCaseSensitiveEvaluationActive = false;

    List<string> expressions = new List<string>()
    {
        "ABS(-3.2d);",
        "acos(-0.5d);",
        "avg(1, 2.5, -4, 6.2);",
        "Floor(4.23d);",
        "IeeeRemainder(9, 8);",
        "log10(1000d);",
    };

    foreach (var expr in expressions)
    {
        try
        {
            var result = evaluator.ScriptEvaluate(expr);
            Console.WriteLine($"{expr}\t {result}\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
```

Let's execute the above code and you will see the following output.

```csharp
ABS(-3.2d);      3.2

acos(-0.5d);     2.0943951023931957

avg(1, 2.5, -4, 6.2);    1.425

Floor(4.23d);    4

IeeeRemainder(9, 8);     1

log10(1000d);    3
```

## Evaluate Integer Numbers As Double

By default, integers values without decimal or suffixes are evaluated as int as in C#. Let's consider the following simple expression `50/15` for evaluation.

```csharp
public static void Example3()
{
    string expression = "50/15";
    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.Evaluate(expression));
}
```

Let's execute the above code and you will see the following output.

```csharp
3
```

Now to evaluate integer as double, we need to set the `evaluator.OptionForceIntegerNumbersEvaluationsAsDoubleByDefault = true;`

```csharp
public static void Example4()
{
    string expression = "50/15";
    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    evaluator.OptionForceIntegerNumbersEvaluationsAsDoubleByDefault = true;

    Console.WriteLine(evaluator.Evaluate(expression));
}
```

Let's execute the above code and you will see the following output.

```csharp
3.3333333333333335
```
