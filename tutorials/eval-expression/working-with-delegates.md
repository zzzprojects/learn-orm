---
PermaID: 100004
Name: Working with Delegates
---

# Working with Delegates

The **Z.Expressions.Eval** library allows you to compile an expression and it will return a delegate. The expression is parsed into tokens and then transformed into syntax node before being compiled using Expression Tree.

The following example shows how to compile an expression to a delegate.

```csharp
public static void Example1()
{
    string expression = "{0}*2 + {1}*3";
    var compiled = Eval.Compile<Func<int, int, int>>(expression);
    int result = compiled(10, 15);

    Console.WriteLine("{0} = {1}", expression, result);
}
```

You can also use the named parameters as shown below.

```csharp
public static void Example2()
{
    string expression = "a*2 + b*3";
    var compiled = Eval.Compile<Func<int, int, int>>(expression, "a", "b");
    int result = compiled(10, 15);

    Console.WriteLine("{0} = {1}", expression, result);
}

```
