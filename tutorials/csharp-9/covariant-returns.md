---
PermaID: 100010
Name: Covariant Returns
---

# Covariant Returns

It is a common pattern in code that different method names have to be invented to work around the language constraint that overrides must return the same type as the overridden method.

 - When we inherit from a class, it is possible to override a method if it is declared abstract or virtual but it is not possible to change the return type of this method. 
 - In C# 9, you can now return a covariant type of the initial type declared in the parent class. 
 - You can override a base class method that has a less-specific type with one that returns a more specific type.
 - For example, you can now return a type that is inherited from the parent class.

Let's consider the following simple program.

```csharp
interface I1 
{ 
    object M(); 
}

class C1 : I1 
{ 
    public object M() 
    { 
        return "C1.M"; 
    } 
}
class C2 : C1, I1 
{ 
    public new string M() 
    { 
        return "C2.M"; 
    } 
}

public class Program
{
    public static void Main(string[] args)
    {
        I1 i = new C2();
        Console.WriteLine(i.M());
    }
}
```
The above example will print **"C1.M"** in the current version of C#, but in C# 9.0, it will print **"C2.M"** under the proposed revision. Due to this breaking change, the .NET team might consider not supporting covariant return types on implicit implementations.

Let's consider another example, before C# 9.0, you can't specify the child class as a return type from the override method if the base method return type is base class as shown below.

```csharp
abstract class Animal
{
    public abstract Food GetFood();
}
class Tiger : Animal
{
    public override Food GetFood()
    {
        return new Meat();
    }
}

class Cat : Animal
{
    public override Food GetFood()
    {
        return new Milk();
    }
}

public class Food
{
}

public class Meat : Food
{
    public Meat()
    {
        Console.WriteLine("I eat meat...");
    }
}

public class Milk : Food
{
    public Milk()
    {
        Console.WriteLine("I drink milk...");
    }
}
```

In the above example, you can see that we have specified the `Food` as a return type in all classes. You will need to cast the initial return type to its derived type as shown below.

```csharp
Tiger tiger = new Tiger();
Cat cat = new Cat();

Meat meat = (Meat)tiger.GetFood();
Milk milk = (Milk)cat.GetFood();
```

Now in C# 9.0, you can explicitly return a covariant by specifying the specific type instead of the base type.

```csharp
abstract class Animal
{
    public abstract Food GetFood();
}
class Tiger : Animal
{
    public override Meat GetFood()
    {
        return new Meat();
    }
}

class Cat : Animal
{
    public override Milk GetFood()
    {
        return new Milk();
    }
}

public class Food
{ 
}

public class Meat : Food
{
    public Meat()
    {
        Console.WriteLine("I eat meat...");
    }
}

public class Milk : Food
{
    public Milk()
    {
        Console.WriteLine("I drink milk...");
    }
}
```

In the above code, you can see the `GetFood` method return type is `Food` while in `Tiger`, `Cat` classes the return type is `Meat` and `Milk` respectively.

Now you don't need to cast it to the specific type.

```csharp
Tiger tiger = new Tiger();
Cat cat = new Cat();

Meat meat = tiger.GetFood();
Milk milk = cat.GetFood();
```

