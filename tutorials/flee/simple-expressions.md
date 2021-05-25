---
PermaID: 100002
Name: Simple Expressions
---

# Simple Expressions

The simple expressions are literals such as integer and real numbers and names of variables. 

 - You can also combine them into complex expressions by using operators. 
 - Operator precedence and associativity determine the order in which the operations in an expression are performed. 
 - You can use parentheses to change the order of evaluation imposed by operator precedence and associativity.

The following example creates a dynamic expression using `context.CompileDynamic` that evaluates to an `Object`.

```csharp
public static void Example1()
{
    string expression = "2 + 13";

    ExpressionContext context = new ExpressionContext();
    IDynamicExpression eDynamic = context.CompileDynamic(expression);

    var result = eDynamic.Evaluate();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```

The `ExpressionContext` holds all the information required for an expression besides the expression text. You can also create a generic expression using `context.CompileGeneric<T>` that evaluates to a strongly-named type.

```csharp
public static void Example2()
{
    string expression = "2 + 13";

    ExpressionContext context = new ExpressionContext();
    IGenericExpression<int> eGeneric = context.CompileGeneric<int>(expression);

    var result = eGeneric.Evaluate();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```

In an expression with multiple operators, the operators with higher precedence are evaluated before the operators with lower precedence. 

In the following example, the multiplication is performed first because it has higher precedence than addition.

```csharp
public static void Example3()
{
    string expression = "2.00 + 2.00 * 2.00";

    ExpressionContext context = new ExpressionContext();
    IGenericExpression<double> eGeneric = context.CompileGeneric<double>(expression);

    var result = eGeneric.Evaluate();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```

You can use the parentheses to change the order of evaluation imposed by operator precedence:

```csharp
public static void Example4()
{
    string expression = "(2.00 + 2.00) * 2.00";

    ExpressionContext context = new ExpressionContext();
    IGenericExpression<double> eGeneric = context.CompileGeneric<double>(expression);

    var result = eGeneric.Evaluate();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```
