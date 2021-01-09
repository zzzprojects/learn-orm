using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    public class WithExpressions
    {
        public static void Example1()
        {
            Customer customer = new Customer
            {
                Name = "Mark",
                Age = 34,
                Address = "23 ashdown",
                Country = "UK"
            };

            var newCustomer = customer with { Name = "John" };

            Console.WriteLine(customer.Name);
            Console.WriteLine(newCustomer.Name);
        }

        record Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
            public string Country { get; set; }
        }
    }    
}
