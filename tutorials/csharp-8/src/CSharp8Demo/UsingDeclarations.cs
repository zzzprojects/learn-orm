using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharp8Demo
{
    public class UsingDeclarations
    {
        public static void WriteToFileUsingStatement()
        {
            List<string> lines = new List<string>()
            {
                "First line.",
                "Second line",
                "Third line."
            };

            using (var file = new StreamWriter("TestFile.txt"))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(line);
                }
            } // file is disposed here
        }

        public static void WriteToFileUsingDeclaration()
        {
            List<string> lines = new List<string>()
            {
                "First line.",
                "Second line",
                "Third line."
            };

            using var file = new StreamWriter("TestFile.txt");
            
            foreach (string line in lines)
            {
                file.WriteLine(line);
            }
        }// file is disposed here
    }
}
