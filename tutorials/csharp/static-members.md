---
PermaID: 100024
Name: Static Members
---

# Static Members

## What is a Static Member?

When any member of the class is declared with the `static` modifier it is known as a static member. In C#, we can declare fields, methods, properties, constructors, and classes as static. In this article, we will understand the static fields, methods, properties of a class, and then in the next article we will discuss the concept of the static class.

 - Any fields, methods, and properties, marked as static, belong to the particular class rather than to any particular object of the given class.
 - Therefore, when we mark a field, method, or property as static, we can use them even without creating any object of the class. 

The main advantage of a static member is that it will not be bound with any object. It is individually accessible with the class name without even creating an object.

### Static Fields

The static fields are declared the same way as the class fields, you just need to add a `static` keyword after the access modifier.

```csharp
public class CustomerInfo
{
    // static variable
    public static int count;
    public string Name { get; set; }
    public string Address { get; set; } 
}
```

The static field is created when we try to access them for the first time and are initialized with the default values of their types. 

 - You can also initialize it with a particular value. 
 - The initialization executes only once when the field is accessed for the first time. 
 - The next time when the field is accessed that field initialization will not execute.

The static field can be initialized as shown below.

```csharp
public static int count = 0;
```

As mentioned before, the static variables are shared between all objects of the class and do not belong to any object of the particular class. It means any object can access and modify the static field values and other objects can see the modified values.

Let's suppose, we want to count the number of created objects of the `CustomerInfo` class, we should use a static field and increment it by one every time the constructor is called.

```csharp
public class CustomerInfo
{
    // static variable
    public static int count;
    public string Name { get; set; }
    public string Address { get; set; }

    public CustomerInfo(string name, string address)
    {
        this.Name = name;
        this.Address = address;

        CustomerInfo.count++;
    }
}
```

Let's create some objects of the `CustomerInfo` class and print the count.

```csharp
Console.WriteLine("Total Customers: {0}", CustomerInfo.count);

CustomerInfo customer1 = new CustomerInfo("John", "11 wall street");
CustomerInfo customer2 = new CustomerInfo("Mark", "22 wall street");
CustomerInfo customer3 = new CustomerInfo("Andy", "13 wall street");
CustomerInfo customer4 = new CustomerInfo("Bruce", "41 wall street");

Console.WriteLine("\nAfter creating a few objects\n");

Console.WriteLine("Total Customers: {0}", CustomerInfo.count);
```

Let's run the above code and you will see the following output.

```csharp
Total Customers: 0

After creating a few objects

Total Customers: 4
```

### Static Methods

Similarly, we can declare a method as static if we want it to be associated only with the class and not with a particular class object.

```csharp
public class MathUtility
{
    public static int Add(int number1, int number2)
    {
        return (number1 + number2);
    }
}
```

Like static fields, static methods can be accessed using the class name.

```csharp
int number1 = 4;
int number2 = 7; 
int result = MathUtility.Add(number1, number2);
Console.WriteLine("{0} + {1} = {2}", number1, number2, result);
```

Let's run the above code and you will see the following output.

```csharp
4 + 7 = 11
```

All the examples related to the static members are available in the `StaticMembers.cs` file of the source code. Download the source code and try out all the examples for better understanding.
