using System;
using System.Collections.Generic;

namespace CSharpTutorialDemo
{
    public class Generics
    {
        class MyClass<T>
        {
            public T Val { get; set; }
        }

        class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static void InstantiatingGenericClass()
        {
            MyClass<int> myClassInt = new MyClass<int>();
            MyClass<string> myClassString = new MyClass<string>();
            MyClass<DateTime> myClassDateTime = new MyClass<DateTime>();

            myClassInt.Val = 34;                       
            myClassString.Val = "This is a C# Tutorial";
            myClassDateTime.Val = DateTime.Today;

            Console.WriteLine("Type: {0}, \t Value: {1}", myClassInt, myClassInt.Val);
            Console.WriteLine("Type: {0}, \t Value: {1}", myClassString, myClassString.Val);
            Console.WriteLine("Type: {0}, \t Value: {1}", myClassDateTime, myClassDateTime.Val);
        }

        public static void ListExample()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, Name = "John" });
            customers.Add(new Customer { Id = 2, Name = "Mark"});
            customers.Add(new Customer { Id = 3, Name = "Stella"});

            foreach (var customer in customers)
            {
                Console.WriteLine("{0}, {1}", customer.Id, customer.Name);
            }
        
        }
    }
}
