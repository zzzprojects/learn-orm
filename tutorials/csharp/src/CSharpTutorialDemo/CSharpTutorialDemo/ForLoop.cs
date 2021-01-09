using System;

namespace CSharpTutorialDemo
{
    public class ForLoop
    {
        public static void Example1()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Counter: {0}", i);
            }
        }

        public static void Example2()
        {
            for (int i = 1, sum = 1; i <= 64; i = i * 2, sum += i)
            {
                Console.WriteLine("i={0}, sum={1}", i, sum);
            }
        }
    }
}
