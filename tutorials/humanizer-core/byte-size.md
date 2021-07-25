---
PermaID: 100012
Name: ByteSize
---

# ByteSize

**ByteSize** is a utility class that makes byte size representation in code easier by removing the ambiguity of the value being represented.

**Humanizer.Core** includes a port of the **ByteSize** library with a few changes and additions to make the interaction of **ByteSize** with the Humanizer API easier and more consistent. 

Let's consider the following simple example which shows how you can convert numbers to byte sizes.

```csharp
public static void Example1()
{
    List<ByteSize> list = new List<ByteSize>()
    {
        7.Bits(),
        16.Bytes(),
        (4.5).Kilobytes(),
        (1.5).Megabytes(),
        (6.3).Gigabytes(),
        (4.7).Terabytes()
    };

    foreach (var value in list)
    {
        Console.WriteLine(value);
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
7 b
16 B
4.5 KB
1.5 MB
6.3 GB
4.7 TB
```

You can also provide a string representation with full words by calling the `ToFullWords` extension method on the `ByteSize` instance.

```csharp
public static void Example2()
{
    List<ByteSize> list = new List<ByteSize>()
    {
        7.Bits(),
        16.Bytes(),
        (4.5).Kilobytes(),
        (1.5).Megabytes(),
        (6.3).Gigabytes(),
        (4.7).Terabytes()
    };

    foreach (var value in list)
    {
        Console.WriteLine(value.ToFullWords());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
7 bits
16 bytes
4.5 kilobytes
1.5 megabytes
6.3 gigabytes
4.7 terabytes
```

It also supports adding and subtract the values by using either `+`/`-` operators or you can also use `Add` and `Subtract` methods.

```csharp
public static void Example3()
{
    var result1 = (10).Gigabytes() + (512).Megabytes();
    var result2 = (512).Megabytes() - (256).Megabytes();
    var result3 = (10).Megabytes().Subtract((2500).Kilobytes()).Add((25).Megabytes());

    Console.WriteLine("(10).Gigabytes() + (512).Megabytes(): \t {0}", result1);
    Console.WriteLine("(512).Megabytes() - (256).Megabytes(): \t {0}", result2);
    Console.WriteLine("(10).Megabytes().Subtract((250000).Kilobytes()).Add((25).Megabytes()): \t {0}", result3);
}
```

Let's execute the above example and you will see the following output.

```csharp
(10).Gigabytes() + (512).Megabytes():    10.5 GB
(512).Megabytes() - (256).Megabytes():   256 MB
(10).Megabytes().Subtract((250000).Kilobytes()).Add((25).Megabytes()):   32.56 MB
```
