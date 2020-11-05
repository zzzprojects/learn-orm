---
PermaID: 100006
Name: With Expressions
---

# With Expressions

A `with` expression allows for "non-destructive mutation", designed to produce a copy of the receiver expression with modifications in assignments.

 - A with expression is not permitted as a statement.
 - A valid `with` expression has a receiver with a non-void type. 
 - The receiver type must be a record.
 - On the right-hand side of the `with` expression is a `member_initializer_list` with a sequence of assignments to an identifier, which must be an accessible instance field or property of the receiver's type.

Let's suppose you have a record with many properties, and you want to create a new record with only one or a few changes. You would have to write a constructor taking each property from the existing record, and then you will specify that one change or few changes. But you can use the `with` keyword and specify your changes on the right side.

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        Customer customer = new Customer
        {
            Name = "Mark",
            Age = 34,
            Address = "23 ashdown",
            Country = "UK"
        };

        var newCustomer = customer with { Name = "John" };

        Console.WriteLine(customer.Name);
        Console.WriteLine(newCustomer.Name);
    }
}

record Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
}
```

As you can see in the above code, we have created a customer record, and using the `with` keyword another customer record is created only changing its name and all other properties remain as is.

 - It will take all the values of `customer`, and creates a new record `newCustomer` with the `Name` changed. 
 - With-expressions use object initializer syntax to state what’s different in the new object from the old object. You can specify multiple properties.
 - The `with` expression causes the copy constructor to get called and then applies the object initializer on top to change the properties accordingly.