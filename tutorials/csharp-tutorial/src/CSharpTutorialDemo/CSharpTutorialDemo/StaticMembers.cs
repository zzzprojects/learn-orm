using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class StaticMembers
    {
        public class CustomerInfo
        {
            // static variable
            public static int count;
            public string Name { get; set; }
            public string Address { get; set; }

            public CustomerInfo(string name, string address)
            {
                this.Name = name;
                this.Address = address;

                CustomerInfo.count++;
            }
        }

        public class MathUtility
        {
            public static int Add(int number1, int number2)
            {
                return (number1 + number2);
            }
        }

        public static void Example1()
        {
            Console.WriteLine("Total Customers: {0}", CustomerInfo.count);

            CustomerInfo customer1 = new CustomerInfo("John", "11 wall street");
            CustomerInfo customer2 = new CustomerInfo("Mark", "22 wall street");
            CustomerInfo customer3 = new CustomerInfo("Andy", "13 wall street");
            CustomerInfo customer4 = new CustomerInfo("Bruce", "41 wall street");

            Console.WriteLine("\nAfter creating a few objects\n");

            Console.WriteLine("Total Customers: {0}", CustomerInfo.count);
        }

        public static void Example2()
        {
            int number1 = 4;
            int number2 = 7; 
            int result = MathUtility.Add(number1, number2);
            Console.WriteLine("{0} + {1} = {2}", number1, number2, result);
        }
    }
}
