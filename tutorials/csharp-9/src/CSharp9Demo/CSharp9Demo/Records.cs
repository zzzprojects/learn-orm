using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    public class Records
    {
        //public record Customer
        //{
        //    public string LastName { get; }
        //    public string FirstName { get; }

        //    public Customer(string first, string last) => (FirstName, LastName) = (first, last);
        //}

        //public record Customer
        //{
        //    public string LastName { get; init; }
        //    public string FirstName { get; init; }
        //}

        public record Customer
        {
            public string LastName { get; init; }
            public string FirstName { get; init; }
        }

        public static void Example1()
        {
            Customer customer1 = new Customer
            {
                FirstName = "Mark",
                LastName = "Upston"
            };

            Customer customer2 = new Customer
            {
                FirstName = "Mark",
                LastName = "Upston"
            };

            Console.WriteLine(customer1.Equals(customer2)); // True
        }

        public record Person
        {
            public string LastName { get; }
            public string FirstName { get; }

            public Person(string first, string last) => (FirstName, LastName) = (first, last);
        }

        public record Employee : Person
        {
            public string Title { get; }

            public Employee(string first, string last, string title) : base(first, last) => Title = title;
        }
    }
}
