---
PermaID: 100003
Name: Variables
---

# Variables

The **Dynamic Expresso** library provides the following standard constants, which you can use directly in the expressions.

| Constant         | Value                | Type            |
| :----------------| :--------------------| :---------------|
| true             | C# true value        | Boolean         |
| false            | C# false value       | Boolean         |
| null             | C# null value        | N/A             |

You can also define your custom variables by using the `SetVariable` method of `Interpreter`. The following example adds two variables `x` and `y`, to use them inside an expression.

```csharp
public static void Example1()
{
    Interpreter interpreter = new Interpreter();

    interpreter.SetVariable("x", 6);
    interpreter.SetVariable("y", 5.5);

    string expression = "x + y * (x - y)";
    var result = interpreter.Eval(expression);

    Console.WriteLine("{0} = {1}", expression, result);
}
```

**Dynamic Expresso** is statically typed. It knows the type of each variable based on the value. 

```csharp
public static void Example2()
{
    Interpreter interpreter = new Interpreter();
    interpreter.SetVariable("myInt", 6);
    interpreter.SetVariable("myDouble", -3.6);
    interpreter.SetVariable("myStr", "Hello World");
    interpreter.SetVariable("myArray", new object[] { 3.5, "Test", false });

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
        var result = interpreter.Eval(expression);
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

Variables can be primitive types or custom complex types such as classes, structures, delegates, arrays, collections, etc.

You can use custom functions with delegate variables using the `Interpreter.SetFunction` method.

```csharp
public static void Example3()
{
    Func<double, double, double> pow = (x, y) => Math.Pow(x, y);
    Interpreter interpreter = new Interpreter();
    interpreter.SetFunction("pow", pow);

    List<string> expressions = new List<string>()
    {
        "pow(1, 2)",
        "pow(2, 2)",
        "pow(3, 2)",
        "pow(4, 2)",
        "pow(5, 2)",
    };

    foreach (var expression in expressions)
    {
        var result = interpreter.Eval(expression);
        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```
