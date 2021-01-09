using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    public class TargetTypedNewExpressions
    {
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Customer()
            {

            }
            public Customer(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
        }

        public static void Example1()
        {
            Customer customer = new();

            if (customer is not null)
            {
                Console.WriteLine(customer.FirstName + " " + customer.LastName);
            }
        }
        public static void Example2()
        {
            Customer customer = new("Mark", "Upston");

            if (customer is not null)
            {
                Console.WriteLine(customer.FirstName + " " + customer.LastName);
            }
        }
    }
}
