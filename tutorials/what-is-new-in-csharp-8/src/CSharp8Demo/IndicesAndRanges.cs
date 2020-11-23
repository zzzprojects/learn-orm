using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    public class IndicesAndRanges
    {
        static string[] nameOfMonths = { 
                                  // index from start    index from end
            "January",            // 0                   ^12
            "February",           // 1                   ^11
            "March",              // 2                   ^10
            "April",              // 3                   ^9
            "May",                // 4                   ^8
            "June",               // 5                   ^7
            "July",               // 6                   ^6
            "August",             // 7                   ^5
            "September",          // 8                   ^4
            "October",            // 9                   ^3
            "November",           // 10                  ^2
            "December"            // 11                  ^1
                                  // 12 (nameOfMonths.Length)  ^0
        };

        public static void Example1()
        {            
            Console.WriteLine("The last month is {0}", nameOfMonths[^1]);
        }

        public static void Example2()
        {
            var names = nameOfMonths[2..5];

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }            
        }

        public static void Example3()
        {
            Range phrase = ^2..^0;
            var names = nameOfMonths[phrase];

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public static void Example4()
        {
            var allMonths = nameOfMonths[..];       // contains all names.
            var firstTwoMonths = nameOfMonths[..2]; // contains first two names i.e. January and February.
            var lastThreeMonths = nameOfMonths[9..];     // contains the last three names.
        }
    }
}











