Module WhileEndLoop
    Public Sub Example1()
        Dim index As Integer = 0
        While index <= 10
            Console.Write(index.ToString & " ")
            index += 1
        End While

        Console.WriteLine("")
    End Sub

    Public Sub Example2()
        Dim index As Integer = 0
        While index < 100000
            index += 1

            If index >= 5 And index <= 8 Then
                Continue While
            End If

            Console.Write(index.ToString & " ")

            If index = 10 Then
                Exit While
            End If
        End While
    End Sub
End Module
