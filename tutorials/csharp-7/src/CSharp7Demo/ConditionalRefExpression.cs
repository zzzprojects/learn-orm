using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class ConditionalRefExpression
    {
        public static void Example1()
        {
            var array1 = new int[] { 21, 37, 19, 93, 5 };
            var array2 = new int[] { 19, 17, 15, 13, 11, 9, 7, 5, 3, 1 };

            int index = 3;
            ref int refValue = ref index < 5 ? ref array1[index] : ref array2[index];
            refValue = 100000;

            index = 6;
            refValue = ref index < 5 ? ref array1[index] : ref array2[index];
            refValue = 100000;

            Console.WriteLine(string.Join(" ", array1));
            Console.WriteLine(string.Join(" ", array2));
        }

        public static void Example2()
        {
            var array1 = new int[] { 21, 37, 19, 93, 5 };
            var array2 = new int[] { 19, 17, 15, 13, 11, 9, 7, 5, 3, 1 };

            int index = 3;
            ref int refValue = ref index < 5 ? ref array1[index] : ref array2[index];
            refValue = 100000;

            index = 12;
            refValue = ref index < 5 ? ref array1[index] : ref index < 10 ? ref array2[index] : ref array2[index - 10];
            refValue = 100000;

            Console.WriteLine(string.Join(" ", array1));
            Console.WriteLine(string.Join(" ", array2));
        }
    }
}
