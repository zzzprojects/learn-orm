---
PermaID: 100011
Name: Supported Data Types
---

# Supported Data Types

The primitive data types are predefined by the language, and they are named by reserved keywords. They represent the basic types of the language.

The **CodingSeb.ExpressionEvaluator** manages the following list of C# primary types.

 - object
 - string
 - bool/bool?
 - byte/byte?
 - char/char?
 - decimal/decimal?
 - double/double?
 - short/short?
 - int/int?
 - long/long?
 - sbyte/sbyte?
 - float/float?
 - ushort/ushort?
 - uint/uint?
 - ulong/ulong?
 - void

You can add additional types by using the `evaluator.Types.Add` method as shown below.

```csharp
public static void Example1()
{
	ExpressionEvaluator evaluator = new ExpressionEvaluator();
	evaluator.Types.Add(typeof(Customer));

	string script = @"
		Customer customer = new Customer()
		{
			FirstName = ""Mark"",
			LastName = ""Upston"",
			BirthDate = new DateTime(1977, 12, 10)
		};

		Console.WriteLine(""Name: {0} {1}\nBirth Date: {2} "", customer.FirstName, customer.LastName, customer.BirthDate);
	";
	Console.WriteLine(evaluator.ScriptEvaluate(script));
}

public class Customer
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime BirthDate { get; set; }
}
```

You can also block access of some types for security or any other reasons by adding it to the `TypesToBlock` list.

The following example doesn't make any sense, and it is just for demonstration purposes.

```csharp
public static void Example2()
{
	ExpressionEvaluator evaluator = new ExpressionEvaluator();
	evaluator.Types.Add(typeof(Customer));

	evaluator.TypesToBlock.Add(typeof(Customer));

	string script = @"
		Customer customer = new Customer()
		{
			FirstName = ""Mark"",
			LastName = ""Upston"",
			BirthDate = new DateTime(1977, 12, 10)
		};

		Console.WriteLine(""Name: {0} {1}\nBirth Date: {2} "", customer.FirstName, customer.LastName, customer.BirthDate);
	";
	Console.WriteLine(evaluator.ScriptEvaluate(script));
}
```

Now when you run the above code, you will get an exception.

To resolve types and namespaces **CodingSeb.ExpressionEvaluator** search in assemblies loaded in the `evaluator.Assemblies` list. By default, the following list of namespaces is available.

 - System
 - System.Linq
 - System.IO
 - System.Text
 - System.Text.RegularExpressions
 - System.ComponentModel
 - System.Dynamic
 - System.Collections
 - System.Collections.Generic
 - System.Collections.Specialized
 - System.Globalization

When the constructor of `ExpressionEvaluator` is called, `evaluator.Assemblies` list contains all loaded assemblies in the current AppDomain by default. You can easily `Clear`, `Add` or `Remove` assemblies on this list.

```csharp
ExpressionEvaluator evaluator = new ExpressionEvaluator();
evaluator.Namespaces.Add(namespace);
evaluator.Namespaces.Remove(namespaceToRemove);
```

