Module ForNextLoop
    Public Sub Example1()
        For index As Integer = 1 To 10
            Console.Write(index.ToString & ", ")
        Next

        Console.WriteLine("")
    End Sub

    Public Sub Example2()
        For number As Double = 5 To 0 Step -0.5
            Console.Write(number.ToString & ", ")
        Next
        Console.WriteLine("")
    End Sub

    Public Sub Example3()
        For indexA = 1 To 3
            Dim sb As New System.Text.StringBuilder()
            For indexB = 20 To 1 Step -2
                sb.Append(indexB.ToString)
                sb.Append(" ")
            Next indexB

            Console.WriteLine(sb.ToString)
        Next indexA
    End Sub

    Public Sub Example4()
        For index As Integer = 1 To 100000

            If index >= 5 AndAlso index <= 8 Then
                Continue For
            End If

            Console.Write(index.ToString & " ")

            ' If index is 10, exit the loop.
            If index = 10 Then
                Exit For
            End If
        Next
        Console.WriteLine("")
    End Sub
End Module
