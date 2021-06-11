---
PermaID: 100004
Name: Parameters
---

# Parameters

Parameters act as variables inside the expression. You can add as many parameters as you want. 

 - Parameters are values that can be defined before the evaluation of an expression. 
 - Parameters are useful when a value is unknown at compile-time or when performance is important, and the parsing can be saved for further calculations.

The following example uses parameters in an expression.

```csharp
public static void Example1()
{
    Interpreter interpreter = new Interpreter();

    var parameters = new[] 
    {
        new Parameter("x", 23),
        new Parameter("y", 7)
    };

    string expression = "x + y * (x - y)";
    var result = interpreter.Eval(expression, parameters);

    Console.WriteLine("{0} = {1}", expression, result);
}
```

You can parse an expression once and invoke it multiple times with different parameter values.

The following example shows how to parse an expression and invoke it multiple times by using the `interpreter.Parse` and `interpreter.Invoke` methods respectively.

```csharp
public static void Example2()
{
    Interpreter interpreter = new Interpreter();

    var parameters = new[]
    {
        new Parameter("x", 23),
        new Parameter("y", 7)
    };

    var myFunc = interpreter.Parse("x + y", parameters);

    Console.WriteLine(myFunc.Invoke(2, 4));
    Console.WriteLine(myFunc.Invoke(21, -4));
    Console.WriteLine(myFunc.Invoke(3, 6));
    Console.WriteLine(myFunc.Invoke(17, 9));
}
```
