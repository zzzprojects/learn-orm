Module DoLoop
    Public Sub Example1()
        Dim index As Integer = 0
        Do
            Console.WriteLine(index.ToString & " ")
            index += 1
        Loop While index <= 10
    End Sub

    Public Sub Example2()
        Dim index As Integer = 0
        Do
            Console.WriteLine(index.ToString & " ")
            index += 1
        Loop Until index > 10
    End Sub

    Public Sub Example3()
        Dim index As Integer = 0
        Do While index <= 100
            If index > 10 Then
                Exit Do
            End If

            Console.WriteLine(index.ToString & " ")
            index += 1
        Loop
    End Sub
End Module
