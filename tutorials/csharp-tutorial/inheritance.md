---
PermaID: 100027
Name: Inheritance
---

# Inheritance

Inheritance is a fundamental principle of object-oriented programming. It allows a class to inherit the behavior or characteristics from base class to child class.

 - It is a concept in which you define parent classes and child classes.
 - The child classes inherit methods and properties of the parent class, but at the same time, they can also modify the behavior of the methods if required. 
 - The child class can also define methods of its own if required.

Let's take a look at an example of class inheritance. The following is the base class `Animal` which contains a single `Name` property and a method `PrintName` which will print the name of the animal on the Console window.

```csharp
class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }
    public void PrintName()
    {
        Console.WriteLine(Name);
    }
}
```

Here are the two-child classes `Cat` and `Dog`, both classes have their own method called `Meow()` and `Bark()` respectively.

```csharp
class Cat : Animal
{
    public Cat(string name) : base (name)
    {
    }

    public void Meow()
    {
        Console.WriteLine("Meow!");
    }
}

class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public void Bark()
    {
        Console.WriteLine("Bark!");
    }
}
```

In the above example, we used the `base` keyword in the constructor of the `Cat` and `Dog` classes. 

 - It indicates that the base class must be used and allows access to its methods, constructors, and member variables. 
 - Using `base()`, we can call the constructor of the base class.

The following code shows how to use the child class object and call the parent class method.

```csharp
Cat cat = new Cat("Stanley");
Dog dog = new Dog("Jackie");

cat.PrintName();
cat.Meow();

dog.PrintName();
dog.Bark();
```

You can see that both child classes objects `cat` and `dog` can access the `PrintName()` method of the parent class as well as their own methods `Meow()` and and `Bark()` respectively.

All the examples related to the inheritance are available in the `inheritance.cs` file of the source code. Download the source code and try out all the examples for better understandings.