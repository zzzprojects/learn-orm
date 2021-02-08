---
PermaID: 100024
Name: Structure
---

# Structure

A structure is a generalization of the user-defined type. In addition to fields, it can expose properties, methods, and events. A structure can implement one or more interfaces, and you can declare individual access levels for each field.

 - You can combine data items of different types to create a structure. 
 - A structure associates one or more elements with each other and with the structure itself. 
 - When you declare a structure, it becomes a composite data type, and you can declare variables of that type.
 - Structures are useful when you want a single variable to hold several related pieces of information.

## Structure Declaration

You can declare a structure using the `Structure` statement. You can specify the access level of a structure using the `Public`, `Protected`, `Friend`, or `Private` keyword.

Let's consider the following simple example where we have declared a structure named `Point3D`, which contains three integers `X`, `Y`, and `Z`.

```csharp
Public Structure Point3D
    Public X As Integer
    Public Y As Integer
    Public Z As Integer
End Structure
```

Structures are also used to represent a record. For example, if you want to keep track of all your customers, you can add the following fields to the structure.

```csharp
Public Structure CustomerInfo
    Public Id As Integer
    Public Name As String
    Public Address As String
End Structure
```

To use the structure, you can create its object using with or without the `new` keyword. 

```csharp
Public Sub Example1()
    Dim point1 As Point3D
    Dim point2 As Point3D = New Point3D()
    point1.X = 10
    point1.Y = 20
    point1.Z = 30
    point2.X = 40
    point2.Y = 50
    point2.Z = 60
    Console.WriteLine("X: {0}, Y: {1}, Z: {2}", point1.X, point1.Y, point1.Z)
    Console.WriteLine("X: {0}, Y: {1}, Z: {2}", point2.X, point2.Y, point2.Z)
End Sub
```

Let's run the above code and it will print the following output on the console window.

```csharp
X: 10, Y: 20, Z: 30
X: 40, Y: 50, Z: 60
```

## Constructors in Structure

A `Structure` only supports constructors that contain parameters. Here in the `CustomerInfo` structure, a parametrized constructor is added.

```csharp
Public Structure CustomerInfo
    Public Id As Integer
    Public Name As String
    Public Address As String

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal address As String)
        Me.Id = id
        Me.Name = name
        Me.Address = address
    End Sub
End Structure
```

You can create its object by calling the parameterized constructor.

```csharp
Public Sub Example2()
    Dim customer As CustomerInfo = New CustomerInfo(1, "Mark", "22 wall street")
    Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", customer.Id, customer.Name, customer.Address)
End Sub
```

Let's run the above code, and it will print the following output on the console window.

```csharp
Id: 1, Name: Mark, Address: 22 wall street
```

## Methods in Structure

You can also add methods to your structure in C#. Here is a simple method `Print()` which will print all the information of a customer on the console window.

```csharp
Public Structure CustomerInfo
    Public Id As Integer
    Public Name As String
    Public Address As String

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal address As String)
        Me.Id = id
        Me.Name = name
        Me.Address = address
    End Sub

    Public Sub Print()
        Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", Me.Id, Me.Name, Me.Address)
    End Sub

End Structure
```

Now to print the customer information, we just need to call the `Print()` method.

```csharp
Public Sub Example3()
    Dim customer As CustomerInfo = New CustomerInfo(1, "Mark", "22 wall street")
    customer.Print()
End Sub
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
 - It can't be inherited from other class or structure types, but it can implement interfaces.
