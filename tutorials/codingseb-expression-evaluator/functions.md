---
PermaID: 100006
Name: Functions
---

# Functions

The **CodingSeb.ExpressionEvaluator** library provides many functions from `System.Math` which you can use directly in your expression or script.

The following example shows built-in functions which you can use directly.

```csharp
public static void Example1()
{
    ExpressionEvaluator evaluator = new ExpressionEvaluator();

    List<string> expressions = new List<string>()
    {
        "Abs(-3.2d)",
        "Acos(-0.5d)",
        "Avg(1, 2.5, -4, 6.2)",
        "Floor(4.23d)",
        "IEEERemainder(9, 8)",
        "Log10(1000d)",
    };

    foreach (var expr in expressions)
    {
        var result = evaluator.Evaluate(expr);
        Console.WriteLine($"{expr} \n\t {result}\n");
    }
}
```

Let's execute the above code and you will see the following output.

```csharp
Abs(-3.2d)
         3.2

Acos(-0.5d)
         2.0943951023931957

Avg(1, 2.5, -4, 6.2)
         1.425

Floor(4.23d)
         4

IEEERemainder(9, 8)
         1

Log10(1000d)
         3
```

You can also add an extension method for the evaluation by using `StaticTypesForExtensionsMethods`. Let's suppose we have a simple string extension method as shown below.

```csharp
public static class StringExtendedMethods
    {
        public static string AddExtended(this string str)
        {
            return str + " extended";
        }
    }
```

Now to add the above extension method to use inside an expression or script, we will use the `StaticTypesForExtensionsMethods` property as shown below.

```csharp
public static void Example2()
{

    ExpressionEvaluator evaluator = new ExpressionEvaluator(new Dictionary<string, object>()
    {
        { "str", "Samle string" }
    });

    evaluator.StaticTypesForExtensionsMethods.Add(typeof(StringExtendedMethods));

    List<string> expressions = new List<string>()
    {
        "str.AddExtended()",
    };

    foreach (var expr in expressions)
    {
        var result = evaluator.Evaluate(expr);
        Console.WriteLine($"{expr} \n\t {result}\n");
    }
}
```

Let's execute the above code and you will see the following output.

```csharp
str.AddExtended()
         Samle string extended
```
