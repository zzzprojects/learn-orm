---
PermaID: 100007
Name: Chain Code Snippets
---

# Chain Code Snippets

Chaining allows you to run multiple statements within a single script. Roslyn also allows you to chain multiple commands and run each command one by one and keep track of the state. 

The following example chains three statements. The first two statements are assigning the values to the variables, and then in the third statement, it will use the results from the previous statements.  

```csharp
static async Task ChainCodeSnippets()
{
    var script = CSharpScript.
        Create<int>("int X = 34;").
        ContinueWith("int Y = 2;").
        ContinueWith("X*2 + Y*2");

    var result = await script.RunAsync();

    Console.WriteLine(result.ReturnValue);
}
```

You can also continue the script execution from a previous state, and each command will continue from the existing state.

```csharp
static async Task ChainCodeSnippets1()
{

    var state = await CSharpScript.RunAsync("int X = 34;");
    state = await state.ContinueWithAsync("int Y = 2;");
    state = await state.ContinueWithAsync("X*2 + Y*2");

    Console.WriteLine(state.ReturnValue);
}
```

Roslyn also allows you to run a C# snippet and inspect the defined script variables, as shown below.

```csharp
static async Task EvaluateScriptVariable()
{
    var state = await CSharpScript.RunAsync<int>("int age = 34; string country = \"US\"; ");

    foreach (var variable in state.Variables)
    {
        Console.WriteLine($"{variable.Name} = {variable.Value} of type {variable.Type}");
    }
}
```
