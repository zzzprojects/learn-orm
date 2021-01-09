using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Net5Demo
{
    public class NonPublicPropertyAccessors
    {
        public class Customer
        {
            public string Name { get; init; }

            [JsonInclude]
            public int Age { get; private set; }

            [JsonInclude]
            public string Address { private get; set; }
        };

        public static void Example1()
        {
            string json = @"{""Name"":""Mark"",""Age"":33,""Address"":""22 ashdown""}";
            Console.WriteLine($"Input JSON: {json}");

            Customer customerDeserialized = JsonSerializer.Deserialize<Customer>(json);
            Console.WriteLine($"Name: {customerDeserialized.Name}");
            Console.WriteLine($"Age: {customerDeserialized.Age}");

            json = JsonSerializer.Serialize<Customer>(customerDeserialized);
            Console.WriteLine($"Output JSON: {json}");
        }
    }
}
 