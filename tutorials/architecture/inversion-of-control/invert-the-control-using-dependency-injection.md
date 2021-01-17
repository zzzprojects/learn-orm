---
PermaID: 100004
Name: Invert the Control using Dependency Injection
---

# Invert the Control using Dependency Injection

Dependency Injection (DI) is a software design pattern, which is used for achieving Inversion of Control (IoC) between classes and their dependencies.

You can take advantage of dependency injection to pass an instance of a concrete logger class using constructor injection as shown below.

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCDemo
{
    public class CustomerService
    {
        private readonly ILogger _logger;
        public CustomerService(ILogger logger)
        {
            _logger = logger;
        }
        public void Log(string message)
        {
            _logger.Log(message);
        }
    }
}
```

Now to use the logging, we need to pass the `ILogger` interface to the `CustomerService` class. Let's create an instance of the `FileLogger` class and use constructor injection to pass the dependency.

```csharp
using System;

namespace IoCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            CustomerService service = new CustomerService(logger);
            service.Log("Hello World!, it will log to the text file.");
        }
    }
}
```

Now if you want to use the `DatabaseLogger`, you don't need to change the implementation of the `CustomerService` class, but you will only need to create an instance of `DatabaseLogger` and pass it to the `CustomerService` constructor.

```csharp
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
```
 
Let's run your application and you will see the following output.

```csharp
Inside Log method of FileLogger.
Method: LogToFile, Text: Hello World!, it will log to the text file.

Inside Log method of DatabaseLogger.
Method: LogToDatabase, Text: Hello World!, it will log to the database.

Inside Log method of XMLLogger.
Method: LogToXML, Text: Hello World!, it will log to the XML file.
```

