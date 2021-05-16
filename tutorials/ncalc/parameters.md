---
PermaID: 100006
Name: Parameters
---

# Parameters

Parameters act as variables inside the expression. You can add as many parameters as you want just by enclosing each variable in square brackets (`[]`). Parameters are useful when a value is unknown at compile-time, or when performance is important and the parsing can be saved for further calculations.

There are various ways to use parameters while evaluating your expressions.

 - Static Parameters
 - Expression Parameters
 - Dynamic Parameters
 - Multi-valued Parameters

## Static Parameters

Static parameters are values that can be defined before the evaluation of an expression. You can access the parameters defined in the expression using the `Expression.Parameters` member of type `Dictionary<string, object>`.

```csharp
public static void Example1()
{
    string expression = "[x] + [y]";

    Expression evaluator = new Expression(expression);
    evaluator.Parameters["x"] = 3;
    evaluator.Parameters["y"] = 4;

    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());
}
```

You can also use special characters like spaces, dots, and also start with digits, etc. in between square brackets when defining parameters.

```csharp
public static void Example2()
{
    string expression = "[my x] + [my y]";

    Expression evaluator = new Expression(expression);
    evaluator.Parameters["my x"] = 3;
    evaluator.Parameters["my y"] = 4;

    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());
}
```

## Expression Parameters

You can split an expression into several ones by defining expression parameters. Expression parameters are not simple values but Expression instances themselves.

The following example uses the expression as a parameter.

```csharp
public static void Example3()
{
    Expression surfaceExpression = new Expression("[width] * [length]");
    Expression volumeExpression = new Expression("[surface] * height");

    surfaceExpression.Parameters["width"] = 1.5;
    surfaceExpression.Parameters["length"] = 2.25;
    volumeExpression.Parameters["height"] = 2;
    volumeExpression.Parameters["surface"] = surfaceExpression;

    Console.WriteLine("{0}: {1}", "Volume", volumeExpression.Evaluate());
}
```

## Dynamic Parameters

Sometimes, you may need a method to evaluate complex parameters. The `Expression` class provides an `EvaluateParameter` event to perform this type of evaluation. Thus, each time a parameter is not defined in the dictionary, this event is called to try to resolve the value.

```csharp
public static void Example4()
{
    Expression expression = new Expression("Round(Pow([Pi], 2) + Pow([Pi], 2) + [X], 2)");

    expression.Parameters["Pi2"] = new Expression("Pi * [Pi]");
    expression.Parameters["X"] = 10;

    expression.EvaluateParameter += delegate (string name, ParameterArgs args)
    {
        if (name == "Pi")
            args.Result = 3.14;
    };

    Console.WriteLine(expression.Evaluate());
}
```

## Multi-valued Parameters

When parameters are `IEnumerable` and you need the result as a list after the evaluation of each value in the parameter, use the `EvaluationOptions.IterateParameters`.

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
