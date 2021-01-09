using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    public static class Extensions
    {
        public static IEnumerator<T> GetEnumerator<T>(this IEnumerator<T> enumerator) => enumerator;
    }

    public class GetEnumeratorSupport
    {
        public static void Example1()
        {
            List<string> daysOfWeek = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            IEnumerator<string> daysOfWeekEnumerator = daysOfWeek.GetEnumerator();

            foreach (var country in daysOfWeekEnumerator)
            {
                Console.WriteLine($"{country} is a beautiful country");
            }
        }
    }
}
