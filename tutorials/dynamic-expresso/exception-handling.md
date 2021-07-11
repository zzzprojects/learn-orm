---
PermaID: 100012
Name: Exception Handling
---

# Exception Handling

Exception handling helps you deal with any unexpected or exceptional situations that occur when a program is running. For example, you can use the `try`, `catch`, and `finally` keywords to try actions that may not succeed, handling failures, and cleaning up resources afterward.

If the syntax of the text is invalid or if there is an error during the parsing, it will throw a `ParseException`. A `ParseException` will be thrown whenever an expression cannot be compiled.

Let's consider the following simple example where the expression syntax is invalid.

```csharp
public static void Example1()
{
    Interpreter interpreter = new Interpreter();

    interpreter.SetVariable("x", 6);
    interpreter.SetVariable("y", 5.5);

    string expression = "x + y +";

    var result = interpreter.Eval(expression);

    Console.WriteLine("{0} = {1}", expression, result);
}
```

Let's run the above code, and you will see the following exception.

```csharp
DynamicExpresso.Exceptions.ParseException: 'Invalid Operation (at index 7).'
```
You can use the `try`, `catch` blocks handles any kind of exceptions.
 
```csharp
public static void Example2()
{
    try
    {
        Interpreter interpreter = new Interpreter();

        interpreter.SetVariable("x", 6);
        interpreter.SetVariable("y", 5.5);

        string expression = "x + y +";

        var result = interpreter.Eval(expression);

        Console.WriteLine("{0} = {1}", expression, result);
    }
    catch (ParseException e)
    {
        Console.WriteLine(e.Message);
    }
}
```

Let's consider another example where the expression uses a variable that is not defined.

```csharp
public static void Example3()
{
    try
    {
        Interpreter interpreter = new Interpreter();
        string expression = "x + y + z";

        interpreter.SetVariable("x", 6);
        interpreter.SetVariable("y", 5.5);

        var result = interpreter.Eval(expression);

        Console.WriteLine("{0} = {1}", expression, result);
    }
    catch (ParseException e)
    {
        Console.WriteLine(e.Message);
    }
}
```

Let's run the above code, and you will see the following output.

```csharp
Unknown identifier 'z' (at index 8).
```
