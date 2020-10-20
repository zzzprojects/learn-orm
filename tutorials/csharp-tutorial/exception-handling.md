---
PermaID: 100031
Name: Exception Handling
---

# Exception Handling

When we write a program, and in most of the cases we rely upon that the program will execute normally and most of the time, programs are following the normal pattern, but there are some exceptions. 

 - When you execute your code and an error occurs, C# will normally stop and generate an error message and will throw an exception.
 - Exceptions in the application must be handled to prevent the crashing of the program and unexpected results.

In C#, exception handling is done with the `try`, `catch`, and `finally` keywords. The `try` encloses the statements that might throw an exception, the `catch` handles an exception and the `finally` can be used for any cleanup work.

The following examples show a `try-catch-finally` statement.

```csharp
try
{
    // Code to try goes here.
}
catch (SomeSpecificException ex)
{
    // Code to handle the exception goes here.
}
finally
{
    // Code to execute after the try (and possibly catch) blocks
}
```

If any exception occurs inside the try block, the control transfers to the appropriate catch block and later to the finally block. 

## Try Block

A `try` block is used to write a portion of code that might be affected by an exception. 

 - If any code throws an exception within that `try` block, the exception will be handled by the corresponding `catch` block.
 - A try block requires one or more associated catch blocks, or a `finally` block, or both.

## Catch Block

When an exception occurs, the `catch` block of code is executed. This is where you can handle the exception, log it, or ignore it.

## Finally Block

A `finally` block contains code that is run regardless of whether or not an exception is thrown in the `try` block, such as releasing resources that are allocated in the `try` block. 

## How It Works?

If any exception occurs inside the try block, the control transfers to the appropriate catch block and later to the finally block.

 - In C#, both catch and finally blocks are optional. 
 - The try block can exist either with one or more catch blocks or a finally block or with both catch and finally blocks.
 - If there is no exception occurred inside the try block, the control directly transfers to the `finally` block. 
 - We can say that the statements inside the `finally` block are executed always.

In the following example, we have several statements in a `try` block. If an exception occurs inside a try block, then the program will jump to the catch block. Inside a catch block, we display a message to instruct the user about the error, and in the finally block we will display a message.

```csharp
try
{
    var num = int.Parse("6");

    Console.WriteLine("The number is {0}", num);

    // let's specify an alphabet in the parse method and see the result.
    var num1 = int.Parse("a");

    Console.WriteLine("The number is {0}", num);

}
catch
{
    Console.Write("Error occurred.");
}
finally
{
    Console.Write("It will be executed always because I am in finally block.");
}
```

The above example may throw an exception when a non-numeric character is specified to convert from string to an `int`.

```csharp
The number is 6
Error occurred.
It will be executed always because I am in finally block.
```

You can also catch the actual error by specifying a parameter of a built-in or custom exception class to get an error detail. The following example includes the `Exception` type parameter that catches all types of exceptions.

```csharp
try
{
    var num = int.Parse("6");

    Console.WriteLine("The number is {0}", num);

    // let's specify an alphabet in the parse method and see the result.
    var num1 = int.Parse("a");

    Console.WriteLine("The number is {0}", num);
}
catch (Exception e)
{
    Console.Write(e.Message);
}
finally
{
    Console.Write("It will be executed always because I am in finally block.");
}
```

Let's run the above code and now you will see the actual error when a character is parsed to an integer.

```csharp
The number is 6
Input string was not in a correct format.
It will be executed always because I am in finally block.
```

## Multiple Catch Blocks

You can use multiple catch blocks when you are not sure about the exception type that may be generated, so you can write different blocks to tackle any type of exception that can occur.

```csharp
try
{
    var num = int.Parse("6");

    Console.WriteLine("The number is {0}", num);

    // let's specify an alphabet in the parse method and see the result.
    var num1 = int.Parse("a");

    Console.WriteLine($"The number is {0}", num);

}
catch (FormatException e)
{
    Console.WriteLine(e.Message);
}
catch (IndexOutOfRangeException e)
{
    Console.WriteLine(e.Message);
}
catch (DivideByZeroException e)
{
    Console.WriteLine(e.Message);
}
catch (Exception e)
{
    Console.Write(e.Message);
}
finally
{
    Console.Write("\nIt will be executed always because I am in finally block.");
}
```

All the examples related to the exception handling are available in the `ExceptionHandling.cs` file of the source code. Download the source code and try out all the examples for better understanding.
