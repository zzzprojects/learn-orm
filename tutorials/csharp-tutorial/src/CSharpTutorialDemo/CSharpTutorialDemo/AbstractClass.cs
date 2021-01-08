using System;

namespace CSharpTutorialDemo
{
    public class AbstractClass
    {
        public abstract class Shape
        {
            public abstract double CalculateArea();
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

        public static void AbstractMethodExample()
        {
            Shape circle = new Circle(2.5);
            Shape rectangle = new Rectangle(4.75, 6.25);

            Console.WriteLine("The area of the circle is " + circle.CalculateArea());
            Console.WriteLine("The area of the rectangle is " + rectangle.CalculateArea());
        }
    }
}
