---
PermaID: 100006
Name: Culture Sensitive Expressions
---

# Culture Sensitive Expressions

**Flee** allows you to specify the culture used to parse expressions. You can enter expressions that use numbers in the format of a particular culture and have them be correctly parsed into an expression.

When the parse culture is set, **Flee** will use the `CultureInfo.NumberFormat.NumberDecimalSeparator` as the decimal point for real numbers and the `CultureInfo.TextInfo.ListSeparator` as the function argument separator.

The following example shows how to create an expression in **English (US)** culture.

```csharp
public static void Example2()
{
    ExpressionContext context = new ExpressionContext();
    context.Options.ParseCulture = new CultureInfo("en-US");

    IDynamicExpression e = context.CompileDynamic("if(1<2, 3, 4)");

    Console.WriteLine(e.Evaluate());
}
```

The same expression is created using **Finnish (Finland)** culture.

```csharp
public static void Example3()
{
    ExpressionContext context = new ExpressionContext();
    context.Imports.AddType(typeof(Math));
    context.Options.ParseCulture = new CultureInfo("fi-FI");

    IDynamicExpression e = context.CompileDynamic("if(1>2; 3; 4)");

    Console.WriteLine(e.Evaluate());
}
```

Here is another example that uses the expression created for **French (France)** culture.

```csharp
public static void Example1()
{
    ExpressionContext context = new ExpressionContext();
    context.Options.ParseCulture = new CultureInfo("fr-FR");
    context.Imports.AddType(typeof(Math));

    // Create an expression that uses numbers in the culture's format
    IDynamicExpression e = context.CompileDynamic("round(100,75; 1)");
    object result = e.Evaluate();

    Console.WriteLine(result);
}
```
