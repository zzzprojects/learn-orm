---
PermaID: 100018
Name: With End With Statement
---

# With End With Statement

Executes a series of statements that repeatedly refer to a single object or structure so that the statements can use a simplified syntax when accessing members of the object or structure. When using a structure, you can only read the values of members or invoke methods, and you get an error if you try to assign values to members of a structure used in a With...End With statement.

Here is how a foreach loop looks like:

```csharp
With object
   [ statements ]
End With
```

The following example shows that each `With` block executes a series of statements on a single object.

```csharp
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
```
