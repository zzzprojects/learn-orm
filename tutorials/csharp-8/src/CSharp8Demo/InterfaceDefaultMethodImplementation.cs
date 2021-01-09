using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    public class InterfaceDefaultMethodImplementation
    {
        private interface ISimpleInterface
        {
            public void DefaultImplementationMethod()
            {
                Console.WriteLine("This is a default method implemented in the interface!");
            }

            public void AnotherMethod();
        }

        class A : ISimpleInterface
        {
            public void AnotherMethod()
            {
                Console.WriteLine("This is a method implemented in class A.");
            }
        }

        class B : ISimpleInterface
        {
            public void DefaultImplementationMethod()
            {
                Console.WriteLine("This is a default method overridden in class B.");
            }
            public void AnotherMethod()
            {
                Console.WriteLine("This is another method implemented in class B.");
            }
        }

        public static void Example1()
        {
            ISimpleInterface obj = new A();
            obj.DefaultImplementationMethod();
            obj.AnotherMethod();
        }

        public static void Example2()
        {
            ISimpleInterface obj = new B();
            obj.DefaultImplementationMethod();
            obj.AnotherMethod();
        }

        public static void Example3()
        {
            A obj = new A();
            //obj.DefaultImplementationMethod();
            obj.AnotherMethod();
        }
    }
}
