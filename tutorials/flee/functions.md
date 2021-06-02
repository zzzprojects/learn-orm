---
PermaID: 100008
Name: Functions
---

# Functions

The **Flee** library allows you to use functions in your expressions. 

 - You can simply define your functions in a class or use the functions of an existing class. 
 - When the expression is evaluated, the functions are called using IL instructions like in a compiled assembly.

Let's consider the following class, which contains various static functions.

```csharp
public static class Calculator
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    public static int Divide(int a, int b)
    {
        return a / b;
    }
}
```

The following example shows how to call the above-defined functions in your expressions.

```csharp
public static void Example1()
{
    ExpressionContext context = new ExpressionContext();
    context.Imports.AddType(typeof(Calculator));

    List<string> expressions = new List<string>()
    {
        "Multiply(2, 3)",
        "Add(5, 6)",
        "Subtract(10, 5)",
        "Divide(60, 6)",
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
Multiply(2, 3) = 6
Add(5, 6) = 11
Subtract(10, 5) = 5
Divide(60, 6) = 10
```

The **Flee** library also supports calling functions with a variable number of arguments. Let's add the following `Sum` function to the `Calculator` class.

```csharp
public static int Sum(params int[] args)
{
    int sum = 0;

    foreach (int i in args)
        sum += i;

    return sum;
}-
```

**Flee** will detect calls to functions marked with the `params` keyword and will package all given arguments into an array of the `params` type.

The following example shows how to call functions with several parameters.

```csharp
public static void Example2()
{
    ExpressionContext context = new ExpressionContext();
    context.Imports.AddType(typeof(Calculator));

    List<string> expressions = new List<string>()
    {
        "Sum(2, 3, 10)",
        "Sum(1, 2, 3, 4, 5, 6)",
        "Sum(2, 4, 6, 8, 10, 12, 14, 16, 18, 20)"
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
Sum(2, 3, 10) = 15
Sum(1, 2, 3, 4, 5, 6) = 21
Sum(2, 4, 6, 8, 10, 12, 14, 16, 18, 20) = 110
```
