using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp7Demo
{
    public class FixedPattern
    {
        public class MyData
        {
            private readonly int _value;
            public MyData(int value)
            {
                _value = value;
            }

            public ref readonly int GetPinnableReference()
            {
                return ref _value;
            }        
        }

        public unsafe static void Example()
        {
            var myData = new MyData(39);
            fixed (int* ptr = myData)
            {
                Console.WriteLine(*ptr); 
            }
        }

        unsafe public static void FixedSpanExample()
        {
            int[] PascalsTriangle = {
                          1,
                        1,  1,
                      1,  2,  1,
                    1,  3,  3,  1,
                  1,  4,  6,  4,  1,
                1,  5,  10, 10, 5,  1
            };

            Span<int> RowFive = new Span<int>(PascalsTriangle, 10, 5);

            fixed (int* ptrToRow = RowFive)
            {
                var sum = 0;
                for (int i = 0; i < RowFive.Length; i++)
                {
                    sum += *(ptrToRow + i);
                }
                Console.WriteLine(sum);
            }
        }

        public unsafe static void Example1()
        {
            var myData1 = new MyData(100);
            var myData2 = new MyData(200);

            fixed (int* ptr1 = myData1, ptr2 = myData2)
            {
                Console.WriteLine(*ptr1);
                Console.WriteLine(*ptr2);
            }
        }

        public unsafe static void Example2()
        {
            var myData = new MyData(72);
            fixed (int* ptr = myData)
            {
                Console.WriteLine(*ptr);

                int* newPtr = ptr;
                newPtr = newPtr + 10;
                Console.WriteLine(*newPtr);

                //ptr = ptr + 10;            //Error
            }
        }
    }
}
