using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Net5Demo
{
    public class CopyJsonSerializerOptions
    {
        public class Customer
        {
            public string Name { get; init; }
            public int Age { get; set; }
            public string Address { get; set; }
        };

        public static void Example1()
        {
            string json = @"{""Name"":""Mark"",""Age"":33,""Address"":""22 Ashdown""}";
            Console.WriteLine($"Input JSON: {json}");

            Customer customerDeserialized = JsonSerializer.Deserialize<Customer>(json);
            Console.WriteLine($"Name: {customerDeserialized.Name}");
            Console.WriteLine($"Age: {customerDeserialized.Age}");

            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            JsonSerializerOptions optionsCopy = new(options);

            json = JsonSerializer.Serialize<Customer>(customerDeserialized, optionsCopy);
            Console.WriteLine($"Output JSON: {json}");
        }
    }
}
