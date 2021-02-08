---
PermaID: 100044
Name: Abstract Class
---

# Abstract Class

The term abstraction is used to hide certain details and showing only essential information to the user. The `MustInherit` modifier indicates that the class or member has a missing or incomplete implementation. 

 - The `MustInherit` modifier can be used with classes, methods, properties, indexers, and events. 
 - When the `MustInherit` modifier is used in a class declaration, it is intended only to be a base class of other classes, and it cannot be instantiated on its own. 
 - Members marked as `MustOverride` must be implemented by non-abstract classes that derive from the abstract class.
 - You can use the `MustOverride` modifier in a method or property declaration to indicate that the method or property does not contain implementation.

Let's have a look at the following simple example.

```csharp
Public MustInherit Class Shape
    Public MustOverride Function CalculateArea() As Double
End Class
```

We have declared the `Shape` class as an abstract. It contains a single method `CalculateArea()`, which is also abstract. So it means that we now need to inherit the `Shape` class and provide the implementation for the `CalculateArea()` method.

```csharp
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

As you can see, we have provided an implementation for the `CalculateArea()` abstract method in both child classes `Circle` and `Rectangle` with their implementation by calculating the area of circle and rectangle respectively.

Now we can create `Circle` and `Rectangle` objects and assign them to `Shape` instances, but we cannot create an object of the `Shape` class because it is an abstract class.

```csharp
Dim circle As Shape = New Circle(2.5)
Dim rectangle As Shape = New Rectangle(4.75, 6.25)

Console.WriteLine("The area of the circle is " & circle.CalculateArea())
Console.WriteLine("The area of the rectangle is " & rectangle.CalculateArea())
```

You can see that both objects can call the `CalculateArea()`, but the right version of the `CalculateArea()` method is not being determined at compile time but determined at runtime. 

Let's run the above code, and you will see the following output.

```csharp
The area of the circle is 19.625
The area of the rectangle is 29.6875
```
