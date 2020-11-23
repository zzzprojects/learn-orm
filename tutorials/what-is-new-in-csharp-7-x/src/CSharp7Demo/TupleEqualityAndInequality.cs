using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class TupleEqualityAndInequality
    {
        public static void Example1()
        {
            (int a, short b) tuple1 = (9, 13);
            (long a, int b) tuple2 = (9, 13);
            (long a, double b) tuple3 = (9, 13.0);
            Console.WriteLine(tuple1 == tuple2);  // output: True
            Console.WriteLine(tuple1 != tuple2);  // output: False
            Console.WriteLine(tuple1 != tuple3);  // output: False
            Console.WriteLine(tuple3 == tuple2);  // output: True
        }

        public static void Example2()
        {
            (int a, short b) tuple1 = (9, 13);
            (long c, int d) tuple2 = (9, 13);
            var tuple3 = (e: 9, f: 13.0);
            Console.WriteLine(tuple1 == tuple2);  // output: True
            Console.WriteLine(tuple1 != tuple2);  // output: False
            Console.WriteLine(tuple1 != tuple3);  // output: False
            Console.WriteLine(tuple3 == tuple2);  // output: True
        }

        public static void Example3()
        {
            int Print(int number)
            {
                Console.WriteLine(number);
                return number;
            }

            Console.WriteLine((Print(10), Print(20)) == (Print(30), Print(40)));
        }
    }
}
