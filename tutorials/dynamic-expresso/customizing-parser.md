---
PermaID: 100013
Name: Customizing Parser
---

# Customizing Parser

The **Dynamic Expresso** library allows you to customize the expression parser. You can use different options to customize the parser, such as `EnableReflection`, `EnableAssignment`, etc. 

Let's consider the following simple example with the default settings.

```csharp
public static void Example1()
{
    try
    {
        Interpreter interpreter = new Interpreter();

        string expression = "typeof(double).GetMethods()";
        var result = interpreter.Eval(expression);
        Console.WriteLine("{0} = {1}", expression, result);

        expression = "typeof(double).Assembly";
        result = interpreter.Eval(expression);
        Console.WriteLine("{0} = {1}", expression, result);
    }
    catch (ParseException e)
    {

        Console.WriteLine(e.Message);
    }
}
```

Let's execute the above code, and you will see the following exception.

```csharp
Reflection expression not allowed. To enable reflection use Interpreter.EnableReflection(). (at index 0).
```

From version 1.3, some reflection methods are blocked to prevent malicious users to call unexpected types or assemblies within an expression.

You can allow the parser to handle the reflection methods by calling the `interpreter.EnableReflection();` method before evaluation.
 
```csharp
public static void Example2()
{
    try
    {
        Interpreter interpreter = new Interpreter();
        interpreter.EnableReflection();

        string expression = "typeof(double).GetMethods()";
        var result = interpreter.Eval(expression);
        Console.WriteLine("{0} = {1}", expression, result);

        expression = "typeof(double).Assembly";
        result = interpreter.Eval(expression);
        Console.WriteLine("{0} = {1}", expression, result);
    }
    catch (ParseException e)
    {

        Console.WriteLine(e.Message);
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
typeof(double).GetMethods() = System.Reflection.MethodInfo[]
typeof(double).Assembly = System.Private.CoreLib, Version=5.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
```

By default, assignment operators are enabled, to ensure that the user cannot change some values that you don't expect, you can disable assignment operators by using the `interpreter.EnableAssignment(AssignmentOperators.None);`.

```csharp
public static void Example3()
{
    try
    {
        Interpreter interpreter = new Interpreter();
        interpreter.EnableAssignment(AssignmentOperators.None);
        int x = 10;
        interpreter.SetVariable("x", x);

        string expression = "x = 13;";
        var result = interpreter.Eval(expression);
        Console.WriteLine("After evaluation, x = {0}", x);
    }
    catch (ParseException e)
    {
        Console.WriteLine(e.Message);
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
Assignment operator '=' not allowed (at index 2).
```
