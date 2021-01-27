---
PermaID: 100007
Name: Constants
---

# Constants

The constants refer to fixed values that the program may not alter during its execution, and these values are also known as literals.

 - Constants store values that, as the name implies, remain constant throughout the execution of an application.
 - Constants can be of any of the basic data types like an integer constant, a floating constant, a character constant, or a string literal. 
 - The constants are treated just like regular variables, except that their values cannot be modified after their definition.

## Constant Declaration

You can use the `Const` statement to declare a constant and set its value. Once a constant is declared, it cannot be modified or assigned a new value.

 - You declare a constant within a procedure or in the declarations section of a module, class, or structure. 
 - Class or structure-level constants are `Private` by default, but may also be declared as `Public`, `Friend`, `Protected`, or `Protected Friend` for the appropriate level of code access.

The following example demonstrates the declaration and use of a constant value.

```csharp
Const DaysInYear = 365
Const WorkDays = 250

Console.WriteLine(DaysInYear)
Console.WriteLine(WorkDays)
```

## Specify Data Type

The following example shows the declaration constants by specifying their data types us `As` keyword.

```csharp
Const MyInteger As Integer = 42
Const DaysInWeek As Short = 7
Const Sunday As String = "Sunday"

Console.WriteLine(MyInteger)
Console.WriteLine(DaysInWeek)
Console.WriteLine(Sunday)
```

## Multiple Constants

You can declare several constants in one declaration statement by specifying the name for each one and separate the declarations with a comma and space as shown below.

```csharp
Const num1 As Integer = 4, num2 As Integer = 5, str1 As String = "Test String"

Console.WriteLine(num1)
Console.WriteLine(num2)
Console.WriteLine(str1)
```

## Scope of User-Defined Constants

A `Const` statement's scope is the same as that of a variable declared in the same location. You can specify the scope in any of the following ways.

 - To create a constant that exists only within a procedure, declare it within that procedure.
 - To create a constant available to all procedures within a class, but not to any code outside that module, declare it in the declarations section of the class.
 - To create a constant that is available to all members of an assembly, but not to outside clients of the assembly, declare it using the Friend keyword in the declarations section of the class.
 - To create a constant available throughout the application, declare it using the Public keyword in the declarations section of the class.

