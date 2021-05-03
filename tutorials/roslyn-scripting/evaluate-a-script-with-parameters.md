---
PermaID: 100006
Name: Evaluate a Script with Parameters
---

# Evaluate a Script with Parameters

When you need to send some information to a method, you can do it by passing the parameters, and parameters act as variables inside the method.

You can send parameters to the expression and use them in the script logic.

```csharp
public class Point
{
    public int X;
    public int Y;
}

static async Task EvaluateWithParameters()
{
    var point = new Point { X = 3, Y = 5 };
    var result = await CSharpScript.EvaluateAsync<int>("X*2 + Y*2", globals: point);
    Console.WriteLine(result);
}
```

You can also create a script and execute it multiple times, as shown below.

```csharp
static async Task EvaluateWithParameters1()
{
    var script = CSharpScript.Create<int>("X*Y", globalsType: typeof(Point));

    script.Compile();
    
    for (int i = 0; i < 10; i++)
    {
        var result = await script.RunAsync(new Point 
        { 
            X = i, 
            Y = i 
        });

        Console.WriteLine(result.ReturnValue);
    }
}
```

The `CSharpScript.Create` method creates a script, and then the `RunAsync` method executes that script multiple times in a `for loop.

You can also use the `CreateDelegate` method of a `Script` class to create a delegate to a script. The delegate doesn't hold compilation resources alive.

```csharp
static async Task EvaluateWithParameters2()
{
    var script = CSharpScript.Create<int>("X*Y", globalsType: typeof(Point));

    ScriptRunner<int> runner = script.CreateDelegate();
    
    for (int i = 0; i< 10; i++)
    {
        var result = await runner(new Point
        {
            X = i,
            Y = i
        });

        Console.WriteLine(result);
    }
}
```

