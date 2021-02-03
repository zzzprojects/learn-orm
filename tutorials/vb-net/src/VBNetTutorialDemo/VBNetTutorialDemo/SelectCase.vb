Module SelectCase
    Public Sub Example1()
        Dim caseSwitch As Integer = 1

        Select Case caseSwitch
            Case 1
                Console.WriteLine("Case 1")
            Case 2
                Console.WriteLine("Case 2")
            Case Else
                Console.WriteLine("Default case")
        End Select
    End Sub

    Public Sub Example2()
        Dim number As Integer = 8
        Select Case number
            Case 1, 2, 3
                Debug.WriteLine("Between 1 and 3")
            Case 4 To 8
                Debug.WriteLine("Between 4 and 8")
            Case Is <= 15
                Debug.WriteLine("Between 9 and 15")
            Case Else
                Debug.WriteLine("Greater than 15")
        End Select
    End Sub
End Module
