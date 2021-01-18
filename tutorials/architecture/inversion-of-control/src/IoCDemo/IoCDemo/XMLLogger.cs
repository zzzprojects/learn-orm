using System;
using System.Collections.Generic;
using System.Text;

namespace IoCDemo
{
    public class XMLLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Inside Log method of XMLLogger.");
            LogToXML(message);
        }
        private void LogToXML(string message)
        {
            Console.WriteLine("Method: LogToXML, Text: {0}", message);
        }
    }
}
