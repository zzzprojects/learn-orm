---
PermaID: 100010
Name: Case Sensitive Expressions
---

# Case Sensitive Expressions

By default, all expressions are considered case-sensitive. For example, `VALUE` is different than `value`. The **Dynamic Expresso** library provides an option to use a case-insensitive parser.

The following example defines a variable called `val` and then uses it in expression.

```csharp
public static void Example1()
{
    Interpreter interpreter = new Interpreter();

    interpreter.SetVariable("val", 6);

    string expression = "val + VAL + Val";
    var result = interpreter.Eval(expression);

    Console.WriteLine("{0} = {1}", expression, result);
}
```

Let's run the above code, and you will see the following exception.

```csharp
DynamicExpresso.Exceptions.UnknownIdentifierException: 'Unknown identifier 'VAL' (at index 6).'
```

To use case insensitive expressions, pass `InterpreterOptions.CaseInsensitive` options to `Interpreter` constructor as a parameter, as shown below.

```csharp
public static void Example2()
{
    Interpreter interpreter = new Interpreter(InterpreterOptions.CaseInsensitive);

    interpreter.SetVariable("val", 6);

    string expression = "val + VAL + Val";
    var result = interpreter.Eval(expression);

    Console.WriteLine("{0} = {1}", expression, result);
}
```

Let's run the above code, and you will see the following output.

```csharp
val + VAL + Val = 18
```
