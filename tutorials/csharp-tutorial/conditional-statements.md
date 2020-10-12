---
PermaID: 100012
Name: Conditional Statements
---

# Conditional Statements

The `if` and `if-else` are conditional control statements. Using conditional statements, the program can behave differently based on a defined condition checked during the execution of the statement.

## if Statement

The basic format of the `if` conditional statement is as follows.

```csharp
if (Boolean expression)
{
    Body of the conditional statement;
}
```

An `if` statement identifies which statement to run based on the value of a **Boolean expression**.

 - The **Boolean expression** can be a boolean variable or boolean logical expression. 
 - **Boolean expressions** cannot be integer unlike other programming languages like C and C++.
 - The **Body of the conditional statement** is the part locked between the curly brackets: {}, and it may consist of one or more statements. 

## if-else Statement

In an `if-else` statement, if the condition evaluates to `true`, the **Body of the conditional statement** runs. If the condition is `false`, the else-statement runs. 

```csharp
if (Boolean expression)
{
    Body of the conditional statement;
}
else
{
    Body of the else statement;
}
```

 - The Boolean expression or condition can't be simultaneously `true` and `false`, the **Body of the conditional statement** and the **Body of the else statement** of an `if-else` statement can never both run. 
 - After the **Body of the conditional statement** or the **Body of the else statement** runs, control is transferred to the next statement after the if statement.

In the following example, the bool variable condition is set to `true` and then checked in the `if` statement. 

```csharp
bool condition = true;

if (condition)
{
    Console.WriteLine("The variable is set to true.");
}
else
{
    Console.WriteLine("The variable is set to false.");
}
```

When there are several operations, we have a complex block operator, i.e. series of commands that follow one after the other, enclosed in curly brackets.

## Multiple if-else Statements

In some cases, we need to use a sequence of `if` structures or multiple `if-else` statements, where the `else` clause is a new `if` structure. 

 - If we use nested if structures, the code would be pushed too far to the right. 
 - In such situations, it is allowed to use a new `if` right after the `else` and it is considered a good practice. 

```csharp
int marks = 79;

if (marks >= 90)
{
    Console.WriteLine("A+");
}
else if (marks >= 80)
{
    Console.WriteLine("A");
}
else if (marks >= 70)
{
    Console.WriteLine("B");
}
else if (marks >= 60)
{
    Console.WriteLine("C");
}
else if (marks >= 50)
{
    Console.WriteLine("D");
}
else
{
    Console.WriteLine("F");
}
```

In the above example, a series of comparisons of a variable `marks` to check `if` it is one of the grades (such as A+, A, B, C, or D). Every following comparison is done only in the case that the previous comparison was not `true`. In the end, if none of the `if` conditions is not fulfilled, the last `else` clause is executed. 

The result of the above example is shown below.

```csharp
B
```