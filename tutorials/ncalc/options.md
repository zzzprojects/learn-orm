---
PermaID: 100008
Name: Options
---

# Options

The **CoreCLR-NCalc** provides various options that can modify the way the evaluation is performed.

## Case Sensitive Evaluation

The code evaluation is case-sensitive by default. Let's say you want to evaluate the following different expressions.

```csharp
public static void Example1()
{
    List<string> expressions = new List<string>()
    {
        "ABS(-3.2);",
        "acos(-0.5);",
        "Floor(4.23);",
        "IeeeRemainder(9, 8);",
        "log10(1000);",
    };

    foreach (var expr in expressions)
    {
        try
        {
            Expression evaluator = new Expression(expr, EvaluateOptions.IgnoreCase);
            var result = evaluator.Evaluate();
            Console.WriteLine($"{expr}\t {result}");
        }
        catch (EvaluationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
```

When you execute the above code you will get the exceptions for those expressions which are not in the camel case. 

```csharp
Function not found ABS. Try Abs instead.
Function not found acos. Try Acos instead.
Floor(4.23);     4
Function not found IeeeRemainder. Try IEEERemainder instead.
Function not found log10. Try Log10 instead.
```

Now to make the code evaluation case insensitive, we need to pass the `EvaluateOptions.IgnoreCase` argument when creating the `Expression` instance.

```csharp
public static void Example2()
{
    List<string> expressions = new List<string>()
    {
        "ABS(-3.2);",
        "acos(-0.5);",
        "Floor(4.23);",
        "IeeeRemainder(9, 8);",
        "log10(1000);",
    };

    foreach (var expr in expressions)
    {
        try
        {
            Expression evaluator = new Expression(expr, EvaluateOptions.IgnoreCase);
            var result = evaluator.Evaluate();
            Console.WriteLine($"{expr}\t {result}");
        }
        catch (EvaluationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
```

Let's execute the above code and you will see the following output.

```csharp
ABS(-3.2);       3.2
acos(-0.5);      2.0943951023931957
Floor(4.23);     4
IeeeRemainder(9, 8);     1
log10(1000);     3
```

## Multi-valued Parameters

By default, a single value is used as a parameter. Now, if you want to use an array or of `IEnumerable` type, we need to pass the `EvaluateOptions.IterateParameters` argument when creating the `Expression` instance.

```csharp
public static void Example5()
{
    Expression expression = new Expression("x ^ c + y", EvaluateOptions.IterateParameters);

    expression.Parameters["x"] = new int[] { 1, 3, 5, 7, 9 };
    expression.Parameters["y"] = new int[] { 0, 2, 4, 6, 8 };
    expression.Parameters["c"] = 3;

    var results = (IList)expression.Evaluate();

    foreach (var result in results)
    {
        Console.WriteLine(result);
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
ABS(-3.2);       3.2
acos(-0.5);      2.0943951023931957
Floor(4.23);     4
IeeeRemainder(9, 8);     1
log10(1000);     3
```
