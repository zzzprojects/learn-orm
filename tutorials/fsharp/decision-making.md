---
PermaID: 100009
Name: Decision Making
---

# Decision Making

The `if...then` and `if...then...else` are conditional control or decision-making expressions. Using these expressions, the program can behave differently based on a defined condition checked during the expression's execution.

## `if...then` Expression

The basic format of the `if...then` expressions is as follows.

```csharp
let age = 15

if age < 16
then Console.WriteLine("You are only {0} years old and already learning F#? Wow!", age)
```

In the above example, the expression runs when the Boolean expression evaluates to `true`. 

## `if...then...else` Expression

The `if...then...else` expression runs different branches of code and also evaluates to a different value depending on the Boolean expression given.

The following example shows how to use the `if...then...else` expression.

```csharp
let num1 = 12
let num2 = 19

if num1 < num2 then Console.WriteLine("{0} is less than {1}", num1, num2)
else Console.WriteLine("{0} is greater than {1}", num1, num2)
```

## Multiple `if...then...else` Expressions

When chaining multiple `if...then...else` expressions together, you can use the keyword `elif` instead of `else if`; they are equivalent.

```csharp
let marks = 79;

if marks >= 90 then Console.WriteLine("A+")
elif marks >= 80 then Console.WriteLine("A")
elif marks >= 70 then Console.WriteLine("B")
elif marks >= 60 then Console.WriteLine("C")
elif marks >= 50 then Console.WriteLine("D")
else Console.WriteLine("F")
```

In the above example, a series of comparisons of a variable `marks` to check if it is one of the grades (such as A+, A, B, C, or D). Every following comparison is done only in the case that the previous comparison was not `true`. In the end, if none of the `if` conditions is not fulfilled, the last `else` clause is executed. 

The result of the above example is shown below.

```csharp
B
```
