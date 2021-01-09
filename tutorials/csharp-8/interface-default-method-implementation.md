---
PermaID: 100001
Name: Interface Default Method Implementation
---

# Interface Default Method Implementation

Before C# 8, if a class implements an interface and you want to add another method to that interface then you will end up breaking the class that implements the interface because members were abstract, and the class needs to provide an implementation for all the members. 

 - In C# 8, you can extend an interface by providing a default implementation to an existing interface without breaking the classes that implement that interface.
 - If the class does not provide the implementation then it will use the default implementation provided in the interface.
 - This feature makes it optional for implementers to override the method or not.

Let's consider the following interface which contains two methods.

```csharp
private interface ISimpleInterface
{
    public void DefaultImplementationMethod()
    {
        Console.WriteLine("This is a default method implemented in the interface!");
    }

    public void AnotherMethod();
}
```

Now we will implement the above interface in two classes.

```csharp
class A : ISimpleInterface
{
    public void AnotherMethod()
    {
        Console.WriteLine("This is a method implemented in class A.");
    }
}

class B : ISimpleInterface
{
    public void DefaultImplementationMethod()
    {
        Console.WriteLine("This is a default method overridden in class B.");
    }
    public void AnotherMethod()
    {
        Console.WriteLine("This is another method implemented in class B.");
    }
}
```

The class `A` provide implementation only for `AnotherMethod()` while the class `B` provide implementation for both `DefaultImplementationMethod` and `AnotherMethod` methods.

Let's call both methods using a class `A` object.

```csharp
ISimpleInterface obj = new A();
obj.DefaultImplementationMethod();
obj.AnotherMethod();
```

Now you execute the above code you will see the following output.

```csharp
This is a default method implemented in the interface!
This is a method implemented in class A.
```

Let's call both methods using a class `B` object.

```csharp
ISimpleInterface obj = new B();
obj.DefaultImplementationMethod();
obj.AnotherMethod();
```

Now you execute the above code and you will see the following output.

```csharp
This is a default method overridden in class B.
This is another method implemented in class B.
```

If you look at the code for class `A`, you can see that the interface has a default method, and class `A` doesn't know about the default method nor provide the implementation of that interface method. Now if you use the variable of class `A` instead of `ISimpleInterface` as shown below.

```csharp
A obj = new A();
obj.DefaultImplementationMethod();       // error
obj.AnotherMethod();
```

It will produce the compile-time error and it means that the inherited class does not know anything about the default method.
