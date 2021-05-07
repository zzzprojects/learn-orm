---
PermaID: 100004
Name: Variables
---

# Variables

The **CodingSeb.ExpressionEvaluator** library provides the following standard constants which you can use directly in the expressions or script.

| Constant         | Value                | Type            |
| :----------------| :--------------------| :---------------|
| null             | C# null value        | N/A             |
| true             | C# true value        | Boolean         |
| false            | C# false value       | Boolean         |
| Pi               | 3.14159265358979     | Double          |
| E                | 2.71828182845905     | Double          |

The following simple example shows the usage of `Pi` and `E` constants.

```csharp
public static void Example1()
{
    string expression = "Pi + E";
    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.Evaluate(expression));
}
```

You can also define your custom variables in a dictionary and assign them to the `Variables` property.

```csharp
public static void Example2()
{
    ExpressionEvaluator evaluator = new ExpressionEvaluator();

    evaluator.Variables = new Dictionary<string, object>()
    {
        { "myInt", 6 },
        { "myDouble", -3.6 },
        { "myStr", "Hello World" },
        { "myArray", new object[] { 3.5, "Test", false } },
    };

    List<string> expressions = new List<string>()
    {
        "myInt + myDouble",
        "myStr + \", you are learning Expression Evaluator\"",
        "myArray.Length",
        "myArray[0]",
        "myArray[1].Length",
        "myArray[2] || true",
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
myInt + myDouble
         2.4

myStr + ", you are learning Expression Evaluator"
         Hello World, you are learning Expression Evaluator

myArray.Length
         3

myArray[0]
         3.5

myArray[1].Length
         4

myArray[2] || true
         True

Multiply(3.54, 13.9)
         17.44
```

The **CodingSeb.ExpressionEvaluator** also allows you to store callable delegates in variables which can very useful as shown below.

```csharp
public static void Example3()
{
    ExpressionEvaluator evaluator = new ExpressionEvaluator();

    evaluator.Variables = new Dictionary<string, object>()
    {
        { "Multiply", new Func<double, double, double>((x, y) => x * y)},
        { "Print", new Action<string>(name => Console.WriteLine($"Hello {name} !!!"))},
    };

    List<string> expressions = new List<string>()
    {
        "Multiply(3.54, 13.9)",
        "Print(\"Smith\")"
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
Multiply(3.54, 13.9)
         17.44

Hello Smith !!!
Print("Smith")
```
