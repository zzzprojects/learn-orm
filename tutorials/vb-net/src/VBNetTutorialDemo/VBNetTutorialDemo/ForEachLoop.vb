Module ForEachLoop
    Public Sub Example1()
        Dim websites As String() = New String(4) {"Google", "YouTube", "Facebook", "Baidu", "Yahoo"}

        For Each site As String In websites
            Console.WriteLine(site)
        Next
    End Sub

    Public Sub Example2()
        Dim numberNames As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)()
        numberNames.Add(1, "One")
        numberNames.Add(2, "Two")
        numberNames.Add(3, "Three")

        For Each item As KeyValuePair(Of Integer, String) In numberNames
            Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value)
        Next
    End Sub
End Module
