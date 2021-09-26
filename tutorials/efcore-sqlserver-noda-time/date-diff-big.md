---
PermaID: 100006
Name: DateDiffBig
---

# DateDiffBig

## DATEDIFF_BIG Function

The `DATEDIFF_BIG` function returns the count (as a signed big integer value) of the specified datepart boundaries crossed between the specified start date and end date. It can handles larger differences between the start date and end date values.

The **SimplerSoftware.EntityFrameworkCore.SqlServer.NodaTime** provides the following methods which use the `DATEDIFF_BIG` function.

 - `DateDiffBigMicrosecond`
 - `DateDiffBigMillisecond`
 - `DateDiffBigNanosecond`
 - `DateDiffBigSecond`

Let's consider the following simple example which uses the `DateDiffBigSecond` method.

```csharp
public static void Example1()
{
    using (EmployeeContext context = new EmployeeContext())
    {
        DbFunctions dbFunctions = null;

        var thisYearTasks = context.Tasks
            .Where(r => dbFunctions.DateDiffBigSecond(r.StartTime, Instant.FromUtc(2021, 1, 1, 0, 0)) >= 100000);

        Console.WriteLine(thisYearTasks.ToQueryString());
    }
}
```

Let's run the above example and you will see the following output.

```csharp
SELECT [t].[Id], [t].[Date], [t].[EmployeeId], [t].[EndTime], [t].[ScheduledDuration], [t].[StartTime]
FROM [Tasks] AS [t]
WHERE DATEDIFF_BIG(SECOND, [t].[StartTime], '2021-01-01T00:00:00.0000000Z') >= CAST(100000 AS bigint)
```

