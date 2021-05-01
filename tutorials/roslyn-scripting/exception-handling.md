---
PermaID: 100008
Name: Exception Handling
---

# Exception Handling

An exception is a problem that arises during the execution of a program. It helps you deal with any unexpected or exceptional situations that occur when a program is running.

When you are evaluating the script, it is provided as an input and very often you do not have control over the input and cannot be sure that whether it will be evaluated or even parsed or not. So it is strongly recommended to keep the evaluation code inside try-catch blocks.

Let's consider the following simple example which chains three different statements.

```csharp
static async Task EvaluateWithException()
{
    var state = await CSharpScript.RunAsync("int X = 34;");
    state = await state.ContinueWithAsync("int Y = 2;");
    state = await state.ContinueWithAsync("x*2 + y*2");

    Console.WriteLine(state.ReturnValue);
}
```

When you execute the above code, you will not see any output and you won't be able to understand what happened. Now let's put the above code in the try-catch block and catch the `CompilationErrorException` exceptions as shown below.

```csharp
static async Task EvaluateWithExceptionHandling()
{
    try
    {
        var state = await CSharpScript.RunAsync("int X = 34;");
        state = await state.ContinueWithAsync("int Y = 2;");
        state = await state.ContinueWithAsync("x*2 + y*2");

        Console.WriteLine(state.ReturnValue);
    }
    catch (CompilationErrorException e)
    {
        Console.WriteLine(string.Join(Environment.NewLine, e.Diagnostics));
    }
}
``` 

The `CompilationErrorException` class has the `Diagnostics` property which allows you to access all the compile issues. Let's execute the above code again and you will see the now the following error messages on the console.

```csharp
(1,1): error CS0103: The name 'x' does not exist in the current context
(1,7): error CS0103: The name 'y' does not exist in the current context
```

We are getting these exceptions because in the first two statements the `X` and `Y` are in upper case while in the third statement `x` and `y` are specified in lower case.
