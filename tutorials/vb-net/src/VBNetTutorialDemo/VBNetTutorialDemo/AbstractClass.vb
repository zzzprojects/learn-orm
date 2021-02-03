Module AbstractClass
    Public MustInherit Class Shape
        Public MustOverride Function CalculateArea() As Double
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

    Public Sub AbstractMethodExample()
        Dim circle As Shape = New Circle(2.5)
        Dim rectangle As Shape = New Rectangle(4.75, 6.25)

        Console.WriteLine("The area of the circle is " & circle.CalculateArea())
        Console.WriteLine("The area of the rectangle is " & rectangle.CalculateArea())
    End Sub

End Module
