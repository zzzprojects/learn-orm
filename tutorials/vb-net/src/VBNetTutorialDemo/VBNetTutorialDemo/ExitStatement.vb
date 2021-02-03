Module ExitStatement
    Public Sub Example1()
        Dim index As Integer = 0
        Do While index <= 100
            If index > 10 Then
                Exit Do
            End If

            Console.Write(index.ToString & " ")
            index += 1
        Loop
    End Sub

    Function Subtract(num1 As Integer, num2 As Integer) As Integer
        Subtract = num1 - num2
        Exit Function
    End Function
End Module
