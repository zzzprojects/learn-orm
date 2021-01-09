using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class ReadonlyReferences
    {
        public static void Example1()
        {
            int value = 11;
            Console.WriteLine(value);
            Print(value);
            value++;
            Console.WriteLine(value);

        }

        private static void Print(in int val)
        {
            int y = val;
            Console.WriteLine(y);          

            y = y + 10;
            Console.WriteLine(y);

            //val = val + 10;              //Error
            Console.WriteLine(val);        
        }
    }
}
