Module Constructors
    Public Class CustomerInfo
        Public Property Name As String
        Public Property Address As String

        Public Sub New()
            Console.WriteLine("Default Constructor Called")
        End Sub

        Public Sub New(ByVal name As String, ByVal address As String)
            Me.Name = name
            Me.Address = address
        End Sub

        Public Sub New(ByVal customer As CustomerInfo)
            Me.Name = customer.Name
            Me.Address = customer.Address
        End Sub

        Public Sub Print()
            Console.WriteLine("Name: {0}, Address: {1}", Me.Name, Me.Address)
        End Sub
    End Class

    Public Class Counter
        Private Sub New()
        End Sub

        Public Shared currentCount As Integer

        Public Shared Function IncrementCount() As Integer
            currentCount += 1
            Return currentCount
        End Function
    End Class

    Sub Example1()
        Dim customer As CustomerInfo = New CustomerInfo()
        customer.Print()
    End Sub

    Sub Example2()
        Dim customer1 As CustomerInfo = New CustomerInfo("John", "11 wall street")
        Dim customer2 As CustomerInfo = New CustomerInfo(customer1)
        customer1.Print()
        customer2.Print()
    End Sub

    Sub Example3()
        Counter.currentCount = 9
        Counter.IncrementCount()
        Console.WriteLine("New count: {0}", Counter.currentCount)
    End Sub
End Module
