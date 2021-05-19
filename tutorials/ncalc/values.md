---
PermaID: 100005
Name: Values
---

# Values

A value is a token representing an element that is evaluated. A value can be either of any of the following.

 - Integer
 - Floating
 - DateTime
 - Boolean
 - String
 - Scientific Notation

## Integers

You can specify the integers using numbers and are evaluated as `Int32`. 

```csharp
public static void Example1()
{
    string expression = "139";
    Expression evaluator = new Expression(expression);
    var result = evaluator.Evaluate();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```
 
## Floating

Use the dot to define the decimal part.

You can specify the floating number by using the dot (`.`) to define the decimal part.
 
```csharp
public static void Example2()
{
    string expression = "139.98";
    Expression evaluator = new Expression(expression);
    var result = evaluator.Evaluate();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```

It is evaluated as `Double`.

## DateTime

To specify and evaluate date time, we need to enclose the string containing date-time between hashtags (`#`).

 - It is evaluated as a `DateTime`. 
 - By default, it uses the current Culture to evaluate.

```csharp
public static void Example3()
{
    string expression = "#2012/07/29#";
    Expression evaluator = new Expression(expression);
    var result = evaluator.Evaluate();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```

## Booleans

You can use the `true` and `false` literals to evaluate as a `Boolean`.

```csharp
public static void Example4()
{
    string expression = "true";
    Expression evaluator = new Expression(expression);
    var result = evaluator.Evaluate();
    Console.WriteLine("{0} ({1})", result, result.GetType());

    expression = "false";
    evaluator = new Expression(expression);
    result = evaluator.Evaluate();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```

## Strings

You can use the single quotes (`'`) to evaluate a string.

```csharp
public static void Example5()
{
    string expression = "'Hi, this is a string.'";
    Expression evaluator = new Expression(expression);
    var result = evaluator.Evaluate();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```

## Scientific Notation

To define the power of ten (`10^`), you can use the `e`.

```csharp
public static void Example6()
{
    string expression = "2.11e3";
    Expression evaluator = new Expression(expression);
    var result = evaluator.Evaluate();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```

It is also evaluated as a `Double`.
