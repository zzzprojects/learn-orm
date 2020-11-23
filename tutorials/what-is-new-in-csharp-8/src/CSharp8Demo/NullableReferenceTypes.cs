using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    public class NullableReferenceTypes
    {

        public static void Example1()
        {
#nullable enable
            //string Name = "Mark";
            //string? Autobiography = null;    
            //string Address = null;          // Warning CS8600  Converting null literal or possible null value to non - nullable type.

            //Console.WriteLine(Name + Autobiography + Address);
        }

        public static void Example2()
        {
            string? path1 = null;
            string? path2 = "new folder";
            ToNiceString(path1);
            ToNiceString(path2);
        }

        private static string? ToNiceString(string? value)
        {
            return value.Replace(" ", "-"); // warning CS8602: Dereference of a possibly null reference
        }
    }
}
