---
PermaID: 100006
Name: Caching
---

# Caching

Caching concept is very simple if the expression was not modified since the last execution the evaluation is not performed and the previous evaluation result is used instead. It ensures that the relatively expensive expression reevaluation is performed only if it is required. 

By default, the caching option is disabled, you can enable it as shown below.

```csharp
CSScript.CacheEnabled = false;
```

The following example evaluates the same expression 10000 times without using caching.

```csharp
public static void Example1()
{
	var lambdaParser = new LambdaParser();

	var varContext = new Dictionary<string, object>();
	varContext["a"] = 55;
	varContext["b"] = 2;

	var sw = new Stopwatch();
	sw.Start();
	for (int i = 0; i < 10000; i++)
	{

		lambdaParser.Eval("(a*2 + 100)/b", varContext);
	}
	sw.Stop();
	Console.WriteLine("10000 iterations: {0} ms", sw.ElapsedMilliseconds);
}
```

Let's run the above code and you will see that it took 141 ms to complete the evaluation of the same expression 10000 times.

```csharp
10000 iterations: 141 ms
```

Now let's enable the caching as shown below.

```csharp
public static void Example2()
{
	var lambdaParser = new LambdaParser() { UseCache = true };

	var varContext = new Dictionary<string, object>();
	varContext["a"] = 55;
	varContext["b"] = 2;

	var sw = new Stopwatch();
	sw.Start();
	for (int i = 0; i < 10000; i++)
	{

		lambdaParser.Eval("(a*2 + 100)/b", varContext);
	}
	sw.Stop();
	Console.WriteLine("10000 iterations: {0} ms", sw.ElapsedMilliseconds);
}
```

Let's run the above code again and you will see that this time it took 23 ms.

```csharp
10000 iterations: 23 ms
```