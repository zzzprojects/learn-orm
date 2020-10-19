---
PermaID: 100030
Name: Interfaces
---

# Interfaces

In the C#, the interface is a definition of a role or you can say a group of abstract actions. It defines what sort of behavior a certain object must exhibit, without specifying how this behavior should be implemented. It can neither be directly instantiated as an object nor can data members be defined. So, an interface is nothing but a collection of method and property declarations.


 - An interface can declare only a group of related functionalities, it is the responsibility of the deriving class to implement that functionality.
 - An interface is defined with the `interface` keyword.
 - An interface can contain declarations of methods, properties, indexers, and events, but it may not declare instance data such as fields, auto-implemented properties, or property-like events.
 - Multiple inheritance is possible with the help of interfaces but not with classes.

The following code shows how to define a simple interface.

```csharp
public interface IShape
{
    double X { get; set; }
    double Y { get; set; }
    void Draw();
    double CalculateArea();
}
```

It is like an abstract class because all the methods which are declared inside the interface are abstract. It cannot have a method body and cannot be instantiated.

Implementing an interface is simply done by inheriting it and defining all the methods and properties declared by the interface as shown below.

```csharp
public class Rectangle : IShape
{
    public double X { get; set; }
    public double Y { get; set; }

    public Rectangle(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double CalculateArea()
    {
        return X * Y;
    }

    public void Draw()
    {
        Console.WriteLine("Draw rectangle of X = {0}, Y = {1}.", X, Y);
    }
}
```

Although a class can inherit from one class only, it can implement any number of interfaces. To implement multiple interfaces, separate them with a comma.

```csharp
public class Rectangle : IShape, IDrawable
```

Now we can create a `Rectangle` object and assign it to a variable of the `IShape` type.

```csharp
IShape rectangle = new Rectangle(5, 7);
rectangle.Draw();
Console.WriteLine("The area of the rectangle is " + rectangle.CalculateArea());
```

Let's run the above code and you will see the following output.

```csharp
Draw rectangle of X = 5, Y = 7.
The area of the rectangle is 35
```

All the examples related to the interfaces are available in the `Interfaces.cs` file of the source code. Download the source code and try out all the examples for better understandings.

