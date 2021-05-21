---
PermaID: 100003
Name: Variables
---

# Variables

The **Flee** library provides the following standard constants, which you can use directly in the expressions or script.

| Constant         | Value                | Type            |
| :----------------| :--------------------| :---------------|
| true             | C# true value        | Boolean         |
| false            | C# false value       | Boolean         |

You can also define your custom variables by using the `Variables` property of `ExpressionContext`.

```csharp
public static void Example1()
{
    ExpressionContext context = new ExpressionContext();
    context.Variables["myInt"] = 6;
    context.Variables["myDouble"] = -3.6;
    context.Variables["myStr"] = "Hello World";
    context.Variables["myArray"] = new object[] { 3.5, "Test", false };

    List<string> expressions = new List<string>()
    {
        "myInt + myDouble",
        "myStr + \", you are learning Expression Evaluator\"",
        "myArray.Length",
        "myArray[0]",
        "myArray[2]",
    };

    foreach (var expression in expressions)
    {
        IDynamicExpression eDynamic = context.CompileDynamic(expression);

        Object result = eDynamic.Evaluate();
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
myArray[2] = False
```
