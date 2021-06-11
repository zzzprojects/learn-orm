---
PermaID: 100004
Name: Supported Data Types
---

# Supported Data Types

The primitive data types are predefined by the language, and they are named by reserved keywords. They represent the basic types of the language.

The **Flee** manages the following list of C# primary types.

 - object
 - string
 - bool
 - byte
 - char
 - decimal
 - double
 - short
 - int
 - long
 - sbyte
 - float
 - ushort
 - uint
 - ulong
 - void

You can add additional types by using the `context.Imports.AddType` method. The following example allows the expression to use all static public members of `System.Math`.

```csharp
public static void Example1()
{
    ExpressionContext context = new ExpressionContext();
    context.Imports.AddType(typeof(Math));

    List<string> expressions = new List<string>()
    {
        "Pow(2, 3)",
        "Sqrt(81)",
        "Pi"
    };

    foreach (var expression in expressions)
    {
        IDynamicExpression eDynamic = context.CompileDynamic(expression);

        Object result = eDynamic.Evaluate();
        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```

As you can see that we have used the `Imports` property to make all the static members of the `System.Math` class available to the expression.

Let's execute the above code, and you will see the following output.

```csharp
Pow(2, 3) = 8
Sqrt(81) = 9
Pi = 3.141592653589793
```
