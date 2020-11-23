using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class Tuples
    {
        public static void Example()
        {
            Tuple<string, int, string> person = new Tuple<string, int, string>("Mark", 23, "22 Ashdown close");
            Console.WriteLine(person);

            Console.WriteLine("Elements in tuple: {0}, {1}, {2}",
                person.Item1, person.Item2, person.Item3);             // Elements in tuple: Mark, 23, 22 Ashdown close
        }
        public static void Example1()
        {
            var person = ("Mark", 23, "22 Ashdown close" );
            Console.WriteLine(person);                                 // (Mark, 23, 22 Ashdown close)

            Console.WriteLine("Elements in tuple: {0}, {1}, {2}", 
                person.Item1, person.Item2, person.Item3);             // Elements in tuple: Mark, 23, 22 Ashdown close
        }

        public static void Example2()
        {
            (string, int, string) person = ("Mark", 23, "22 Ashdown close");
            Console.WriteLine(person);                                 // (Mark, 23, 22 Ashdown close)

            Console.WriteLine("Elements in tuple: {0}, {1}, {2}",
                person.Item1, person.Item2, person.Item3);             // Elements in tuple: Mark, 23, 22 Ashdown close
        }

        public static void Example3()
        {
            (string Name, int Age, string Address) person = ("Mark", 23, "22 Ashdown close");
            Console.WriteLine(person);                                // (Mark, 23, 22 Ashdown close)

            Console.WriteLine("Name: {0}, Age: {1}, Address: {2}",
                person.Name, person.Age, person.Address);             // Name: Mark, Age: 23, Address: 22 Ashdown close
        }

        public static void Example4()
        {
            var person = (Name: "Mark", Age:23, Address: "22 Ashdown close");
            Console.WriteLine(person);                                // (Mark, 23, 22 Ashdown close)

            Console.WriteLine("Name: {0}, Age: {1}, Address: {2}",
                person.Name, person.Age, person.Address);             // Name: Mark, Age: 23, Address: 22 Ashdown close
        }

        public static void Example5()
        {
            var person = GetPerson();
            Console.WriteLine(person);                                // (Mark, 23, 22 Ashdown close)

            Console.WriteLine("Name: {0}, Age: {1}, Address: {2}",
                person.Name, person.Age, person.Address);             // Name: Mark, Age: 23, Address: 22 Ashdown close
        }

        private static (string Name, int Age, string Address) GetPerson()
        {
            string Name = "Mark";
            int Age = 23;
            string Address = "22 Ashdown close";

            return (Name, Age, Address);
        }
    }
}
