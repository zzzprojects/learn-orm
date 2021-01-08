using System;

namespace CSharpTutorialDemo
{
    public class ConditionalStatements
    {
        public static void Example1()
        {
            bool condition = true;

            if (condition)
            {
                Console.WriteLine("The variable is set to true.");
            }
            else
            {
                Console.WriteLine("The variable is set to false.");
            }
        }

        public static void Example2()
        {
            int marks = 79;

            if (marks >= 90)
            {
                Console.WriteLine("A+");
            }
            else if (marks >= 80)
            {
                Console.WriteLine("A");
            }
            else if (marks >= 70)
            {
                Console.WriteLine("B");
            }
            else if (marks >= 60)
            {
                Console.WriteLine("C");
            }
            else if (marks >= 50)
            {
                Console.WriteLine("D");
            }
            else
            {
                Console.WriteLine("F");
            }
        }
    }
}
