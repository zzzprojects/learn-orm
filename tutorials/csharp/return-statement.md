---
PermaID: 100011
Name: Return Statement
---

# Return Statement

The return statement terminates the execution of the method in which it appears and returns control to the calling method. 

 - When the method is executed and returns a value, we can imagine that C# puts this value where the method has been called. 
 - The returned value can be used for any purpose from the calling method.

Generally, the return statement is useful when you want to get some value from any other method, if there is no need to get value from a method you can use void as a return type.

In the following example, `Add` and `Subtract` methods have `int` as return type and the `Caller` method has `void` as a return type.

```csharp
public int Add(int a, int b)
{
    return a + b;
}

public int Subtract(int a, int b)
{
    return a - b;
}

public void Caller()
{
    int numA = 4;
    int numB = 32;

    int result1 = Add(numA, numB);
    int result2 = Subtract(numA, numB);
}
```
In the `Add` and `Subtract` methods, we used a return statement at the end. It will execute the method and return the resultant value using a return statement. In the above example, `Add` and `Subtract` returns an integer after adding or subtracting the two integers passed as parameters.

If the return statement is inside a try block and if there is a finally block then it will be executed before control returns to the calling method.

```csharp
class Program
{
    static void Main(string[] args)
    {
        var result = ReturnExample(2, 1);
        Console.WriteLine(result);
    }

    public static int ReturnExample(int a, int b)
    {
        try
        {
            Console.WriteLine("Try block.");
            return a + b;
        }
        catch
        {
            Console.WriteLine("Catch");
        }
        finally
        {
            Console.WriteLine("finally block.");
        }

        return 0;
    }
}
```

Let's run the above example and you will see the following result.

```csharp
Try block.
finally block.
Result: 3
```

All the examples related to the return statement are available in the `ReturnStatement.cs` file of the source code. Download the source code and try out all the examples for better understanding.
