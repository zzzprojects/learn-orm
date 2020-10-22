using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorialDemo
{
    public class ExceptionHandling
    {
        public static void TryCatchExample1()
        {
            try
            {
                var num = int.Parse("6");

                Console.WriteLine("The number is {0}", num);

                // let's specify an alphabet in the parse method and see the result.
                var num1 = int.Parse("a");

                Console.WriteLine($"The number is {0}", num);

            }
            catch
            {
                Console.Write("Error occurred.");
            }
            finally
            {
                Console.Write("It will be executed always because I am in finally block.");
            }
        }

        public static void TryCatchExample2()
        {
            try
            {
                var num = int.Parse("6");

                Console.WriteLine("The number is {0}", num);

                // let's specify an alphabet in the parse method and see the result.
                var num1 = int.Parse("a");

                Console.WriteLine($"The number is {0}", num);

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                Console.Write("\nIt will be executed always because I am in finally block.");
            }
        }

        public static void TryCatchExample3()
        {
            try
            {
                var num = int.Parse("6");

                Console.WriteLine("The number is {0}", num);

                // let's specify an alphabet in the parse method and see the result.
                var num1 = int.Parse("a");

                Console.WriteLine($"The number is {0}", num);

            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                Console.Write("\nIt will be executed always because I am in finally block.");
            }
        }
    }
}
