---
PermaID: 100014
Name: ByteRate
---

# ByteRate

**Humanizer.Core** provides a `Per` method of `ByteSizeto` that helps you calculate the rate at which a quantity of bytes has been transferred. 

 - The `Per` method takes the amount of time it took to transfer the bytes as an argument.
 - It returns a `ByteRate` that contains a `Humanize` method. 

Let's consider the following simple example.

```csharp
public static void Example1()
{
    var size = ByteSize.FromGigabytes(4.5);
    var measurementInterval = TimeSpan.FromMinutes(12);

    var rate = size.Per(measurementInterval).Humanize();

    Console.WriteLine("{0} data downloaded in {1} min and the rate is {2}", size, measurementInterval.TotalMinutes, rate);
}
```

Let's execute the above example and you will see the following output.

```csharp
4.5 GB data downloaded in 12 min and the rate is 6.4 MB/s
```

As you can see that by default, rates are given in seconds (MB/s). You can pass a `TimeUnit` to Humanize for an alternate interval. 

```csharp
public static void Example2()
{
    var size = ByteSize.FromGigabytes(10);
    var measurementInterval = TimeSpan.FromMinutes(23);

    var ratePerMinute = size.Per(measurementInterval).Humanize(TimeUnit.Minute);
    var ratePerHour = size.Per(measurementInterval).Humanize(TimeUnit.Hour);

    Console.WriteLine("{0} data downloaded in {1} min and the rate is {2}", size, measurementInterval.TotalMinutes, ratePerMinute);
    Console.WriteLine("{0} data downloaded in {1} min and the rate is {2}", size, measurementInterval.TotalMinutes, ratePerHour);
}
```

Let's execute the above example and you will see the following output.

```csharp
10 GB data downloaded in 23 min and the rate is 445.2173913043478 MB/min
10 GB data downloaded in 23 min and the rate is 26.08695652173913 GB/hour
```

You can also specify a format for the bytes part as shown below.

```csharp
public static void Example3()
{
    var size = ByteSize.FromGigabytes(10);
    var measurementInterval = TimeSpan.FromMinutes(23);

    var ratePerMinute = size.Per(measurementInterval).Humanize("#.##", TimeUnit.Minute);
    var ratePerHour = size.Per(measurementInterval).Humanize("#.##", TimeUnit.Hour);

    Console.WriteLine("{0} data downloaded in {1} min and the rate is {2}", size, measurementInterval.TotalMinutes, ratePerMinute);
    Console.WriteLine("{0} data downloaded in {1} min and the rate is {2}", size, measurementInterval.TotalMinutes, ratePerHour);
}
```

You will now see only two decimal places as specified as a format in the above example.

```csharp
10 GB data downloaded in 23 min and the rate is 445.22 MB/min
10 GB data downloaded in 23 min and the rate is 26.09 GB/hour
```
