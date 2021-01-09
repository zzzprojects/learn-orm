using System;
using System.Collections;

namespace CSharpTutorialDemo
{
    public class Collections
    {
        public static void ArrayListExample()
        {
            // Creates and initializes a new ArrayList.
            ArrayList myArrayList = new ArrayList();

            myArrayList.Add("This is a C# Tutorial.");
            myArrayList.Add(DateTime.Today);
            myArrayList.Add(2);

            // Display the values of the ArrayList.
            foreach (Object obj in myArrayList)
            {
                Console.WriteLine("{0}", obj);
            }
        }

        public static void StackExample()
        {
            Stack myStack = new Stack();

            myStack.Push("Mark");
            myStack.Push("John");
            myStack.Push("Andy");

            while (myStack.Count != 0)
            {
                Console.WriteLine("{0}", myStack.Pop());
            }

        }

        public static void HashtableExample()
        {
            Hashtable tutorials = new Hashtable();

            tutorials.Add("1", "C# Tutorial");
            tutorials.Add("2", "SQL Server Tutorial");
            tutorials.Add("3", "EF Tutorial");

            foreach (DictionaryEntry tutorial in tutorials)
            {
                Console.WriteLine(tutorial.Key + ", " + tutorial.Value);

            }
        }
    }
}
