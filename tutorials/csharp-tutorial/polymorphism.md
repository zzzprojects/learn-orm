---
PermaID: 100028
Name: Polymorphism
---

# Polymorphism

Polymorphism is the next fundamental principle of Object-Oriented Programming (OOP). Polymorphism is a Greek word that means **many-shaped** i.e. one object has many forms or has one name with multiple functionalities. 

 - Polymorphism allows treating objects of a derived class as objects of its base class. 
 - It provides the ability to a class to have multiple implementations with the same name.

In C#, there are two types of polymorphism. 

 - [Compile-time Polymorphism](#compile-time-polymorphism) 
 - [Runtime Polymorphism](#runtime-polymorphism)

## Compile-time Polymorphism

Compile-time polymorphism is achieved using method overloading and operator overloading. The method overloading means defining multiple methods with the same name but with different parameters.

 - Using method overloading you can perform different tasks with the same method name by passing different parameters.
 - You can overload methods in the same class only, it doesn't need a parent-child relationship.

Compile-time polymorphism is also known as static binding or early binding. The following code shows the method overloading of `Add()` methods, where both methods have the same name and different parameters.

```csharp
public class MathUtility
{
    public int Add(int number1, int number2)
    {
        return (number1 + number2);
    }
    public int Add(int number1, int number2, int number3)
    {
        return (number1 + number2 + number3);
    }
}
```

In the above class, we defined two methods with the same name `Add` but with different parameters to achieve method overloading and it is called a compile-time polymorphism in c#.

You can call these methods to achieve a different result.

```csharp
MathUtility utility = new MathUtility();

utility.Add(2, 3);              // 5
utility.Add(2, 3, 4);           // 9
```

### Runtime Polymorphism

Runtime polymorphism is achieved by method overriding which is also known as dynamic binding or late binding. The method overriding means defining methods in parent and child class with the same name and signature but different implementation.

 - In this type of polymorphism, we override a base class method in the derived class by creating a similar function with a different implementation.
 - This can be achieved by using `override` & `virtual` keywords along with the inheritance principle.

Here is the simple example of method overriding, where the `Shape` class contains a virtual method `CalculateArea()` which we will override in child classes.

```csharp
public class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

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

As you can see, we have two child classes `Circle` and  `Rectangle`; both classes override the `CalculateArea()` method with their own implementation by calculating the area of circle and rectangle respectively.

Now we can create `Shape`, `Circle` and `Rectangle` objects and assign them to `Shape` instances.

```csharp
Shape shape = new Shape();
Shape circle = new Circle(3.0);
Shape rectangle = new Rectangle(3.0, 4.0);

Console.WriteLine("The area of the shape is " + shape.CalculateArea());
Console.WriteLine("The area of the circle is " + circle.CalculateArea());
Console.WriteLine("The area of the rectangle is " + rectangle.CalculateArea());
```

You can see that both objects can call the `CalculateArea()` but the right version of the `CalculateArea()` method is not being determined at compile time but determined at runtime. 

Let's run the above code and you will see the following output.

```csharp
The area of the shape is 0
The area of the circle is 28.26
The area of the rectangle is 12
```

All the examples related to the polymorphism are available in the `Polymorphism.cs` file of the source code. Download the source code and try out all the examples for better understandings.
