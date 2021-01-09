using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Net5Demo
{
    public class IncludeFields
    {
        public class Customer
        {
            public string Name;
            public int Age;
            public string Address;
        }

        public static void Example1()
        {
            var json = @"{""Name"":""Mark"",""Age"":40,""Address"":""22 Ashdown""} ";
            Console.WriteLine($"Input JSON: {json}");

            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };

            var customer = JsonSerializer.Deserialize<Customer>(json, options);

            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Age: {customer.Age}");
            Console.WriteLine($"Address: {customer.Address}");

            var roundTrippedJson = JsonSerializer.Serialize<Customer>(customer, options);

            Console.WriteLine($"Output JSON: {roundTrippedJson}");
        }

        public class Customer2
        {
            [JsonInclude]
            public string Name;
            [JsonInclude]
            public int Age;
            [JsonInclude]
            public string Address;
        }

        public static void Example2()
        {
            var json = @"{""Name"":""John"",""Age"":31,""Address"":""22 wall street""} ";
            Console.WriteLine($"Input JSON: {json}");

            var customer = JsonSerializer.Deserialize<Customer2>(json);

            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Age: {customer.Age}");
            Console.WriteLine($"Address: {customer.Address}");

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var roundTrippedJson = JsonSerializer.Serialize<Customer2>(customer, options);

            Console.WriteLine($"Output JSON: {roundTrippedJson}");
        }
    }
}
