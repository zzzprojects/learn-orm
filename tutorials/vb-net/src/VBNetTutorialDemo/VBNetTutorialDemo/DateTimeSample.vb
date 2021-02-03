Module DateTimeSample
    Public Sub Example1()
        Dim date1 = New DateTime(2017, 12, 11, 7, 39, 22)
        Console.WriteLine(date1)
    End Sub

    Public Sub Example2()
        Dim date1 As DateTime = DateTime.Now
        Dim date2 As DateTime = DateTime.UtcNow
        Dim date3 As DateTime = DateTime.Today

        Console.WriteLine(date1)
        Console.WriteLine(date2)
        Console.WriteLine(date3)
    End Sub

    Public Sub Example3()
        Dim dateString = "5/1/2008 8:30:52 AM"
        Dim date1 As DateTime =
            DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture)
        Console.WriteLine(date1)

        Dim iso8601String = "20080501T08:30:52Z"
        Dim dateISO8602 As DateTime =
            DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture)
        Console.WriteLine(date1)
    End Sub

    Public Sub Example4()
        Dim formats As String() = {"yyyyMMdd", "HHmmss"}
        Dim dateStrings As String() = {"20130816", "20131608", "  20130816   ", "115216", "521116", "  115216  "}
        Dim parsedDate As DateTime

        For Each dateStr In dateStrings

            If DateTime.TryParseExact(dateStr, formats, Nothing, System.Globalization.DateTimeStyles.AllowWhiteSpaces Or System.Globalization.DateTimeStyles.AdjustToUniversal, parsedDate) Then
                Console.WriteLine($"{dateStr} --> {parsedDate}")
            Else
                Console.WriteLine($"Cannot convert {dateStr}")
            End If
        Next
    End Sub
End Module
