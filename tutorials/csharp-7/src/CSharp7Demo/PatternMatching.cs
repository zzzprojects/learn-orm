using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class PatternMatching
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class Teacher : Person
        {
            public double Salary { get; set; }
        }

        public class Student : Person
        {
            public double GPA { get; set; }
        }

        public static void IsTypePatternExample()
        {
            List<Person> people = new List<Person>()
            {
                new Teacher() { Name = "Stella", Age = 19, Salary = 5000 },
                new Student() { Name = "Mark", Age = 19, GPA = 3.20 },
                new Student() { Name = "John", Age = 20, GPA = 2.89 }
            };

            foreach (var person in people)
            {
                // Before C# 7.0
                if (person is Teacher)
                {
                    Console.WriteLine("Salary: {0}", ((Teacher)person).Salary);
                }
                else if (person is Student)
                {
                    Console.WriteLine("GPA: {0}", ((Student)person).GPA);
                }

                // In C# 7.0 and later
                if (person is Teacher t)
                {
                    Console.WriteLine("Salary: {0}", t.Salary);
                }
                else if (person is Student s)
                {
                    Console.WriteLine("GPA: {0}", s.GPA);
                }
            }
        }

        public static void SwitchClassicPatternExample()
        {
            int caseSwitch = 1;

            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
        public static void SwitchTypePattern()
        {
            List<Person> people = new List<Person>()
            {
                new Teacher() { Name = "Stella", Age = 19, Salary = 5000 },
                new Student() { Name = "Mark", Age = 19, GPA = 3.20 },
                new Student() { Name = "John", Age = 20, GPA = 2.89 }
            };

            foreach (var person in people)
            {
                Console.WriteLine("Name: {0}, Age: {1}, {2}", person.Name, person.Age, GetAdditionalInfo(person));
            }
        }

        private static string GetAdditionalInfo(Person person)
        {
            switch (person)
            {
                case Teacher t:
                    return "Salary: " + t.Salary;
                case Student s:
                    return "GPA: " + s.GPA;
                default:
                    throw new ArgumentException(message: "It is not a recognized person", paramName: nameof(person));
            }
        }

        private static string GetAdditionalInfoUsingWhenClause(Person person)
        {
            switch (person)
            {
                case Teacher t when t.Salary == 0.0:
                case Student s when s.GPA == 0.0:
                    return "";

                case Teacher t:
                    return "Salary: " + t.Salary;
                case Student s:
                    return "GPA: " + s.GPA;
                default:
                    throw new ArgumentException(message: "It is not a recognized person", paramName: nameof(person));
            }
        }

        private static string GetAdditionalInfoUsingWhenClauseAndNullCase(Person person)
        {
            switch (person)
            {
                case Teacher t when t.Salary == 0.0:
                case Student s when s.GPA == 0.0:
                    return "";

                case Teacher t:
                    return "Salary: " + t.Salary;
                case Student s:
                    return "GPA: " + s.GPA;
                case null:
                    throw new ArgumentNullException(paramName: nameof(person), message: "Person must not be null");
                default:
                    throw new ArgumentException(message: "It is not a recognized person", paramName: nameof(person));
            }
        }
    }
}
