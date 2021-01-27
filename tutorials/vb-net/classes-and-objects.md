---
PermaID: 100009
Name: Classes and Objects
---

# Classes and Objects

## What is Class?

A Class statement defines a new data type. A class is a fundamental building block of object-oriented programming (OOP).

 - You can use `Class` only at namespace or module level. 
 - The declaration context for a class must be a source file, namespace, class, structure, module, or interface, and cannot be a procedure or block.

### Rules

 - **Nesting:** You can define one class within another. The outer class is called the containing class, and the inner class is called a nested class.
 - **Inheritance:** If the class uses the Inherits Statement, you can specify only one base class or interface. A class cannot inherit from more than one element.
   - A class cannot inherit from another class with a more restrictive access level. For example, a Public class cannot inherit from a Friend class.
   - A class cannot inherit from a class nested within it.
 - **Implementation:** If the class uses the `Implements` Statement, you must implement every member defined by every interface you specify in interface names. An exception to this is the reimplementation of a base class member.
 - **Default Property:** A class can specify at most one property as its default property.

A class is nothing but a group of different data members or objects with the same properties, processes, events of an object, and general relationships to other member functions. It is defined by the keyword `class`, followed by an identifier (name) of the class and a set of data members and methods in a separate code block.

```csharp
Public Class Customer
    Public Property Id As Integer
    Public Property Name As String
    Public Property Address As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal address As String)
        Me.Id = id
        Me.Name = name
        Me.Address = address
    End Sub

    Public Sub Print()
        Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", Me.Id, Me.Name, Me.Address)
    End Sub
End Class
```

The class `Customer` defines the properties `Id`, `Name`, and `Address`. The two constructors are defined for creating instances of the class `Customer`, respectively with and without parameters, and a method of the class `Print()`.


## What is Object?

An object is a combination of code and data that can be treated as a unit. An object can be a piece of an application, like control or a form. An entire application can also be an object.

 - Each object in Visual Basic is defined by a class. 
 - A class describes the variables, properties, procedures, and events of an object. 
 - Objects are instances of classes; you can create as many objects you need once you have defined a class.

Let's consider the following example where we create an object of the `Customer` class using the parameterless constructor, initializes the object, and print the object values by calling the `Print()` method.

```csharp
Dim customer As Customer = New Customer()
customer.Id = 1
customer.Name = "Andy"
customer.Address = "22 wall street"

customer.Print()
```

In the above example, you can see that we have created a `customer` object for the `Customer` class. Now you can use the `customer` object to access all the data members and functions of the `Customer` class.

You can also use the parameterized constructor for object initialization as shown below.

```csharp
Dim customer As Customer = New Customer(2, "John", "11 wall street")
customer.Print()
```

Let's run the above code, and it will print the following output on the console window.

```csharp
Id: 1, Name: Andy, Address: 22 wall street
```
