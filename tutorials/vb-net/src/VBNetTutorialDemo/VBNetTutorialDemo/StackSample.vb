Module StackSample
    Public Sub Example()
        Dim myStack As Stack = New Stack()
        myStack.Push("Hello")
        myStack.Push("World")
        myStack.Push("!")
        Console.WriteLine("myStack")
        Console.WriteLine(vbTab & "Count:    {0}", myStack.Count)
        Console.Write(vbTab & "Values:")

        For Each obj In myStack
            Console.Write("    {0}", obj)
        Next
    End Sub
End Module
