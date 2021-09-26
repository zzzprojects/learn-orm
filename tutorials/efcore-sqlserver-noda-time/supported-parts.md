---
PermaID: 100004
Name: Supported Parts
---

# Supported Parts

## DATEPART Function

The `DATEPART` function returns an integer representing the specified datepart of the specified date. 

The **SimplerSoftware.EntityFrameworkCore.SqlServer.NodaTime** provides the following methods which use the `DATEPART` function.

 - `Year`
 - `Quarter`
 - `Month`
 - `DayOfYear`
 - `Day`
 - `Week`
 - `WeekDay`
 - `Hour`
 - `Minute`
 - `Second`
 - `Millisecond`
 - `Microsecond`
 - `Nanosecond`
 - `TzOffset`
 - `IsoWeek`

Let's consider the following simple example where we want to get all the tasks that started in 2021.

```csharp
public static void Example1()
{
    using (EmployeeContext context = new EmployeeContext())
    {
        var thisYearTasks = context.Tasks
            .Where(t => t.StartTime.Year() == 2021);

        Console.WriteLine(thisYearTasks.ToQueryString());
    }
}
```

Let's run the above example and you will see the following output.

```csharp
SELECT [t].[Id], [t].[EmployeeId], [t].[EndTime], [t].[ScheduledDuration], [t].[StartTime]
FROM [Tasks] AS [t]
WHERE DATEPART(year, [t].[StartTime]) = 2021
```
