using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class LocalFunction
    { 

        public static void SimpleLoalFunctionExample()
        {
            WriteMessage("Hello!");
            WriteMessage("You are calling");
            WriteMessage("a local function");

            void WriteMessage(string message)
            {
                Console.WriteLine("The message is: {0}", message);
            }
        }
        public static void AddExampleUsingLocalFunction()
        {
            int num1 = 34;
            int num2 = 21;
            Console.WriteLine(AddNumbers());

            int AddNumbers()
            {
                return num1 + num2;
            }
        }
    }
}
