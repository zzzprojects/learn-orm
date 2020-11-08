using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9Demo
{
    public class CovariantReturns
    {
        public static void Example1()
        {
            Tiger tiger = new Tiger();
            Cat cat = new Cat();

            Meat meat = tiger.GetFood();
            Milk milk = cat.GetFood();
        }
        abstract class Animal
        {
            public abstract Food GetFood();
        }
        class Tiger : Animal
        {
            public override Meat GetFood()
            {
                return new Meat();
            }
        }

        class Cat : Animal
        {
            public override Milk GetFood()
            {
                return new Milk();
            }
        }

        public class Food
        {
        }

        public class Meat : Food
        {
            public Meat()
            {
                Console.WriteLine("I eat meat...");
            }
        }

        public class Milk : Food
        {
            public Milk()
            {
                Console.WriteLine("I drink milk...");
            }
        }
    }
}
