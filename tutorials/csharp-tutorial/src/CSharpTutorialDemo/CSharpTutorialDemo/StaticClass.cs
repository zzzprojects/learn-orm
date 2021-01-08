using System;

namespace CSharpTutorialDemo
{
    public class StaticClass
    {
        public static class MathUtility
        {
            public static int Add(int number1, int number2)
            {
                return (number1 + number2);
            }

            public static int Subtract(int number1, int number2)
            {
                return (number1 - number2);
            }

            public static int Multiply(int number1, int number2)
            {
                return (number1 * number2);
            }
        }

        public static void Example1()
        {
            int number1 = 5;
            int number2 = 9;

            int result1 = MathUtility.Add(number1, number2);
            int result2 = MathUtility.Subtract(number1, number2);
            int result3 = MathUtility.Multiply(number1, number2);

            Console.WriteLine("{0} + {1} = {2}", number1, number2, result1);
            Console.WriteLine("{0} - {1} = {2}", number1, number2, result2);
            Console.WriteLine("{0} * {1} = {2}", number1, number2, result3);
        }
    }
}
