using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp8Demo
{
    public class AsynchronousStreams
    {
        public static async Task PrintEvenSequenceAsync()
        {
            await foreach (var number in GenerateEvenSequence())
            {
                Console.WriteLine(number);
            }
        }
        private static async IAsyncEnumerable<int> GenerateEvenSequence()
        {
            for (int i = 0; i <= 50; i = i + 2)
            {
                await Task.Delay(100);
                yield return i;
            }
        }
    }
}
