---
PermaID: 100008
Name: Variables Declaration and Initialization
---

# Variables Declaration and Initialization

The **CodingSeb.ExpressionEvaluator** library allows you to declare and use variables inside scripts. The declaration and initialization of a variable from a script have been evolved in the different versions of ExpressionEvaluator.

 - When you assign a variable that does not exist, it will be created automatically.
 - Before version 1.4.0.0, it was the only way to declare a variable.
 - From version 1.4.0.0, you can optionally use the `var` keyword.
 - From version 1.4.3.0 you can declare a strongly typed variable.

The following example shows how to declare variables before version 1.4.0.0.

```csharp
public static void Example1()
{
    string script = @"
        myInt = 79;
        myDouble = 2.5;
        myStr = ""hello"";
        myList = new List<string>()
        {
            ""test string 1"",
            ""test string 2"",
        };
        Console.WriteLine(myInt.GetType());
        Console.WriteLine(myDouble.GetType());
        Console.WriteLine(myStr.GetType());
        Console.WriteLine(myList.GetType());
    ";

    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.ScriptEvaluate(script));
}
```

The following example shows how to declare variables using the `var` keyword, which is supported after version 1.4.0.0.

```csharp
public static void Example2()
{
    string script = @"
        var myInt = 79;
        var myDouble = 2.5;
        var myStr = ""hello"";
        var myList = new List<string>()
        {
            ""test string 1"",
            ""test string 2"",
        };
        Console.WriteLine(myInt.GetType());
        Console.WriteLine(myDouble.GetType());
        Console.WriteLine(myStr.GetType());
        Console.WriteLine(myList.GetType());
    ";

    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.ScriptEvaluate(script));
}
```

From version 1.4.3.0, you can declare a strongly typed variable, as shown in the below example.

```csharp
public static void Example3()
{
    string script = @"
        int myInt = 79;
        double myDouble = 2.5;
        string myStr = ""hello"";
        List<string> myList = new List<string>()
        {
            ""test string 1"",
            ""test string 2"",
        };
        Console.WriteLine(myInt.GetType());
        Console.WriteLine(myDouble.GetType());
        Console.WriteLine(myStr.GetType());
        Console.WriteLine(myList.GetType());
    ";

    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.ScriptEvaluate(script));
}
```

