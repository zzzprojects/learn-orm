Module Strings


    Public Sub Example()

        Dim str1 As String
        Dim str2 As String = Nothing
        Dim str3 As String = String.Empty
        Dim sqlServerPath As String = "C:\Program Files (x86)\Microsoft SQL Server"
        Dim vsPath As String = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community"
        Dim str4 = "It is sample message of a strongly-typed System.String!"
        Const str5 As String = "You can't change me now"
        Dim letters As Char() = {"A", "B", "C"}
        Dim alphabet As String = New String(letters)
        Dim firstName As String = "John "
        Dim lastName As String = "Doe"
        Dim name As String = firstName & lastName
        Dim text As String = "This is a ""string"" in C#."

        str1 = "test string 1"
        str2 = "test string 2"
        str3 = "test string 3"
        Console.WriteLine("str1: {0}", str1)
        Console.WriteLine("str2: {0}", str3)
        Console.WriteLine("str3: {0}", str3)
        Console.WriteLine("sqlServerPath: {0}", sqlServerPath)
        Console.WriteLine("vsPath: {0}", vsPath)
        Console.WriteLine("str4: {0}", str4)
        Console.WriteLine("str5: {0}", str5)
        Console.WriteLine("alphabet: {0}", alphabet)
        Console.WriteLine("name: {0}", name)
        Console.WriteLine("text: {0}", Text)
    End Sub
End Module
