---
PermaID: 100002
Name: Evaluate Expression
---

# Evaluate Expression

The simple expressions are literals such as integer and real numbers and names of variables. 

 - You can also combine them into complex expressions by using operators. 
 - Operator precedence and associativity determine the order in which the operations in an expression are performed. 
 - You can use parentheses to change the order of evaluation imposed by operator precedence and associativity.

The `Expression` class provides an `Evaluate` method to evaluate your expressions at run-time. The following example evaluates a simple mathematical expression.

```csharp
public static void Example1()
{
    string expression = "1 + 2";
    var exprObj = new Expression(expression);
    var result = exprObj.Evaluate();
    Console.WriteLine("{0} = {1}", expression, result);
}
```

The `Evaluate` method evaluates the string passed as a parameter and returns its resulting value. 

You can also get the strongly-typed evaluation by using the generic version of the same method as shown below.

```csharp
public static void Example2()
{
    string expression = "1 + 2";
    var exprObj = new Expression(expression);
    int result = exprObj.Evaluate<int>();
    Console.WriteLine("{0} = {1}", expression, result);
}
```

In an expression with multiple operators, the operators with higher precedence are evaluated before the operators with lower precedence. 

In the following example, multiplication is performed first because it has higher precedence than addition.

```csharp
public static void Example3()
{
    string expression = "1 + 2 * 3";
    var exprObj = new Expression(expression);
    var result = exprObj.Evaluate();
    Console.WriteLine("{0} = {1}", expression, result);
}
```

You can use the parentheses to change the order of evaluation imposed by operator precedence.

```csharp
public static void Example4()
{
    string expression = "(1 + 2) * 3";
    var exprObj = new Expression(expression);
    var result = exprObj.Evaluate();
    Console.WriteLine("{0} = {1}", expression, result);
}
```
