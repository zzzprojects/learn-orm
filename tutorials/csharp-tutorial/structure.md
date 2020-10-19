---
PermaID: 100018
Name: Structure
---

# Structure

In C#, a structure is a value type that can encapsulate data and related functionality. It is declared using the `struct` keyword. 

 - The structure can contain fields, methods, constants, constructors, properties, indexers, operators, etc.
 - Typically, the structure is used to design small data-centric types that provide little or no behavior.
 - If you need the behavior of a type, you will need to define a class which we will discuss later. 

The general format of a structure declaration is as follows.

```csharp
<AccessModifiers> struct <StructName> 
{ 
    //Body 
}
```

 - **AccessModifiers:** It is declared directly within a namespace so it can be either public or internal. If no access modifier is specified, `internal` is the default.  
 - **struct:** The `struct` is the required keyword.
 - **StructName:** It is the name of the structure and you can use any name supported by C#.

Let's consider the following simple example where we have declared a structure named `Point3D` which contains three integers `X`, `Y`, and `Z`.

```csharp
public struct Point3D
{
    public int X;
    public int Y;
    public int Z;
}
```

Structures are also used to represent a record. For example, if you want to keep track of all your customers, you can add the following fields to the structure.

```csharp
public struct Customer
{
    public int Id;
    public string Name;
    public string Address;
}
```

To use the structure, you can create its object using with or without the `new` keyword. 

```csharp
Point3D point1;
Point3D point2 = new Point3D();

point1.X = 10;
point1.Y = 20;
point1.Z = 30;

point2.X = 40;
point2.Y = 50;
point2.Z = 60;

Console.WriteLine("X: {0}, Y: {1}, Z: {2}", point1.X, point1.Y, point1.Z);
Console.WriteLine("X: {0}, Y: {1}, Z: {2}", point2.X, point2.Y, point2.Z);
```

Let's run the above code and it will print the following output on the console window.

```csharp
X: 10, Y: 20, Z: 30
X: 40, Y: 50, Z: 60
```

## Constructors in Structure

A `struct` only supports constructors which contain parameters. Here in the Customer structure, a parametrized constructor is added.

```csharp
public struct Customer
{
    public int Id;
    public string Name;
    public string Address;

    public Customer(int id, string name, string address)
    {
        this.Id = id;
        this.Name = name;
        this.Address = address;
    }
}
```

You can create its object by calling the parameterized constructor.

```csharp
Customer customer = new Customer(1, "Mark", "22 wall street");

Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", customer.Id, customer.Name, customer.Address);
```

Let's run the above code and it will print the following output on the console window.

```csharp
Id: 1, Name: Mark, Address: 22 wall street
```

## Methods in Structure

You can also add methods to your structure in C#. Here is a simple method `Print()` which will print all the information of a customer on the console window.

```csharp
public struct Customer
{
    public int Id;
    public string Name;
    public string Address;

    public Customer(int id, string name, string address)
    {
        this.Id = id;
        this.Name = name;
        this.Address = address;
    }

    public void Print()
    {
        Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", this.Id, this.Name, this.Address);
    }
}
```

Now to print the customer information, we just need to call the `Print()` method.

```csharp
Customer customer = new Customer(2, "John", "11 wall street");

customer.Print();
```

Let's run the above code and it will print the following output on the console window.

```csharp
Id: 2, Name: John, Address: 11 wall street
```

## Limitations

When you are working with structures, you must keep in mind the following limitations.

 - Structure doesn't support a parameterless constructor but provides an implicit parameterless constructor that produces the default value of the type.
 - It can't initialize an instance field or property at its declaration, it can only initialize a static or const field or a static property at its declaration.
 - A constructor must initialize all instance fields of the structure.
 - It can't be inherited from other class or structure type, but it can implement interfaces (will be discussed later).

All the examples related to the structure are available in the `Structure.cs` file of the source code. Download the source code and try out all the examples for better understanding.
