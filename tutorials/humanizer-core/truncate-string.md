---
PermaID: 100016
Name: Truncate String
---

# Truncate String

**Humanizer.Core** provides a `Truncate()` string extension method that truncates a `string`. Let's consider the following simple example that truncates a string.

```csharp
public static void Example1()
{
    string input = "This is a string truncate example";
    string result = input.Truncate(17);
    Console.WriteLine(result);
}
```

Let's execute the above example and you will see the following output.

```csharp
This is a string.
```

As you can see that by default the `.` character is used to truncate strings. It allows you to specify some other character as the 2nd parameter for truncation.

```csharp
public static void Example2()
{
    string input = "This is a string truncate example";
    string result = input.Truncate(17, "...");
    Console.WriteLine(result);
}
```

Let's execute the above example and you will see the following output.

```csharp
This is a stri...
```

The advantage of using the '.' character instead of "..." is that it only takes a single character which allows more text to be shown before truncation. 

The default truncation strategy is `Truncator.FixedLength` to truncate the input string to a specific length, including the truncation string length. You can use other strategies by specifying the 3rd argument as shown below.

```csharp
public static void Example3()
{
    string input = "This is a string truncate example"; 
    
    Console.WriteLine(input.Truncate(17, Truncator.FixedLength));
    Console.WriteLine(input.Truncate(17, "...", Truncator.FixedLength));

    Console.WriteLine(input.Truncate(17, Truncator.FixedNumberOfCharacters));
    Console.WriteLine(input.Truncate(17, "...", Truncator.FixedNumberOfCharacters));

    Console.WriteLine(input.Truncate(5, Truncator.FixedNumberOfWords));
    Console.WriteLine(input.Truncate(5, "...", Truncator.FixedNumberOfWords));
}
```

Let's execute the above example and you will see the following output.

```csharp
This is a string.
This is a stri...
This is a string tru.
This is a string t...
This is a string truncate.
This is a string truncate...
```
