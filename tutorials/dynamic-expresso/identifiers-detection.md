---
PermaID: 100011
Name: Identifiers Detection
---

# Identifiers Detection

Sometimes you need to check which identifiers such as, variables, types, parameters, etc., are used in expression before parsing it. 

 - You may need to validate all the identifiers or ask the user to enter the parameter's value in a given expression.
 - If you parse an expression that contains an identifier without defining them will throw an exception.

Let's consider the following example containing various variables like `x`, `y`, and `z` in the expression, but you will see that we have defined and `x` and `y`.

```csharp
public static void Example1()
{
    Interpreter interpreter = new Interpreter();

    interpreter.SetVariable("x", 6);
    interpreter.SetVariable("y", 5.5);

    string expression = "x + y + z";

    var result = interpreter.Eval(expression);

    Console.WriteLine("{0} = {1}", expression, result);
}
```

Let's run the above code, and you will see the following exception.

```csharp
DynamicExpresso.Exceptions.UnknownIdentifierException: 'Unknown identifier 'z' (at index 18).'
```

The **Dynamic Expresso** library provides the `Interpreter.DetectIdentifiers` method to obtain a list of user identifiers, both known and unknown. The following will detect an unknown identifier and will notify the user if there is any.

```csharp
public static void Example2()
{
    Interpreter interpreter = new Interpreter();

    interpreter.SetVariable("x", 6);
    interpreter.SetVariable("y", 5.5);

    string expression = "x + y + z";

    var detectedIdentifiers = interpreter.DetectIdentifiers(expression);

    var unknownIdentifiers = detectedIdentifiers.UnknownIdentifiers.ToList();

    if (unknownIdentifiers.Count > 0)
    {
        foreach (var unknownIdentifier in unknownIdentifiers)
        {
            Console.WriteLine("Identifier \"{0}\" is not defined in your expression.", unknownIdentifier);
        }
    }
    else
    {
        var result = interpreter.Eval(expression);

        Console.WriteLine("{0} = {1}", expression, result);
    }
}
```

Let's run the above code, and you will see the following output.

```csharp
Identifier "z" is not defined in your expression.
```
