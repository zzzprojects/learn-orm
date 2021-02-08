---
PermaID: 100048
Name: Delegates
---

# Delegates

A delegate is a data type that holds a reference to a method with a compatible signature. It is similar to a function pointer in C and C++.

 - A delegate is a reference type variable that holds the reference to a method, and the reference can be changed at runtime.
 - It is mainly used for implementing events, and the call-back methods and all delegates are implicitly derived from the `System.Delegate` class.
 - It provides a way that tells which method is to be called when an event is triggered.

The following example declares a delegate named `MyDelegate` that can encapsulate a method that takes a string as an argument and returns `void`.

```csharp
Private Delegate Sub MyDelegate(ByVal message As String)
```

The delegate type can be declared using the `delegate` keyword. After a delegate declaration, you can call those methods whose return type and parameter-list match with the delegate using its instance.

Let's create a simple method that will take a string as a parameter and print that string to the console window.

```csharp
Private Sub PrintMessage(ByVal message As String)
    Console.WriteLine(message)
End Sub
```

A delegate object is created with the help of the `new` keyword or you can assign the method name directly to the delegate object as shown below. 

```csharp
Private Sub Welcome(ByVal message As String)
    Console.WriteLine("Welcome: " & message)
End Sub

Private Sub GoodBye(ByVal message As String)
    Console.WriteLine("Bye-bye: " & message)
End Sub
```

Once a delegate is instantiated, a method call made to the delegate is passed by the delegate to that method. 

```csharp
Public Sub Example1()
    Dim delegate1 As MyDelegate = New MyDelegate(AddressOf PrintMessage)
    Dim delegate2 As MyDelegate = AddressOf PrintMessage
    delegate1("This is a VB.NET Tutorial.")
    delegate1("You are learning Delegates.")
End Sub
```

Let's run the above code, and you will see the following output.

```csharp
This is a VB.NET Tutorial.
You are learning Delegates.
```

Let's have a look into another example where we use a single delegate object and different methods with that object. Here are the delegate declaration and `MathUtility` class implementation.

```csharp
Private Delegate Function MyMathDelegate(ByVal number1 As Integer, ByVal number2 As Integer) As Integer

Module MathUtility
    Function Add(ByVal number1 As Integer, ByVal number2 As Integer) As Integer
        Return (number1 + number2)
    End Function

    Function Subtract(ByVal number1 As Integer, ByVal number2 As Integer) As Integer
        Return (number1 - number2)
    End Function

    Function Multiply(ByVal number1 As Integer, ByVal number2 As Integer) As Integer
        Return (number1 * number2)
    End Function
End Module
```

The following code first instantiates the delegate object and uses different methods one by one.

```csharp
Public Sub Example2()
    Dim mathDelegate As MyMathDelegate = New MyMathDelegate(AddressOf MathUtility.Add)
    Dim num1 As Integer = 10
    Dim num2 As Integer = 20
    Console.WriteLine("Add({0}, {1}) = {2}", num1, num2, mathDelegate(num1, num2))
    mathDelegate = AddressOf MathUtility.Subtract
    Console.WriteLine("Subtract({0}, {1}) = {2}", num1, num2, mathDelegate(num1, num2))
    mathDelegate = AddressOf MathUtility.Multiply
    Console.WriteLine("Multiply({0}, {1}) = {2}", num1, num2, mathDelegate(num1, num2))
End Sub
```

Let's run the above code and you will see the following output.

```csharp
Add(10, 20) = 30
Subtract(10, 20) = -10
Multiply(10, 20) = 200
```

## Combine Delegates

A useful property of delegate objects is that multiple objects can be assigned to one delegate instance using the `Delegate.Combine` method. 

 - The multicast delegate contains a list of the assigned delegates. 
 - When the multicast delegate is called, it invokes the delegates in the list, in order. 
 - Only delegates of the same type can be combined.

The following code shows how you can use the multicasting of a delegate.

```csharp
Private Delegate Sub MyDelegate(ByVal message As String)

Private Sub Welcome(ByVal message As String)
    Console.WriteLine("Welcome: " & message)
End Sub

Private Sub GoodBye(ByVal message As String)
    Console.WriteLine("Bye-bye: " & message)
End Sub

Public Sub CombineDelegatesExample()
    Dim welcomeDel As MyDelegate = AddressOf Welcome
    Dim goodByeDel As MyDelegate = AddressOf GoodBye
    Dim welcomeGoodByeDel As MyDelegate = [Delegate].Combine(welcomeDel, goodByeDel)

    Console.WriteLine("Call welcomeDel.")
    welcomeDel("Mark")
    Console.WriteLine(vbLf & "Call goodByeDel.")
    goodByeDel("John")
    Console.WriteLine(vbLf & "Call welcomeGoodByeDel.")
    welcomeGoodByeDel("Stella")
End Sub
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
