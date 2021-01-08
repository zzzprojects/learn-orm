using System;

namespace CSharpTutorialDemo
{
    public class SwitchStatement
    {
        public static void SimpleSwitch()
        {
            int caseSwitch = 1;

            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        public static void MultipleLabelsExample()
        {
            int number = 6;
            switch (number)
            {
                case 1:
                case 4:
                case 6:
                case 8:
                case 10:
                    Console.WriteLine("The number is not prime!");
                    break;
                case 2:
                case 3:
                case 5:
                case 7:
                    Console.WriteLine("The number is prime!");
                    break;
                default:
                    Console.WriteLine("Unknown number!");
                    break;
            }
        }
    }
}
