using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class RegularExpressionsTests
    {
        public static void Example1()
        {
            string customers = "John, samantha, Andy, Smith, Allen, Mark, Stella, Scarlett";

            // Create a pattern for a word that starts with letter "S"  
            string pattern = @"\b[S]\w+";
  
            Regex expr = new Regex(pattern);
 
            MatchCollection matchedCustomers = expr.Matches(customers);

            Console.WriteLine("The following names of the customers start with \"S\"\n");

            foreach (var match in matchedCustomers)
            {
                Console.WriteLine(match);
            }
        }

        public static void Example2()
        {
            string customers = "John, samantha, Andy, Smith, Allen, Mark, Stella, Scarlett";

            // Create a pattern for a word that starts with letter "S"  
            string pattern = @"\b[S]\w+";

            Regex expr = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection matchedCustomers = expr.Matches(customers);

            Console.WriteLine("The following names of the customers start with \"S\" or  or \"s\"\n");

            foreach (var match in matchedCustomers)
            {
                Console.WriteLine(match);
            }
        }

        public static void EmailValidation()
        {
            string[] emails =
            {
                "parth@gmail.com",
                "john@gmail.com",
                "stella@gmail",
                "andy.123@gmail.com",
                "mark.gmail.com",
                "@gmail.com"
            };

            foreach (string email in emails)
            {
                if (IsValidEmail(email))
                   Console.WriteLine("{0, 20}: is a valid E-mail address.", email);
                else
                   Console.WriteLine("{0, 20}: is not a valid E-mail address.", email);
            }
        }

        private static bool IsValidEmail(string email)
        {
            // This Pattern is use to verify the email 
            string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);

            if (re.IsMatch(email))
                return (true);
            else
                return (false);
        }
    }
}
