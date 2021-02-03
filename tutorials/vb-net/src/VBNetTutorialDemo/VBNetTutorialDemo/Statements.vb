Module Statements
    Sub DeclaredStatement()
        Const age As Integer = 42
        Dim length As Double = 50.7
    End Sub

    Sub ExecutableStatement()
        Dim a As Integer = 13

        If (a < 20) Then
            Console.WriteLine("a is less than 20")
        Else
            Console.WriteLine("a is greater than 20")
        End If

        Console.WriteLine("value of a is : {0}", a)
        Console.ReadLine()
    End Sub
End Module
