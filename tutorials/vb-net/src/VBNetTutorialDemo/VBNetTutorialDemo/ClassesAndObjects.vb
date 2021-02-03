Public Module ClassesAndObjects
    Public Class Customer
        Public Property Id As Integer
        Public Property Name As String
        Public Property Address As String

        Public Sub New()
        End Sub

        Public Sub New(ByVal id As Integer, ByVal name As String, ByVal address As String)
            Me.Id = id
            Me.Name = name
            Me.Address = address
        End Sub

        Public Sub Print()
            Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", Me.Id, Me.Name, Me.Address)
        End Sub
    End Class

    Sub Example1()
        Dim customer As Customer = New Customer()
        customer.Id = 1
        customer.Name = "Andy"
        customer.Address = "22 wall street"

        customer.Print()
    End Sub

    Sub Example2()
        Dim customer As Customer = New Customer(2, "John", "11 wall street")
        customer.Print()
    End Sub

End Module
