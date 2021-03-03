---
PermaID: 100039
Name: Inheritance
---

# Inheritance

Inheritance is used to model the "is-a" relationship, or subtyping, in object-oriented programming.

 - You specify inheritance relationships by using the `inherit` keyword in a class declaration. 
 - If you do not use the `inherit` keyword by default it inherits object class. 
 - A class can have at most one direct base class. 

The basic syntax for inheritance is shown below.

```csharp
type MyDerived(...) =
    inherit MyBase(...)
```

## Inherited Members

 - If a class inherits from another class, the methods and members of the base class are available to users of the derived class as if they were direct members of the derived class.
 - Any let bindings and constructor parameters are private to a class and, therefore, cannot be accessed from derived classes.
 - The keyword `base` is available in derived classes and refers to the base class instance. It is used like the self-identifier.

The following example shows a simple inheritance.

```csharp
type Person(name:string, age:int) =  
    class  
        member this.DisplayName() = printf"Name: %s\nAge: %d\n" name age  
    end  
  
type Employee(name, age:int, salary:int) =  
    class  
        inherit Person(name, age)  
        member this.DisplaySalary() = printf"Salary = $%d" salary  
    end  
  
let emp = new Employee("Andy", 23, 4500)  
emp.DisplayName()  
emp.DisplaySalary()  
```

## Virtual Member

In F#, virtual members work differently as compared to other .NET languages. To declare a new virtual member, you can use the `abstract` keyword. You do this regardless of whether you provide a default implementation for that method. 

The following syntax shows how to define a virtual method in a base class.

```csharp
abstract member [method-name] : [type]

default [self-identifier].[method-name] [argument-list] = [method-body]
```

You can define a virtual method in a derived class as shown in the below syntax.

```csharp
override [self-identifier].[method-name] [argument-list] = [method-body]
```

If you omit the default implementation in the base class, the base class becomes an abstract class.

The following example shows the declaration of a new virtual method `TopSpeed` in a base class and how to override it in a derived class.

```csharp
type Vehicle() =
    abstract member TopSpeed: unit -> int
    default this.TopSpeed() = 100

type Car() =
    inherit Vehicle()
    override this.TopSpeed() = base.TopSpeed() + 100

// test
let vehicle = new Vehicle()
printfn "vehicle.TopSpeed = %i" <| vehicle.TopSpeed()
let car = new Car()
printfn "rocket.TopSpeed = %i" (car.TopSpeed())
```

To override an abstract method or property in a subclass, use the `override` keyword instead of the `member` keyword.