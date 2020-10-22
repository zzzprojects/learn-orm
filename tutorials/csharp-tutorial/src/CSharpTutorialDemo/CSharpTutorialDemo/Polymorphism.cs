using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class Polymorphism
    {
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

        public static void MethodOverloadingExample()
        {
            MathUtility utility = new MathUtility();

            utility.Add(2, 3);              // 5
            utility.Add(2, 3, 4);           // 9
        }

        public static void MethodOverridingExample()
        {
            Shape shape = new Shape();
            Shape circle = new Circle(3.0);
            Shape rectangle = new Rectangle(3.0, 4.0);

            Console.WriteLine("The area of the shape is " + shape.CalculateArea());
            Console.WriteLine("The area of the circle is " + circle.CalculateArea());
            Console.WriteLine("The area of the rectangle is " + rectangle.CalculateArea());
        }
    }
}
