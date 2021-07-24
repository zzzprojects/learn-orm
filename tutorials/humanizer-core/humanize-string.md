---
PermaID: 100001
Name: Humanize String
---

# Humanize String

**Humanizer.Core** provides a `Humanize()` string extension method that converts a computerized string into more readable human-friendly strings.

Let's consider the following simple example which contains different strings and it will convert it to readable human-friendly strings.

```csharp
public static void Example1()
{
    List<string> list = new List<string>()
    {
        "MyTestString",
        "My_Test_String",
        "my_test_string",
    };

    foreach (var str in list)
    {
        Console.WriteLine(str.Humanize());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
My test string
My Test String
my test string
```

A string that contains only unbroken upper case letters is always treated as an acronym regardless of its length.

```csharp
public static void Example2()
{
    List<string> list = new List<string>()
    {
        "MYTESTSTRING",
        "MY_TEST_STRING",
    };

    foreach (var str in list)
    {
        Console.WriteLine(str.Humanize());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
MYTESTSTRING
MY TEST STRING
```

You may also specify the desired letter casing by passing any of the following enum values as a parameter to the `Humanize()`  method.

```csharp
public enum LetterCasing
{
    Title = 0,    
    AllCaps = 1,  
    LowerCase = 2,
    Sentence = 3  
}
``` 

The following example converts the string to the various casing as specified as a parameter.

```csharp
public static void Example3()
{
    string str = "MyTestString";

    Console.WriteLine(str.Humanize(LetterCasing.Title));
    Console.WriteLine(str.Humanize(LetterCasing.AllCaps));
    Console.WriteLine(str.Humanize(LetterCasing.LowerCase));
    Console.WriteLine(str.Humanize(LetterCasing.Sentence));
}
```

Let's execute the above example and you will see the following output.

```csharp
My Test String
MY TEST STRING
my test string
My test string
``` 