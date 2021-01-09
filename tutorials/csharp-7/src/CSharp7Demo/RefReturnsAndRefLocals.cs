using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp7Demo
{
    public class RefReturnsAndRefLocals
    {
        public class Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }

        private static ref Customer GetLastCustomer(Customer[] customers)
        {
            return ref customers[customers.Length -1];
        }

        public static void Example()
        {
            Customer[] customers = new Customer[]
            {
                new Customer () { Name =  "Mark", Age = 24, Address = "22 Ashdown close"},
                new Customer () { Name =  "John", Age = 31, Address = "9 Ashdown close"},
                new Customer () { Name = "Stella", Age = 29, Address = "32 burak town" }
            };

            ref Customer customerReference = ref GetLastCustomer(customers);

            PrintCustomerInfo(customerReference);                          // Name: Stella, Age: 29, Address: 32 burak town

            customerReference.Name = "Jenifer";

            PrintCustomerInfo(customers[customers.Length -1]);             // Name: Jenifer, Age: 29, Address: 32 burak town
        }

        private static void PrintCustomerInfo(Customer customer)
        {
            Console.WriteLine("Name: {0}, Age: {1}, Address: {2}", customer.Name, customer.Age, customer.Address);
        }
    }
}
