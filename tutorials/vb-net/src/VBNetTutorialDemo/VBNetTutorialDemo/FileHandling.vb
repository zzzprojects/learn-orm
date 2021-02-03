Imports System.IO

Module FileHandling
    Public Sub Example1()
        Dim writeText As String = "This is a VB.NET Tutorial, and you are learning file handling."

        'Create a file and write the content of writeText to it
        File.WriteAllText("test.txt", writeText)

        'Read the contents from the file
        Dim readText As String = File.ReadAllText("test.txt")
        Console.WriteLine(readText)
    End Sub

    Public Sub Example2()
        Dim path As String = "D:\MyTest.txt"

        If Not File.Exists(path) Then
            Console.WriteLine("File doesn't exist, we will create a file first." & vbLf)

            Using sw As StreamWriter = File.CreateText(path)
                sw.WriteLine("This is a VB.NET Tutorial,")
                sw.WriteLine("and you are learning")
                sw.WriteLine("file handling.")
            End Using
        Else
            Console.WriteLine("File already exists, no need to create it." & vbLf)
        End If

        Using sr As StreamReader = File.OpenText(path)
            Dim s As String
            s = sr.ReadLine()
            While (s IsNot Nothing)
                Console.WriteLine(s)
                s = sr.ReadLine()
            End While
        End Using
    End Sub
End Module
