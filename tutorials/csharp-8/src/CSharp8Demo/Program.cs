using System;
using System.Threading.Tasks;

namespace CSharp8Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //IndicesAndRanges.Example1();
            //IndicesAndRanges.Example2();
            //IndicesAndRanges.Example3();
            //IndicesAndRanges.Example4();

            //InterfaceDefaultMethodImplementation.Example1();
            //InterfaceDefaultMethodImplementation.Example2();
            //InterfaceDefaultMethodImplementation.Example3();

            //ReadOnlyMembers.Example1();

            //StaticLocalFunctions.AddExampleWithLocalFunction();
            //StaticLocalFunctions.AddExampleWithStaticLocalFunction();

            //await AsynchronousStreams.PrintEvenSequenceAsync();

            //NullCoalescingAssignment.Example3();

            //UnmanagedConstructedTypes.Example();

            StackallocInNestedExpressions.Example();
            StackallocInNestedExpressions.Example1();
        }
    }
}
