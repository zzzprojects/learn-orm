Module Interfaces
    Interface IShape
        Property X As Double
        Property Y As Double
        Sub Draw()
        Function CalculateArea() As Double
    End Interface

    Public Class Rectangle
        Implements IShape

        Public Property X As Double Implements IShape.X
        Public Property Y As Double Implements IShape.Y

        Public Sub New(ByVal xVal As Double, ByVal yVal As Double)
            X = xVal
            Y = yVal
        End Sub

        Public Function CalculateArea() As Double Implements IShape.CalculateArea
            Return X * Y
        End Function

        Public Sub Draw() Implements IShape.Draw
            Console.WriteLine("Draw rectangle of X = {0}, Y = {1}.", X, Y)
        End Sub

    End Class

    Public Sub Example1()
        Dim rectangle As IShape = New Rectangle(5, 7)
        rectangle.Draw()
        Console.WriteLine("The area of the rectangle is " & rectangle.CalculateArea())
    End Sub
End Module
