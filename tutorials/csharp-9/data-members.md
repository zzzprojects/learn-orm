---
PermaID: 100007
Name: Data Members
---

# Data Members

The record type intends to be immutable, with `init-only` public properties that can be modified using `with-expression`. To optimize for that common case, records change the defaults of what a simple member declaration of the type string `Name` means. 

Instead of an implicitly private field, as you declare it in other classes and structs, in records you can use the shorthand for a public, init-only auto-property as shown below.

```csharp
public record Customer { string Name; int Age;  string Address; string Country; }
```

The above declaration is similar to the following declaration.

```csharp
public record Customer
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Address { get; init; }
    public string Country { get; init; }
}
```

If you want a private field, you can just add the private modifier explicitly as shown below.

```csharp
private string Name;
```

Sometimes it's useful to have a more positional approach to a record, where its content is given via constructor arguments and can be extracted with positional deconstruction. 

It is also possible to specify your constructor and deconstructor in a record.

```csharp
public record Customer
{
    string Name;
    int Age;
    string Address;
    string Country;

    public Customer(string name, int age, string address, string country) 
        => (Name, Age, Address, Country) = (name,  age, address, country);

    public void Deconstruct(out string name, out int age, out string address, out string country)
        => (name, age, address, country) = (Name, Age, Address, Country);
}
```

You can express the same thing in much shorter syntax as shown below.

```csharp
public record Customer ( string Name, int Age,  string Address, string Country );
```

It declares the public init-only auto-properties and the constructor and the deconstructor.

```csharp
// positional construction
Customer customer = new ("Mark", 34, "23 ashdown", "UK");

// positional deconstruction
var (name, age, address, country) = customer;
```
