---
PermaID: 100020
Name: Classes and Objects
---

# Classes and Objects

In the last few decades programming experienced incredible growth and new concepts changed the way programs are built. The classes and objects are interrelated terms and basics for OOP, these two terms are inseparable parts of the life of any modern programmers.

## What is Class?

A class is nothing but a collection of various fields, properties, and functions. It is defined by the keyword `class`, followed by an identifier (name) of the class and a set of data members and methods in a separate code block.

```csharp
<AccessModifier> class <name>
{
    // Fields, properties, methods, and events go here...
}
```

 - **<AccessModifiers>:** It represents the access modifiers that can be `public`, `internal` or `private`, etc. 
 - **<name>:** The name of the class follows the class keyword. The name of the class must be a valid C# identifier name. 

The remainder of the definition is the class body, where the behavior and data are defined. Fields, properties, methods, and events in a class are collectively referred to as class members.


Here is an example of a class that contains several fields, properties, and methods. You can now see the definition of the class.

```csharp
public class CustomerInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public CustomerInfo()
    { 
    }

    public CustomerInfo(int id, string name, string address)
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

The class `CustomerInfo` defines the properties `Id`, `Name`, and `Address`. The two constructors are defined for creating instances of the class `CustomerInfo`, respectively with and without parameters, and a method of the class `Print()`.

## What is Object?

The object is an instance of a class to access the defined properties and methods. It is a concrete entity based on a class and is created at runtime. You can create an object using the `new` keyword followed by the name of the class. 

Let's consider the following example where we create an object of the `CustomerInfo` class using the parameterless constructor, initializes the object, and print the object values by calling the `Print()` method.

```csharp
CustomerInfo customer = new CustomerInfo();

customer.Id = 1;
customer.Name = "Andy";
customer.Address = "22 wall street";

customer.Print();
```

In the above example, you can see that we have created a `customer` instance for the `CustomerInfo` class. The instance `customer` is a reference to an object that is based on `CustomerInfo`. Now you can use the `customer` object to access all the data members and functions of the `CustomerInfo` class.

You can also use the parameterized constructor for object initialization as shown below.

```csharp
CustomerInfo customer = new CustomerInfo(2, "John", "11 wall street");
customer.Print();
```

Let's run the above code and it will print the following output on the console window.

```csharp
Id: 2, Name: John, Address: 11 wall street
```

All the examples related to the classes and objects are available in the `ClassesAndObjects.cs` file of the source code. Download the source code and try out all the examples for better understanding.
