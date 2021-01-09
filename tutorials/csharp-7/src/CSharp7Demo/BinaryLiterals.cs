using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class BinaryLiterals
    {
        public static void Example()
        {
            var value1 = 0b1001;
            var value2 = 0b01001001;
            var value3 = 0b01001111;

            Console.WriteLine("Value of value1 is: {0}", value1);
            Console.WriteLine("Value of value2 is: {0}", value2);
            Console.WriteLine("Value of value3 is: {0}", value3);

            Console.WriteLine("Char value of value2 is: {0}", Convert.ToChar(value2));
            Console.WriteLine("Char value of value3 is: {0}", Convert.ToChar(value3));
        }
    }
}
