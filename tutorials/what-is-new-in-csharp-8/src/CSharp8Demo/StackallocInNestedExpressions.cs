using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    public class StackallocInNestedExpressions
    {
        public static void Example()
        {
            Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };

            var index = numbers.IndexOfAny(stackalloc[] { 4, 8, 12 });

            Console.WriteLine(index);   // output: 3  
        }

        public static void Example1()
        {
            string input = "This is a simple string \r\n";
            ReadOnlySpan<char> trimmedChar = input.AsSpan().Trim(stackalloc[] { ' ', '\r', '\n' });

            Console.WriteLine(trimmedChar.ToString());
        }
    }
}
