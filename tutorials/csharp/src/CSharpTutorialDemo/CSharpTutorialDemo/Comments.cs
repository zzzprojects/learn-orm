// C# program file to demonstrate the different types of comments

using System;

namespace CSharpTutorialDemo
{
    public class Comments
    {
        /// <summary>
        /// Employee class which keep all the information related to an employee.
        /// </summary>
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }

            // Default parameterless constructor
            public Employee()
            {
            }

            /* This a parameterized constructor which takes the following parameters
                - id
                - name
                - address
               It will initialize the employee object with values passed as parameters. 
            */
            public Employee(int id, string name, string address)
            {
                this.Id = id;
                this.Name = name;
                this.Address = address;
            }

            /// <summary> 
            /// Method to print all the information on console window. 
            /// </summary> 
            public void Print()
            {
                Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", this.Id, this.Name, this.Address);
            }
        }

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
            int counter = 0;                                // Initialize the counter

            while (counter <= 5)
            {                
                Console.WriteLine("Number: " + counter);    // Print the counter value
                counter++;                                  // Increment the counter
            }
        }

        public static void Example3()
        {
            /*
            for (int i = 0; i <= 10; i++)
            {
                if (i > 3 && i < 8)
                    continue;

                Console.WriteLine("Counter: {0}", i);
            }
            */

            Console.WriteLine(" Entire code block is commented");
        }
    }
}
