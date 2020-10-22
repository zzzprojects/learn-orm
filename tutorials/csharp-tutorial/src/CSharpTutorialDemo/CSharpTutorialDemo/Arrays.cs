using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class Arrays
    {
        public static void CreateAndThenInitialize()
        {
            int[] myArray = new int[6];

            myArray[0] = 1;
            myArray[1] = 2;
            myArray[2] = 3;
            myArray[3] = 4;
            myArray[4] = 5;
            myArray[5] = 6;

            for (int i = 0; i < 6; i++)
                Console.WriteLine(myArray[i]);
        }

        public static void InitializeWithDefaultValues()
        {
            int[] myArray = { 1, 2, 3, 4, 5, 6 };
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            for (int i = 0; i < 6; i++)
                Console.WriteLine(myArray[i]);

            for (int i = 0; i < 7; i++)
                Console.WriteLine(daysOfWeek[i]);
        }

        public static void AccessArray()
        {
            int[] myArray = { 1, 2, 3, 4, 5, 6 };
            
            for (int i = 0; i < 6; i++)
                Console.WriteLine(myArray[i]);

            int index = 3;

            myArray[index] = 100;

            for (int i = 0; i < 6; i++)
                Console.WriteLine(myArray[i]);
        }
    }
}
