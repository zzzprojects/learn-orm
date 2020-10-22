using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class Strings
    {
        public static void Example1()
        {
            string sqlServerPath = "C:\\Program Files (x86)\\Microsoft SQL Server";
            string vsPath = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community";
            var str4 = "It is sample message of a strongly-typed System.String!";

            Console.WriteLine(sqlServerPath);
            Console.WriteLine(vsPath);
            Console.WriteLine(str4);
        }

        public static void ConstStringExample()
        {
            const string str5 = "You can't change me now";
            Console.WriteLine(str5);

            //Uncoment the below line and you will see error.
            //str5 = "try to change the value";
        }

        public static void StringConstructorExample()
        {
            char[] letters = { 'A', 'B', 'C' };
            string alphabet = new string(letters);

            Console.WriteLine(alphabet);
        }

        public static void StringConcatinatationExample()
        {
            string firstName = "John ";
            string lastName = "Doe";
            string name = firstName + lastName;

            Console.WriteLine(firstName);
            Console.WriteLine(lastName);
            Console.WriteLine(name);
        }

        public static void SpecialCharacterExample()
        {
            string text = "This is a \"string\" in C#.";
            Console.WriteLine(text);
        }
    }
}
