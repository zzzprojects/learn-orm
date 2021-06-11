---
PermaID: 100007
Name: Supported Data Types
---

# Supported Data Types

The primitive data types are predefined by the language, and they are named by reserved keywords. They represent the basic types of language.

The **Z.Expressions.Eval** manages the following list of C# primary types.

 - object
 - string
 - bool
 - byte
 - char
 - decimal
 - double
 - short
 - int
 - long
 - sbyte
 - float
 - ushort
 - uint
 - ulong
 - void

You can add additional types by using the `EvalContext.RegisterType` method as shown below.

```csharp
class Calculator
{
	public static int Add(int a, int b)
	{
		return a + b;
	}

	public static int Subtract(int a, int b)
	{
		return a - b;
	}
	public static int Multiply(int a, int b)
	{
		return a * b;
	}
	public static int Divide(int a, int b)
	{
		return a / b;
	}
}

public static void Example1()
{
	var context = new EvalContext();

	context.RegisterType(typeof(Calculator));

	List<string> expressions = new List<string>()
	{
		"Calculator.Add(10, 5)",
		"Calculator.Subtract(10, 5)",
		"Calculator.Multiply(10, 5)",
		"Calculator.Divide(10, 5)"
	};

    foreach (var expression in expressions)
    {
		var result = context.Execute<int>(expression);

		Console.WriteLine("{0}: {1}", expression, result);
	}
}
```

Let's run the above code and you will see the following output.

```csharp
Calculator.Add(10, 5): 15
Calculator.Subtract(10, 5): 5
Calculator.Multiply(10, 5): 50
Calculator.Divide(10, 5): 2
```

You can also use the `EvalContext.RegisterStaticMember` method which allows you to use static member names without qualifying them with their namespace or type name as shown below.

```csharp
public static void Example2()
{
	var context = new EvalContext();

	context.RegisterStaticMember(typeof(Calculator));

	List<string> expressions = new List<string>()
	{
		"Add(10, 5)",
		"Subtract(10, 5)",
		"Multiply(10, 5)",
		"Divide(10, 5)"
	};

	foreach (var expression in expressions)
    {
        var result = context.Execute<decimal>(expression);

        Console.WriteLine("{0}: {1}", expression, result);
    }
}
```
