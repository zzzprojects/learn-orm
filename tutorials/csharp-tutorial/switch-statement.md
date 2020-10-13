---
PermaID: 100013
Name: Switch Statement
---

# Switch Statement

A switch statement allows a variable to be tested for equality against a list of values. It is a selection statement that chooses a single switch section to execute from a list of candidates based on a pattern match with the match expression.

 - Each value is called a case, and the variable being switched on is checked for each switch case.
 - It provides an efficient way to transfer the execution to different parts of a code based on the value of the expression. 
 - The structure switch-case chooses which part of the programming code to execute based on the calculated value of a certain expression

```csharp
switch (expression) 
{
    case value1: // statement sequence
         break;
    
    case value2: // statement sequence
         break;
    .
    .
    .
    case valueN: // statement sequence
         break;
    
    default:    // default statement sequence
}
```

The switch statement can be used to replace the `if...else if` statement in C#. 

 - The advantage of using a switch over the `if...else if` statement is the codes will look much cleaner and readable with switch.
 - The switch statement evaluates the expression and compares its value with the values of each case such as value1, value2, up to valueN. 
 - When it finds the matching value, the statements inside that case are executed.

Let's consider the following simple example of a switch statement.

```csharp
int caseSwitch = 1;

switch (caseSwitch)
{
    case 1:
        Console.WriteLine("Case 1");
        break;
    case 2:
        Console.WriteLine("Case 2");
        break;
    default:
        Console.WriteLine("Default case");
        break;
}
```

## Rules

 - In C#, you can't use duplicate case values, it must be used only once.
 - The switch expression can be of a type such as `int`, `char`, `byte`, `short`, `enum`, or `string` type.
 - The switch expression and the case value must be of the same data type.
 - You can't use variables as the case value, it must be a constant or a literal.
 - To terminate the current sequence, use the `break` statement.
 - The default statement is optional and it is executed if none of the above cases matches the expression.

## Multiple Labels

The multiple labels are appropriate when you want to execute the same structure in more than one case. Let's consider the following example.

```csharp
int number = 6;
switch (number)
{
    case 1:
    case 4:
    case 6:
    case 8:
    case 10:
        Console.WriteLine("The number is not prime!");
        break;
    case 2:
    case 3:
    case 5:
    case 7:
        Console.WriteLine("The number is prime!"); 
        break;
    default:
        Console.WriteLine("Unknown number!"); 
        break;
}
```
In the above example, the multiple labels are implemented using case statements without a break statement. 

 - So here, first, the integer value of the expression is calculated and that is 6, and then this value is compared to every integer value in the case statements. 
 - When a match is found, the code block after it is executed. 
 - If no match is found, the default block is executed. 

The above example displays the following output.

```csharp
The number is not prime!
```