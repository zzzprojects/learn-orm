using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public struct Point3D
    {
        public int X;
        public int Y;
        public int Z;
    }

    public struct Customer
    {
        public int Id;
        public string Name;
        public string Address;

        public Customer(int id, string name, string address)
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

    public class Structure
    {
        public static void Example1()
        {
            Point3D point1;
            Point3D point2 = new Point3D();

            point1.X = 10;
            point1.Y = 20;
            point1.Z = 30;

            point2.X = 40;
            point2.Y = 50;
            point2.Z = 60;

            Console.WriteLine("X: {0}, Y: {1}, Z: {2}", point1.X, point1.Y, point1.Z);
            Console.WriteLine("X: {0}, Y: {1}, Z: {2}", point2.X, point2.Y, point2.Z);
        }

        public static void Example2()
        {
            Customer customer = new Customer(1, "Mark", "22 wall street");

            Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", customer.Id, customer.Name, customer.Address);
        }

        public static void Example3()
        {
            Customer customer = new Customer(2, "John", "11 wall street");

            customer.Print();
        }
    }
}
