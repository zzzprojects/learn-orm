---
PermaID: 100003
Name: Humanize DateTime
---

# Humanize DateTime

On many websites, you will see the time of posting comments like Facebook and YouTube (3 hours ago, 10 hours ago, etc.). Now to calculate time like this, **Humanizer.Core** provides a `Humanize()` extension method that tells you how far back or forward in time is.

Let's consider the following simple example which contains various dates and it will convert it to how far back or forward the time is now.

```csharp
public static void Example1()
{
    List<DateTime> dateTimes = new List<DateTime>()
    {
        DateTime.Now.AddMinutes(-45),
        DateTime.UtcNow.AddHours(-5),
        DateTime.Now.AddDays(7),
        DateTime.UtcNow.AddMonths(7),
        DateTime.Now.AddYears(-1),
    };

    foreach (var date in dateTimes)
    {
        Console.WriteLine("{0}: \t {1}", date, date.Humanize());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
7/24/2021 9:10:54 PM:    45 minutes ago
7/24/2021 11:55:54 AM:   5 hours ago
7/31/2021 9:55:54 PM:    6 days from now
2/24/2022 4:55:54 PM:    7 months from now
7/24/2020 9:55:54 PM:    one year ago
```

Humanizer supports both local and UTC dates as well as dates with offset `DateTimeOffset`. 

```csharp
public static void Example2()
{
    List<DateTimeOffset> dateTimeOffsets = new List<DateTimeOffset>()
    {
        DateTimeOffset.Now.AddMinutes(20),
        DateTimeOffset.UtcNow.AddHours(-9),
        DateTimeOffset.Now.AddDays(-5),
        DateTimeOffset.UtcNow.AddMonths(2),
        DateTimeOffset.Now.AddYears(3),
    };

    foreach (var date in dateTimeOffsets)
    {
        Console.WriteLine("{0}: \t {1}", date, date.Humanize());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
7/24/2021 10:30:41 PM +05:00:    19 minutes from now
7/24/2021 8:10:41 AM +00:00:     9 hours ago
7/19/2021 10:10:41 PM +05:00:    5 days ago
9/24/2021 5:10:41 PM +00:00:     2 months from now
7/24/2024 10:10:41 PM +05:00:    3 years from now
```