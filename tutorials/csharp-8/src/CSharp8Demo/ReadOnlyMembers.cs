using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    public class ReadOnlyMembers
    {
        public struct Rectangle
        {
            public double Height { get; set; }
            public double Width { get; set; }
            public readonly double Area => (Height * Width);
            public Rectangle(double height, double width)
            {
                Height = height;
                Width = width;
            }
            public readonly override string ToString()
            {
                return $"(Total area for height: {Height}, width: {Width}) is {Area}";
            }                
        }

        public static void Example1()
        {
            var rectangle = new Rectangle(20.0, 30.0);
            Console.WriteLine(rectangle.ToString());
        }
    }
}
