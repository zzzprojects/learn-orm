---
PermaID: 100001
Name: Init-only Properties
---

# Init-only Properties

The `init` feature is designed to be compatible with existing `get` only properties. Specifically, it is meant to be a completely additive change for a property that is `get` only today but desires more flexible object creation semantics.

 - The init only properties can be set at the point of object creation but become effectively `get` only once object creation has completed. 
 - It allows for a much more flexible immutable model in C#.
 - An init only property is declared by using the `init` accessor in place of the `set` accessor.

The following code shows the declaration of init only properties.

```csharp
class Customer
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
```

## Why we need Init-only Properties

To know the benefits of the init only properties, we need to understand the problem it is actually trying to solve. 

In some classes, we need to make properties publicly readable which you can declare as shown below.

```csharp
class Customer
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}
```

Now you can only set the `FirstName` and `LastName` properties inside the class, such as constructor.

```csharp
class Customer
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Customer(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }
}
```

The main issue is that you can not use an object initializer instead of a constructor.

```csharp
Customer customer = new Customer
{ 
    FirstName = "Mark",
    LastName = "Upston"
};
``` 

You will get the following errors.

```csharp
Error CS0272: The property or indexer 'Customer.FirstName' cannot be used in this context because the set accessor is inaccessible
Error CS0272: The property or indexer 'Customer.LastName' cannot be used in this context because the set accessor is inaccessible
```

Another problem is that in some cases, you want a property to be set inside a constructor *or* object initialization and then not be changed once it is created, such as an immutable property. 

Using the `private set;` you can not achieve complete immutability by only setting that property within a constructor or method. For example, a method can be called to change the property.

```csharp
public void SetFirstName(string firstName)
{
    this.FirstName = firstName;
}
public void SetLastName(string lastName)
{
    this.LastName = lastName;
}
```

There come the init-only properties which solve this issue. Let's change the `Customer` class by changing the `private set` to `init` as shown below.

```csharp
public record Person
{
    public string LastName { get; init; }
    public string FirstName { get; init; }
}
```

Now you can use the object initializer without any issue. 

```csharp
Customer customer = new Customer
{ 
    FirstName = "Mark",
    LastName = "Upston"
};
``` 

You will not able to change the property values after creation. 