---
PermaID: 100004
Name: Functions
---

# Functions

The **CoreCLR-NCalc** library provides many functions from `System.Math` which you can use directly in your expression or script.

The framework includes the following built-in functions.

| Name              | Description                                                                                 |
| :-----------------| :-------------------------------------------------------------------------------------------|
| Abs               | Returns the absolute value of a specified number.	                                          |
| Acos              | Returns the angle whose cosine is the specified number.                                     |
| Asin              | Returns the angle whose sine is the specified number.	                                      |
| Atan              | Returns the angle whose tangent is the specified number.	                                  |
| Ceiling           | Returns the smallest integer greater than or equal to the specified number.                 |
| Cos               | Returns the cosine of the specified angle.                                                  |
| Exp               | Returns e raised to the specified power.	                                                  |
| Floor             | Returns the largest integer less than or equal to the specified number.                     |
| IEEERemainder     | Returns the remainder resulting from the division of a specified number by another specified number. |
| Log               | Returns the logarithm of a specified number.                                                |
| Log10             | Returns the base 10 logarithm of a specified number.                                        |
| Max               | Returns the larger of two specified numbers.                                                |
| Min               | Returns the smaller of two numbers.                                                         |
| Pow               | Returns a specified number raised to the specified power.                                   |
| Round             | Rounds a value to the nearest integer or specified number of decimal places. The mid number behavior can be changed by using EvaluateOption.RoundAwayFromZero during construction of the Expression object. |
| Sign              | Returns a value indicating the sign of a number.                                            |
| Sin               | Returns the sine of the specified angle.                                                    |
| Sqrt              | Returns the square root of a specified number.                                              |
| Tan               | Returns the tangent of the specified angle.                                                 |
| Truncate          | Calculates an integral part of a number.                                                   |
| in                | Returns whether an element is in a set of values.	                                          |
| if                | Returns a value based on a condition.	                                                      |

Let's consider the following simple example, which shows the usage of built-in functions.

```csharp
public static void Example1()
{        
    string expression = "Abs(-3.2)";
    Expression evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = "Acos(-0.5)";
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = "Floor(4.23)";
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = "IEEERemainder(9, 8)";
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = "Log10(1000)";
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = "in(1 + 1, 1, 2, 3)";
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());

    expression = "if(3 % 2 = 1, 'value is true', 'value is false')";
    evaluator = new Expression(expression);
    Console.WriteLine("{0} = {1}", expression, evaluator.Evaluate());
}
```
