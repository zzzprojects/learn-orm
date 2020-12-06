using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Net5Demo
{
    public class AllowOrWriteNumbersInQuotes
    {
        public class Customer
        {
            public string Name { get; init; }
            public int Age { get; set; }
            public string Address { get; set; }
        }

        public static void Example()
        {
            Customer customer = new()
            {
                Name = "Mark",
                Age = 40,
                Address = "22 Ashdown"
            };

            JsonSerializerOptions options = new()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
                WriteIndented = true
            };

            string customerJson = JsonSerializer.Serialize<Customer>(customer, options);

            Console.WriteLine($"Output JSON:\n{customerJson}");

            Customer customerDeserialized = JsonSerializer.Deserialize<Customer>(customerJson, options);

            Console.WriteLine($"Name: {customerDeserialized.Name}");
            Console.WriteLine($"Age: {customerDeserialized.Age}");
            Console.WriteLine($"Address: {customerDeserialized.Address}");
        }
    }
}
