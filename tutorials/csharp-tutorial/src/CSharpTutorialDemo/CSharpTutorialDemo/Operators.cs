using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class Operators
    {
        public static void Example1()
        {
            int a = 10;
            int b = 20;

            Console.WriteLine("a + b = {0}", a + b);
            Console.WriteLine("a - b = {0}", a - b);
            Console.WriteLine("a * b = {0}", a * b);

            Console.WriteLine("a + (b++) = {0}", a + (b++));
            Console.WriteLine("a + b = {0}", a + b);

            Console.WriteLine("a + (++b) = {0}", a + (++b));
            Console.WriteLine("a + b = {0}", a + b);
        }

        public static void Example2()
        {
            int squarePerimeter = 17;
            int squareSideInt = squarePerimeter / 4;
            Console.WriteLine(squareSideInt);

            double squareSideDouble = squarePerimeter / 4.0;
            Console.WriteLine(squareSideDouble);         
        }

        public static void Example3()
        {
            Console.WriteLine(7/0.0);
            Console.WriteLine(-3/0.0);
        }

        public static void Example4()
        {
            bool a = true;
            bool b = false;

            Console.WriteLine(a && b);             // False
            Console.WriteLine(a || b);             // True
            Console.WriteLine(!b);                 // True
            Console.WriteLine(b || true);          // True
            Console.WriteLine((5 > 7) ^ (a == b)); // False
        }

        public static void Example5()
        {
            byte a = 3;                // 0000 0011 = 3 
            byte b = 5;                // 0000 0101 = 5 

            Console.WriteLine(a | b);  // 0000 0111 = 7 
            Console.WriteLine(a & b);  // 0000 0001 = 1 
            Console.WriteLine(a ^ b);  // 0000 0110 = 6 
            Console.WriteLine(~a & b); // 0000 0100 = 4 
            Console.WriteLine(a << 1); // 0000 0110 = 6 
            Console.WriteLine(a << 2); // 0000 1100 = 12 
            Console.WriteLine(a >> 1); // 0000 0001 = 1
        }

        public static void Example6()
        {
            int x = 10; 
            int y = 5; 
            
            Console.WriteLine("x > y : " + (x > y));   // True 
            Console.WriteLine("x < y : " + (x < y));   // False 
            Console.WriteLine("x >= y : " + (x >= y)); // True 
            Console.WriteLine("x <= y : " + (x <= y)); // False 
            Console.WriteLine("x == y : " + (x == y)); // False 
            Console.WriteLine("x != y : " + (x != y)); // True
        }

        public static void Example7()
        {
            int x = 6;
            string helloString = "Hello string.";
            int y = x + 3;

            Console.WriteLine(x);            // 6       
            Console.WriteLine(helloString);  // Hello string.
            Console.WriteLine(y);            // 9
        }

        public static void Example8()
        {
            int x = 2; 
            int y = 4; 
            
            x *= y; // Same as x = x * y; 
            
            Console.WriteLine(x); // 8
        }

        public static void Example9()
        {
            string csharp = "C# "; 
            string tutorial = "Tutorial."; 
            
            string csharpTutorial = csharp + tutorial; 
            Console.WriteLine(csharpTutorial);    // C# Tutorial. 

            string csharp8 = csharp + " " + 8; 
            Console.WriteLine(csharp8);           // C# 8
        }

        public static void Example10()
        {
            int myInt = 7; 
            Console.WriteLine(myInt); // 7 
            
            long myLong = myInt; 
            Console.WriteLine(myLong); // 7

            Console.WriteLine(myLong + myInt); // 14
        }

        public static void Example11()
        {
            double myDouble = 5.1d; 
            Console.WriteLine(myDouble);     // 5.1 

            long myLong = (long)myDouble; 
            Console.WriteLine(myLong);       // 5 

            myDouble = 5e9d;                 // 5 * 10^9 
            Console.WriteLine(myDouble);     // 5000000000 
            int myInt = (int)myDouble; 
            Console.WriteLine(myInt);        // -2147483648 
            Console.WriteLine(int.MinValue); // -2147483648
        }
    }
}
