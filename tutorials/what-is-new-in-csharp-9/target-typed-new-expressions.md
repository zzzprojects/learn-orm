---
PermaID: 100003
Name: Target-typed new Expressions
---

# Target-typed new Expressions

## Target Typing
 
C# 9.0 provides better target typing and some expressions that weren't previously target typed become able to be guided by their context. Target typing is a term we use for when an expression gets its type from the context of where it's being used. 

## Target-typed new Expressions

The `new` expressions in C# have always required a type to be specified except for implicitly typed array expressions. 

```csharp
class Program
{
    static void Main(string[] args)
    {
        Customer customer = new Customer();
    }
}

class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```

Now in C# 9, you can leave out the type if there's a clear type that the expressions are being assigned to. 

```csharp
class Program
{
    static void Main(string[] args)
    {
        Customer customer = new();
    }
}

class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```

You can see that we have already defined the type for the `customer` variable, it can infer that when you call `new()` without a type. It allows you to omit the type of object you are instantiating. Obviously, you can’t combine it with the `var` keyword. 

It even works with constructors with parameters.

```csharp
class Program
{
    static void Main(string[] args)
    {
        Customer customer = new("Mark", "Upston");
    }
}

class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Customer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

```

The use of the `var` keyword is almost the reverse of the improvements to target typing in C# 9.