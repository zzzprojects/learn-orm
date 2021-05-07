---
PermaID: 100005
Name: Additional Variables Declaration
---

# Additional Variables Declaration

The **CodingSeb.ExpressionEvaluator** library allows you to assign an expression to your custom variable by using the `SubExpression`.

The following example shows the usage of the `SubExpression`.

```csharp
public static void Example1()
{
	ExpressionEvaluator evaluator = new ExpressionEvaluator();

	evaluator.Variables["a"] = 4;
	evaluator.Variables["b"] = 7;
	evaluator.Variables["c"] = new SubExpression("a+b");
	evaluator.Variables["d"] = new SubExpression("c+3");

	List<string> expressions = new List<string>()
	{
		"a",
		"b",
		"c",
		"d",
		"d",
		"a + b",
		"c + 10"
	};

	foreach (var expr in expressions)
	{
		var result = evaluator.Evaluate(expr);
		Console.WriteLine($"{expr}:\t {result}\n");
	}
}
```

Let's execute the above code and you will see the following output.

```csharp
a:       4

b:       7

c:       11

d:       14

d:       14

a + b:   11

c + 10:  21
```

In addition to `Variables` dictionary, the **CodingSeb.ExpressionEvaluator** also provides a `Context` property of type object which allows you to access all public properties, fields, and methods directly of that particular object which is assigned to the `Context`.

```csharp
public static void Example2()
{
	ExpressionEvaluator evaluator = new ExpressionEvaluator();

	evaluator.Context = new Customer()
	{
		FirstName = "Mark",
		LastName = "Upston",
		BirthDate = new DateTime(1977, 12, 10)
	};

	List<string> expressions = new List<string>()
	{
		"FirstName + \" \" + LastName",
		"GetAge()",
	};

	foreach (var expr in expressions)
	{
		var result = evaluator.Evaluate(expr);
		Console.WriteLine($"{expr}:\t {result}\n");
	}
}

public class Customer
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime BirthDate { get; set; }

	public int GetAge()
	{
		DateTime date = DateTime.Now;
		var age = date.Year - BirthDate.Year;
		if (BirthDate.Date > date.AddYears(-age)) age--;
		return age;
	}
}
```

Let's execute the above code and you will see the following output.

```csharp
FirstName + " " + LastName:      Mark Upston

GetAge():        43
```