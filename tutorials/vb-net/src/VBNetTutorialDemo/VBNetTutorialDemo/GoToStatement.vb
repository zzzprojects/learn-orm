Module GoToStatement
    Public Sub Example1()
        Dim number As Integer = 1
        Dim sampleString As String

        If number = 1 Then
            GoTo Line1
        Else
            GoTo Line2
        End If
Line1:
        sampleString = "Number equals 1"
        GoTo LastLine
Line2:
        sampleString = "Number equals 2"
LastLine:
        Console.WriteLine(sampleString)
    End Sub
End Module
