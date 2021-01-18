using System;

namespace IoCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            CustomerService service = new CustomerService(logger);
            service.Log("Hello World!, it will log to the text file.\n");

            logger = new DatabaseLogger();
            service = new CustomerService(logger);
            service.Log("Hello World!, it will log to the database.\n");

            logger = new XMLLogger();
            service = new CustomerService(logger);
            service.Log("Hello World!, it will log to the XML file.\n");
        }
    }
}
