---
PermaID: 100013
Name: Exception Handling
---

# Exception Handling

Exception handling helps you deal with any unexpected or exceptional situations that occur when a program is running. You can use the `try`, `catch`, and `finally` keywords to try actions that may not succeed, to handle failures, and to clean up resources afterward.

Expressions can fail to compile if the syntax of the text is invalid. An `ExpressionCompileExpression` will be thrown whenever an expression cannot be compiled.

```csharp
public static void Example1()
{
    try
    {
        string expression = "2 + 13 -";

        ExpressionContext context = new ExpressionContext();
        IDynamicExpression eDynamic = context.CompileDynamic(expression);

        Object result = eDynamic.Evaluate();
        Console.WriteLine("{0} ({1})", result, result.GetType());
    }
    catch (ExpressionCompileException e)
    {
        if (e.Reason == CompileExceptionReason.SyntaxError)
            Console.WriteLine("Check your expression syntax");
    }
}
```

Let's execute the above code, and you will see the following output.

```csharp
Check your expression syntax
```
