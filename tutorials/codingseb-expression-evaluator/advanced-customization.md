---
PermaID: 100013
Name: Advanced Customization
---

# Advanced Customization

The **CodingSeb.ExpressionEvaluator** allows you some deeper customizations of the parsing process. 

 - You can do customization which is mostly available by inheritance. 
 - Most of the class is now in protected visibility in place of private and the majority of init and parsing methods are now virtual.

Let's consider we want to use `and` and `or` operator instead of `&&` and `||` and to do so we need to add a new class and inherit it from the `ExpressionEvaluator`.

```csharp
public class XExpressionEvaluator : ExpressionEvaluator
{
    protected override void Init()
    {
        operatorsDictionary.Add("and", ExpressionOperator.ConditionalAnd);
        operatorsDictionary.Add("or", ExpressionOperator.ConditionalOr);
        operatorsDictionary.Remove("&&");
        operatorsDictionary.Remove("||");
    }
}
```

As you can see that we have added `and` and `or` operators to the dictionary and then removed the `&&` and `||`.

The following example shows the usage of `and` and `or` operators.

```csharp
public static void Example1()
{
	ExpressionEvaluator evaluator = new XExpressionEvaluator();

	List<string> expressions = new List<string>()
	{
		"true and true",
		"true and false",
		"false and true",
		"false and false",
		"true && true",
		"true or true",
		"true or false",
		"false or true",
		"false or false",
		"true || true"
	};

	foreach (var expr in expressions)
	{
		try
		{
			Console.WriteLine(expr);
			Console.WriteLine(evaluator.Evaluate(expr));
		}
		catch (Exception exception)
		{
			Console.WriteLine(exception);
		}
		finally
		{
			Console.WriteLine(string.Empty);
		}
	}
}
```
