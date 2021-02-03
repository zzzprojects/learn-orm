Module ContinueStatement
    Public Sub Example1()
        For i As Integer = 0 To 10
            If i > 3 AndAlso i < 8 Then
                Continue For
            End If
            Console.WriteLine("Counter: {0}", i)
        Next
    End Sub

    Public Sub Example2()
        Dim i As Integer = 0
        While i < 10
            If i = 6 Then
                Console.WriteLine(" Skipped number is {0}", i)
                i += 1
                Continue While
            End If
            Console.WriteLine(" Value of i is {0}", i)
            i += 1
        End While
    End Sub

End Module
