---
PermaID: 100025
Name: Static Class
---

# Static Class

A static class is the same as a non-static class, the only difference is that a static class cannot be instantiated. 

 - In other words, you cannot use the new operator to create a variable of the class type. 
 - You access the members of a static class by using the class name itself.
 - A static class can contain static members only, you can't add non-static members to a static class.

Similar to static members, a class is static when the keyword static is used in its declaration. 

```csharp
[<AccessModifier>] static class <ClassName>
{
// … Class body goes here
}
```

## Why We Need Static Class?

Let's suppose that we have a class with a single method that always works in the same manner. For example, we have a method that takes two numbers as a parameter and returns their sum as a result. 

 - In this scenario, there is no matter exactly which object of that class is going to call that method since it will always do the same thing by adding two numbers, independent of the calling object.
 - The behavior of the method does not depend on the object state.
 - So why the need to create an object to call that method provided that the method does not depend on any of the objects of that class?
 - A static class can be used as a convenient container for sets of methods that just operate on input parameters and do not have to get or set any internal instance fields.   

Let's have a look into the following static class which contains three static methods.

```csharp
public static class MathUtility
{
    public static int Add(int number1, int number2)
    {
        return (number1 + number2);
    }

    public static int Subtract(int number1, int number2)
    {
        return (number1 - number2);
    }

    public static int Multiply(int number1, int number2)
    {
        return (number1 * number2);
    }
}
```

You can call static members using the class name.

```csharp
int number1 = 5;
int number2 = 9;

int result1 = MathUtility.Add(number1, number2);
int result2 = MathUtility.Subtract(number1, number2);
int result3 = MathUtility.Multiply(number1, number2);

Console.WriteLine("{0} + {1} = {2}", number1, number2, result1);
Console.WriteLine("{0} - {1} = {2}", number1, number2, result2);
Console.WriteLine("{0} * {1} = {2}", number1, number2, result3);
```

Let's run the above code and you will see the following output.

```csharp
5 + 9 = 14
5 - 9 = -4
5 * 9 = 45
```

All the examples related to the static class are available in the `StaticClass.cs` file of the source code. Download the source code and try out all the examples for better understandings.