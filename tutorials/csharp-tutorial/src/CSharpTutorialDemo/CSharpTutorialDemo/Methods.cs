using System;

namespace CSharpTutorialDemo
{
    public class Methods
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static void Caller()
        {
            int numA = 4;
            int numB = 32;

            int result1 = Add(numA, numB);
            int result2 = Subtract(numA, numB);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }
    }
}
