---
PermaID: 100009
Name: Customizing Parser
---

# Customizing Parser

The **Flee** library allows you to customize the expression parser. 

 - You can use the `ExpressionContext.ParserOptions` property to customize the parser. 
 - You set the properties to the values you want and then call RecreateParser to apply your changes.

Let's consider the following simple example with the default settings.

```csharp
public static void Example1()
{
    ExpressionContext context = new ExpressionContext();
    context.Imports.AddType(typeof(Math));

    string expression = "Min(2.50, 4.75)";
    var eDynamic = context.CompileDynamic(expression);

    var result = eDynamic.Evaluate();
    Console.WriteLine("{0} = {1}", expression, result);
}
```

Let's execute the above code, and you will see the following output.

```csharp
Min(2.50, 4.75) = 2.5
```

Now let's say we want to use comma (`,`) instead of dot (`.`) as a decimal separator, and use semicolon (`;`) instead of a comma (`,`) as an argument separator.

```csharp
public static void Example2()
{
    ExpressionContext context = new ExpressionContext();
    context.Imports.AddType(typeof(Math));

    context.ParserOptions.DecimalSeparator = ',';
    context.ParserOptions.FunctionArgumentSeparator = ';';
    context.ParserOptions.RecreateParser();

    var expression = "Min(2,50; 4,75)";
    var eDynamic = context.CompileDynamic(expression);

    var result = eDynamic.Evaluate();
    Console.WriteLine("{0} = {1}", expression, result);
}
```

Let's execute the above code, and you will see the following output.

```csharp
Min(2,50; 4,75) = 2.5
```
