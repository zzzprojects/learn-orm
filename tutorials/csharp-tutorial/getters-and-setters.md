---
PermaID: 100023
Name: Getters and Setters
---

# Getters and Setters

In C#, properties combine aspects of both fields and methods. It is one or two code blocks, representing a get accessor and/or a set accessor or simply you can call them getter and setter. 

 - The code block for the `get` accessor is executed when the property is read
 - The code block for the `set` accessor is executed when the property is assigned a new value.
 
In the previous examples, you have seen variables declared in the following format.

```csharp
public class CustomerInfo
{
    public string Name { get; set; }
}
```

In C#, it is known as Auto-Implementated property, because when the code is compiled it will automatically convert the above line into a more traditional getter and setter as shown below.

```csharp
public class CustomerInfo
{
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value ;
        }
    }
}
```

 - The body of the get accessor resembles that of a method, it must return a value of the property type.
 - The set accessor resembles a method whose return type is `void`, it uses an implicit parameter called `value`, whose type is the type of the property.

The following examples show that when you assign a value to the property, the set accessor is called using an argument that provides the new value and when you assign the property value to another variable, the get accessor is called to read the value of the property. 

```csharp
CustomerInfo customer = new CustomerInfo();

customer.Name = "John";               // call the setter and set the name
string name = customer.Name;          // call the getter and return the name

Console.WriteLine("The name of the customer is {0}", name);
```

In C# 6 and later, you can initialize auto-implemented properties similar to fields as shown below.

```csharp
public string City { get; set; } = "New York";
```

A property without a `set` accessor is considered read-only and property without a `get` accessor is considered write-only.

```csharp
public string ReadOnly { get; private set; }
public string WriteOnly { private get; set; }
```

All the examples related to the constructors are available in the `GettersAndSetters.cs` file of the source code. Download the source code and try out all the examples for better understandings.