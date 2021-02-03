Module QueueSample
    Public Sub Example()
        Dim myQ As Queue = New Queue()
        myQ.Enqueue("Hello")
        myQ.Enqueue("World")
        myQ.Enqueue("!")
        Console.WriteLine("myQ")
        Console.WriteLine(vbTab & "Count:    {0}", myQ.Count)
        Console.Write(vbTab & "Values:")

        For Each obj As Object In myQ
            Console.Write("    {0}", obj)
        Next

        Console.WriteLine()
    End Sub
End Module
