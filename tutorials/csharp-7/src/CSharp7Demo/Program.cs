using System;
using System.Threading.Tasks;

namespace CSharp7Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //PatternMatching.IsTypePatternExample();

            //ThrowExpressions.Example1();
            //ThrowExpressions.Example2();

            //BinaryLiterals.Example();

            //DigitSeparators.Example1();
            //DigitSeparators.Example2();
            //DigitSeparators.Example3();

            //AsyncReutrnTypes.PrintRandomNumberUsingValueTask();

            //var helloWorld = await GetHelloWorldAsync();
            //Console.WriteLine(helloWorld);

            //Tuples.Example();
            //Tuples.Example1();
            //Tuples.Example2();
            //Tuples.Example3();
            //Tuples.Example4();
            //Tuples.Example5();

            //ReadonlyReferences.Example1();

            //NonTrailingNamedArguments.Example1();

            //PrivateProtected.Example();

            //ConditionalRefExpression.Example1();
            //ConditionalRefExpression.Example2();

            //UnmanagedGenericConstraints.Example();
            //IndexingFixedFieldsWithoutPinning.Example();

            //FixedPattern.Example();
            //FixedPattern.FixedSpanExample();
            //FixedPattern.Example1();

            //RefReturnsAndRefLocals.Example();

            //StackallocArrayInitializers.Example1();
            //StackallocArrayInitializers.Example3();

            //TupleEqualityAndInequality.Example1();
            //TupleEqualityAndInequality.Example2();
            TupleEqualityAndInequality.Example3();
        }

        static Task<string> GetHelloWorldAsync()
        {
            return Task.FromResult("Hello Async World");
        }
    }
}
