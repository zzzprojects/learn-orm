---
PermaID: 100003
Name: Operators
---

# Operators

In a programming language, operators are special symbols such as `+`, `-`, `^`, etc., that perform some action on operands. The **CoreCLR-NCalc** library manages a large set of C# operators, and it also respects the C# precedence rules of operators.

 - Operators allow the processing of primitive data types and objects. 
 - They take as an input one or more operands and return some value as a result. 
 
For example, operators are the signs for adding, subtracting, multiplication, and division like `+`, `-`, `*`, `/`, and the operations they perform on the integers and the real numbers.

## Types

Below is a list of the different types of operators which are most common.

| Type                                           | Operators                                                          |
|:-----------------------------------------------|:-------------------------------------------------------------------|
| [Arithmetic](#arithmetic)                      | `-`, `+`, `*`, `/`, `%`, `++`, `--`                                |
| [Logical](#logical)                            | `&&`, `\|\|`, `!`                                               |
| [Bitwise](#bitwise)                            | `&`, `\|`, `^`, `~`, `<<`, `>>`                                     |
| [Comparison](#comparison)                      | `==`,`!=`, `>`, `<`, `>=`, `<=`                                    |

### Arithmetical

In C#, the arithmetical operators are `+`, `-`, `*`, etc., and they perform mathematical operations such as addition, subtraction, and multiplication respectively on numerical values and the result is also a numerical value.

Here are some examples of arithmetic operators and their effects.


```csharp
public static void Example1()
{
    string expression = string.Format("3 + 6");
    Expression evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("3 - 6");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("3 * 6");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("3 / 6");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("3 % 6");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());
}
```

Let's run the above code, and you will see the following output.

```csharp
3 + 6 = 9
3 - 6 = -3
3 * 6 = 18
3 / 6 = 0.5
3 % 6 = 3
```    

### Logical

Logical operators or you can say Boolean operators take Boolean values and return a Boolean result (`true` or `false`).

The following table contains the logical operators in C# and the operations that they perform.

| A        | B         | A && B              | A \|\| B         |
|:---------|:----------|:--------------------|:-----------------|
| true     | true      | true                | true             |
| true     | false     | false               | true             |
| false    | true      | false               | true             |
| false    | false     | false               | false            |

Let's consider the following simple examples of logical operators.

```csharp
public static void Example2()
{
    string expression = string.Format("true || false");
    Expression evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("true or false");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("true && false");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("true and false");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("true or false and true");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("!false");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());
}
```

The `and` operator has more priority than the `or`, thus in the example above, `false and true` are evaluated first. 

### Bitwise

A bitwise operator is an operator that acts on the binary representation of numeric types. 

 - In computers, all the data and particularly numerical data are represented as a series of ones and zeros. 
 - For example, number 55 in the binary numeral system is represented as 00110111.

```csharp
public static void Example3()
{
    string expression = string.Format("2 >> 3");
    Expression evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("2 << 3");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("2 & 3");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("2 | 3");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("2 ^ 3");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("~false");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());
}
```

### Comparison Operators

Comparison operators are used to comparing two or more operands. C# supports the following comparison operators.

- greater than (>)
- less than (<)
- greater than or equal to (>=)
- less than or equal to (<=)
- equality (==)
- difference (!=)

The following example shows the usage of comparison operators.

```csharp
public static void Example4()
{
    string expression = string.Format("2 > 3");
    Expression evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("2 < 3");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("2 >= 3");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("2 <= 3");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("2 != 3");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = string.Format("2 == 3");
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());
}
```
