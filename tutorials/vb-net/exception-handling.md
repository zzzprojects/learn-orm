---
PermaID: 100033
Name: Exception Handling
---

# Exception Handling

When we write a program, in most of the cases we rely upon that the program will execute normally and most of the time, programs are following the normal pattern, but there are some exceptions. 

 - When you execute your code and an error occurs, VB.NET will normally stop and generate an error message and will throw an exception.
 - Exceptions in the application must be handled to prevent the crashing of the program and unexpected results.

In VB.NET, exception handling is done with the `Try...Catch...Finally` statement. The `Try` encloses the statements that might throw an exception, the `Catch` handles an exception, and the `Finally` can be used for any cleanup work.

The basic syntax of the `Try...Catch...Finally` statement is as follows.

```csharp
Try
    tryStatement(s)
    Exit Try
Catch exception As type
    catchStatement(s)
    Exit Try
Finally
    finallyStatement(s)
End Try
```

If any exception occurs inside the `Try` block, then control transfers to the appropriate `Catch` block and later to the `Finally` block. 

## Try Block

A `Try` block is used to write a portion of code that might be affected by an exception. 

 - If any code throws an exception within that `Try` block, the exception will be handled by the corresponding `Catch` block.
 - A `Try` block requires one or more associated `Catch` blocks, or a `Finally` block, or both.

## Catch Block

When an exception occurs, the `Catch` block of code is executed. This is where you can handle the exception, log it, or ignore it.

## Finally Block

A `Finally` block contains code that is run regardless of whether or not an exception is thrown in the `Try` block, such as releasing resources that are allocated in the `Try` block. 

## How It Works?

If any exception occurs inside the `Try` block, then control transfers to the appropriate `Catch` block and later to the `Finally` block.

 - In VB.NET, both catch and finally blocks are optional. 
 - The `Try` block can exist either with one or more `Catch` blocks or a `Finally` block or with both `Catch` and `Finally` blocks.
 - If no exception occurred inside the `Try` block, the control directly transfers to the `Finally` block. 
 - We can say that the statements inside the `Finally` block are always executed.

In the following example, we have several statements in a `Try` block. If an exception occurs inside a `Try` block, then the program will jump to the `Catch` block. Inside a `Catch` block, we display a message to instruct the user about the error, and in the `Finally` block we will display a message.

```csharp
Public Sub Example1()
    Try
        Dim num = Integer.Parse("6")
        Console.WriteLine("The number is {0}", num)
        Dim num1 = Integer.Parse("a")
        Console.WriteLine("The number is {0}", num)
    Catch
        Console.Write("Error occurred.")
    Finally
        Console.Write("It will be executed always because I am in Finally block.")
    End Try
End Sub
```

The above example may throw an exception when a non-numeric character is specified to convert from string to an `int`.

```csharp
The number is 6
Error occurred.
It will be executed always because I am in Finally block.
```

You can also catch the actual error by specifying a parameter of a built-in or custom exception class to get an error detail. The following example includes the `Exception` type parameter that catches all types of exceptions.

```csharp
Public Sub Example2()
    Try
        Dim num = Integer.Parse("6")
        Console.WriteLine("The number is {0}", num)
        Dim num1 = Integer.Parse("a")
        Console.WriteLine("The number is {0}", num)
    Catch e As Exception
        Console.Write(e.Message)
    Finally
        Console.Write("It will be executed always because I am in Finally block.")
    End Try
End Sub
```

Let's run the above code and now you will see the actual error when a character is parsed to an integer.

```csharp
The number is 6
Input string was not in a correct format.
It will be executed always because I am in Finally block.
```

## Multiple Catch Blocks

You can use multiple `Catch` blocks when you are not sure about the exception type that may be generated, so you can write different blocks to tackle any type of exception that can occur.

```csharp
Public Sub Example3()
    Try
        Dim num = Integer.Parse("6")
        Console.WriteLine("The number is {0}", num)
        Dim num1 = Integer.Parse("a")
        Console.WriteLine($"The number is {0}", num)
    Catch e As FormatException
        Console.WriteLine(e.Message)
    Catch e As IndexOutOfRangeException
        Console.WriteLine(e.Message)
    Catch e As DivideByZeroException
        Console.WriteLine(e.Message)
    Catch e As Exception
        Console.Write(e.Message)
    Finally
        Console.Write(vbLf & "It will be executed always because I am in finally block.")
    End Try
End Sub
```
