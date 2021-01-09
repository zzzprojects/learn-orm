using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public static class Extensions
    {
        unsafe public static byte[] ToByteArray<T>(this T argument) where T : unmanaged
        {
            var size = sizeof(T);
            var result = new Byte[size];
            Byte* p = (byte*)&argument;
            for (var i = 0; i < size; i++)
                result[i] = *p++;
            return result;
        }
    }
    public class UnmanagedGenericConstraints
    {
        // Unmanaged type
        struct Point
        {
            public int X;
            public int Y { get; set; }
        }

        // Not an unmanaged type
        struct Customer
        {
            public string FirstName;
            public string LastName;
        }
        public static void Example()
        {
            Point point = new Point();
            point.X = 10;
            point.Y = 20;

            var pointBytes = point.ToByteArray<Point>();

            int val = 10;
            var intBytes = val.ToByteArray<int>();

            Customer customer = new Customer()
            {
                FirstName = "Mark",
                LastName = "Upston"
            };

            //var customerBytes = customer.ToByteArray<Customer>();             //Error
        }
    }
}
