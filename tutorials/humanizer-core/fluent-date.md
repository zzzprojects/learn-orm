---
PermaID: 100008
Name: Fluent Date
---

# Fluent Date

**Humanizer.Core** provides a fluent API to deal with `DateTime` and `TimeSpan`. It also provides a lot of extension methods in various categories to deal with date and time. 

Let's consider the following example which uses different methods.

```csharp
public static void Example1()
{
    Console.WriteLine("In.TheYear(2019): \t {0}", In.TheYear(2019));
    Console.WriteLine("In.January: \t {0}", In.January);
    Console.WriteLine("In.AprilOf(2017): \t {0}", In.AprilOf(2017));
    Console.WriteLine("In.One.Second: \t {0}", In.One.Second);
    Console.WriteLine("In.Three.Years: \t {0}", In.Three.Years);
    Console.WriteLine("On.September.The4th: \t {0}", On.September.The4th);
    Console.WriteLine("DateTime.Now + 2.Days() + 3.Hours() - 5.Minutes(): \t {0}", DateTime.Now + 2.Days() + 3.Hours() - 5.Minutes());
}
```

Let's execute the above example and you will see the following output.

```csharp
In.TheYear(2019):        1/1/2019 12:00:00 AM
In.January:      1/1/2021 12:00:00 AM
In.AprilOf(2017):        4/1/2017 12:00:00 AM
In.One.Second:   7/24/2021 11:35:51 PM
In.Three.Years:          7/24/2024 11:35:50 PM
On.September.The4th:     9/4/2021 12:00:00 AM
DateTime.Now + 2.Days() + 3.Hours() - 5.Minutes():       7/27/2021 7:30:50 AM
```

Here is another example that uses some more extension methods.

```csharp
public static void Example2()
{
    var dateTime = new DateTime(2020, 12, 31, 3, 31, 59, 125);

    Console.WriteLine("Original DateTime: \t {0}", dateTime);

    Console.WriteLine("dateTime.In(2018): \t {0}", dateTime.In(2018));
    Console.WriteLine("dateTime.At(2): \t {0}", dateTime.At(2));
    Console.WriteLine("dateTime.At(2, 20, 15): \t {0}", dateTime.At(2, 20, 15));
    Console.WriteLine("dateTime.AtNoon(): \t {0}", dateTime.AtNoon());
    Console.WriteLine("dateTime.AtMidnight(): \t {0}", dateTime.AtMidnight());
    
}
```

Let's execute the above example and you will see the following output.

```csharp
Original DateTime:       12/31/2020 3:31:59 AM
dateTime.In(2018):       12/31/2018 3:31:59 AM
dateTime.At(2):          12/31/2020 2:00:00 AM
dateTime.At(2, 20, 15):          12/31/2020 2:20:15 AM
dateTime.AtNoon():       12/31/2020 12:00:00 PM
dateTime.AtMidnight():   12/31/2020 12:00:00 AM
```