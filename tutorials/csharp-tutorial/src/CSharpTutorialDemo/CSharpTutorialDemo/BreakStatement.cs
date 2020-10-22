using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class BreakStatement
    {
        public static void Example1()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Counter: {0}", i);

                if (i == 5)
                    break;
            }
        }

        public static void Example2()
        {
            int caseSwitch = 1;

            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
}
