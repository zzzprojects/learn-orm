---
PermaID: 100008
Name: Caching
---

# Caching

Caching mechanism in **CS-Script** was inspired by a similar feature in Python. The concept is very simple if the script file was not modified since the last execution the compilation is not performed and the previous compilation result is used instead. 

 - It ensures that the relatively expensive script recompilation is performed only if it is required.
 - The runtime performance of the C# scripting solution is identical to the compiled application. 

## Why Caching?

 - The compilation is a heavy task and is a potential performance hit, the initialization of the engine can also bring an enormous startup overhead. This is when caching comes to the rescue.
 - The truly impressive execution speed is attributed to the fact that the script at runtime is just an ordinary CLR assembly, which just happens to be compiled on-fly.

The **CS-Script** caching algorithm can partially support file-less scripts, which are also known as eval execution. 

The following example code creates two delegates, but the code is compiled only once.

```csharp
public static void Example1()
{
    string script = @"double Add(double a, double b)
        {
            return a + b;
        }";

    var addInt = CSScript.Evaluator.CreateDelegate<double>(script);
    var addDouble = CSScript.Evaluator.CreateDelegate<double>(script);

    Console.WriteLine("Add(3, 2): {0}", addInt(3, 2));
    Console.WriteLine("Add(13.5, 21.75): {0}", addDouble(13.5, 21.75));

}
```

By default, the caching option is enabled. You can disable it as shown below.

```csharp
CSScript.CacheEnabled = false;
```
