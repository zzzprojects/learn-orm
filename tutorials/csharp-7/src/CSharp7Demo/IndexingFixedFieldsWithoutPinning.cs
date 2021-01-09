using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Demo
{
    public class IndexingFixedFieldsWithoutPinning
    {
        unsafe struct MyStructure
        {
            public fixed int myFixedField[10];
        }
 
        public class IterateData
        {
            MyStructure numbers = new MyStructure();
            MyStructure cubes = new MyStructure();

            public unsafe void PrintArrayUsingPinning()
            {
                for (int i = 0; i < 10; i++)
                {
                    fixed (int* ptrNumbers = numbers.myFixedField)
                    fixed (int* ptrCubes = cubes.myFixedField)
                    {
                        ptrNumbers[i] = i;
                        ptrCubes[i] = i * i * i;
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    fixed (int* ptrNumbers = numbers.myFixedField)
                    fixed (int* ptrCubes = cubes.myFixedField)
                    {
                        Console.WriteLine(ptrNumbers[i] + " cube " + ptrCubes[i]);
                    }
                }
            }

            public unsafe void PrintArrayWithoutPinning()
            {
                for (int i = 0; i < 10; i++)
                {
                    numbers.myFixedField[i] = i;
                    cubes.myFixedField[i] = i * i * i;
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(numbers.myFixedField[i] + " cube " + cubes.myFixedField[i]);                 
                }
            }
        }

        public static void Example()
        {
            IterateData data = new IterateData();
            data.PrintArrayUsingPinning();
            data.PrintArrayWithoutPinning();
        }
    }
}
