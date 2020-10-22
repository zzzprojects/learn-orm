using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class MultidimensionalArrays
    {
        public static void Example1()
        {
            int[,] matrix = 
            {
                {1, 2, 3, 4}, // row 0 values
                {5, 6, 7, 8}, // row 1 values
            };

            Console.WriteLine(matrix[0, 0]);
            Console.WriteLine(matrix[0, 1]);
            Console.WriteLine(matrix[0, 2]);
            Console.WriteLine(matrix[0, 3]);
            Console.WriteLine(matrix[1, 0]);
            Console.WriteLine(matrix[1, 1]);
            Console.WriteLine(matrix[1, 2]);
            Console.WriteLine(matrix[1, 3]);
        }

        public static void Example2()
        {
            int[,] matrix =
            {
                {1, 2, 3, 4}, // row 0 values
                {5, 6, 7, 8}, // row 1 values
            };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine("matrix[{0}, {1}] = {2}", i, j, matrix[i, j]);
                }
            }
        }

        public static void Example3()
        {
            int[,] myArray =
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
            };

            myArray[1, 2] = 25;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine("myArray[{0}, {1}] = {2}", i, j, myArray[i, j]);
                }
            }
        }
    }
}
