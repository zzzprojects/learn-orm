using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    public class FunctionPointers
    {
        unsafe class Util
        {
            public static void Log()
            {
                Console.WriteLine("Log method without parameters.");
            }

            public static void Log(int val)
            {
                Console.WriteLine("Log method with 1 int parameter and the value is {0}.", val);
            }

            public static void Use()
            {
                delegate*<void> a1 = &Log;      // Log()
                delegate*<int, void> a2 = &Log; // Log(int i)

                a1();
                a2(4);
            }
        }

        public static void Example1()
        {
            Util.Use();
        }
    }
}
