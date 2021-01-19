---
PermaID: 100006
Name: Variables
---

# Variables

In VB.NET, a variable is used to hold the value that can be used further in the programming. 

 - A variable is a simple name used to store the value of a specific data type in computer memory. 
 - Each variable has a particular data type that determines the size, range, and fixed space in computer memory. 
 - Using variables, you can perform various operations and manipulate their values.

## Variable Declaration

The Visual Basic compiler uses the `Dim` statement to determine the variable's data type and other information, such as what code can access the variable. 

In VB.NET, the declaration of a variable involves giving the variable a name and defining the data type to which it belongs. We use the following syntax:

```csharp
Dim VarName as DataType
```

In the above syntax, `VarName` is the variable name while `DataType` is the name to which the variable belongs.

The following example declares a variable to hold an Integer value.

```csharp
Dim numberOfCustomers As Integer
```

In the above example, `numberOfCustomers` is the variable name while `Integer` is the data type to which variable `numberOfCustomers` belongs.

You can specify any data type or the name of an enumeration, structure, class, or interface.

```csharp
Dim finished As Boolean
Dim monitorBox As System.Windows.Forms.Form
```

For a reference type, you use the `New` keyword to create a new instance of the class or structure that is specified by the data type. 

```csharp
Dim bottomLabel As New System.Windows.Forms.Label
```

If you use `New`, you do not use an initializer expression. Instead, you supply arguments, if they are required, to the constructor of the class from which you are creating the variable.

## Variable Initialization

You can assign a value to a variable when it is created. For a value type, you use an initializer to supply an expression to be assigned to the variable. The expression must evaluate to a constant that can be calculated at compile time.

```csharp
Dim quantity As Integer = 10
Dim message As String = "Just started"
```

If an initializer is specified and a data type is not specified in an `As` clause, type inference is used to infer the data type from the initializer. 

```csharp
' Use explicit typing.
Dim num1 As Integer = 3

' Use local type inference.
Dim num2 = 3
```

In the above example, both `num1` and `num2` are strongly typed as integers. In the second declaration, type inference infers the type from the value `3`.

You can use an object initializer to declare instances of named and anonymous types. The following code creates an instance of a Student class and uses an object initializer to initialize properties.

```csharp
Dim author As New Author With {.First = "Michael",
                                  .Last = "Tucker"}
```

## Declaring Multiple Variables

You can declare several variables in one declaration statement, specifying the variable name for each one, and following each array name with parentheses. Multiple variables are separated by commas.

```csharp
Dim num1, num2, numbers() As Integer
```

If you declare more than one variable with one `As` clause, you cannot supply an initializer for that group of variables.

You can specify different data types for different variables by using a separate `As` clause for each variable you declare. Each variable takes the data type specified in the first `As` clause encountered after its variable name part.

```csharp
Dim a, b, c As Single, x, y As Double, i As Integer
```
