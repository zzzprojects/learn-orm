---
PermaID: 100022
Name: Constructors
---

# Constructors

In object-oriented programming, when creating an object from a given class, it is necessary to call a special method of the class known as a constructor.

## What Is a Constructor?

The constructor is a special method of a class, which does not have a return type, it has the same name as the name of its class.

 - The main purpose of the constructor is to initialize the memory, allocated for the object, where its fields will be stored.
 - You can call the constructor using the `new` keyword.

To declare the constructor in your class, use the following format.

```csharp
<AccessModifiers> <ClassName>(<parametersList>)
{
}
```

 - As you already know, the constructors are similar to methods, but they do not have a return type.
 - It is mandatory that the name of every constructor matches the name of the class in which it resides. 
 - It is not allowed to declare a method whose name matches the name of the class.

There are various types of constructors.

 - [Default Constructor](#default-constructor)
 - [Parameterized Constructor](#parameterized-constructor)
 - [Copy Constructor](#copy-constructor)
 - [Private Constructor](#private-constructor)
 - [Static Constructor](#static-constructor)

### Default Constructor

If you don't provide a constructor for your class, C# creates one by default that instantiates the object and sets member variables to the default values.

Here is an example of the most simplified parameterless constructor in the `CustomerInfo` class.

```csharp
public CustomerInfo()
{ 
}
```

The following code shows how to call a default parameterless constructor.

```csharp
CustomerInfo customer = new CustomerInfo();
```

In the above example, using the `new` keyword, we call the constructor of the class `CustomerInfo`. The memory is allocated for the newly created object of the `CustomerInfo` type.

### Parameterized Constructor

Similar to the methods, if we need extra data to create an object, the constructor gets it through a parameter list. The following example passes two strings variables `name` and `address` as a parameter to the constructor.

```csharp
public CustomerInfo(string name, string address)
{
    this.Name = name;
    this.Address = address;
}
```

Similarly, the call of a constructor with parameters is done in the same way as the call of a method with parameters. The required values are supplied as a list separated with commas.

```csharp
CustomerInfo customer = new CustomerInfo("John", "11 wall street");
```

There is no limit to parameters, you can have as many parameters as you want.

### Copy Constructor

The constructor which creates an object by copying variables from another object is called a copy constructor. The purpose of a copy constructor is to initialize a new instance to the values of an existing instance.

```csharp
public CustomerInfo(CustomerInfo customer)
{
    this.Name = customer.Name;
    this.Address = customer.Address;
}
```

The copy constructor is called by passing the object as a parameter of the same class.

```csharp
CustomerInfo customer1 = new CustomerInfo("John", "11 wall street");
CustomerInfo customer2 = new CustomerInfo(customer1);

customer1.Print();
customer2.Print();
```

Let's execute the above code and you will see the same values for both objects.

```csharp
Name: John, Address: 11 wall street
Name: John, Address: 11 wall street
```

### Private Constructor

A private constructor is declared by specifying the `private` access modifier. It is used to prevent creating instances of a class when we have only static members. 

```csharp
public class Counter
{
    private Counter() 
    { }

    public static int currentCount;
    public static int IncrementCount()
    {
        return ++currentCount;
    }
}
```

You can call the members using the class name instead of creating its object.

```csharp
Counter.currentCount = 9;
Counter.IncrementCount();
Console.WriteLine("New count: {0}", Counter.currentCount);
```

Let's execute the above code and you will see the following output.

```csharp
New count: 10
```

### Static Constructor

A static constructor is used to initialize any static data, or to perform a particular action that needs to be performed only once. It does not take any access modifiers or any parameters.

 - It is called automatically before the first instance is created or any static members are referenced.
 - When it is executing then the user has no control.
.
```csharp
public static int minimumAge;
static CustomerInfo()
{
    minimumAge = 18;
}
```

To see how it works, we will print a message on the console in both default and static constructors.

```csharp
static CustomerInfo()
{
    minimumAge = 18;
    Console.WriteLine("Static Constructor Called");
}

public CustomerInfo()
{
    Console.WriteLine("Default Constructor Called");
}
```

Now let's call the default constructor and see the order in which the static and default constructors are called.

```csharp
CustomerInfo customer = new CustomerInfo();
Console.WriteLine("Minimum Age: {0}", CustomerInfo.minimumAge);
```

Let's execute the above code and you will see the following output.

```csharp
Static Constructor Called
Default Constructor Called
Minimum Age: 18
```

As you can see, we just called the default constructor, but the compiler calls the static constructor before the default constructor.

All the examples related to the constructors are available in the `ConstructorsTests.cs` file of the source code. Download the source code and try out all the examples for better understanding.
