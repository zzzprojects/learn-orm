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

 - The `VariableCollection` object that is returned is a dictionary of strings to objects. 
 - The first character of a variable name must be a letter or underscore and the following characters can be either letters, underscores, or numbers.

The following example adds two variables `x` and `y` and used them inside an expression.

```csharp
public static void Example1()
{
    ExpressionContext context = new ExpressionContext();

    context.Variables["x"] = 6;
    context.Variables["y"] = 5.5;

    IDynamicExpression e = context.CompileDynamic("x + y * (x - y)");
}
```

**Flee** is statically typed, it knows the type of each variable based on the value. 

```csharp
public static void Example2()
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

You can also use expressions as variables in other expressions. When the top-level expression is evaluated, each sub-expression will be evaluated to provide the variable's value.

```csharp
public static void Example3()
{
    ExpressionContext context = new ExpressionContext();
    context.Variables.Add("a", 64);
    IDynamicExpression e1 = context.CompileDynamic("a / 8");

    context = new ExpressionContext();
    context.Variables.Add("a", 3);
    IDynamicExpression e2 = context.CompileDynamic("a * a");

    context = new ExpressionContext();
    context.Variables.Add("x", e1);
    context.Variables.Add("y", e2);

    IDynamicExpression eDynamic = context.CompileDynamic("x + y");
    Object result = eDynamic.Evaluate();
    Console.WriteLine(result);
}
```

