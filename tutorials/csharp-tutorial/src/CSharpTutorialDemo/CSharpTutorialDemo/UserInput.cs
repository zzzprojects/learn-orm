using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class UserInput
    {
        public static void ReadLineExample()
        {
            Console.WriteLine("Enter some text...");
            var str = Console.ReadLine();
            Console.WriteLine("You entered '{0}'", str);
        }

        public static void ReadExample()
        {
            Console.WriteLine("Enter some text...");
            var str = Console.Read();
            Console.WriteLine("Ascii Value = {0}", str);
        }

        public static void ReadKeyExample()
        {
            Console.WriteLine("Press any key to continue...");
            var key = Console.ReadKey();
            Console.WriteLine("\nYou pressed {0} key.", key.Key);
        }

        public static void ReadNumericValuesExample()
        {
            Console.WriteLine("Enter an integer...");
            string userInputInt = Console.ReadLine();

            // Converts to integer type
            int intVal = Convert.ToInt32(userInputInt);
            Console.WriteLine("You entered {0}", intVal);

            Console.WriteLine("Enter a real/double value...");
            string userInputDouble = Console.ReadLine();

            // Converts to double type
            double doubleVal = Convert.ToDouble(userInputDouble);
            Console.WriteLine("You entered {0}", doubleVal);
        }
    }
}
