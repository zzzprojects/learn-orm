---
PermaID: 100012
Name: Access Modifiers
---

# Access Modifiers

In visual basic, access modifiers are the keywords, and those are useful to define an accessibility level for all the types and type members. Access modifiers can control whether they can be accessed in other classes or current assembly or other assemblies based on your requirements.

The keywords that specify access level are called access modifiers. 

| Access Modifier         | Description                                                         |
| :-----------------------| :-------------------------------------------------------------------|
| Public                  | Any code that can see a public element can access it.                |
| Protected               | Code in the class that declares a protected element, or a class derived from it, can access the element. |
| Friend                  | Code in the assembly that declares a friend element can access it.   |
| Protected Friend        | Code in the same class or the same assembly as a protected friend element, or within any class derived from the element's class, can access it. |
| Private                 | Code in the type that declares a private element, including code within contained types, can access the element. |
| Private Protected       | Code in the class that declares a private protected element, or code in a derived class found in the same assembly as the base class. |

## Public

The `Public` keyword in the declaration statement specifies that the element can be accessed from code anywhere in the same project, from other projects that reference the project, and from any assembly built from the project. 

The following code shows a simple Public declaration:

```csharp
Public Class Customer
    Public Property Id As Integer
    Public Property Name As String
    Public Property Address As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal address As String)
        Me.Id = id
        Me.Name = name
        Me.Address = address
    End Sub

    Public Sub Print()
        Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", Me.Id, Me.Name, Me.Address)
    End Sub
End Class
```

 - You can use `Public` only at module, interface, or namespace level. 
 - You can declare a public element at the level of a source file or namespace, or inside an interface, module, class, or structure, but not in a procedure.

## Protected

The `Protected` keyword in the declaration statement specifies that the element can be accessed only from within the same class, or from a class derived from this class. 

The following code shows a simple Protected declaration:

```csharp
Public Class Customer
    Protected Property Id As Integer
    Protected Property Name As String
    Protected Property Address As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal address As String)
        Me.Id = id
        Me.Name = name
        Me.Address = address
    End Sub

    Protected Sub Print()
        Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", Me.Id, Me.Name, Me.Address)
    End Sub
End Class
```

In the above example, you can see that a `Customer`  class is defined with required variables and method using the `Protected` access modifier

 - You can use `Protected` only at class level, and only when you declare a member of a class. 
 - You can declare a protected element in a class, but not at the level of a source file or namespace, or inside an interface, module, structure, or procedure.

## Friend

The `Friend` keyword in the declaration statement specifies that the element can be accessed from within the same assembly, but not from outside the assembly. 

The following code shows a simple `Friend` declaration.

```csharp
Public Class Customer
    Friend Property Id As Integer
    Friend Property Name As String
    Friend Property Address As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal address As String)
        Me.Id = id
        Me.Name = name
        Me.Address = address
    End Sub

    Friend Sub Print()
        Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", Me.Id, Me.Name, Me.Address)
    End Sub
End Class
```

 - You can use `Friend` only at the module, interface, or namespace level. 
 - You can declare a friend element at the level of a source file or namespace, or inside an interface, module, class, or structure, but not in a procedure.

## Protected Friend

The `Protected Friend` keyword combination in the declaration statement specifies that the element can be accessed either from derived classes or from within the same assembly, or both. 

The following code shows a simple `Protected Friend` declaration.

```csharp
Public Class Customer
    Protected Friend Property Id As Integer
    Protected Friend Property Name As String
    Protected Friend Property Address As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal address As String)
        Me.Id = id
        Me.Name = name
        Me.Address = address
    End Sub

    Protected Friend Sub Print()
        Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", Me.Id, Me.Name, Me.Address)
    End Sub
End Class
```

 - You can use `Protected Friend` only at class level, and only when you declare a member of a class. 
 - You can declare a protected friend element in a class, but not at the level of a source file or namespace, or inside an interface, module, structure, or procedure.

## Private

The `Private` keyword in the declaration statement specifies that the element can be accessed only from within the same module, class, or structure. 

The following code shows a simple `Private` declaration.

```csharp
Public Class Customer
    Private Property Id As Integer
    Private Property Name As String
    Private Property Address As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal address As String)
        Me.Id = id
        Me.Name = name
        Me.Address = address
    End Sub

    Public Sub Print()
        Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", Me.Id, Me.Name, Me.Address)
    End Sub
End Class
```

You can use `Private` only at the module level. IT means you can declare a private element inside a module, class, or structure, but not at the level of a source file or namespace, inside an interface, or in a procedure.

 - At the module level, the `Dim` statement without any access level keywords is equivalent to a `Private` declaration. 
 - However, you might want to use the `Private` keyword to make your code easier to read and interpret.

## Private Protected

The `Private Protected` keyword combination in the declaration statement specifies that the element can be accessed only from within the same class, as well as from derived classes found in the same assembly as the containing class. 

The `Private Protected` access modifier is supported starting with Visual Basic 15.5. The following example shows a `Private Protected` declaration.

```csharp
Public Class Customer
    Private Protected Property Id As Integer
    Private Protected Property Name As String
    Private Protected Property Address As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal address As String)
        Me.Id = id
        Me.Name = name
        Me.Address = address
    End Sub

    Public Sub Print()
        Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", Me.Id, Me.Name, Me.Address)
    End Sub
End Class
```

 - You can declare a `Private Protected` element only inside of a class. 
 - You cannot declare it within an interface or structure, nor can you declare it at the level of a source file or namespace, inside an interface or a structure, or in a procedure.
