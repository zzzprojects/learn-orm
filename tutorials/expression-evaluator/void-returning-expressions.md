---
PermaID: 100005
Name: Void Returning Expressions
---

# Void Returning Expressions

The **ExpressionEvaluator** library provides `Eval()` and `ScopeCompile()` functions which compile the expression into a `Func<>` delegate, and expects a return value. If expressions that return void such as code blocks are compiled as a `Func<>` will throw an exception.

To avoid this case, alternatively, you can call the `Call()` and `ScopeCompileCall()` methods to assume that the expression returns void and compiles the expression into an `Action<>` delegate.

Let's consider we have a simple class that contains one property and two void functions.

```csharp
public class MyClass
{
    public int X { get; set; }
    public void Increment()
    {
        X++;
    }

    public void Increment(int value)
    {
        X += value;
    }
}
```

The following example shows how to compile the void functions using the `Call()` and `ScopeCompileCall()` methods.

```csharp
public static void Example1()
{
    var data = new MyClass();

    var c1 = new CompiledExpression() { StringToParse = "X = 10" };
    var f1 = c1.ScopeCompileCall<MyClass>();
    Console.WriteLine(data.X);
    f1(data);
    Console.WriteLine(data.X);

    var reg = new TypeRegistry();
    reg.RegisterSymbol("data", data);
    var c1a = new CompiledExpression() { StringToParse = "data.Increment(5)", TypeRegistry = reg };
    Console.WriteLine(data.X);
    c1a.Call();
    Console.WriteLine(data.X);

    var c2 = new CompiledExpression() { StringToParse = "data.Increment()", TypeRegistry = reg };
    var f2 = c2.ScopeCompileCall();
    Console.WriteLine(data.X);
    f2(data);
    Console.WriteLine(data.X);
}
```

Now let's execute the above code and you will see the following output.

```csharp
0
10
10
15
15
16
```