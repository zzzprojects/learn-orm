---
PermaID: 100005
Name: DateDiff
---

# DateDiff

## DATEDIFF Function

The `DATEPART` function returns the count (as a signed integer value) of the specified datepart boundaries crossed between the specified start date and end date.

The **SimplerSoftware.EntityFrameworkCore.SqlServer.NodaTime** provides the following methods which use the `DATEDIFF` function.

 - DateDiffDay
 - DateDiffHour
 - DateDiffMicrosecond
 - DateDiffMillisecond
 - DateDiffMinute
 - DateDiffMonth
 - DateDiffNanosecond
 - DateDiffSecond
 - DateDiffWeek
 - DateDiffYear

Let's consider the following simple example which uses the `DateDiffDay` method.

```csharp
public static void Example1()
{
    using (EmployeeContext context = new EmployeeContext())
    {
        DbFunctions dbFunctions = null;

        var thisYearTasks = context.Tasks
            .Where(t => dbFunctions.DateDiffDay(t.Date, new LocalDate(2021, 1, 1)) >= 150);

        Console.WriteLine(thisYearTasks.ToQueryString());
    }
}
```

Let's run the above example and you will see the following output.

```csharp
SELECT [t].[Id], [t].[Date], [t].[EmployeeId], [t].[EndTime], [t].[ScheduledDuration], [t].[StartTime]
FROM [Tasks] AS [t]
WHERE DATEDIFF(DAY, [t].[Date], '2021-01-01') >= 150
```

