using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    public class TargetTypedConditionalExpressions
    {
        public static void Example1()
        {
            var status = true;
            Print(status ? 1 : 2);
        }

        private static void Print(short number)
        {
            Console.WriteLine("{0}: {1}", number.GetType(), number);
        }
    }
}
