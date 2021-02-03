Module Arrays
    Public Sub Example1()
        Dim myArray1 As Integer()
        Dim myArray2 As Integer() = New Integer(5) {}
        Dim myArray3(5) As Double
        Dim myArray4 As Integer() = {1, 2, 3, 4, 5, 6}
        Dim daysOfWeek As String() = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"}
        myArray4(3) = 100
        Console.WriteLine(myArray4(3))
    End Sub

    Public Sub Example2()
        Dim myArray4 As Integer() = {1, 2, 3, 4, 5, 6}

        ' Assign a new array size and retain the current values.
        ReDim Preserve myArray4(20)

        ' Assign a new array size and retain only the first five values.
        ReDim Preserve myArray4(4)

        ' Assign a new array size and discard all current element values.
        ReDim myArray4(15)
    End Sub

    Public Sub Example3()
        ' Create a 10-element integer array.
        Dim numbers(9) As Integer
        Dim value As Integer = 2

        ' Write values to it.
        For ctr As Integer = 0 To 9
            numbers(ctr) = value
            value *= 2
        Next

        ' Read and sum the array values.  
        Dim sum As Integer
        For ctr As Integer = 0 To 9
            sum += numbers(ctr)
        Next
        Console.WriteLine($"The sum of the values is {sum:N0}")
    End Sub
End Module
