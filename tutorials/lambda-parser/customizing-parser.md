---
PermaID: 100007
Name: Customizing Parser
---

# Customizing Parser

The **NReco.LambdaParser** library allows you to customize the expression parser. You can use the `AllowSingleEqualSign` option, which will allow the parser to consider the `=` sign of equality instead of `==`. 

Let's consider the following simple example with the default settings.

```csharp
public static void Example1()
{
    var varContext = new Dictionary<string, object>()
    {
        { "a",  10 },
        { "nullVar", null }
    };
    List<string> expressions = new List<string>()
    {
        "null == nullVar",
        "a == nullVar",
        "5 == a - 5",
        "a == 10",
    };

    var lambdaParser = new LambdaParser();

    foreach (var expression in expressions)
    {
        var result = lambdaParser.Eval(expression, varContext);
        Console.WriteLine("{0}: {1}", expression, result);
    }
}
```

Let's execute the above code, and you will see the following exception.

```csharp
null == nullVar: True
a == nullVar: False
5 == a - 5: True
a == 10: True
```

You can allow the parser to consider the `=` sign of equality instead of `==` by setting the `AllowSingleEqualSign` to `true` as shown below.

```csharp
public static void Example2()
{
    var varContext = new Dictionary<string, object>()
    {
        { "a",  10 },
        { "nullVar", null }
    };
    List<string> expressions = new List<string>()
    {
        "null = nullVar",
        "a = nullVar",
        "5 = a - 5",
        "a = 10",
        "a == 15",
    };

    var lambdaParser = new LambdaParser() { AllowSingleEqualSign = true };

    foreach (var expression in expressions)
    {
        var result = lambdaParser.Eval(expression, varContext);
        Console.WriteLine("{0}: {1}", expression, result);
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
null = nullVar: True
a = nullVar: False
5 = a - 5: True
a = 10: True
a == 15: False
```
