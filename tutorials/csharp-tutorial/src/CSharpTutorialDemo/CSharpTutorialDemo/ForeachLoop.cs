using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class ForeachLoop
    {
        public static void Example1()
        {
            string[] websites = new string[5] { "Google", "YouTube", "Facebook", "Baidu", "Yahoo!" };

            foreach (string site in websites)
            {
                Console.WriteLine(site);
            }
        }

        public static void Example2()
        {
            Dictionary<int, string> numberNames = new Dictionary<int, string>();

            numberNames.Add(1, "One"); 
            numberNames.Add(2, "Two");
            numberNames.Add(3, "Three");

            foreach (KeyValuePair<int, string> item in numberNames)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }
        }
    }
}
