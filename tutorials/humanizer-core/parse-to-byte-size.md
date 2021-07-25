---
PermaID: 100013
Name: Parse to ByteSize
---

# Parse to ByteSize

**Humanizer.Core**  to turn a string representation back into a ByteSize instance, but you can use Parse and TryParse on ByteSize to do that. Like other TryParse methods, ByteSize.TryParse returns a boolean value indicating whether or not the parsing was successful. If the value is parsed it is output to the out parameter supplied:

```csharp
public static void Example1()
{
    List<string> list = new List<string>()
    {
        "7b",
        "16B",
        "4.5KB",
        "1.5MB",
        "6.3GB",
        "4.7TB"
    };

    foreach (var value in list)
    {
        ByteSize output;
        ByteSize.TryParse(value, out output);

        Console.WriteLine("{0}: \t {1}", value, output.ToFullWords());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
7b:      7 bits
16B:     16 bytes
4.5KB:   4.5 kilobytes
1.5MB:   1.5 megabytes
6.3GB:   6.3 gigabytes
4.7TB:   4.7 terabytes
```
