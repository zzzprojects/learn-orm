using System;

namespace CSharpTutorialDemo
{
    public class GettersAndSetters
    {
        public class CustomerInfo
        {
            public string Name { get; set; }
            public string City { get; set; } = "New York";

            public string ReadOnly { get; private set; }
            public string WriteOnly { private get; set; }
        }

        public static void Example1()
        {
            CustomerInfo customer = new CustomerInfo();

            customer.Name = "John";               // call the setter and set the name
            string name = customer.Name;          // call the getter and return the name

            Console.WriteLine("The name of the customer is {0}", name);
        }
    }
}
