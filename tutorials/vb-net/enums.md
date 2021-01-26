---
PermaID: 100022
Name: Enums
---

# Enums

An `Enum` or enumeration type is a special data type that represents a group of constants. It is a value type defined by a set of named constants of the underlying integral numeric type. 

 - Enumeration is a structure, which resembles a class but differs from it in that in the enum body we can only declare constants. 
 - It can take values only from the constants listed in the type. 
 - An enumerated variable cannot have a `null` value.

To define an enumeration type, use the `enum` keyword. The basic syntax of the `Enum` statement looks like as shown below.

```csharp
Enum enumerationname [ As datatype ]
   memberlist
End Enum
```

If you have a set of unchanging values that are logically related to each other, you can define them together in an enumeration. 

 - It provides meaningful names for the enumeration and its members, which are easier to remember than their values. 
 - You can then use the enumeration members in many places in your code.

The benefits of using enumerations include the following.

 - Reduces errors caused by transposing or mistyping numbers.
 - Makes it easy to change values in the future.
 - Makes code easier to read, which means it is less likely that errors will be introduced.
 - Ensures forward compatibility. If you use enumerations, your code is less likely to fail if in the future someone changes the values corresponding to the member names.
 - An enumeration has a name, an underlying data type, and a set of members. Each member represents a constant.

Let's consider a simple example of defining an enumeration for the days of the week. The constants in this enumeration are the names of the days.

```csharp
Enum Days
    Sunday
    Monday
    Tuesday
    Wednesday
    Thursday
    Friday
    Saturday
End Enum
```

By default, the compiler will assign integer values to each constants starting with 0 if the values are not assigned. The first constant of an `enum` will be 0, and the value of each successive constant is increased by 1.

You can access the enum variable as shown below.

```csharp
Public Sub Example1()
    Dim day As Days = Days.Tuesday
    Console.WriteLine("The day is {0}", day)
End Sub
```

Let's run the above code and it will print the following output on the console window.

```csharp
The day is Tuesday
```

Here is another enum example where we have assigned a value to the first constant only, so the compiler will assign the values to the remaining constants.

```csharp
Enum Months
    January = 1
    February
    March
    April
    May
    June
    July
    August
    September
    October
    November
    December
End Enum
```

When you assign a different value to the `enum` first constant and it is other than the default value, it will automatically assign incremental values to the other members sequentially.

You can also assign different values to each constant as shown below.

```csharp
Enum Categories
    Sports = 1
    Arts = 3
    Clothing = 7
    Fashion = 15
    Electronics = 21
    HealthCare = 33
End Enum
```

To get the numerical representation of the constant, you can convert its value to an `int` as shown below.

```csharp
Dim category As Categories = Categories.HealthCare
Dim intVal As Integer = CInt(category)

Console.WriteLine("The numerical value of {0} is {1}", category, intVal)
```

Let's run the above code and it will print the following output on the console window.

```csharp
The numerical value of HealthCare in 33
```
