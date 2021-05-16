---
PermaID: 100007
Name: Exception Handling
---

# Exception Handling

Exception handling helps you deal with any unexpected or exceptional situations that occur when a program is running. You can use the `try`, `catch`, and `finally` keywords to try actions that may not succeed, to handle failures, and to clean up resources afterward.

When the expression has a syntax error, the evaluation will throw an `EvaluationException`.

```csharp
public static void Example1()
{
    try
    {
        string expression = "[x] + [y] +";

        Expression evaluator = new Expression(expression);
        evaluator.Parameters["x"] = 3;
        evaluator.Parameters["y"] = 4;

        Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());
    }
    catch (EvaluationException e)
    {
        Console.WriteLine("Error catched: " + e.Message);
    }
}
```

You can also detect syntax errors before evaluating the expression by calling the `HasErrors()` method as shown below.

```csharp
public static void Example2()
{
    try
    {
        string expression = "[x] + [y] +";

        Expression evaluator = new Expression(expression);
        evaluator.Parameters["x"] = 3;
        evaluator.Parameters["y"] = 4;

        if (!evaluator.HasErrors())
        {
            Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());
        }
        else
        {
            Console.WriteLine(evaluator.Error);
        }
        
    }
    catch (EvaluationException e)
    {
        Console.WriteLine("Error catched: " + e.Message);
    }
}
```
