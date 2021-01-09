using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class DigitSeparators
    {
        public static void Example1()
        {
            long num1 = 1000000000000;
            long num2 = 1000500000;

            Console.WriteLine(num1);
            Console.WriteLine(num2);
        }

        public static void Example2()
        {
            long num1 = 1_000_000_000_000;
            long num2 = 10_00_50_00_00;

            Console.WriteLine(num1);
            Console.WriteLine(num2);
        }

        public static void Example3()
        {
            int bin = 0b1001__1010__0001__0100;
            int hex = 0x1b_a0_44_fe;
            int dec = 33_554_432;
            double real = 1_000.111_1e-3;
            ushort shortVal = 0b1011_1100_1011_0011;

            Console.WriteLine(bin);
            Console.WriteLine(hex);
            Console.WriteLine(dec);
            Console.WriteLine(real);
            Console.WriteLine(shortVal);
        }
    }
}
