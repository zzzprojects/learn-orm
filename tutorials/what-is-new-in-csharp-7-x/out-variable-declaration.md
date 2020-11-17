---
PermaID: 100002
Name: Out Variable Declaration
---

# Out Variable Declaration

The **out variable declaration** feature introduced in C# 7.0 enables you to declare a variable where that it is being passed as an `out` argument. A variable declared this way is called an out variable.

Before C# 7.0, to use an out variable, you must first declare a variable of the correct type before using it, and then pass it as an `out` parameter as shown below.

```csharp
string address;
GetAddress(out address);
Console.WriteLine(address);
```

In C# 7.0, you can declare `out` variable in the same place it is used. It is a more cohesive approach without reliance on any external variable.

```csharp
GetAddress(out string address);
Console.WriteLine(address);
```

You can also declare more than one output parameter using the new syntax, as shown below.

```csharp
private static void GetCoords(out double x, out double y, out double z)
{
    x = 0.0;
    y = 0.0;
    z = 3.0;
}

public static void Example3()
{
    GetCoords(out double x, out double y, out double z);
    Console.WriteLine("X: {0}, Y: {1}, Z: {2}", x, y, z);
}
```

You can also omit the parameter you don't wish to return using `out _` discard (which can be declared with an underscore).

```csharp
private static void GetEmployee(out string name, out string title, out int age, out double salary)
{
    name = "Mark";
    title = "Software Developer";
    age = 21;
    salary = 5000;---
PermaID: 100002
Name: Out Variable Declaration
```

# Out Variable Declaration

The **out variable declaration** feature introduced in C# 7.0 enables you to declare a variable at the location that it is being passed as an `out` argument. A variable declared this way is called an out variable.

Before C# 7.0, to use an out variable, you must first declare a variable of the correct type before using it and then pass it as an `out` parameter, as shown below.

```csharp
string address;
GetAddress(out address);
Console.WriteLine(address);
```

In C# 7.0, you can declare the `out` variable in the same place it is used. It is a more cohesive approach without reliance on any external variable.

```csharp
GetAddress(out string address);
Console.WriteLine(address);
```

You can also declare more than one output parameter using the new syntax as shown below.

```csharp
private static void GetCoords(out double x, out double y, out double z)
{
    x = 0.0;
    y = 0.0;
    z = 3.0;
}

public static void Example3()
{
    GetCoords(out double x, out double y, out double z);
    Console.WriteLine("X: {0}, Y: {1}, Z: {2}", x, y, z);
}
```

You can also omit the parameter you don't wish to return using `out _` discard (which can be declared with an underscore).

```csharp
private static void GetEmployee(out string name, out string title, out int age, out double salary)
{
    name = "Mark";
    title = "Software Developer";
    age = 21;
    salary = 5000;
}

public static void Example4()
{
    GetEmployee(out string name, out string title, out int age, out _ );
    Console.WriteLine("Name: {0}, Title: {1}, Age: {2}", name, title, age);
}
```

You can also use the `var` keyword and the compiler will be able to tell the type unless there are conflicting overrides.

```csharp
private static void GetEmployee(out string name, out string title, out int age, out double salary)
{
    name = "Mark";
    title = "Software Developer";
    age = 21;
    salary = 5000;
}

public static void Example5()
{
    GetEmployee(out var name, out var title, out var age, out _);
    Console.WriteLine("Name: {0}, Title: {1}, Age: {2}", name, title, age);
}
```
```
}

public static void Example4()
{
    GetEmployee(out string name, out string title, out int age, out _ );
    Console.WriteLine("Name: {0}, Title: {1}, Age: {2}", name, title, age);
}
```

You can also use the `var` keyword and the compiler will be able to tell the type unless there are conflicting overrides.

```csharp
private static void GetEmployee(out string name, out string title, out int age, out double salary)
{
    name = "Mark";
    title = "Software Developer";
    age = 21;
    salary = 5000;
}

public static void Example5()
{
    GetEmployee(out var name, out var title, out var age, out _);
    Console.WriteLine("Name: {0}, Title: {1}, Age: {2}", name, title, age);
}
```
