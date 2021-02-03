Module Collections
    Public Sub Example1()
        Dim customers As List(Of Customer) = New List(Of Customer)()
        customers.Add(New Customer With {
            .Id = 1,
            .Name = "John"
        })
        customers.Add(New Customer With {
            .Id = 2,
            .Name = "Mark"
        })
        customers.Add(New Customer With {
            .Id = 3,
            .Name = "Stella"
        })

        For Each customer In customers
            Console.WriteLine("{0}, {1}", customer.Id, customer.Name)
        Next
    End Sub

    Public Sub Example2()
        Dim myAL As ArrayList = New ArrayList()
        myAL.Add("Hello")
        myAL.Add("World")
        myAL.Add("!")
        Console.WriteLine("myAL")
        Console.WriteLine("    Count:    {0}", myAL.Count)
        Console.WriteLine("    Capacity: {0}", myAL.Capacity)
        Console.Write("    Values:")

        For Each obj As Object In myAL
            Console.Write("   {0}", obj)
        Next

    End Sub

    Public Sub Example3()
        Dim customers As New Microsoft.VisualBasic.Collection()
        customers.Add(New Customer With {
            .Id = 1,
            .Name = "John"
        }, "1")
        customers.Add(New Customer With {
            .Id = 2,
            .Name = "Mark"
        }, "2")
        customers.Add(New Customer With {
            .Id = 3,
            .Name = "Stella"
        }, "3")

        For Each customer In customers
            Console.WriteLine("{0}, {1}", customer.Id, customer.Name)
        Next
    End Sub
End Module
