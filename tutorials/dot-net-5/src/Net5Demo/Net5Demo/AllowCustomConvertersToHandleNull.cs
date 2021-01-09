using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Net5Demo
{
    public class AllowCustomConvertersToHandleNull
    {
        public class AddressConverter : JsonConverter<string>
        {
            public override bool HandleNull => true;

            public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return reader.GetString() ?? "No address provided.";
            }

            public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value);
            }
        }

        public class Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
            [JsonConverter(typeof(AddressConverter))]
            public string Address { get; set; }
        }

        public static void Example1()
        {
            var json = @"{""Name"":""Mark"",""Age"":40,""Address"":null} ";
            Console.WriteLine($"Input JSON: {json}");

            Customer customer = JsonSerializer.Deserialize<Customer>(json);

            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Age: {customer.Age}");
            Console.WriteLine($"Address: {customer.Address}");
        }
    }
}
