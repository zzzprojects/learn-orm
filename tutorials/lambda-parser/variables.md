---
PermaID: 100003
Name: Variables
---

# Variables

The **NReco.LambdaParser** library provides the following standard constants, which you can use directly in the expressions or script.

| Constant         | Value                | Type            |
| :----------------| :--------------------| :---------------|
| null             | C# null value        | N/A             |
| true             | C# true value        | Boolean         |
| false            | C# false value       | Boolean         |

You can also define your custom variables in a dictionary object and pass them to the `Eval` method as a parameter.

```csharp
public static void Example1()
{
    var varContext = new Dictionary<string, object>()
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

    var lambdaParser = new NReco.Linq.LambdaParser();

    foreach (var expression in expressions)
    {
        var result = lambdaParser.Eval(expression, varContext);
        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
myInt + myDouble = 2.4
myStr + ", you are learning Expression Evaluator" = Hello World, you are learning Expression Evaluator
myArray.Length = 3
myArray[0] = 3.5
myArray[1].Length = 4
myArray[2] || true = True
```

The **NReco.LambdaParser** also allows you to store callable delegates in variables which can be very useful, as shown below.

```csharp
public static void Example2()
{
    var varContext = new Dictionary<string, object>()
    {
        { "Multiply", new Func<double, double, double>((x, y) => x * y)},
        { "Print", new Action<string>(name => Console.WriteLine($"Hello {name} !!!"))},
    };

    List<string> expressions = new List<string>()
    {
        "Multiply(3.54, 13.9)",
        "Print(\"Smith\")"
    };

    var lambdaParser = new NReco.Linq.LambdaParser();

    foreach (var expression in expressions)
    {
        var result = lambdaParser.Eval(expression, varContext);
        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
Multiply(3.54, 13.9) = 49.206
Hello Smith !!!
Print("Smith") =
```
