---
PermaID: 100004
Name: Evaluate Expression
---

# Evaluate Expression

The `CSharpScript` class provides various static methods to evaluate your expressions at run-time. The following example evaluates a simple expression `2 + 3` using the `EvaluateAsync` method.

```csharp
static async Task EvaluateExample1()
{
    var result = await CSharpScript.EvaluateAsync("2 + 3");
    Console.WriteLine(result);
}
```

The `CSharpScript.EvaluateAsync` method is an async method that evaluates the string passed as a parameter and returns its resulting value. 

You can also get the strongly-typed evaluation by using the generic version of the same method as shown below.

```csharp
static async Task EvaluateExample2()
{
    int result = await CSharpScript.EvaluateAsync<int>("4 + 6");
    Console.WriteLine(result);
}
```

