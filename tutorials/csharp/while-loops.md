---
PermaID: 100014
Name: While Loops
---

# While Loops

## What is Loop?

In programming, developers often require a repeated execution of a sequence of operations. A loop is a basic programming construct that allows repeated execution of a fragment of source code. 

### What is While Loops?

In a while loop, the code is repeated a fixed number of times or it repeats until a given condition is true.

```csharp
while (condition)
{
    body loop;
}
```

 - The while statement executes a statement or a block of statements while a specified condition evaluates to true.
 - The condition is evaluated before each execution of the loop, a while loop executes zero or more times. 

#### Example

Let's consider a very simple example of using the while loop. 

```csharp
// Initialize the counter
int counter = 0;

// Execute the loop body while the loop condition holds
while (counter <= 5)
{
    // Print the counter value
    Console.WriteLine("Number: " + counter);

    // Increment the counter
    counter++;
}
```

It will print the numbers in the range from 0 to 4 in ascending order on the console window.

```csharp
Number: 0
Number: 1
Number: 2
Number: 3
Number: 4
```

### What is do-while Loops?

The `do-while` loop is similar to the `while` loop, but it checks the condition after each execution of its body loop.

```csharp
do
{
    executable code;
} 
while (condition);
```

The body of the `do-while` loop will execute at least once irrespective of the test-expression.

#### Example

Let's consider the same example of using the `do-while` loop.

```csharp
// Initialize the counter
int counter = 0;

// Execute the do-while body loop
do
{
    // Print the counter value
    Console.WriteLine("Number: " + counter);

    // Increment the counter
    counter++;
}
while (counter <= 5);
```

It will print the numbers in the range from 0 to 5 in ascending order on the console window.

```csharp
Number: 0
Number: 1
Number: 2
Number: 3
Number: 4
Number: 5
```

You can see that `do-while` is executed one more time and that is because the condition is checked after the body is executed, but in while loop, the condition is checked at the start.

