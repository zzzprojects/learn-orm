using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Net5Demo
{
    public class ImmutableTypesAndRecords
    {
        public struct Customer
        {
            public string Name { get; init; }
            public int Age { get; set; }
            public string Address { get; set; }

            [JsonConstructor]
            public Customer(string name, int age, string address)
            {
                (Name, Age, Address) = (name, age, address);
            }
        }

        public static void Example1()
        {
            var json = @"{""name"":""Mark"",""age"":40,""address"":""22 Ashdown""} ";
            Console.WriteLine($"Input JSON: {json}");

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            var customer = JsonSerializer.Deserialize<Customer>(json, options);

            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Age: {customer.Age}");
            Console.WriteLine($"Address: {customer.Address}");

            var roundTrippedJson = JsonSerializer.Serialize<Customer>(customer, options);

            Console.WriteLine($"Output JSON: {roundTrippedJson}");
        }

        public record Forecast(DateTime Date, int TemperatureC)
        {
            public string? Summary { get; init; }
        };

        public static void Example2()
        {
            Forecast forecast = new(DateTime.Now, 40)
            {
                Summary = "Hot!"
            };

            string forecastJson = JsonSerializer.Serialize<Forecast>(forecast);
            Console.WriteLine(forecastJson);
            Forecast? forecastObj = JsonSerializer.Deserialize<Forecast>(forecastJson);
            Console.WriteLine(forecastObj);
        }
    }
}
