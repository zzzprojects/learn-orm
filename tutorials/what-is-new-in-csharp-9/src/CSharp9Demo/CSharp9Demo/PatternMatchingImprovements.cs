using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    public class PatternMatchingImprovements
    {
        public enum LifeStage
        {
            Prenatal,
            Infant,
            Toddler,
            EarlyChild,
            MiddleChild,
            Adolescent,
            EarlyAdult,
            MiddleAdult,
            LateAdult
        }

        private static LifeStage LifeStageAtAge(int age) => age switch
        {
            < 0 => LifeStage.Prenatal,
            < 2 => LifeStage.Infant,
            < 4 => LifeStage.Toddler,
            < 6 => LifeStage.EarlyChild,
            < 12 => LifeStage.MiddleChild,
            < 20 => LifeStage.Adolescent,
            < 40 => LifeStage.EarlyAdult,
            < 65 => LifeStage.MiddleAdult,
            _ => LifeStage.LateAdult,
        };

        public static void RelationalPatterns()
        {
            Console.WriteLine(LifeStageAtAge(4));
            Console.WriteLine(LifeStageAtAge(13));
            Console.WriteLine(LifeStageAtAge(28));
            Console.WriteLine(LifeStageAtAge(84));
        }

        public record Customer
        {
            public string Name { get; init; }
        }

        public static void PatternCombinators()
        {
            Customer customer = new Customer
            {
                Name = "Mark Upston"
            };

            if (customer is not null)
            {
                Console.WriteLine(customer.Name);
            }
        }

        private static bool IsLetter(char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');

        public static void PatternCombinators2()
        {
            Console.WriteLine(IsLetter('q'));
            Console.WriteLine(IsLetter('`'));
            Console.WriteLine(IsLetter(']'));
            Console.WriteLine(IsLetter('B'));
        }
    }
}
