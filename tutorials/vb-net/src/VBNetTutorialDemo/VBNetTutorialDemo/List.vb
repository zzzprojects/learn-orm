Module List
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
        Dim dinosaurs As List(Of String) = New List(Of String)()
        Console.WriteLine(vbLf & "Capacity: {0}", dinosaurs.Capacity)
        dinosaurs.Add("Tyrannosaurus")
        dinosaurs.Add("Amargasaurus")
        dinosaurs.Add("Mamenchisaurus")
        dinosaurs.Add("Deinonychus")
        dinosaurs.Add("Compsognathus")
        Console.WriteLine()

        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & "Capacity: {0}", dinosaurs.Capacity)
        Console.WriteLine("Count: {0}", dinosaurs.Count)
        Console.WriteLine(vbLf & "Contains(""Deinonychus""): {0}", dinosaurs.Contains("Deinonychus"))
        Console.WriteLine(vbLf & "Insert(2, ""Compsognathus"")")
        dinosaurs.Insert(2, "Compsognathus")
        Console.WriteLine()

        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & "dinosaurs[3]: {0}", dinosaurs(3))
        Console.WriteLine(vbLf & "Remove(""Compsognathus"")")
        dinosaurs.Remove("Compsognathus")
        Console.WriteLine()

        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        dinosaurs.TrimExcess()
        Console.WriteLine(vbLf & "TrimExcess()")
        Console.WriteLine("Capacity: {0}", dinosaurs.Capacity)
        Console.WriteLine("Count: {0}", dinosaurs.Count)
        dinosaurs.Clear()
        Console.WriteLine(vbLf & "Clear()")
        Console.WriteLine("Capacity: {0}", dinosaurs.Capacity)
        Console.WriteLine("Count: {0}", dinosaurs.Count)
    End Sub

End Module
