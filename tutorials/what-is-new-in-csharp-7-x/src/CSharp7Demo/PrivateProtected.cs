using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class PrivateProtected
    {
        class A
        {
            private protected int privateProtectedIntVal { get; set; }
            public int publicIntVal { get; set; }
        }

        class B : A
        {
            public static void AccessValue()
            {
                A a = new A();
                //a.privateProtectedIntVal = 5;          //Error
                a.publicIntVal = 10;

                B b = new B();
                b.publicIntVal = 15;
                b.privateProtectedIntVal = 20;
            }
        }

        public static void Example()
        {
            
        }
    }
}
