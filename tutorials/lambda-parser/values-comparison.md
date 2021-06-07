---
PermaID: 100005
Name: Values Comparison
---

# Values Comparison

**NReco.LambdaParser** uses `ValueComparer` when comparing values by default. But it also allows you to provide your implementation or configure its option to get the desired behavior. You can customize the `ValueComparer` with the following two options.

## NullComparison 

It determines how comparison with null is handled and it also provides two options:

 - `MinValue`: `null` is treated as a minimum possible value for any type - like .NET IComparer
 - `Sql`: `null` is not comparable with any type, including another null - like in SQL

Let's consider the following simple example which uses the default options.

```csharp
public static void Example1()
{
	var varContext = new Dictionary<string, object>()
	{
		{ "obj",  new string("test string") },
		{ "nullVar", null }
	};

	List<string> expressions = new List<string>()
	{
		"null == nullVar",
		"5 > nullVar",
		"testObj != null",
		"nullVar>5",
	};

	var lambdaParser = new LambdaParser();

	foreach (var expression in expressions)
	{
		var result = lambdaParser.Eval(expression, varContext);
		Console.WriteLine("{0} = {1}", expression, result);
	}
}
```

Let's run the above code and you will see the following output.

```csharp
null == nullVar = True
5 > nullVar = True
testObj != null = False
nullVar>5 = False
```

Now let's set the `ValueComparer.NullComparison` value to `ValueComparer.NullComparisonMode.Sql` and pass it as a parameter to the `LambdaParser` constructor as shown below. 

```csharp
public static void Example2()
{
	var varContext = new Dictionary<string, object>()
	{
		{ "obj",  new string("test string") },
		{ "nullVar", null }
	};

	List<string> expressions = new List<string>()
	{
		"null == nullVar",
		"5 > nullVar",
		"testObj != null",
		"nullVar > 5",
	};

	var lambdaParser = new LambdaParser(new ValueComparer() { NullComparison = ValueComparer.NullComparisonMode.Sql });

	foreach (var expression in expressions)
	{
		var result = lambdaParser.Eval(expression, varContext);
		Console.WriteLine("{0} = {1}", expression, result);
	}			
}
```

Let's run the above code and you will see the following output.

```csharp
null == nullVar = False
5 > nullVar = False
testObj != null = True
nullVar>5 = False
```

## SuppressErrors

It allows you to avoid convert exceptions. If an error appears during comparison exception is not thrown and this means that values are not comparable and will return `false`.


