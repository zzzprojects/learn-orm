using System;

namespace CSharpTutorialDemo
{
    public class WhileLoop
    {
        public static void Example1()
        {
            // Initialize the counter
            int counter = 0;

            // Execute the loop body while the loop condition holds
            while (counter <= 5)
            {
                // Print the counter value
                Console.WriteLine("Number: " + counter);

                // Increment the counter
                counter++;
            }
        }

        public static void Example2()
        {
            // Initialize the counter
            int counter = 0;

            // Execute the do-while body loop
            do
            {
                // Print the counter value
                Console.WriteLine("Number : " + counter);

                // Increment the counter
                counter++;
            }
            while (counter <= 5);
        }
    }
}
