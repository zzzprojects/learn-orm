---
PermaID: 100006
Name: String Extensions Support
---

# String Extensions Support

The **Z.Expressions.Eval** library extends the `String` class with methods like `Execute` & `Compile` to execute and compile C# expression. The string extensions use the default context to execute and compile expressions.

The following example uses the `Execute` extension method of the `string` class.

```csharp
public static void Example1()
{
    string expression = "a*2 + b*3 - 3";
    int result = expression.Execute<int>(new { a = 10, b = 5 });
    Console.WriteLine("{0} = {1}", expression, result);
}
```

Let's consider another example where the `Execute` extension method of the `string` class takes a dictionary object as a parameter.

```csharp
public static void Example2()
{
    string expression = "a*2 + b*3 - 3";

    var values = new Dictionary<string, object>()
    {
        { "a", 10 },
        { "b", 5 }
    };

    int result = expression.Execute<int>(values);
    Console.WriteLine("{0} = {1}", expression, result);
}
```

The following example shows how to compile an expression to a delegate using the `Execute` extension method.

```csharp
public static void Example3()
{
    string expression = "a*2 + b*3";
    var compiled = expression.Compile<Func<int, int, int>>("a", "b");
    int result = compiled(10, 15);

    Console.WriteLine("{0} = {1}", expression, result);
}
```
