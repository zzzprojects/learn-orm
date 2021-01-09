using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8Demo
{
    public class NullCoalescingAssignment
    {
        public static void Example1()
        {
            List<int> numList = null;
            numList ??= new List<int>() { 34, 71};

            Console.WriteLine(string.Join(" ", numList));  // output: 34 71

            int? val = null;
            numList.Add(val ??= 120);

            Console.WriteLine(string.Join(" ", numList));  // output: 34 71 120
            Console.WriteLine(val);                        // output: 120
        }

        public static void Example2()
        {
            Display<string>("value", "backup value");       // value
            Display<string>(null, "backup value");          // backup value
        }

        private static void Display<T>(T value, T backup)
        {
            Console.WriteLine(value ?? backup);
        }

        private static double SumNumbers(List<double[]> numList, int index)
        {
            return numList?[index]?.Sum() ?? double.NaN;
        }

        public static void Example3()
        {
            double[] values1 = { 10.0, 20.0 };
            double[] values2 = { 30.0, 40.0 };
            double[] values3 = { 50.0, 60.0 };

            List<double[]> numList = new List<double[]>() { values1, values2, values3 };

            Console.WriteLine(SumNumbers(numList, 1));   // 70
            Console.WriteLine(SumNumbers(null, 0));      // NaN
        }
    }
}
