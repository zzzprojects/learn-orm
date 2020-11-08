using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    public class InitOnlyProperties
    {
        public record Customer
        {
            public string LastName { get; init; }
            public string FirstName { get; init; }
        }

        public static void Example1()
        {
            Customer customer = new Customer
            {
                FirstName = "Mark",
                LastName = "Upston"
            };

            Console.WriteLine(customer.FirstName + " " + customer.LastName); 
        }
    }
}
