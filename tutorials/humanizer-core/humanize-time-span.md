---
PermaID: 100005
Name: Humanize TimeSpan
---

# Humanize TimeSpan

A `TimeSpan` object represents a time interval duration of time or elapsed time that is measured as a positive or negative number of days, hours, minutes, seconds, and fractions of a second. **Humanizer.Core** provides a `Humanize()` extension method on a `TimeSpan` to a get human friendly representation for it

Let's consider the following simple example.

```csharp
public static void Example1()
{
    List<TimeSpan> timeSpans = new List<TimeSpan>()
    {
        TimeSpan.FromMinutes(-45),
        TimeSpan.FromSeconds(-5000),
        TimeSpan.FromMilliseconds(700000000),
        TimeSpan.FromHours(1371),
        TimeSpan.FromDays(-42),
    };

    foreach (var timeSpan in timeSpans)
    {
        Console.WriteLine("{0}: \t {1}", timeSpan, timeSpan.Humanize());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
-00:45:00:       45 minutes
-01:23:20:       1 hour
8.02:26:40:      1 week
57.03:00:00:     8 weeks
-42.00:00:00:    6 weeks
```

The default value of precision is 1 which means only the largest time unit is returned as you saw in the above example. You can also specify the precision parameter for the `Humanize` extension method which allows you to specify the precision of the returned value. 

```csharp
public static void Example2()
{
    var timeSpan = TimeSpan.FromMilliseconds(797893450904);

    Console.WriteLine(timeSpan.Humanize(1));
    Console.WriteLine(timeSpan.Humanize(2));
    Console.WriteLine(timeSpan.Humanize(3));
    Console.WriteLine(timeSpan.Humanize(4));
    Console.WriteLine(timeSpan.Humanize(5));
    Console.WriteLine(timeSpan.Humanize(6));
}
```

Let's execute the above example and you will see the following output.

```csharp
1319 weeks
1319 weeks, 1 day
1319 weeks, 1 day, 21 hours
1319 weeks, 1 day, 21 hours, 4 minutes
1319 weeks, 1 day, 21 hours, 4 minutes, 10 seconds
1319 weeks, 1 day, 21 hours, 4 minutes, 10 seconds, 904 milliseconds
```
