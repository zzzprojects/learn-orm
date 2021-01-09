using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Net5Demo
{
    public class IgnoreProperties
    {
        //public class Customer
        //{
        //    public string Name;
        //    public int Age;
        //    [JsonIgnore]
        //    public string Address;
        //}

        //public static void Example1()
        //{
        //    Customer customer = new()
        //    {
        //        Name = "Mark",
        //        Age = 40,
        //        Address = "22 Ashdown"
        //    };

        //    var json = JsonSerializer.Serialize<Customer>(customer);

        //    Console.WriteLine($"Output JSON: {json}");
        //}

        public class Customer
        {
            public string Name { get; set; }

            public int Age { get; set; }

            [JsonIgnore]
            public string? Address { get; set; }
        };

        public static void Example1()
        {
            Customer customer = new()
            {
                Name = "Mark",
                Address = "22 wall street.",
                Age = 23
            };

            string json = JsonSerializer.Serialize<Customer>(customer);

            Console.WriteLine(json);
        }

        public class Customer2
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
            public string Name { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
            public int Age { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? Address { get; set; }
        };

        public static void Example2()
        {
            Customer2 customer = new()
            {
                Name = default,
                Address = null,
                Age = default
            };

            string json = JsonSerializer.Serialize<Customer2>(customer);

            Console.WriteLine(json);
        }

        public class Customer3
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string? Address { get; set; }
            public DateTime? DOB { get; private set; }

            public Customer3(string name, int age, string address, DateTime dob)
            {
                (Name, Age, Address, DOB) = (name, age, address, dob);
            }
        };

        public static void Example3()
        {
            Customer3 customer = new("Mark", 31, "22 wall street.", DateTime.Now.AddYears(-29));

            var options = new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = true,
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize<Customer3>(customer, options);

            Console.WriteLine(json);
        }

        public class Customer4
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string? Address { get; set; }
        };

        public static void Example4()
        {
            Customer4 customer = new()
            {
                Name = "Mark",
                Address = null,
                Age = 23
            };

            JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };


            string json = JsonSerializer.Serialize<Customer4>(customer, options);

            Console.WriteLine(json);
        }

        public class Customer5
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string? Address { get; set; }
            public DateTime? DOB { get; set; }
        };

        public static void Example5()
        {
            Customer5 customer = new()
            {
                Name = "Mark",
                Address = "11 wall street.",
                Age = 25,
                DOB = default
            };

            JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };


            string json = JsonSerializer.Serialize<Customer5>(customer, options);

            Console.WriteLine(json);
        }
    }
}
