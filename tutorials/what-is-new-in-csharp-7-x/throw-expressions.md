---
PermaID: 100003
Name: Throw Expressions
---

# Throw Expressions

In your application, when an unexpected runtime error arises due to a violation of system or application constraint, or a condition that is not expected to occur during normal execution of the program then it will throw an exception and you will need to provide a `catch` block to catch that exception. 

 - In C# 7.0, a new feature **Throw Expressions** is introduced which will allow you to throw exceptions from conditional expressions, null-coalescing expressions, and most importantly, with expression-bodied members. 
 - Before C# 7, the throw was just a statement, but now it can be used within the body of the code because it now works as an expression. 

Starting with C# 7.0, `throw` can be used as an expression as well as a statement. The following example uses a throw expression to throw an ArgumentException if a method is passed an empty string array. 

```csharp
private static void DisplayFirstNumber(string[] numbers)
{
    string arg = numbers.Length >= 1 ? numbers[0] : throw new ArgumentException("You must supply an argument");

    if (int.TryParse(arg, out var number))
        Console.WriteLine("You entered {0}", number);
    else
        Console.WriteLine("{0} is not a number.", arg);
}

public static void Example1()
{
    DisplayFirstNumber(new string[] { "3", "6", "12" });    // You entered 3
    DisplayFirstNumber(new string[] { "a", "6", "12" });    // a is not a number.
    DisplayFirstNumber(new string[] { });                   // System.ArgumentException: 'You must supply an argument'
}
```

Before C# 7.0, this logic would need to appear in an `if/else` statement as shown below.

```csharp
private static void DisplayFirstNumber(string[] numbers)
{
    string arg = "";
    if (numbers.Length >= 1)
        arg = numbers[0];
    else
        throw new ArgumentException("You must supply an argument");

    if (int.TryParse(arg, out var number))
        Console.WriteLine("You entered {0}", number);
    else
        Console.WriteLine("{0} is not a number.", arg);
}
```

You can also use a null-coalescing operator to throw an exception as shown in the below example. 

```csharp
class Customer
{
    private string name;
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
    }
}

public static void Example2()
{
    Customer customer = new Customer();
    customer.Name = null;
}
```

A throw expression throws the value produced by evaluating **_the null_coalescing_expression_**, which must denote a value of the class type `System.Exception`, or of a class type that derives from `System.Exception`.