using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class StackallocArrayInitializers
    {
        public static void Example1()
        {
            Span<int> evenNumbers = stackalloc int[10];

            for (int i = 0; i < 10; i++)
            {
                evenNumbers[i] = i*2;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(evenNumbers[i]);
            }
        }

        public static void Example2()
        {
            int length = 250;
            Span<byte> bytes = length <= 256 ? stackalloc byte[length] : new byte[length];
        }

        public unsafe static void Example3()
        {
            int* oddNumbers = stackalloc int[5] { 1, 3, 5, 7, 9 };

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(oddNumbers[i]);
            }
        }
    }
}
