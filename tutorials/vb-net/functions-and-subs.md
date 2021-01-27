---
PermaID: 100008
Name: Functions and Subs
---

# Functions and Subs

## Function Procedure

In VB.NET, a function is a separate group of codes used to perform a specific task when the defined function is called in a program. 

 - When the Function procedure returns to the calling code, execution continues with the statement that follows the statement that called the procedure. 
 - You can create more than one function in a program to perform various functionalities. 
 - The function is also useful to code reusability by reducing the duplicity of the code. 
 - For example, if you need to use the same functionality at multiple places in a program, you can simply create a function and call it whenever required.

### Defining a Function

You can define a `Function` procedure only at the module level. Therefore, the declaration context for a function must be a class, a structure, a module, or an interface and can't be a source file, a namespace, a procedure, or a block.

 - By default, the `Function` procedure is public, but you can adjust their access modifiers' access levels.
 - A `Function` procedure can declare the data type of the value that the procedure returns.

The following code defines a function called `Add`, which takes two parameters and returns the sum.

```csharp
Public Module Functions
    Function Add(num1 As Integer, num2 As Integer) As Integer
        Return num1 + num2
    End Function
End Class
```

### Returning from a Function

To return a value from a function, you can either include it in a Return statement or assign the value to the function name.

The following example shows two different functions, one function returns a value using the return statement while the other function assigns the value to the function name and then uses the Exit Function statement to return.

```csharp
Public Module Functions
    Function Add(num1 As Integer, num2 As Integer) As Integer
        Return num1 + num2
    End Function

    Function Subtract(num1 As Integer, num2 As Integer) As Integer
        Subtract = num1 - num2
        Exit Function
    End Function
End Module

```

The Return statement simultaneously assigns the return value and exits the function.

 - The `Exit Function` and `Return` statements cause an immediate exit from a Function procedure. 
 - Any number of `Exit Function` and `Return` statements can appear anywhere in the procedure, and you can mix Exit Function and Return statements.
 - If you use `Exit Function` without assigning a value to name, the procedure returns the default value for the data type that is specified in the return type. 
 - If the return type is not specified, the procedure returns Nothing, which is the default value for `Object`.

## Sub Procedure

A `Sub` procedure is a group of codes enclosed by the `Sub` and `End Sub` statements. The `Sub` procedure performs a task and then returns control to the calling code, but it does not return a value to the calling code.

 - Each time the procedure is called, its statements are executed, starting with the first executable statement after the `Sub` statement and ending with the first `End Sub`, `Exit Sub`, or `Return` statement encountered.
 - You can define a Sub procedure in modules, classes, and structures. 
 - By default, it is `Public`, and you can call it from anywhere in your application that has access to the module, class, or structure in which you defined it.
 - It can take arguments, such as constants, variables, or expressions, which are passed to it by the calling code.

The following example uses the `Sub` statement to define the name, parameters, and code that form the body of a `Sub` procedure.

```csharp
Public Module Subs
    Sub CalculateArea(length As Double, width As Double)
        Dim area As Double
        If length = 0 Or width = 0 Then
            ' If either argument = 0 then exit Sub immediately.
            Exit Sub
        End If

        area = length * width
        ' Print area to Immediate window.
        Console.WriteLine(area)
    End Sub
End Module
```

## Calling a Function or Sub

You can call a `Function` or `Sub` procedure by using the procedure name, followed by the argument list in parentheses, in an expression. 

 - You can omit the parentheses only if you aren't supplying any arguments. 
 - However, your code is more readable if you always include the parentheses.

The following code calls the above-defined functions and sub from the `Main` method.

```csharp
Imports System

Module Program
    Sub Main()

        Dim val1 = Functions.Add(3, 4)
        Dim val2 = Functions.Subtract(3, 4)
        Subs.CalculateArea(8, 5)

    End Sub
End Module

```
When a `Sub` procedure returns to the calling code, execution continues with the statement after the statement that called it.

You can also call a function by using the `Call` keyword. In that case, the return value is ignored. Use of the `Call` keyword isn't recommended in most cases.
