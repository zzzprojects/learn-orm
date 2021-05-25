---
PermaID: 100002
Name: Simple Expressions
---

# Simple Expressions

The simple expressions are literals such as integer and real numbers and names of variables. 

 - You can also combine them into complex expressions by using operators. 
 - Operator precedence and associativity determine the order in which the operations in an expression are performed. 
 - You can use parentheses to change the order of evaluation imposed by operator precedence and associativity.

The following example evaluates an expression to an `object` using the `interpreter.Eval` method.

```csharp
public static void Example1()
{
    string expression = "2 + 13";

    Interpreter interpreter = new Interpreter();
    var result = interpreter.Eval(expression);

    Console.WriteLine("{0} = {1}", expression, result);
}
```

You can also evaluate an expression to a strongly-named type by using the generic version of the `interpreter.Eval<int>` method.

```csharp
public static void Example2()
{
    string expression = "2 + 13";

    Interpreter interpreter = new Interpreter();
    int result = interpreter.Eval<int>(expression);

    Console.WriteLine("{0} = {1}", expression, result);
}
```

In an expression with multiple operators, the operators with higher precedence are evaluated before the operators with lower precedence. 

In the following example, multiplication is performed first because it has higher precedence than addition.

```csharp
public static void Example3()
{
    string expression = "2.00 + 2.00 * 2.00";

    Interpreter interpreter = new Interpreter();
    var result = interpreter.Eval(expression);

    Console.WriteLine("{0} = {1}", expression, result);
}
```

You can use the parentheses to change the order of evaluation imposed by operator precedence.

```csharp
public static void Example4()
{
    string expression = "(2.00 + 2.00) * 2.00";

    Interpreter interpreter = new Interpreter();
    var result = interpreter.Eval(expression);

    Console.WriteLine("{0} = {1}", expression, result);
}
```
