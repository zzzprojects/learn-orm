---
PermaID: 100011
Name: Statements
---

# Statements

In VB.NET, a statement is a complete instruction. It can contain keywords, operators, variables, constants, and expressions. The statements can be categorized into the following categories.

 - [Declaration Statements](#declaration-statements)
 - [Executable Statements](#executable-statements)

## Declaration Statements

You use declaration statements to name and define procedures, variables, properties, arrays, and constants. When you declare a programming element, you can also define its data type, access level, and scope. 

Declaration statements include the following.

| Statement             | Description                                                      |
| :---------------------| :----------------------------------------------------------------|
| Dim                   | Declares and allocates storage space for one or more variables.  |
| Const                 | Declares and defines one or more constants. |
| Enum                  | Declares an enumeration and defines the values of its members. |
| Class                 | Declares the name of a class and introduces the definition of the variables, properties, events, and procedures that the class comprises. |
| Structure             | Declares the name of a structure and introduces the definition of the variables, properties, events, and procedures that the structure comprises. |
| Module                | Declares the name of a module and introduces the definition of the variables, properties, events, and procedures that the module comprises. |
| Interface             | Declares the name of an interface and introduces the definitions of the members that the interface comprises. |
| Function              | Declares the name, parameters, and code that defines a `Function` procedure. |
| Declare               | Declares a reference to a procedure implemented in an external file. |
| Operator              | Declares the operator symbol, operands, and code that define an operator procedure on a class or structure. |
| Event                 | Declares a user-defined event. |
| Delegate              | Used to declare a delegate. A delegate is a reference type that refers to a Shared method of a type or an instance method of an object.  |

The following example contains three declarations.

```csharp
Sub Example1()
    Const maxAge As Integer = 60
    Dim height As Double = 6.5
End Sub
```

 - The first declaration is the `Sub` statement, it declares a procedure named which is `Public`.
 - The second declaration is the `Const` statement, which declares the constant `maxAge`, specifying the Integer data type and a value of `60`.
 - The third declaration is the `Dim` statement, which declares the variable `height`. 

## Executable Statements

An executable statement performs an action. It can call a procedure, branch to another place in the code, loop through several statements, or evaluate an expression. An assignment statement is a special case of an executable statement.

The following example uses an `If...Then...Else` control structure to run different blocks of code based on the value of a variable. 

```csharp
Sub ExecutableStatement()
    Dim a As Integer = 13

    If (a < 20) Then
        Console.WriteLine("a is less than 20")
    Else
        Console.WriteLine("a is greater than 20")
    End If

    Console.WriteLine("value of a is : {0}", a)
    Console.ReadLine()
End Sub
```
