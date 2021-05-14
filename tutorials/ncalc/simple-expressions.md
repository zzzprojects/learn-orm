---
PermaID: 100002
Name: Simple Expressions
---

# Simple Expressions

The simple expressions are literals such as integer and real numbers and names of variables. 

 - You can also combine them into complex expressions by using operators. 
 - Operator precedence and associativity determine the order in which the operations in an expression are performed. 
 - You can use parentheses to change the order of evaluation imposed by operator precedence and associativity.

The following example evaluates a simple mathematical expression.

```csharp
public static void Example1()
{
    string expression = "2 + 13";
    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.Evaluate(expression));
}
```

You can also evaluate the `System.Math` functions directly as shown in the below example.

```csharp
public static void Example2()
{
    string expression = "Pow(5, 3)";
    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.Evaluate(expression));
}
```

In an expression with multiple operators, the operators with higher precedence are evaluated before the operators with lower precedence. 

In the following example, the multiplication is performed first because it has higher precedence than addition.

```csharp
public static void Example3()
{
    string expression = "4 + 3 * 7";
    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.Evaluate(expression));
}
```

You can use the parentheses to change the order of evaluation imposed by operator precedence:

```csharp
public static void Example4()
{
    string expression = "(4 + 3) * 7";
    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.Evaluate(expression));
}
```
