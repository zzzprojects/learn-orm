using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class ReturnStatement
    {
        private static int Add(int a, int b)
        {
            return a + b;
        }

        private static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static void Example1()
        {
            int numA = 4;
            int numB = 32;

            int result1 = Add(numA, numB);
            int result2 = Subtract(numA, numB);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        public static void Example2()
        {
            var result = ReturnExample(2, 1);
            Console.WriteLine(result);
        }
        private static int ReturnExample(int a, int b)
        {
            try
            {
                Console.WriteLine("Try block.");
                return a + b;
            }
            catch
            {
                Console.WriteLine("Catch");
            }
            finally
            {
                Console.WriteLine("finally block.");
            }

            return 0;
        }
    }
}
