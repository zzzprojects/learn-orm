---
PermaID: 100017
Name: Ref Returns and Ref Locals
---

# Ref Returns and Ref Locals

A reference return value allows a method to return a reference to a variable, rather than a value, back to a caller. The caller can then choose to treat the returned variable as if it were returned by value or by reference. The caller can create a new variable that is itself a reference to the returned value, called a ref local.

## Reference Return

A reference return value means that a method returns a reference to some variable. That variable's scope must include the method. 

 - The lifetime of that variable must extend beyond the return of the method. 
 - Any modifications to the return value by the caller are made to the variable that is returned by the method.
 - When a method is declared that returns a reference, it indicates that the method returns an alias to a variable. 
 - The calling code should have access to that variable through the alias, including modifying it. 
 - It follows that methods returning by reference can't have the return type void.

To declare a method returning reference we need to use the `ref` keyword in the method signature. The `ref` is also needed in the return statement.

```csharp
public class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}

private static ref Customer GetLastCustomer(Customer[] customers)
{
    return ref customers[customers.Length -1];
}
```

Let's try to call `GetLastCustomer` and it will return a reference.

```csharp
Customer[] customers = new Customer[]
{
    new Customer () { Name =  "Mark", Age = 24, Address = "22 Ashdown close"},
    new Customer () { Name =  "John", Age = 31, Address = "9 Ashdown close"},
    new Customer () { Name = "Stella", Age = 29, Address = "32 burak town" }
};

ref Customer customerReference = ref GetLastCustomer(customers);

PrintCustomerInfo(customerReference);               // Name: Stella, Age: 29, Address: 32 burak town

customerReference.Name = "Jenifer";

PrintCustomerInfo(customers[customers.Length -1]);  // Name: Jenifer, Age: 29, Address: 32 burak town
```

The Ref local in C# is a new variable type that is used to store the references. It is mostly used in conjunction with Ref returns to store the reference in a local variable. That means local variables now can also be declared with the ref modifier as you can see in the above example.

```csharp
ref Customer customerReference = ref GetLastCustomer(customers);
```