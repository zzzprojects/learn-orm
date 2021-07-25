---
PermaID: 100010
Name: Roman Numerals
---

# Roman Numerals

Roman numerals are a number system that was devised by the ancient Romans for the purpose of counting and performing other day-to-day transactions. Several letters from the Latin alphabet are used for the representation of roman numerals.

**Humanizer.Core** provides the `ToRoman` extension method that converts numbers to roman numerals. Let's consider the following simple example which converts integer numbers to roman numerals.

```csharp
public static void Example1()
{
    List<int> list = new List<int>()
    {
        1,
        2,
        3,
        4,
        5
    };

    foreach (var value in list)
    {
        Console.WriteLine("{0}: \t {1}", value, value.ToRoman());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
1:       I
2:       II
3:       III
4:       IV
5:       V
```

It also supports the reverse operation using the `FromRoman` extension method.

```csharp
public static void Example2()
{
    List<string> list = new List<string>()
    {
        "VI",
        "VII",
        "VIII",
        "IX",
        "X"
    };

    foreach (var value in list)
    {
        Console.WriteLine("{0}: \t {1}", value, value.FromRoman());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
VI:      6
VII:     7
VIII:    8
IX:      9
X:       10
```

