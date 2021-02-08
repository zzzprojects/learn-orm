---
PermaID: 100042
Name: Inheritance
---

# Inheritance

Inheritance is a fundamental principle of object-oriented programming. It allows a class to inherit the behavior or characteristics from base class to child class.

 - It is a concept in which you define parent classes and child classes.
 - The child classes inherit methods and properties of the parent class, but at the same time, they can also modify the behavior of the methods if required. 
 - The child class can also define methods of its own if required.
 - The `Inherits` statement is used to declare a new class, called a derived class, based on an existing class, known as a base class.

## Rules

Here are some of the inheritance rules, and the modifiers you can use to change the way classes inherit or are inherited:

 - By default, all classes are inheritable unless marked with the `NotInheritable` keyword. 
 - Classes can inherit from other classes in your project or from classes in other assemblies that your project references.
 - Unlike languages that allow multiple inheritances, Visual Basic allows only single inheritance in classes. 
 - Although multiple inheritances are not allowed in classes, classes can implement multiple interfaces to effectively accomplish the same ends.
 - To prevent exposing restricted items in a base class, the access type of a derived class must be equal to or more restrictive than its base class. For example, a `Public` class cannot inherit a `Friend` or a `Private` class, and a `Friend` class cannot inherit a `Private` class.

## Inheritance Modifiers

Visual Basic introduces the following class-level statements and modifiers to support inheritance.

 - **`Inherits` statement:** Specifies the base class.
 - **`NotInheritable` modifier:** Prevents programmers from using the class as a base class.
 - **`MustInherit` modifier:** Specifies that the class is intended for use as a base class only. Instances of `MustInherit` classes cannot be created directly; they can only be created as base class instances of a derived class.

Let's take a look at an example of class inheritance. The following is the base class `Animal` which contains a single `Name` property and a method `PrintName` which will print the name of the animal on the Console window.

```csharp
Class Animal
    Public Property Name As String

    Public Sub New(ByVal name As String)
        name = name
    End Sub

    Public Sub PrintName()
        Console.WriteLine(Name)
    End Sub
End Class
```

Here are the two-child classes `Cat` and `Dog`, both classes have their method called `Meow()` and `Bark()` respectively.

```csharp
Class Cat
    Inherits Animal

    Public Sub New(ByVal name As String)
        MyBase.New(name)
    End Sub

    Public Sub Meow()
        Console.WriteLine("Meow!")
    End Sub
End Class

Class Dog
    Inherits Animal

    Public Sub New(ByVal name As String)
        MyBase.New(name)
    End Sub

    Public Sub Bark()
        Console.WriteLine("Bark!")
    End Sub
End Class
```

In the above example, we used the `MyBase` keyword in the constructor of the `Cat` and `Dog` classes. 

 - It indicates that the base class must be used and allows access to its methods, constructors, and member variables. 
 - Using `MyBase.New`, we can call the constructor of the base class.

The following code shows how to use the child class object and call the parent class method.

```csharp
Dim cat As Cat = New Cat("Stanley")
Dim dog As Dog = New Dog("Jackie")
cat.PrintName()
cat.Meow()
dog.PrintName()
dog.Bark()
```

You can see that both child class objects `cat` and `dog` can access the `PrintName()` method of the parent class as well as their methods `Meow()` and `Bark()` respectively.
