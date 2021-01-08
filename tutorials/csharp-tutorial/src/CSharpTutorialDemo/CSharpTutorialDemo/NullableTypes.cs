using System;

namespace CSharpTutorialDemo
{
    public class NullableTypes
    {
        public static void Example1()
        {
            Nullable<int> i = null;
            int? j = 4;

            Console.WriteLine(i.GetValueOrDefault());     // It will print 0
            Console.WriteLine(j.GetValueOrDefault());     // It will print 4
        }

        public static void Example2()
        {
            Nullable<int> i = null;

            if (i.HasValue)
                Console.WriteLine(i.Value); // or Console.WriteLine(i)
            else
                Console.WriteLine("Null");
        }

        public static void Example3()
        {
            int? a = null;
            int? b = 40;

            int c = a ?? -1;
            int d = b ?? -1;

            Console.WriteLine($"c is {c}");  // output: c is -1
            Console.WriteLine($"d is {d}");  // output: d is 40
        }

        public static void Example4()
        {
            int? num = null;
            int n2 = (int)num;
        }
    }
}
