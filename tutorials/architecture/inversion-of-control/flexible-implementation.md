---
PermaID: 100003
Name: Flexible Implementation
---

# Flexible Implementation

The solution to the problem specified in the previous article is to use an interface that the concrete logger classes would implement. 

Let's create an interface called `ILogger` and replace the following code. 

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCDemo
{
    public interface ILogger
    {
        void Log(string message);
    }
}

```

Now we will implement this interface in our concrete classes `FileLogger`, `XMLLogger`, and `DatabaseLogger`.

Here is the updated `FileLogger` class.

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCDemo
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Inside Log method of FileLogger.");
            LogToFile(message);
        }
        private void LogToFile(string message)
        {
            Console.WriteLine("Method: LogToFile, Text: {0}", message);
        }
    }
}
```

Update the `XMLLogger` class as shown below.

```csharp
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
```

Similarly, update the `DatabaseLogger` class as well.

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCDemo
{
    public class DatabaseLogger : ILogger
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

You can now use or change the concrete implementation of the `ILogger` interface whenever necessary. The following code shows the `CustomerService` class calling the `Log` method.

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCDemo
{
    public class CustomerService
    {
        public void Log
        {
            ILogger logger = new DatabaseLogger();
            logger.Log(message);
        }
    }
}
```

Its better now, but the only problem is that if you want to use the `FileLogger` or `XMLLogger` instead of `DatabaseLogger`, you could change the implementation of the `Log` method in the `CustomerService` class to meet the requirement, but that doesn't make the design flexible. 

To make the design more flexible, we will use inversion of control and dependency injection.