using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class Interfaces
    {
        public interface IShape
        {
            double X { get; set; }
            double Y { get; set; }
            void Draw();
            double CalculateArea();
        }

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

        public static void Example1()
        {
            IShape rectangle = new Rectangle(5, 7);
            rectangle.Draw();
            Console.WriteLine("The area of the rectangle is " + rectangle.CalculateArea());
        }
    }
}
