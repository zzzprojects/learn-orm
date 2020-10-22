using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class ContinueStatement
    {
        public static void Example1()
        {
            for (int i = 0; i <= 10; i++)
            {
                if (i > 3 && i < 8)
                    continue;

                Console.WriteLine("Counter: {0}", i);
            }
        }
    }
}
