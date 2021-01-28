---
PermaID: 100030
Name: DateTime
---

# DateTime

In most of the applications, you need some form of date function returning the current date and time. VB.Net also provides powerful tools for date arithmetic that makes manipulating dates easy.

 - It represents an instant in time, typically expressed as a date and time of day.
 - The `DateTime` value type represents dates and times with values ranging from **00:00:00, January 1, 0001** to **11:59:59 P.M., December 31, 9999** in the **Gregorian** calendar.

## Initializing a DateTime Object

You can assign an initial value to a new DateTime value in many different ways.

 - Calling a constructor, either one where you specify arguments for values or use the implicit parameterless constructor.
 - Assigning a DateTime to the return value of a property or method.
 - Parsing a DateTime value from its string representation.
 - Using Visual Basic-specific language features to instantiate a DateTime.

The following code creates a specific date using the `DateTime` constructor specifying the year, month, day, hour, minute, and second.

```csharp
Private Sub Example1()
    Dim date1 = New DateTime(2017, 12, 11, 7, 39, 22)
    Console.WriteLine(date1)
End Sub
```

You can assign the `DateTime` object a date and time value returned by a property or method. 

```csharp
Public Sub Example2()
    Dim date1 As DateTime = DateTime.Now
    Dim date2 As DateTime = DateTime.UtcNow
    Dim date3 As DateTime = DateTime.Today

    Console.WriteLine(date1)
    Console.WriteLine(date2)
    Console.WriteLine(date3)
End Sub
```

The above example assigns the current date and time, the current **Coordinated Universal Time (UTC)** date and time, and the current date to three new `DateTime` variables.

## Parse String to a DateTime

The `Parse`, `ParseExact`, `TryParse`, and `TryParseExact` methods all convert a string to its equivalent date and time value. The following examples use the `Parse` and `ParseExact` methods to parse a string and convert it to a `DateTime` value. 

```csharp
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
```

The second format uses a form supported by the **ISO 8601** standard for representing date and time in string format. This standard representation is often used to transfer date information in web services.

The following example uses the `TryParseExact(String, String[], IFormatProvider, DateTimeStyles, DateTime)` method to convert strings that must be either in a "yyyyMMdd" format or a "HHmmss" format to `DateTime` values.

```csharp
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
```

If a string cannot be parsed, the `Parse` and `ParseExact` methods throw an exception. 

 - The `TryParse` and `TryParseExact` methods return a `Boolean` value that indicates whether the conversion succeeded or failed. 
 - You should use the `TryParse` or `TryParseExact` methods in scenarios where performance is important. 
 - The parsing operation for date and time strings tends to have a high failure rate, and exception handling is expensive. 
 - Use these methods if strings are input by users or coming from an unknown source.
