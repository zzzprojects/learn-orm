using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class OutVariableDeclaration
    {
        private static void GetAddress(out string address)
        {
            address = "22 ashdown";
        }
            

        public static void Example1()
        {
            string address;
            GetAddress(out address);
            Console.WriteLine(address);
        }

        public static void Example2()
        {
            GetAddress(out string address);
            Console.WriteLine(address);
        }

        private static void GetCoords(out double x, out double y, out double z)
        {
            x = 0.0;
            y = 0.0;
            z = 3.0;
        }

        public static void Example3()
        {
            GetCoords(out double x, out double y, out double z);
            Console.WriteLine("X: {0}, Y: {1}, Z: {2}", x, y, z);
        }

        private static void GetEmployee(out string name, out string title, out int age, out double salary)
        {
            name = "Mark";
            title = "Software Developer";
            age = 21;
            salary = 5000;
        }

        public static void Example4()
        {
            GetEmployee(out string name, out string title, out int age, out _ );
            Console.WriteLine("Name: {0}, Title: {1}, Age: {2}", name, title, age);
        }

        public static void Example5()
        {
            GetEmployee(out var name, out var title, out var age, out _);
            Console.WriteLine("Name: {0}, Title: {1}, Age: {2}", name, title, age);
        }
    }
}
