---
PermaID: 100009
Name: Convert Numbers
---

# Convert Numbers

Computers and numbers go hand in hand, and as a programmer, you will be working with numbers in many forms most of the time. Numbers can be divided into two types. 

 - **Integer:** Whole numbers without decimal points and can be negative or positive numbers.
 - **Floating-point:** Numbers with one or more decimal points and can be negative or positive numbers.

**Humanizer.Core** provides a fluent API that allows you to convert number to number, number to words, and number to ordinal words, etc. 

The following example shows the conversion of a number to a number which produces usually big numbers in a clearer fashion.

```csharp
public static void Example1()
{
    List<double> list = new List<double>()
    {
        3.6.Billions(),
        8.50.Hundreds().Thousands(),
        6.Tens(),
        100.Millions()
    };

    foreach (var value in list)
    {
        Console.WriteLine(value);
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
3600000000
850000
60
100000000
```

**Humanizer.Core** provides the `ToWords` extension method that converts numbers to words.

```csharp
public static void Example2()
{
    List<int> list = new List<int>()
    {
        3,
        850,
        1000,
        326782
    };

    foreach (var value in list)
    {
        Console.WriteLine("{0}: \t {1}", value, value.ToWords());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
3:       three
850:     eight hundred and fifty
1000:    one thousand
326782:          three hundred and twenty-six thousand seven hundred and eighty-two
```

**Humanizer.Core** provides the `ToOrdinalWords` extension method that returns the ordinal representation of the number in words.

```csharp
public static void Example3()
{
    List<int> list = new List<int>()
    {
        3,
        850,
        1000,
        326782
    };

    foreach (var value in list)
    {
        Console.WriteLine("{0}: \t {1}", value, value.ToOrdinalWords());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
3:       third
850:     eight hundred and fiftieth
1000:    thousandth
326782:          three hundred and twenty-six thousand seven hundred and eighty-second
```
