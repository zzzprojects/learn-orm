using System;

namespace CSharpTutorialDemo
{
    public class ConstructorsTests
    {
        public class CustomerInfo
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public static int minimumAge;
            static CustomerInfo()
            {
                minimumAge = 18;
                Console.WriteLine("Static Constructor Called");
            }

            public CustomerInfo()
            {
                Console.WriteLine("Default Constructor Called");
            }

            public CustomerInfo(string name, string address)
            {
                this.Name = name;
                this.Address = address;
            }

            public CustomerInfo(CustomerInfo customer)
            {
                this.Name = customer.Name;
                this.Address = customer.Address;
            }

            public void Print()
            {
                Console.WriteLine("Name: {0}, Address: {1}", this.Name, this.Address);
            }
        }

        public class Counter
        {
            private Counter() 
            { }

            public static int currentCount;
            public static int IncrementCount()
            {
                return ++currentCount;
            }
        }

        public static void Example1()
        {
            CustomerInfo customer = new CustomerInfo();

            customer.Print();
        }

        public static void Example2()
        {
            CustomerInfo customer1 = new CustomerInfo("John", "11 wall street");
            CustomerInfo customer2 = new CustomerInfo(customer1);

            customer1.Print();
            customer2.Print();
        }

        public static void Example3()
        {
            Counter.currentCount = 9;
            Counter.IncrementCount();
            Console.WriteLine("New count: {0}", Counter.currentCount);
        }

        public static void Example4()
        {
            CustomerInfo customer = new CustomerInfo();

            Console.WriteLine("Minimum Age: {0}", CustomerInfo.minimumAge);
        }
    }
}
