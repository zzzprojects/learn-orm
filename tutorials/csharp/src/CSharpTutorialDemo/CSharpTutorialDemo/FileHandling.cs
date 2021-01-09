using System;
using System.IO;

namespace CSharpTutorialDemo
{
    public class FileHandling
    {
        public static void SimpleReadWriteExample()
        {
            string writeText = "This is a C# Tutorial, and you are learning file handling.";

            // Create a file and write the content of writeText to it
            File.WriteAllText("test.txt", writeText);

            // Read the contents from the file
            string readText = File.ReadAllText("test.txt");

            Console.WriteLine(readText);
        }

        public static void FileExistsExample()
        {
            string path = @"D:\MyTest.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("File doesn't exist, we will create a file first.\n");

                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("This is a C# Tutorial,");
                    sw.WriteLine("and you are learning");
                    sw.WriteLine("file handling.");
                }
            }
            else
            {
                Console.WriteLine("File already exists, no need to create it.\n");
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
