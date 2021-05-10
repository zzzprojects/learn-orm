---
PermaID: 100007
Name: Variables and Functions Evaluation on the Fly
---

# Variables and Functions Evaluation on the Fly

The **CodingSeb.ExpressionEvaluator** library allows you to add variables and functions on the fly during evaluation using the C# events.

 - It always fires `PreEvaluateVariable` and `PreEvaluateFunction` events before all the evaluations of variables, fields, properties, and functions. 
 - If you cancel these two events, no further evaluations are done.
 - After all standard evaluation of all variables, fields, properties, functions, and methods, it fires `EvaluateVariable` and `EvaluateFunction` events. 
 - These two events are fired only if no others evaluations succeed. 
 - It avoids conflicts, but it also has some performance drawbacks.

The following example shows how to use the events which are fired before and after the evaluation.

```csharp
public static void Examle1()
{
	ExpressionEvaluator evaluator = new ExpressionEvaluator();

	evaluator.PreEvaluateVariable += PreEvaluateVariableMethod;
	evaluator.PreEvaluateFunction += PreEvaluateFunctionMethod;

	evaluator.EvaluateVariable += PostEvaluateVariableMethod;
	evaluator.EvaluateFunction += PostEvaluateFunctionMethod;

	List<string> expressions = new List<string>()
	{
		"var1 + 13",
		"Pi",
		"TestMethod(5)",
		"Abs(-3)",
		"var1 + 2",
		"SayHello(\"Mark\")",
		"3.MultipliedBy2",
		"3.Add(2)",
		"GenericNamespace<List<string>>()",
		"GenericAssembly<string>"
	};

	foreach (var expr in expressions)
	{
		try
		{
			var result = evaluator.Evaluate(expr);
			Console.WriteLine($"{expr}:\t {result}\n");

		}
		catch (Exception exception)
		{
			Console.WriteLine("throw an exception : " + exception.Message);
		}
		finally
		{
			Console.WriteLine(string.Empty);
		}
	}
}


private static void PreEvaluateVariableMethod(object sender, VariablePreEvaluationEventArg e)
{
	if (e.Name.Equals("var1"))
	{
		e.Value = 9;
	}
	else if (e.Name.StartsWith("P"))
	{
		e.CancelEvaluation = true;
	}
}

private static void PreEvaluateFunctionMethod(object sender, FunctionPreEvaluationEventArg e)
{
	if (e.Name.Equals("TestMethod") && e.Args.Count == 1)
	{
		e.Value = "It is a test for " + e.EvaluateArg(0);
	}
	else if (e.Name.StartsWith("A"))
	{
		e.CancelEvaluation = true;
	}
}

private static void PostEvaluateVariableMethod(object sender, VariableEvaluationEventArg e)
{
	if (e.Name.ToLower().Equals("var2"))
	{
		e.Value = 8;
	}
	else if (e.Name.Equals("MultipliedBy2") && e.This is int)
	{
		e.Value = (int)e.This * 2;
	}
	else if (e.Name.Equals("GenericAssembly") && e.HasGenericTypes)
	{
		// e.EvaluateGenericTypes() return a Type[]
		e.Value = e.EvaluateGenericTypes()[0].Assembly.GetName().Name;
	}
}

private static void PostEvaluateFunctionMethod(object sender, FunctionEvaluationEventArg e)
{
	if (e.Name.ToLower().Equals("sayhello") && e.Args.Count == 1)
	{
		e.Value = "Hello " + e.EvaluateArg(0);
	}
	else if (e.Name.Equals("Add") && e.This is int)
	{
		e.Value = (int)e.This + (int)e.EvaluateArg(0);
	}
	else if (e.Name.Equals("GenericNamespace") && e.HasGenericTypes)
	{
		// e.EvaluateGenericTypes() return a Type[]
		e.Value = e.EvaluateGenericTypes()[0].Namespace;
	}
}
```

Let's execute the above code, and you will see the following output.

```csharp
var1 + 13:       22


throw an exception : Variable [Pi] unknown in expression : [Pi]

TestMethod(5):   It is a test for 5


throw an exception : Function [Abs] unknown in expression : [Abs(-3)]

var1 + 2:        11


SayHello("Mark"):        Hello Mark


3.MultipliedBy2:         6


throw an exception : [] object has no Method named "Add".

GenericNamespace<List<string>>():        System.Collections.Generic


GenericAssembly<string>:         System.Private.CoreLib
```
