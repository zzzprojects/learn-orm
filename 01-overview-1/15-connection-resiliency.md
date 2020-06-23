---
PermaID: 100014
Name: Connection Resiliency
---

# Connection Resiliency

Connection resiliency is the ability to automatically retry certain transient errors when attempting to connect to the database.

* In most of the applications, a database connection is always vulnerable to connection breaks due to back-end failures and network instability.
* With the rise of cloud-based database servers such as Windows Azure and connections over less reliable networks, it is now more common for connection breaks to occur.

In Entity Framework 6, we can easily deal with timeouts, deadlocks, and other transient SQL errors. In this article, we will discuss how to implement it.

## Implementation

The first step is to create a class that inherits from `DbExecutionStrategy` and overrides `ShouldRetryOn()`. Let's add a new class `MyExecutionStrategy` to the _**DAL**_ folder and add the following code.

```csharp
using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace MvcWithEF6Demo.DAL
{
    public class MyExecutionStrategy : DbExecutionStrategy
    {
        public MyExecutionStrategy()
        {
        }

        public MyExecutionStrategy(int maxRetryCount, TimeSpan maxDelay) : base(maxRetryCount, maxDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception ex)
        {
            bool retry = false;

            SqlException sqlException = ex as SqlException;
            if (sqlException != null)
            {
                int[] errorsToRetry = { 1205, -2, 2601 };

                if (sqlException.Errors.Cast<SqlError>().Any(x => errorsToRetry.Contains(x.Number)))
                {
                    retry = true;
                }
                else
                {

                }
            }
            if (ex is TimeoutException)
            {
                retry = true;
            }
            return retry;
        }
    }
}
```

The `ShouldRetryOn()` takes an `Exception` as an argument, examines it, and returns a boolean indicating to the EF context whether it should be retried after a short wait.

## Enabling an Execution Strategy

To hook it into our Entity Framework, we need to create a new class `MyDbConfiguration` that inherits from `DbConfiguration`. The easiest way to tell EF to use an execution strategy is with the `SetExecutionStrategy` method of the `DbConfiguration` class.

```csharp
using System.Data.Entity;

namespace MvcWithEF6Demo.DAL
{
    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new MyExecutionStrategy());
        }
    }
}
```

It tells EF to use the `MyExecutionStrategy` when connecting to SQL Server. The context will automatically find this class on compilation when it is just available in the assembly.

In all the controllers change the `catch` block that catches `DataException` exceptions with `RetryLimitExceededException` exceptions as shown below.

```csharp
catch (RetryLimitExceededException)
{
    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
}
```

* Previously, the `DataException` was used to try and identify errors that might be transient to give a friendly "try again" message. 
* Now we have implemented a retry policy, the only errors likely to be transient will already have been tried and failed several times.
* The actual exception returned will be wrapped in the `RetryLimitExceededException` exception.

