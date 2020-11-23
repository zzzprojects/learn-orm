using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class NonTrailingNamedArguments
    {
        private static void PrintEmployeeInfo(string name, int age, string address, bool isActive = default, bool isManager = default)
        {
            Console.WriteLine("Name: {0}, Age: {1}, Address: {2}, Is Active: {3}, Is Manager: {4}", name, age, address, isActive, isManager);
        }

        public static void Example()
        {
            PrintEmployeeInfo("Mark", 24, "22 Ashdown close");
            PrintEmployeeInfo("John", 31, "9 Ashdown close", true, false);
            PrintEmployeeInfo(name:"Stella", age:29, address:"32 burak town", isActive:true, isManager:true);
            PrintEmployeeInfo(age:27, address:"81 wall street", name: "Andy", isManager: true, isActive: true);
        }

        public static void Example1()
        {
            PrintEmployeeInfo(name: "Stella", age: 29, address: "32 burak town", true, true);
        }

        private static int Add(int num1, int num2, int num3=default, int num4=default)
        {
            return num1 + num2 + num3 + num4;
        }

        public static void Example2()
        {
            Console.WriteLine(Add(10, 20));               // 30
            Console.WriteLine(Add(10, 20, 30));           // 60
            Console.WriteLine(Add(10, 20, num3: 30));      // 60
            Console.WriteLine(Add(10, 20, num4: 30));      // 60
            Console.WriteLine(Add(10, 20, num3: 30, 40));      // 60
        }
    }
}
