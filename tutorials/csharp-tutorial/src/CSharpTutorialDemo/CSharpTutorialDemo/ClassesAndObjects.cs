using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class ClassesAndObjects
    {
        public class CustomerInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }

            public CustomerInfo()
            {
            }

            public CustomerInfo(int id, string name, string address)
            {
                this.Id = id;
                this.Name = name;
                this.Address = address;
            }

            public void Print()
            {
                Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", this.Id, this.Name, this.Address);
            }
        }

        public static void Example1()
        {
            CustomerInfo customer = new CustomerInfo();

            customer.Id = 1;
            customer.Name = "Andy";
            customer.Address = "22 wall street";

            customer.Print();
        }

        public static void Example2()
        {
            CustomerInfo customer = new CustomerInfo(2, "John", "11 wall street");

            customer.Print();
        }
    }
}
