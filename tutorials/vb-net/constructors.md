---
PermaID: 100011
Name: Constructors
---

# Constructors

In object-oriented programming, when creating an object from a given class, it is necessary to call a special method of the class known as a constructor.

## What Is a Constructor?

The constructor is a special method of a class created with a `New` keyword and does not have a return type. The main purpose of the constructor is to initialize the memory, allocated for the object, where its fields will be stored.

There are various types of constructors.

 - [Default Constructor](#default-constructor)
 - [Parameterized Constructor](#parameterized-constructor)
 - [Copy Constructor](#copy-constructor)
 - [Private Constructor](#private-constructor)

### Default Constructor

If you don't provide a constructor for your class, VB.NET creates one by default that instantiates the object and sets member variables to the default values.

Here is an example of the most simplified parameterless constructor in the `CustomerInfo` class.

```csharp
Public Sub New()
    Console.WriteLine("Default Constructor Called")
End Sub
```

The following code shows how to call a default parameterless constructor.

```csharp
Dim customer As CustomerInfo = New CustomerInfo()
```

In the above example, using the `New` keyword, we call the constructor of the class `CustomerInfo`. The memory is allocated for the newly created object of the `CustomerInfo` type.

### Parameterized Constructor

Similar to the methods, if we need extra data to create an object, the constructor gets it through a parameter list. The following example passes two strings variables `name` and `address` as a parameter to the constructor.

```csharp
Public Sub New(ByVal name As String, ByVal address As String)
    Me.Name = name
    Me.Address = address
End Sub
```

Similarly, the call of a constructor with parameters is done in the same way as the call of a method with parameters. The required values are supplied as a list separated with commas.

```csharp
Dim customer1 As CustomerInfo = New CustomerInfo("John", "11 wall street")
```

There is no limit to parameters, you can have as many parameters as you want.

### Copy Constructor

The constructor which creates an object by copying variables from another object is called a copy constructor. The purpose of a copy constructor is to initialize a new instance to the values of an existing instance.

```csharp
Public Sub New(ByVal customer As CustomerInfo)
    Me.Name = customer.Name
    Me.Address = customer.Address
End Sub
```

The copy constructor is called by passing the object as a parameter of the same class.

```csharp
Dim customer1 As CustomerInfo = New CustomerInfo("John", "11 wall street")
Dim customer2 As CustomerInfo = New CustomerInfo(customer1)

customer1.Print()
customer2.Print()
```

Let's execute the above code and you will see the same values for both objects.

```csharp
Name: John, Address: 11 wall street
Name: John, Address: 11 wall street
```

### Private Constructor

A private constructor is declared by specifying the `Private` access modifier. It is used to prevent creating instances of a class when we have only `Shared` members. 

```csharp
Public Class Counter
    Private Sub New()
    End Sub

    Public Shared currentCount As Integer

    Public Shared Function IncrementCount() As Integer
        currentCount += 1
        Return currentCount
    End Function
End Class
```

You can call the members using the class name instead of creating its object.

```csharp
Counter.currentCount = 9
Counter.IncrementCount()
Console.WriteLine("New count: {0}", Counter.currentCount)
```

Let's execute the above code and you will see the following output.

```csharp
New count: 10
```
