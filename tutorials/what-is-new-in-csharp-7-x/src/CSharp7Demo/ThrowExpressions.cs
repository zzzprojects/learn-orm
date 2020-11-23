using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class ThrowExpressions
    {
        private static void DisplayFirstNumber(string[] numbers)
        {
            //string arg = "";
            //if (numbers.Length >= 1)
            //    arg = numbers[0];
            //else
            //    throw new ArgumentException("You must supply an argument");

            string arg = numbers.Length >= 1 ? numbers[0] : throw new ArgumentException("You must supply an argument");

            if (int.TryParse(arg, out var number))
                Console.WriteLine("You entered {0}", number);
            else
                Console.WriteLine("{0} is not a number.", arg);
        }

        public static void Example1()
        {
            DisplayFirstNumber(new string[] { "3", "6", "12" });    // You entered 3
            DisplayFirstNumber(new string[] { "a", "6", "12" });    // a is not a number.
            DisplayFirstNumber(new string[] { });                   // System.ArgumentException: 'You must supply an argument'
        }

        class Customer
        {
            private string name;
            public string Name
            {
                get => name;
                set => name = value ?? throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
            }

        }

        public static void Example2()
        {
            Customer customer = new Customer();
            customer.Name = null;
        }
    }
}
