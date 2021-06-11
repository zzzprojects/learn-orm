---
PermaID: 100012
Name: Expando Object
---

# Expando Object

The `ExpandoObject` represents an object whose members can be dynamically added and removed at run time.

 - It enables you to add and delete members of its instances at run time and set and get these members' values.
 - It also supports dynamic binding, which enables you to use standard syntax like `myObject.MyMember` instead of more complex syntax like `myObject.GetAttribute("MyMember")`.
 - It is also a dictionary of properties and in **CodingSeb.ExpressionEvaluator**, you can use it as an object or as a dictionary.

The following example shows the basic usage of `ExpandoObject`.

```csharp
public static void Example1()
{
    string script = @"
        dynamic customer = new System.Dynamic.ExpandoObject();
        customer.Name = ""Mark Upston"";
        customer.Age = 53;
        customer.Address = ""New York, US"";
        Console.WriteLine(""{0} is {1} years old and lives in {2}"", customer.Name, customer.Age, customer.Address);
    ";

    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.ScriptEvaluate(script));
}
```

In C#, to enable late binding for an instance of the `ExpandoObject` class, you must use the `dynamic` keyword.

The `ExpandoObject` class also allows you to define and use methods, as shown below.

```csharp
public static void Example2()
{
    string script = @"
        dynamic myObject = new ExpandoObject();

        myObject.Add = (a, b) => 
        {
            return (a + b).ToString();
        };

        Console.WriteLine(myObject.Add(13, 42));
    ";

    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.ScriptEvaluate(script));
}
```
