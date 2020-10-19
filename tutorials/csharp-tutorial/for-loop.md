---
PermaID: 100015
Name: For Loop
---

# For Loop

The `for-loop` is slightly more complicated than `while` and `do-while` loops but it can solve more complicated tasks with less code. Here is the scheme describing `for-loop`.

```csharp
for (Initialization; Condition; iterator)
{
    loop's body;
}
```

The `for` loop has the following three blocks.

### Initialization 

The initialization block initializes a local for loop variable. 

 - It sets the starting value for a counter of the number of iterations to be made by the loop. 
 - An integer variable is used for this purpose and is traditionally named `i`.

### Condition 

The condition is a boolean expression that will return either `true` or `false`. 

 - Upon each iteration of the loop, the test expression is evaluated and that iteration will only continue while this expression is true. 
 - When the tested expression becomes false, the loop ends immediately without executing the statements again.

### Iterator

The iterator either increment or decrement the loop variable. On each iteration, the counter is updated then the statements are executed.

## Example

Let's consider a very simple example of using the `for` loop. 

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Counter: {0}", i);
}
```

 - In the above example, `int i = 0` is an initializer where an `int i` is defined and initialized to 0. 
 - The condition expression is `i < 5`, if it returns `true` then it will execute a code block. 
 - After executing the code block, it will go to the iterator and i++ is an incremental statement that increments the value of a loop variable `i` by 1. 
 - Now, it will check the conditional expression again and repeat the same steps until the conditional expression returns `false`. 

Let's run the above code and it will print the following output on the console window.

```csharp
Counter: 0
Counter: 1
Counter: 2
Counter: 3
Counter: 4
```

Here is another example that is a little bit more complicated. 

```csharp
for (int i = 1, sum = 1; i <= 64; i = i * 2, sum += i)
{
    Console.WriteLine("i={0}, sum={1}", i, sum);
}
```

In the above example, we have two variables `i` and `sum`, that initially have the value of 1, but we update them consecutively at each iteration of the loop. Let's try this example and you will see the following output.

```csharp
i=1, sum=1
i=2, sum=3
i=4, sum=7
i=8, sum=15
i=16, sum=31
i=32, sum=63
i=64, sum=127
```

All the examples related to the `for` loop are available in the `ForLoop.cs` file of the source code. Download the source code and try out all the examples for better understanding.
