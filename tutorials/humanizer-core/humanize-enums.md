---
PermaID: 100003
Name: Humanize Enums
---

# Humanize Enums

An `enum` type is a value type defined by a set of named constants of the underlying integral numeric type. When you call the `ToString` directly on enum members, it will give less than ideal output for users. Normally, the `[Description]` data annotation attribute is used to get a more friendly output. 

**Humanizer.Core** provides a `Humanize()` extension method that allows you to put some space between words of an enum member.

Let's consider the following simple example which contains various enum members and it will convert it to human-friendly strings.

```csharp
enum EnumDataType
{
    MyEnumIntegerType,
    MyEnumFloatType,
    MyEnumDoubleType,
    MyEnumStringType,
}

public static void Example1()
{
    Console.WriteLine(EnumDataType.MyEnumDoubleType.Humanize());
    Console.WriteLine(EnumDataType.MyEnumFloatType.Humanize());
    Console.WriteLine(EnumDataType.MyEnumStringType.Humanize());
    Console.WriteLine(EnumDataType.MyEnumIntegerType.Humanize());
}
```

Let's execute the above example and you will see the following output.

```csharp
My enum double type
My enum float type
My enum string type
My enum integer type
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

The following example converts the enum to the various casing as specified as a parameter.

```csharp
public static void Example2()
{
    Console.WriteLine(EnumDataType.MyEnumDoubleType.Humanize(LetterCasing.Title));
    Console.WriteLine(EnumDataType.MyEnumFloatType.Humanize(LetterCasing.AllCaps));
    Console.WriteLine(EnumDataType.MyEnumStringType.Humanize(LetterCasing.Sentence));
    Console.WriteLine(EnumDataType.MyEnumIntegerType.Humanize(LetterCasing.LowerCase));
}
```

Let's execute the above example and you will see the following output.

```csharp
My Enum Double Type
MY ENUM FLOAT TYPE
My enum string type
my enum integer type
``` 