using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class Delegates
    {
        private delegate void MyDelegate(string message);
        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void Welcome(string message)
        {
            Console.WriteLine("Welcome: " + message);
        }

        private static void GoodBye(string message)
        {
            Console.WriteLine("Bye-bye: " + message);
        }

        private delegate int MyMathDelegate(int number1, int number2);
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
            MyDelegate delegate1 = new MyDelegate(PrintMessage);
            MyDelegate delegate2 = PrintMessage;

            delegate1("This is a C# Tutorial.");
            delegate1("You are learning Delegates.");
        }
        public static void Example2()
        {
            MyMathDelegate mathDelegate = new MyMathDelegate(MathUtility.Add);
            int num1 = 10;
            int num2 = 20;

            Console.WriteLine("Add({0}, {1}) = {2}", num1, num2, mathDelegate(num1, num2));

            // Assign the Subract method reference to the delegate object.
            mathDelegate = MathUtility.Subtract;
            Console.WriteLine("Subtract({0}, {1}) = {2}", num1, num2, mathDelegate(num1, num2));

            // Assign the Multiply method reference to the delegate object.
            mathDelegate = MathUtility.Multiply;
            Console.WriteLine("Multiply({0}, {1}) = {2}", num1, num2, mathDelegate(num1, num2));
        }

        public static void CombineDelegatesExample()
        {
            MyDelegate welcomeDel = Welcome;
            MyDelegate goodByeDel = GoodBye;

            MyDelegate welcomeGoodByeDel = welcomeDel + goodByeDel;

            Console.WriteLine("Call welcomeDel.");
            welcomeDel("Mark");

            Console.WriteLine("\nCall goodByeDel.");
            goodByeDel("John");

            Console.WriteLine("\nCall welcomeGoodByeDel.");
            welcomeGoodByeDel("Stella");
        }
    }
}
