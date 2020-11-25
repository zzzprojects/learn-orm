---
PermaID: 100012
Name: Private Protected
---

# Private Protected

The `private protected` keyword combination is a member access modifier. A `private protected` member is accessible by types derived from the containing class, but only within its containing assembly.

 - It is introduced to overcome the limitation of `protected internal`. 
 - The `protected internal` allows access by derived classes or classes that are in the same assembly, `private protected` limits access to derived types declared in the same assembly.
 - In a `private protected` access modifier, the derived class from the different assembly cannot access the members which are `private protected`.


Let's consider the following example that contains a `private protected` property in the base class.

```csharp
class A
{
    private protected int privateProtectedIntVal { get; set; }
    public int publicIntVal { get; set; }
}

class B : A
{
    public static void AccessValue()
    {
        A a = new A();
        //a.privateProtectedIntVal = 5;          //Error
        a.publicIntVal = 10;

        B b = new B();
        b.publicIntVal = 15;
        b.privateProtectedIntVal = 20;
    }
}
```

As you can see, we can access the base class `A` private protected member using the reference of derived class `B`.

But if you uncomment the commented line, you will get the following compile-time error.

```csharp
Error CS1540 Cannot access protected member 'A.privateProtectedIntVal' via a qualifier of type 'A'; the qualifier must be of type 'B' (or derived from it)
```

Because we are trying to access private protected members with base class `A` reference instead of the derived class.

 

When you execute the above c# program, you will get the result as shown below.
