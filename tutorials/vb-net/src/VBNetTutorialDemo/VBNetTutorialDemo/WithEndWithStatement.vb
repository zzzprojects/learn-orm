Module WithEndWithStatement
    Private Sub AddAuthor()
        Dim author As New Author

        With author
            .Name = "Coho Vineyard"
            .Address = "Redmond"
        End With

        With author.Books
            .Add("Introduction to Machine Learning")
            .Add("Advanced Topics in Machine Learning")
        End With
    End Sub

    Public Class Author
        Public Property Name As String
        Public Property Address As String

        Public Property Books As New List(Of String)
    End Class
End Module
