---
PermaID: 100005
Name: Data Types
---

# Data Types

The primitive data types are predefined by the language and they are named by reserved keywords. They represent the basic types of language.

The **Dynamic Expresso** manages the following list of C# primary types.

 - Object/object 
 - Boolean/bool 
 - Char/char
 - String/string
 - SByte/Byte/byte
 - Int16/UInt16/Int32/int/UInt32/Int64/long/UInt64 
 - Single/Double/double/Decimal/decimal 
 - DateTime/TimeSpan
 - Guid
 - Math/Convert

You can add additional types by using the `Interpreter.Reference` method as shown below.

```csharp
public static void Example1()
{
    Interpreter interpreter = new Interpreter();
    interpreter.Reference(typeof(Customer));

    interpreter.SetVariable("customer", new Customer()
    {
        FirstName = "Mark",
        LastName = "Upston",
        BirthDate = new DateTime(1977, 12, 10)
    });

    string expression = "customer.FirstName + ' ' + customer.LastName";

    var result = interpreter.Eval(expression);
    Console.WriteLine(result);
}

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}
```

Now when you run the above code you will see the following output.

```csharp
Mark Upston
```
