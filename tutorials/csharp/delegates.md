---
PermaID: 100035
Name: Delegates
---

# Delegates

A delegate is a data type that holds a reference to a method with a compatible signature. It is similar to a function pointer in C and C++.

 - A delegate is a reference type variable that holds the reference to a method and the reference can be changed at runtime.
 - It is mainly used for implementing events and the call-back methods and all delegates are implicitly derived from the `System.Delegate` class.
 - It provides a way that tells which method is to be called when an event is triggered.

The following example declares a delegate named `MyDelegate` that can encapsulate a method that takes a string as an argument and returns `void`.

```csharp
public delegate void MyDelegate(string message);
```

The delegate type can be declared using the `delegate` keyword. After a delegate declaration, you can call those methods whose return type and parameter-list matches with the delegate using its instance.

Let's create a simple method that will take a string as a parameter and print that string to the console window.

```csharp
private static void PrintMessage(string message)
{
    Console.WriteLine(message);
}
```

A delegate object is created with the help of the `new` keyword or you can assign the method name directly to the delegate object as shown below. 

```csharp
MyDelegate delegate1 = new MyDelegate(PrintMessage);
MyDelegate delegate2 = PrintMessage;

delegate1("This is a C# Tutorial.");
delegate1("You are learning Delegates.");
```

Once a delegate is instantiated, a method call made to the delegate is passed by the delegate to that method. Let's run the above code and you will see the following output.

```csharp
This is a C# Tutorial.
You are learning Delegates.
```

Let's have a loot into another example where we use a single delegate object and different methods with that object. Here are the delegate declaration and `MathUtility` class implementation.

```csharp
private delegate int MyMathDelegate(int number1, int number2);
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

The following code first instantiates the delegate object and uses different methods one by one.

```csharp
MyMathDelegate mathDelegate = new MyMathDelegate(MathUtility.Add);
int num1 = 10;
int num2 = 20;

Console.WriteLine("Add({0}, {1}) = {2}", num1, num2, mathDelegate(num1, num2));

// Assign the Subtract method reference to the delegate object.
mathDelegate = MathUtility.Subtract;
Console.WriteLine("Subtract({0}, {1}) = {2}", num1, num2, mathDelegate(num1, num2));

// Assign the Multiply method reference to the delegate object.
mathDelegate = MathUtility.Multiply;
Console.WriteLine("Multiply({0}, {1}) = {2}", num1, num2, mathDelegate(num1, num2));
```

Let's run the above code and you will see the following output.

```csharp
Add(10, 20) = 30
Subtract(10, 20) = -10
Multiply(10, 20) = 200
```

## Combine Delegates

A useful property of delegate objects is that multiple objects can be assigned to one delegate instance by using the `+` operator. 

 - The multicast delegate contains a list of the assigned delegates. 
 - When the multicast delegate is called, it invokes the delegates in the list, in order. 
 - Only delegates of the same type can be combined.

The following code shows how you can use multicasting of a delegate.

```csharp
private delegate void MyDelegate(string message);

private static void Welcome(string message)
{
    Console.WriteLine("Welcome: " + message);
}

private static void GoodBye(string message)
{
    Console.WriteLine("Bye-bye: " + message);
}

public static void CombineDelegatesExample()
{
    MyDelegate welcomeDel = Welcome;
    MyDelegate goodByeDel = GoodBye;

    MyDelegate welcomeGoodByeDel = welcomeDel + goodByeDel;

    Console.WriteLine("Call welcomeDel.");
    welcomeDel("Mark");

    Console.WriteLine("\nCall goodByeDel.");
    goodByeDel("John");

    Console.WriteLine("\nCall welcomeGoodByeDel.");
    welcomeGoodByeDel("Stella");
}
```

Let's run the above code and you will see the following output.

```csharp
Call welcomeDel.
Welcome: Mark

Call goodByeDel.
Bye-bye: John

Call welcomeGoodByeDel.
Welcome: Stella
Bye-bye: Stella
```

For more information about delegates, visit [https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/)

All the examples related to the delegates are available in the `Delegates.cs` file of the source code. Download the source code and try out all the examples for better understanding.
