---
PermaID: 100015
Name: Convert Angle Directions to Words
---

# Convert Angle Directions to Words

**Humanizer.Core** provides a `ToHeading()` extension method that allows you to convert a numeric angle direction to words. The heading can be a double whereas the result will be a string. 

Let's consider the following simple example.

```csharp
public static void Example1()
{
    List<double> list = new List<double>()
    {
        0,
        90,
        180,
        225,
        270,
        360,
        720
    };

    foreach (var val in list)
    {
        Console.WriteLine("{0} => {1}", val, val.ToHeading());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
0 => N
90 => E
180 => S
225 => SW
270 => W
360 => N
720 => N
```

By default, the `ToHeading()` method returns a short representation (e.g. N, E, S, W), you can also get a full representation of the heading (e.g. north, east, south or west) just bypassing the `HeadingStyle.Full` as an argument as shown below.

```csharp
public static void Example2()
{
    List<double> list = new List<double>()
    {
        0,
        90,
        180,
        225,
        270,
        360,
        720
    };

    foreach (var val in list)
    {
        Console.WriteLine("{0} => {1}", val, val.ToHeading(HeadingStyle.Full));
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
0 => north
90 => east
180 => south
225 => southwest
270 => west
360 => north
720 => north
```

**Humanizer.Core** provides a `ToHeadingArrow()` extension method that returns a unicode arrow character (e.g. ↑, →, ↓, ←).

```csharp
public static void Example3()
{
    List<double> list = new List<double>()
    {
        0,
        90,
        180,
        360
    };

    foreach (var val in list)
    {
        Console.WriteLine("{0} => {1}", val, val.ToHeadingArrow());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
0 => ↑
90 => →
180 => ↓
360 => ↑
```
