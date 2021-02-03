Module Enums
    Enum Days
        Sunday
        Monday
        Tuesday
        Wednesday
        Thursday
        Friday
        Saturday
    End Enum

    Enum Months
        January = 1
        February
        March
        April
        May
        June
        July
        August
        September
        October
        November
        December
    End Enum

    Enum Categories
        Sports = 1
        Arts = 3
        Clothing = 7
        Fashion = 15
        Electronics = 21
        HealthCare = 33
    End Enum

    Public Sub Example1()
        Dim day As Days = Days.Tuesday
        Console.WriteLine("The day is {0}", day)
    End Sub

    Public Sub Example2()
        Dim category As Categories = Categories.HealthCare
        Dim intVal As Integer = CInt(category)

        Console.WriteLine("The numerical value of {0} is {1}", category, intVal)
    End Sub
End Module
