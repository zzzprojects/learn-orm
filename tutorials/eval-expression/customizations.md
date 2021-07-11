---
PermaID: 100010
Name: Customizations
---

# Customizations

The **Z.Expressions.Eval** library allows you to customize the expression parser under which the C# expression is compiled. You can use different options to customize the parser, such as use caret (`^`) for exponent, includes a member from all parameters, etc.

Let's consider the following simple example with the default settings where the `^` symbol is used as the **XOR** operator.

```csharp
public static void Example1()
{
    var context = new EvalContext() 
    { 
        UseCache = false 
    };

    string expression = "4^3";
    var result = context.Execute(expression);
    Console.WriteLine("{0} = {1}", expression, result);
}
```

Let's execute the above code, and you will see the following exception.

```csharp
4^3 = 7
```

You can allow the parser to handle the `^` symbol as an exponent operator instead by using the `UseCaretForExponent` option as shown below.
 
```csharp
public static void Example2()
{
    var context = new EvalContext()
    {
        UseCaretForExponent = true
    };

    string expression = "4^3";
    var result = context.Execute(expression);
    Console.WriteLine("{0} = {1}", expression, result);

    // new operator of XOR
    expression = "4^|3";
    result = context.Execute(expression);
    Console.WriteLine("{0} = {1}", expression, result);
}
```

A new operator `^|` is available for the bitwise XOR operator. Let's execute the above code, and you will see the following output.

```csharp
4^3 = 64
4^|3 = 7
```

By default, all expressions are considered case-insensitive. For example, `Math.Pow(2, 3)` is the same as `Math.pOW(2, 3)` as shown below. 

```csharp
public static void Example3()
{
    try
    {
        List<string> expressions = new List<string>()
        {
            "Math.Pow(2, 3)",
            "Math.pOW(2, 3)"
        };

        var context = new EvalContext();

        foreach (var expression in expressions)
        {
            var result = context.Execute(expression);
            Console.WriteLine("{0}: {1}", expression, result);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
Math.Pow(2, 3): 8
Math.pOW(2, 3): 8
```

The **Z.Expressions.Eval** library provides an option to use a case-sensitive parser. You can enable the case sensitivity by using the `IsCaseSensitive` options as shown below.

```csharp
public static void Example4()
{
    try
    {
        List<string> expressions = new List<string>()
        {
            "Math.Pow(2, 3)",
            "Math.pOW(2, 3)"
        };

        var context = new EvalContext();

        context.UseCache = false;
        context.IsCaseSensitive = true;

        foreach (var expression in expressions)
        {
            var result = context.Execute(expression);
            Console.WriteLine("{0}: {1}", expression, result);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
Math.Pow(2, 3): 8
Oops! No applicable member has been found for the expression. The error occurred for expression "." at position 4 near ".pOW(2, 3)".
```
