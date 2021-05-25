---
PermaID: 100012
Name: Calculation Engine
---

# Calculation Engine

The `CalculationEngine` allows you to create a network of expressions. The engine allows expressions to reference the results of other expressions in the engine, tracks dependencies, and recalculateis in natural order.

```csharp
public static void Example1()
{
    CalculationEngine engine = new CalculationEngine();
    ExpressionContext context = new ExpressionContext();
    VariableCollection variables = context.Variables;

    context.Variables.Add("x", 5);
    context.Variables.Add("y", 10);

    engine.Add("a", "x * 2", context);
    engine.Add("b", "y + 20", context);
    engine.Add("c", "a + b", context);

    int result = engine.GetResult<int>("c");
    Console.WriteLine("c = {0}", result);

    variables["x"] = 15;
    engine.Recalculate("a");

    result = engine.GetResult<int>("c");
    Console.WriteLine("c = {0}", result);
}
```

Let's execute the above code, and you will see the following output.

```csharp
c = 40
c = 60
```
