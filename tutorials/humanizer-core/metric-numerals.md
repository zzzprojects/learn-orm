---
PermaID: 100011
Name: Metric Numerals
---

# Metric Numerals

In the Metric System there are standard ways to talk about big and small numbers, for example, "kilo" is used for a thousand, and "mega" is used for a million, etc.

| Name          | Number               | Prefix            | Symbol  |
| :-------------| :--------------------| :-----------------| :-------|
| trillion      | 1,000,000,000,000    | tera              | T       |
| billion       | 1,000,000,000        | giga              | G       |
| million       | 1,000,000            | mega              | M       |
| thousand      | 1,000                | kilo              | k       |
| hundred       | 100                  | hecto             | h       |
| ten           | 10                   | deka              | da      |	 	 
| thousandth    | 0.001                | milli             | m       |
| millionth     | 0.000 001            | micro             | µ       |
| billionth     | 0.000 000 001        | nano              | n       |
| trillionth    | 0.000 000 000 001    | pico              | p       |

**Humanizer.Core** provides the `ToMetric` extension method that converts numbers to metric numerals. Let's consider the following simple example which converts several numbers to metric numerals.

```csharp
public static void Example3()
{
    List<double> list = new List<double>()
    {
        1000,
        300000000,
        345600000000.00,
        0.1,
        0.001,
        0.00000345,
    };

    foreach (var value in list)
    {
        Console.WriteLine("{0}: \t {1}", value, value.ToMetric());
    }
}
```

Let's execute the above example and you will see the following output

```csharp
1000:    1k
300000000:       300M
345600000000:    345.6G
0.1:     100m
0.001:   1m
3.45E-06:        3.45µ
```

It also supports the reverse operation using the `FromMetric` extension method.

```csharp
public static void Example4()
{
    List<string> list = new List<string>()
    {
        "5M",
        "1.1T",
        "3m",
        "7p",
        "2.5n",
    };

    foreach (var value in list)
    {
        Console.WriteLine("{0}: \t {1}", value, value.FromMetric());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
5M:      5000000
1.1T:    1100000000000
3m:      0.003
7p:      7E-12
2.5n:    2.5E-09
```