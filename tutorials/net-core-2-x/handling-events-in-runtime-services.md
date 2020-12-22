---
PermaID: 100018
Name: Handling Events in Runtime Services
---

# Handling Events in Runtime Services

Most of the time you may want to monitor your application's use of runtime services, such as the GC, JIT, and ThreadPool, to understand how they impact your application. 

 - On Windows systems, this is commonly done by monitoring the ETW events of the current process. 
 - While this continues to work well, it is not always possible to use ETW if you are running in a low-privilege environment or on Linux or macOS.

In .NET Core 2.2, CoreCLR events can now be consumed using the `System.Diagnostics.Tracing.EventListener` class. 

 - These events describe the behavior of such runtime services as GC, JIT, ThreadPool, and interop. 
 - These are the same events that are exposed as part of the CoreCLR ETW provider.
 - This allows for applications to consume these events or use a transport mechanism to send them to a telemetry aggregation service. 

The following example shows how to subscribe to events in the following code sample.

```csharp
internal sealed class SimpleEventListener : EventListener
{
    // Called whenever an EventSource is created.
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        // Watch for the .NET runtime EventSource and enable all of its events.
        if (eventSource.Name.Equals("Microsoft-Windows-DotNETRuntime"))
        {
            EnableEvents(eventSource, EventLevel.Verbose, (EventKeywords)(-1));
        }
    }

    // Called whenever an event is written.
    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        // Write the contents of the event to the console.
        Console.WriteLine($"ThreadID = {eventData.OSThreadId} ID = {eventData.EventId} Name = {eventData.EventName}");
        for (int i = 0; i < eventData.Payload.Count; i++)
        {
            string payloadString = eventData.Payload[i]?.ToString() ?? string.Empty;
            Console.WriteLine($"\tName = \"{eventData.PayloadNames[i]}\" Value = \"{payloadString}\"");
        }
        Console.WriteLine("\n");
    }
}
```

In .NET Core 2.2 the following two properties are also added to the `EventWrittenEventArgs` class to provide additional information about ETW events:

 - `EventWrittenEventArgs.OSThreadId`
 - `EventWrittenEventArgs.TimeStamp`