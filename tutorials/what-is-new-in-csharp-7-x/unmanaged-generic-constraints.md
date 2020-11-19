---
PermaID: 100014
Name: Unmanaged Generic Constraints
---

# Unmanaged Generic Constraints

Constraints specify the capabilities and expectations of a type parameter. Declaring those constraints means you can use the operations and method calls of the constraining type. Without any constraints, the type of argument could be any type. 

 - The compiler can only assume the members of `System.Object`, which is the ultimate base class for any .NET type. 
 - If the client code uses a type that doesn't satisfy a constraint, the compiler issues an error. 
 - Constraints are specified by using the `where` contextual keyword. 

You can use the generic type constraints on class declarations, method declarations, and local functions. Before C# 7.3, the following types of constraints were supported.

 - Reference type constraint (`class`) 
 - Value type constraint (`struct`)
 - Interfaces or base class constraints, and whether a parameterless constructor should be present (`new()`). 

In C# 7.3, the unmanaged constraint feature is introduced which will give language enforcement to unmanaged types. Unmanaged types are one of the core building blocks for interop code, the lack of support in generics makes it impossible to create re-usable routines across all unmanaged types.  

### Unmanaged Type Constraints

To enable this type of scenario, a new constraint `unmanaged` is added that can only be met by types that fit into the unmanaged type definition. The `unmanaged` constraint enables you to write reusable routines to work with types that can be manipulated as blocks of memory as shown below.

```csharp
unsafe public static byte[] ToByteArray<T>(this T argument) where T : unmanaged
{
    var size = sizeof(T);
    var result = new Byte[size];
    Byte* p = (byte*)&argument;
    for (var i = 0; i < size; i++)
        result[i] = *p++;
    return result;
}
```

The above code converts the type to an array of bytes for transmission on a wire.

```csharp
// Unmanaged type
struct Point
{
    public int X;
    public int Y { get; set; }
}

// Not an unmanaged type
struct Customer
{
    public string FirstName;
    public string LastName;
}
public static void Example()
{
    Point point = new Point();
    point.X = 10;
    point.Y = 20;

    var pointBytes = point.ToByteArray<Point>();

    int val = 10;
    var intBytes = val.ToByteArray<int>();

    Customer customer = new Customer()
    {
        FirstName = "Mark",
        LastName = "Upston"
    };

    //var customerBytes = customer.ToByteArray<Customer>();             //Error
}
```

As you can see that you can call the `ToByteArray()` with an unmanaged type such as `Point` which is an unmanaged `struct` and `int`, but when you try to call it with a type that is not unmanaged such as, the `Customer` you will get the compile-time error.

