using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    public class DataMembers
    {
        public record Customer(string Name, int Age, string Address, string Country);

        public static void Example()
        {
            // positional construction
            Customer customer = new("Mark", 34, "23 ashdown", "UK");

            // positional deconstruction
            var (name, age, address, country) = customer;

            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(address);
            Console.WriteLine(country);
        }
    }
}
