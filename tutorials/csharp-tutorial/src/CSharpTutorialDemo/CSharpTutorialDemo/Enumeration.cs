using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    enum Days
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday        
    }

    enum Months
    {
        January           = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    enum Categories
    {
        Sports         = 1,
        Arts           = 3,
        Clothing       = 7,
        Fashion        = 15,
        Electronics    = 21,
        HealthCare     = 33
    }

    public class Enumeration
    {
        public static void Example1()
        {
            Days day = Days.Tuesday;
            Console.WriteLine("The day is {0}",day);
        }

        public static void Example2()
        {
            Categories category = Categories.HealthCare;
            int intVal = (int)category;

            Console.WriteLine("The numerical value of {0} in {1}", category, intVal);
        }
    }
}
