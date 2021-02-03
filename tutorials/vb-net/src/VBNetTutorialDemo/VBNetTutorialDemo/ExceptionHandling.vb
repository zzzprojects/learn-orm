Module ExceptionHandling
    Public Sub Example1()
        Try
            Dim num = Integer.Parse("6")
            Console.WriteLine("The number is {0}", num)
            Dim num1 = Integer.Parse("a")
            Console.WriteLine("The number is {0}", num)
        Catch
            Console.Write("Error occurred.")
        Finally
            Console.Write("It will be executed always because I am in Finally block.")
        End Try
    End Sub

    Public Sub Example2()
        Try
            Dim num = Integer.Parse("6")
            Console.WriteLine("The number is {0}", num)
            Dim num1 = Integer.Parse("a")
            Console.WriteLine("The number is {0}", num)
        Catch e As Exception
            Console.Write(e.Message)
        Finally
            Console.Write("It will be executed always because I am in Finally block.")
        End Try
    End Sub

    Public Sub Example3()
        Try
            Dim num = Integer.Parse("6")
            Console.WriteLine("The number is {0}", num)
            Dim num1 = Integer.Parse("a")
            Console.WriteLine($"The number is {0}", num)
        Catch e As FormatException
            Console.WriteLine(e.Message)
        Catch e As IndexOutOfRangeException
            Console.WriteLine(e.Message)
        Catch e As DivideByZeroException
            Console.WriteLine(e.Message)
        Catch e As Exception
            Console.Write(e.Message)
        Finally
            Console.Write(vbLf & "It will be executed always because I am in finally block.")
        End Try
    End Sub
End Module
