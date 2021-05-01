---
PermaID: 100005
Name: Add Namespace to Evaluation
---

# Add Namespace to Evaluation

In the `EvaluateAsync` method, you can evaluate a member as shown below.   

```csharp
static async Task EvaluateExample3()
{
    var result = await CSharpScript.EvaluateAsync("System.Console.WriteLine(System.DateTime.Now)");
}
```

As you can see that we have specified a member with a full qualified path. Now if you have a lot of code to evaluate or you need to use the same member several times, it will be very difficult to specify a fully qualified path again and again. 

The `CSharpScript.EvaluateAsync` method also provides an overload that also takes `ScriptOptions` as a parameter.

```csharp
static async Task EvaluateExample4()
{
    var result = await CSharpScript.EvaluateAsync("Console.WriteLine(DateTime.Now)", 
        ScriptOptions.Default.WithImports("System"));
}
```

The `ScriptOptions.Default.WithImports("System")` adds `using System;` to the script. 

Sometimes, you will need to add class members to the script to use directly without calling their class name. For example, if you are using `System.Math.Sqrt` several times, and now you want to use just `Sqrt`. Like adding references, if you use `WithImports` with a class name, it adds using static `System.Math;`.

```csharp
static async Task EvaluateExample5()
{
    double result = await CSharpScript.EvaluateAsync<double>("Sqrt(64)",
        ScriptOptions.Default.WithImports("System.Math"));

    Console.WriteLine(result);
}
```

You can also add references very easily with `WithReferences` method.

```csharp
static async Task EvaluateExample6()
{
    var result = await CSharpScript.EvaluateAsync("System.Net.Dns.GetHostName()",
        ScriptOptions.Default.WithReferences(typeof(System.Net.Dns).Assembly));
    Console.WriteLine(result);
}
```
