---
PermaID: 100010
Name: Module Statement
---

# Module Statement

The `Module` statement declares the name of a module and introduces the definition of the variables, properties, events, and procedures that the module comprises.

 - It defines a reference type available throughout its namespace.  
 - Every module has exactly one instance and does not need to be created or assigned to a variable. 
 - Modules do not support inheritance or implement interfaces. 
 - A module is not a type as a class or structure and you cannot declare a programming element to have the data type of a module.
 - You can use `Module` only at the namespace level and must be declared in a source file or namespace, and it cannot be declared in a class, structure, module, interface, procedure, or block. 
 - You cannot nest a module within another module, or any type. 

## Different Between Class and Module

A module is similar to a class but there are some important differences as well.

 - Previous versions of Visual Basic recognize two types of modules: **class modules (.cls files)** and **standard modules (.bas files)**. 
 - The current version calls these classes and modules, respectively.
 - You can control whether a member of a class is a shared or instance member.
 - Classes are object-oriented, but modules are not, so only classes can be instantiated as objects.

Modules are VB.NET counterparts to C# `static` classes. When your class is designed solely for helper functions and extension methods and you don't want to allow **inheritance** and **instantiation**, you use a `Module`.

Let's consider the following example in which we have defined a `Module`.

```csharp
Public Module Constants
    Public Sub Example1()
        Const DaysInYear = 365
        Const WorkDays = 250

        Console.WriteLine(DaysInYear)
        Console.WriteLine(WorkDays)
    End Sub

    Public Sub Example2()
        Const MyInteger As Integer = 42
        Const DaysInWeek As Short = 7
        Const Sunday As String = "Sunday"

        Console.WriteLine(MyInteger)
        Console.WriteLine(DaysInWeek)
        Console.WriteLine(Sunday)
    End Sub

    Public Sub Example3()
        Const num1 As Integer = 4, num2 As Integer = 5, str1 As String = "Test String"

        Console.WriteLine(num1)
        Console.WriteLine(num2)
        Console.WriteLine(str1)
    End Sub
End Module
```

To call the procedure defined in a `Module`, use the module name as shown below.

```csharp
Module Program
    Sub Main()

        Constants.Example1()
        Constants.Example2()
        Constants.Example3()

    End Sub
End Module
```
