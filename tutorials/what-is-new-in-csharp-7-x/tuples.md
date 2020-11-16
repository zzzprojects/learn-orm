---
PermaID: 100009
Name: Tuples
---

# Tuples

## What is a Tuple?

A tuple provides a syntax that allows you to combine the assignment of multiple variables, of varying types, in a single statement.

 - It is a finite ordered list of values of different types, which combines related values without having to create a specific type to hold them.
 - It provides concise syntax to group multiple data elements in a lightweight data structure. 

## Why Tuples?

In C#, you can see a rich syntax for classes and structs that are used to explain your design intent, but sometimes that requires extra work with minimal benefit. 

 - In many cases, you may have methods that return more than one variable, the traditional way is using the `out` parameter but there are some limitations for the `out` parameter such as, you can't use it with the `async` method. 
 - To support these scenarios tuples were added to C#. 

Before C# 7.1, a set of `Tuple` classes was already available in the .NET Framework. The following example shows how you can declare a tuple variable, initialize it, and access its data members.

```csharp
Tuple<string, int, string> person = new Tuple<string, int, string>("Mark", 23, "22 Ashdown close");
Console.WriteLine(person);          // (Mark, 23, 22 Ashdown close)

Console.WriteLine("Elements in tuple: {0}, {1}, {2}", 
    person.Item1, person.Item2, person.Item3);             // Elements in tuple: Mark, 23, 22 Ashdown close
```

In C# 7.1, a new feature is introduced to improve support for tuples. You can declare tuples types like anonymous types, except that tuples are not limited to the current method. 

The following example shows the same example using the new feature.


```csharp
var person = ("Mark", 23, "22 Ashdown close" );
Console.WriteLine(person);                                 // (Mark, 23, 22 Ashdown close)

Console.WriteLine("Elements in tuple: {0}, {1}, {2}", 
    person.Item1, person.Item2, person.Item3);             // Elements in tuple: Mark, 23, 22 Ashdown close
```

As you can see that it becomes much cleaner and easy to read. To define a tuple type, you can specify types of all its data members as shown below.

```csharp
(string, int, string) person = ("Mark", 23, "22 Ashdown close");
Console.WriteLine(person);                                 // (Mark, 23, 22 Ashdown close)

Console.WriteLine("Elements in tuple: {0}, {1}, {2}",
    person.Item1, person.Item2, person.Item3);             // Elements in tuple: Mark, 23, 22 Ashdown close
```

## Named Properties

You can assign names to the properties instead of having the default property names such as `Item1`, `Item2` etc.

```csharp
(string Name, int Age, string Address) person = ("Mark", 23, "22 Ashdown close");
Console.WriteLine(person);                                 // (Mark, 23, 22 Ashdown close)

Console.WriteLine("Name: {0}, Age: {1}, Address: {2}",
    person.Name, person.Age, person.Address);             // Name: Mark, Age: 23, Address: 22 Ashdown close
```

You can also assign names on the right side with values as shown below.

```csharp
var person = (Name: "Mark", Age:23, Address: "22 Ashdown close");
Console.WriteLine(person);                                // (Mark, 23, 22 Ashdown close)

Console.WriteLine("Name: {0}, Age: {1}, Address: {2}",
    person.Name, person.Age, person.Address);             // Name: Mark, Age: 23, Address: 22 Ashdown close
```

You can provide names either on the left or right sides but not on both sides. The left side has precedence over the right side. The following will ignore names on the right side.

One of the most common use cases of tuples is to use as a method return type. You can group method results in a tuple return type instead of defining `out` method parameters as shown below.

```csharp
private static (string Name, int Age, string Address) GetPerson()
{
    string Name = "Mark";
    int Age = 23;
    string Address = "22 Ashdown close";

    return (Name, Age, Address);
}

public static void Example5()
{
    var person = GetPerson();
    Console.WriteLine(person);                                // (Mark, 23, 22 Ashdown close)

    Console.WriteLine("Name: {0}, Age: {1}, Address: {2}",
        person.Name, person.Age, person.Address);             // Name: Mark, Age: 23, Address: 22 Ashdown close
}
```