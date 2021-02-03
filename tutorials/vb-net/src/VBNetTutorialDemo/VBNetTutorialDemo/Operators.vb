Module Operators
    Public Sub Example1()
        Dim a As Integer = 10
        Dim b As Integer = 20

        Console.WriteLine("a + b = {0}", a + b)
        Console.WriteLine("a - b = {0}", a - b)
        Console.WriteLine("a * b = {0}", a * b)
    End Sub

    Public Sub Example2()
        Dim squarePerimeter As Integer = 17
        Dim squareSideInt As Integer = squarePerimeter / 4
        Console.WriteLine(squareSideInt)
        Dim squareSideDouble As Double = squarePerimeter / 4.0
        Console.WriteLine(squareSideDouble)
    End Sub

    Public Sub Example3()
        Dim a As Boolean = True
        Dim b As Boolean = False
        Console.WriteLine(a AndAlso b)
        Console.WriteLine(a OrElse b)
        Console.WriteLine(Not b)
        Console.WriteLine(b OrElse True)
        Console.WriteLine((5 > 7) Xor (a = b))
    End Sub

    Public Sub Example4()
        Dim a As Byte = 3
        Dim b As Byte = 5

        Console.WriteLine(a Or b)
        Console.WriteLine(a And b)
        Console.WriteLine(a Xor b)
        Console.WriteLine(Not a And b)
    End Sub

    Public Sub Example5()
        Dim x As Integer = 10
        Dim y As Integer = 5
        Console.WriteLine("x > y : " & (x > y))
        Console.WriteLine("x < y : " & (x < y))
        Console.WriteLine("x >= y : " & (x >= y))
        Console.WriteLine("x <= y : " & (x <= y))
        Console.WriteLine("x == y : " & (x = y))
        Console.WriteLine("x != y : " & (x <> y))
    End Sub

    Public Sub Example6()
        Dim vbnet As String = "VB.NET "
        Dim tutorial As String = "Tutorial."
        Dim vbnetTutorial As String = vbnet & tutorial
        Console.WriteLine(vbnetTutorial)
        Dim csharp8 As String = vbnet + "15"
        Console.WriteLine(csharp8)
    End Sub
End Module
