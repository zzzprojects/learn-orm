using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    public class StaticLocalFunctions
    {
        public static void AddExampleWithLocalFunction()
        {
            int num1 = 4;
            int num2 = 10;

            Console.WriteLine(Add());

            int Add()
            {
                return num1 + num2;
            }
        }
        public static void AddExampleWithStaticLocalFunction()
        {
            Console.WriteLine(Add(4, 5));
            Console.WriteLine(Add(13, 39));
            Console.WriteLine(Add(71, 103));

            static int Add(int num1, int num2)
            {
                return num1 + num2;
            }
        }

        public static void StaticLocalFunction()
        {
            //int num = 40;

            //Console.WriteLine(GetNumSquare());

            //static int GetNumSquare()
            //{
            //    return num * num;
            //}
        }
    }
}
