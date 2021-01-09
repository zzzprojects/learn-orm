using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Net5Demo
{
    public class CreateJsonSerializerOptionsWithWebDefaults
    {
        public class Customer
        {
            public string Name { get; init; }
            public int Age { get; set; }
            public string Address { get; set; }
        };

        public static void Example1()
        {
            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            Console.WriteLine($"PropertyNameCaseInsensitive: {options.PropertyNameCaseInsensitive}");
            Console.WriteLine($"JsonNamingPolicy: {options.PropertyNamingPolicy}");
            Console.WriteLine($"NumberHandling: {options.NumberHandling}");

            Customer customer = new()
            {
                Name = "Mark",
                Address = "22 wall street.",
                Age = 23
            };

            string json = JsonSerializer.Serialize<Customer>(customer, options);

            Console.WriteLine($"Output JSON: {json}");
        }
    }
}
