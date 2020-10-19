---
PermaID: 100019
Name: Enums
---

# Enums

An `enum` or enumeration type is a special data type that represents a group of constants. It is a value type defined by a set of named constants of the underlying integral numeric type. 

 - Enumeration is a structure, which resembles a class but differs from it in that in the enum body we can only declare constants. 
 - It can take values only from the constants listed in the type. 
 - An enumerated variable cannot have a `null` value.

To define an enumeration type, use the `enum` keyword.

```csharp
<AccessModifiers> enum <EnumName>
{
    constant1, 
    constant2, 
    ., 
    ., 
    constantN
}
```

 - **<AccessModifiers>:** It represent the access modifiers which can be `public`, `internal` and `private`. 
 - **<EnumName>:** It follows the rules for names in C#. 
 - **Constants:"" These are separated by commas and are declared in the enumeration block.

The constants' names in C# follow the **PascalCase** rule according to the Microsoft's official C# coding convention. So, the naming of constants in one particular enumeration follows the same principle.

Let's consider a simple example of defining an enumeration for the days of the week. The constants in this enumeration are the names of the days.

```csharp
enum Days
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday   
}
```

By default, the compiler will assign integer values to each constants starting with 0 if the values are not assigned. The first constant of an `enum` will be 0, and the value of each successive constant is increased by 1.

You can access the enum variable as shown below.

```csharp
Days day = Days.Tuesday;
Console.WriteLine("The day is {0}",day);
```

Let's run the above code and it will print the following output on the console window.

```csharp
The day is Tuesday
```

Here is another enum example where we have assigned a value to the first constant only, so the compiler will assign the values to the remaining constants.

```csharp
enum Months
{
    January           = 1,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}
```

When you assign a different value to the `enum` first constant and it is other than the default value, it will automatically assign incremental values to the other members sequentially.

You can also assign different values to each constant as shown below.

```csharp
enum Categories
{
    Sports         = 1,
    Arts           = 3,
    Clothing       = 7,
    Fashion        = 15,
    Electronics    = 21,
    HealthCare     = 33
}
```

To get the numerical representation of the constant, you can convert its value to an `int` as shown below.

```csharp
Categories category = Categories.HealthCare;
int intVal = (int)category;

Console.WriteLine("The numerical value of {0} is {1}", category, intVal);
```

Let's run the above code and it will print the following output on the console window.

```csharp
The numerical value of HealthCare in 33
```

All the examples related to the enumeration are available in the `Enumeration.cs` file of the source code. Download the source code and try out all the examples for better understanding.
