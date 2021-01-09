---
PermaID: 100017
Name: Break and Continue Statements
---

# Break and Continue Statements

## Break Statement

A `break` statement can be included in any kind of loop to immediately terminate the loop when a test condition is met. The `break` ensures no further iterations of that loop will be executed.

 - When the `break` statement is executed, it immediately terminates the loop and transfers the program control to the next statement after the loop.
 - It can also be used to terminate a case in the `switch` statement.
 - If the `break` statement is used inside nested loops, then it terminates only those loops which contain the `break` statement.

### Example

In the following example, the conditional statement contains a counter that is supposed to count from 0 to 10; however, the break statement terminates the loop after `i` is equal to 5.

```csharp
for (int i = 0; i <= 10; i++)
{
    Console.WriteLine("Counter: {0}", i);

    if (i == 5)
        break;
}
```

Let's run the above code and it will print the following output on the console window.

```csharp
Counter: 0
Counter: 1
Counter: 2
Counter: 3
Counter: 4
Counter: 5
```

Let's consider the following example of a `break` statement inside the `switch` statement.

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

Let's run the above code and it will print the following output on the console window.

```csharp
Case 1
```

## Continue Statement

A `continue` statement can be included in any kind of loop to immediately terminate that particular iteration of the loop when a test condition is met. 

 - The continue statement allows the loop to proceed to the next iteration.
 - It stops the current iteration of the inner loop, without terminating the loop. 

### Example

In the following example, a counter is initialized to count from 0 to 10. The `continue` statement is executed when the boolean expression `(i > 3 && i < 8)` is `true`. 

```csharp
for (int i = 0; i <= 10; i++)
{
    if (i > 3 && i < 8)
        continue;

    Console.WriteLine("Counter: {0}", i);
}
```

The statements inside the `for-loop` after the `continue` statement are skipped in the iterations where `i` is greater than 3 and `i` is less than 8. 

Let's run the above code and it will print the following output on the console window.

```csharp
Counter: 0
Counter: 1
Counter: 2
Counter: 3
Counter: 8
Counter: 9
Counter: 10
```

All the examples related to the `break` and `continue` statements are available in the `BreakStatement.cs` and `ContinueStatement.cs` files respectively of the source code. Download the source code and try out all the examples for better understandings.