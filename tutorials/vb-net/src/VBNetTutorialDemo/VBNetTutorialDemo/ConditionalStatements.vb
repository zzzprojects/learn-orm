Module ConditionalStatements
    Public Sub Example1()
        Dim num1 As Integer = 7
        Dim num2 As Integer = -1

        If num1 > 0 Then
            Console.WriteLine("num1 is valid.")
        End If

        If num2 < 0 Then
            Console.WriteLine("num2 is not valid.")
        End If
    End Sub

    Public Sub Example2()
        Dim randomizer As New Random()
        Dim count As Integer = randomizer.Next(0, 5)

        Dim message As String

        If count = 0 Then
            message = "There are no items."
        Else
            message = $"There are {count} items."
        End If

        Console.WriteLine(message)
    End Sub

    Public Sub Example3()
        Dim marks As Integer = 79

        If marks >= 90 Then
            Console.WriteLine("A+")
        ElseIf marks >= 80 Then
            Console.WriteLine("A")
        ElseIf marks >= 70 Then
            Console.WriteLine("B")
        ElseIf marks >= 60 Then
            Console.WriteLine("C")
        ElseIf marks >= 50 Then
            Console.WriteLine("D")
        Else
            Console.WriteLine("F")
        End If
    End Sub
End Module
