---
PermaID: 100011
Name: Non-trailing Named Arguments
---

# Non-trailing Named Arguments

## What is Named Arguments?

An argument with an argument-name is referred to as a named argument, whereas an argument without an argument name is a positional argument. The named arguments free you from matching the order of parameters in the parameter lists of called methods. 

 - The parameter for each argument can be specified by parameter name. 
 - Before C# 7.2, when you call a method with named arguments or optional parameters, all the named arguments must be specified at the end of the method signature after all the required arguments.
 - It was not allowed to appear a positional argument after a named argument in an argument list.

Let's consider the following example in which the `PrintEmployeeInfo()` method is called using named and optional arguments.

```csharp
private static void PrintEmployeeInfo(string name, int age, string address, bool isActive = default, bool isManager = default)
{
    Console.WriteLine("Name: {0}, Age: {1}, Address: {2}, Is Active: {3}, Is Manager: {4}", name, age, address, isActive, isManager);
}

public static void Example()
{
    PrintEmployeeInfo("Mark", 24, "22 Ashdown close");
    PrintEmployeeInfo("John", 31, "9 Ashdown close", true, false);
    PrintEmployeeInfo(name:"Stella", age:29, address:"32 burak town", isActive:true, isManager:true);
    PrintEmployeeInfo(age:27, address:"81 wall street", name: "Andy", isManager: true, isActive: true);
}
```

Before C# 7.2, it was not allowed to specify the named arguments before positional arguments.

```csharp
PrintEmployeeInfo(name:"Stella", age:29, address:"32 burak town", true, true);
```

Now in C# 7.2, it is allowed to have named arguments after positional ones.