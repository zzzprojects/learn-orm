

# Abstract Class

The term abstraction is used to hide certain details and showing only essential information to the user. The `abstract` modifier indicates that the class or member has a missing or incomplete implementation. 

 - The `abstract` modifier can be used with classes, methods, properties, indexers, and events. 
 - When `abstract` modifier is used in a class declaration then it is intended only to be a base class of other classes, and it can not instantiated on its own. 
 - Members marked as abstract must be implemented by non-abstract classes that derive from the abstract class.
 - You can use the `abstract` modifier in a method or property declaration to indicate that the method or property does not contain implementation.

Let's have a look into the following simple example.

```csharp
public abstract class Shape
{
    public abstract double CalculateArea();
}
```

We have declared the `Shape` class as an abtract. It contains a single method `CalculateArea()` which is also an abtract. So it means that we now need to inherit the `Shape` class and provide the implementation for the `CalculateArea()` method.

```csharp
public class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(double radius)
    {
        Radius = radius;
    }
    public override double CalculateArea()
    {
        return (3.14) * Math.Pow(Radius, 2);
    }
}

public class Rectangle : Shape
{
    public double Height { get; set; }
    public double Width { get; set; }
    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }
    public override double CalculateArea()
    {
        return Height * Width;
    }
}
```

As you can see that we have provided implementation for `CalculateArea()` abstract method in both child classes `Circle` and `Rectangle` with their own implementation by calculating the area of circle and rectangle respectively.

Now we can create `Circle` and  `Rectangle` objects and assign them to `Shape` instances, but we can not create an object of `Shape` class, because it is an abstract class.

```csharp
Shape circle = new Circle(2.5);
Shape rectangle = new Rectangle(4.75, 6.25);

Console.WriteLine("The area of the circle is " + circle.CalculateArea());
Console.WriteLine("The area of the rectangle is " + rectangle.CalculateArea());
```

You can see that both objects can call the `CalculateArea()` but the right version of the `CalculateArea()` method is not being determined at compile time but determined at runtime. 

Let's run the above code and you will see the following output.

```csharp
The area of the circle is 19.625
The area of the rectangle is 29.6875
```

All the examples related to the abstract class are available in the `AbstractClass.cs` file of the source code. Download the source code and try out all the examples for better understandings.
