using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7Demo
{
    public class AsyncReutrnTypes
    {
        static readonly Random random = new Random();
        public static async void PrintRandomNumberUsingValueTask()
        {
            Console.WriteLine($"You rolled {await GetDiceRollAsync()}");
            int number = await GetNumber();
            Console.WriteLine("Random number: {0}", number);
        }

        public static async ValueTask<int> GetNumber()
        {            
            await Task.Delay(1);
            return random.Next(1, 1000);
        }

        static async ValueTask<int> GetDiceRollAsync()
        {
            Console.WriteLine("Shaking dice...");

            int roll1 = await RollAsync();
            int roll2 = await RollAsync();

            return roll1 + roll2;
        }

        static async ValueTask<int> RollAsync()
        {
            await Task.Delay(500);

            int diceRoll = random.Next(1, 7);
            return diceRoll;
        }
    }
}
