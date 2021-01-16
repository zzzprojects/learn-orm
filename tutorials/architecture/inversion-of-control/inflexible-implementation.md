---
PermaID: 100002
Name: Inflexible Implementation
---

# Inflexible Implementation

Now if you want to add the support of database for logging. The existing implementation wouldn't support this and you would be compelled to change the implementation. You can either change the implementation of the FileLogger class, or you can add a new class and implement the database support.

Let's add a new class file named `DatabaseLogger.cs` and add the following code.

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCDemo
{
    public class DatabaseLogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Inside Log method of DatabaseLogger.");
            LogToDatabase(message);
        }
        private void LogToDatabase(string message)
        {
            Console.WriteLine("Method: LogToDatabase, Text: {0}", message);
        }
    }
}
```

Similarly, you can also add another target for logging such as XML, JSON, etc. Let's add a new class file named `XMLLogger.cs` and add the following code.

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCDemo
{
    public class XMLLogger
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
```

You can create an instance of the `DatabaseLogger` and `XMLLogger` classes inside the `CustomerService` class as shown below.

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCDemo
{
    public class CustomerService
    {
        private readonly FileLogger _fileLogger = new FileLogger();
        private readonly DatabaseLogger _databaseLogger = new DatabaseLogger();
        private readonly XMLLogger _xmlLogger = new XMLLogger();

        public void LogToFile(string message)
        {
            _fileLogger.Log(message);
        }
        public void LogToDatabase(string message)
        {
            _databaseLogger.Log(message);
        }
        public void LogToXML(string message)
        {
            _xmlLogger.Log(message);
        }
    }
}
```

As you can see that we have added support for the database and XML, but this design is not flexible and you will need to change the `CustomerService` class every time you need to log to a new log target. 

It is not only cumbersome but also will make it extremely difficult for you to manage the `CustomerService` class over time.