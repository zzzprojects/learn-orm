using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8Demo
{
    public class SwitchExpressions
    {
        public static void Example1()
        {
            var input = 2;

            var result = input switch
            {
                1 => "Case 1",
                2 => "Case 2",
                3 => "Case 3",
                4 => "Case 4",
                _ => "default"
            };

            Console.WriteLine(result);

            //string result;
            switch (input)
            {
                case 1:
                    result = "Case 1";
                    break;
                case 2:
                    result = "Case 1";
                    break;
                case 3:
                    result = "Case 1";
                    break;
                case 4: 
                    result = "Case 1";
                    break;
                default:
                    result = "default";
                    break;
            }

            Console.WriteLine(result);
        }

        public enum Directions
        {
            Up,
            Down,
            Right,
            Left
        }

        public static void Example2()
        {
            var direction = Directions.Down;
            Console.WriteLine("Map view direction is {0}", direction);

            var orientation = direction switch
            {
                Directions.Up => "North",
                Directions.Right => "East",
                Directions.Down => "South",
                Directions.Left => "West",
                _ => throw new NotImplementedException(),
            };
            Console.WriteLine("Cardinal orientation is {0}", orientation);
        }
    }
}
