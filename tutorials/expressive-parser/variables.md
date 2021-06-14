---
PermaID: 100003
Name: Variables
---

# Variables

The **ExpressiveParser** library provides the following standard constants, which you can use directly in the expressions or script.

| Constant         | Value                | Type            |
| :----------------| :--------------------| :---------------|
| null             | C# null value        | N/A             |
| true             | C# true value        | Boolean         |
| false            | C# false value       | Boolean         |
| e                | Power of 10          | N/A

You can also define your custom variables in a dictionary object and pass them to the `Evaluate` method as a parameter. To use your custom variables in an expression, specify the variable inside square brackets (`[]`) as shown below. 

```csharp
public static void Example1()
{
    var varibles = new Dictionary<string, object>()
    {
        { "myInt", 6 },
        { "myDouble", -3.6 },
        { "myStr", "Hello World" },
    };

    List<string> expressions = new List<string>()
    {
        "[myInt]",
        "[myDouble] + 3.0",
        "[myInt] + [myDouble]",
        "[myStr]",
        "[myStr] + \", you are learning Expression Evaluator\"",
    };

    foreach (var expression in expressions)
    {
        var exprObj = new Expression(expression);
        var result = exprObj.Evaluate(varibles);
        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
[myInt] = 6
[myDouble] + 3.0 = -0.6000000000000001
[myInt] + [myDouble] = 2.4
[myStr] = Hello World
[myStr] + ", you are learning Expression Evaluator" = Hello World, you are learning Expression Evaluator
```
