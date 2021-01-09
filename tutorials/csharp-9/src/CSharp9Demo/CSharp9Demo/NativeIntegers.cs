using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    class NativeIntegers
    {
        public static void Example1()
        {
            int x = 3;
            nint y = 3;
            nint z = y + 1;
            z--;

            var name1 = typeof(nint);              // System.IntPtr
            var name2 = typeof(nuint);             // System.UIntPtr
            var name3 = (x + 1).GetType();         // System.Int32
            var name4 = (y + 1).GetType();         // System.IntPtr
            var name5 = (x + y).GetType();         // System.IntPtr

            long v = 10;
            var name6 = (x + v).GetType();         // System.Int64

            var result1 = nint.Equals(x, y);       // False
            var result2 = nint.Equals((nint)x, y); // True
            var result3 = y + 1 > x;               // True;
            var result4 = y - 1 == x;              // False
        }
    }
}
