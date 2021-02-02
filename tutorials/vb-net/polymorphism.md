---
PermaID: 100028
Name: Polymorphism
---

# Polymorphism

Polymorphism is the next fundamental principle of Object-Oriented Programming (OOP). Polymorphism is a Greek word that means **many-shaped** i.e. one object has many forms or has one name with multiple functionalities. 

 - Polymorphism allows treating objects of a derived class as objects of its base class. 
 - It provides the ability for a class to have multiple implementations with the same name.

There are two types of polymorphism. 

 - [Compile-time Polymorphism](#compile-time-polymorphism) 
 - [Runtime Polymorphism](#runtime-polymorphism)

## Compile-time Polymorphism

Compile-time polymorphism is achieved using method overloading and operator overloading. The method overloading means defining multiple methods with the same name but with different parameters.

 - Using method overloading you can perform different tasks with the same method name by passing different parameters.
 - You can overload methods in the same class only, it doesn't need a parent-child relationship.

Compile-time polymorphism is also known as static binding or early binding. The following code shows the method overloading of `Add()` methods, where both methods have the same name and different parameters.

```csharp
Public Class MathUtility
    Public Function Add(ByVal number1 As Integer, ByVal number2 As Integer) As Integer
        Return (number1 + number2)
    End Function

    Public Function Add(ByVal number1 As Integer, ByVal number2 As Integer, ByVal number3 As Integer) As Integer
        Return (number1 + number2 + number3)
    End Function
End Class
```

In the above class, we defined two methods with the same name `Add` but with different parameters to achieve method overloading and it is called a compile-time polymorphism.

You can call these methods to achieve a different result.

```csharp
Public Sub MethodOverloadingExample()
    Dim utility As MathUtility = New MathUtility()

    utility.Add(2, 3)
    utility.Add(2, 3, 4)
End Sub
```

### Runtime Polymorphism

Runtime polymorphism is achieved by method overriding which is also known as dynamic binding or late binding. The method overriding means defining methods in parent and child class with the same name and signature but different implementation.

 - In this type of polymorphism, we override a base class method in the derived class by creating a similar function with a different implementation.
 - This can be achieved by using `Overridable` & `Overrides` keywords along with the inheritance principle.

#### Overriding members

By default, a derived class inherits all members from its base class. If you want to change the behavior of the inherited member, you need to override it. That is, you can define a new implementation of the method, property, or event in the derived class.

The following modifiers are used to control how properties and methods are overridden.

| Modifier      | Description                                                               |
| :-------------| :-------------------------------------------------------------------------|
| Overridable   | Allows a class member to be overridden in a derived class.                |
| Overrides     | Overrides a virtual (overridable) member defined in the base class.       |
| NotOverridable| Prevents a member from being overridden in an inheriting class.           |
| MustOverride  | Requires that a class member be overridden in the derived class.       |
| Shadows       | Hides a member inherited from a base class                                |

Here is the simple example of method overriding, where the `Shape` class contains an `Overridable` method `CalculateArea()` which we will override in child classes.

```csharp
Public Class Shape
    Public Overridable Function CalculateArea() As Double
        Return 0
    End Function
End Class

Public Class Circle
    Inherits Shape

    Public Property Radius As Double

    Public Sub New(ByVal rad As Double)
        Radius = rad
    End Sub

    Public Overrides Function CalculateArea() As Double
        Return (3.14) * Math.Pow(Radius, 2)
    End Function
End Class

Public Class Rectangle
    Inherits Shape

    Public Property Height As Double
    Public Property Width As Double

    Public Sub New(ByVal h As Double, ByVal w As Double)
        Height = h
        Width = w
    End Sub

    Public Overrides Function CalculateArea() As Double
        Return Height * Width
    End Function
End Class
```

As you can see, we have two child classes `Circle` and  `Rectangle` and both classes override the `CalculateArea()` method with their implementation by calculating the area of circle and rectangle respectively.

Now we can create `Shape`, `Circle`, and `Rectangle` objects and assign them to `Shape` instances.

```csharp
Public Sub MethodOverridingExample()
    Dim shape As Shape = New Shape()
    Dim circle As Shape = New Circle(3.0)
    Dim rectangle As Shape = New Rectangle(3.0, 4.0)

    Console.WriteLine("The area of the shape is " & shape.CalculateArea())
    Console.WriteLine("The area of the circle is " & circle.CalculateArea())
    Console.WriteLine("The area of the rectangle is " & rectangle.CalculateArea())
End Sub
```

You can see that both objects can call the `CalculateArea()` but the right version of the `CalculateArea()` method is not being determined at compile time but determined at runtime. 

Let's run the above code and you will see the following output.

```csharp
The area of the shape is 0
The area of the circle is 28.26
The area of the rectangle is 12
```

All the examples related to the polymorphism are available in the `Polymorphism.cs` file of the source code. Download the source code and try out all the examples for better understandings.
