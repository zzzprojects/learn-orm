using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    public class UnconstrainedTypeParameterAnnotations
    {
        public static void Example1()
        {
#nullable enable
            var s1 = new string[0].FirstOrDefault();  // string? s1
            var s2 = new string?[0].FirstOrDefault(); // string? s2

            var i1 = new int[0].FirstOrDefault();  // int i1
            var i2 = new int?[0].FirstOrDefault(); // int? i2
#nullable disable
        }

        public static void Example2()
        {
#nullable enable
            var u1 = new U[0].FirstOrDefault();  // U? u1
            var u2 = new U?[0].FirstOrDefault(); // U? u2
#nullable disable
        }
    }

    internal class U
    {
    }

    class A1
    {
        public virtual void F1<T>(T? t) where T : struct { }
        public virtual void F1<T>(T? t) where T : class { }
    }

    class B1 : A1
    {
        public override void F1<T>(T? t) /*where T : struct*/ { }
        public override void F1<T>(T? t) where T : class { }
    }
}
