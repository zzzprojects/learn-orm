Module HashtableSample
    Public Sub Example1()
        Dim openWith As Hashtable = New Hashtable()
        openWith.Add("txt", "notepad.exe")
        openWith.Add("bmp", "paint.exe")
        openWith.Add("dib", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")

        Try
            openWith.Add("txt", "winword.exe")
        Catch
            Console.WriteLine("An element with Key = ""txt"" already exists.")
        End Try

        Console.WriteLine("For key = ""rtf"", value = {0}.", openWith("rtf"))
        openWith("rtf") = "winword.exe"
        Console.WriteLine("For key = ""rtf"", value = {0}.", openWith("rtf"))
        openWith("doc") = "winword.exe"

        If Not openWith.ContainsKey("ht") Then
            openWith.Add("ht", "hypertrm.exe")
            Console.WriteLine("Value added for key = ""ht"": {0}", openWith("ht"))
        End If

        Console.WriteLine()

        For Each de As DictionaryEntry In openWith
            Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value)
        Next

        Dim valueColl As ICollection = openWith.Values
        Console.WriteLine()

        For Each s As String In valueColl
            Console.WriteLine("Value = {0}", s)
        Next

        Dim keyColl As ICollection = openWith.Keys
        Console.WriteLine()

        For Each s As String In keyColl
            Console.WriteLine("Key = {0}", s)
        Next

        Console.WriteLine(vbLf & "Remove(""doc"")")
        openWith.Remove("doc")

        If Not openWith.ContainsKey("doc") Then
            Console.WriteLine("Key ""doc"" is not found.")
        End If
    End Sub
End Module
