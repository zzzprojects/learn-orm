Module Polymorphism
    Public Class MathUtility
        Public Function Add(ByVal number1 As Integer, ByVal number2 As Integer) As Integer
            Return (number1 + number2)
        End Function

        Public Function Add(ByVal number1 As Integer, ByVal number2 As Integer, ByVal number3 As Integer) As Integer
            Return (number1 + number2 + number3)
        End Function
    End Class

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

    Public Sub MethodOverloadingExample()
        Dim utility As MathUtility = New MathUtility()
        utility.Add(2, 3)
        utility.Add(2, 3, 4)
    End Sub

    Public Sub MethodOverridingExample()
        Dim shape As Shape = New Shape()
        Dim circle As Shape = New Circle(3.0)
        Dim rectangle As Shape = New Rectangle(3.0, 4.0)

        Console.WriteLine("The area of the shape is " & shape.CalculateArea())
        Console.WriteLine("The area of the circle is " & circle.CalculateArea())
        Console.WriteLine("The area of the rectangle is " & rectangle.CalculateArea())
    End Sub
End Module
