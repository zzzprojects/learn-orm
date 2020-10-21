---
PermaID: 100036
Name: Events
---

# Events

An event is a message or you can say a notification that is sent by an object to signal the occurrence of an action. 

 - The action can be caused by user interaction, such as a button click, or it can result from some other program logic, such as changing a property's value. 
 - The object that raises the event is called the event sender or publisher, and the object who receives the notification is called the receiver or subscriber. 
 - The event sender doesn't know which object or method will receive or handle the events it raises. 
 - In C#, an event is dependent on the delegate, the delegate defines the signature for the event handler method of the subscriber class.

Let's consider the following example, we declare an event named `ThresholdReached`. The event is associated with the `EventHandler` delegate and raised in a method named `OnThresholdReached`.

```csharp
public event EventHandler ThresholdReached;

protected virtual void OnThresholdReached(EventArgs e)
{
    EventHandler handler = ThresholdReached;
    if (handler != null)
    {
        handler(this, e);
    }
}
```

C# provides the `EventHandler` and `EventHandler<TEventArgs>` delegates to support most event scenarios. The following code shows how to raise the event. 

```csharp
class Counter
{
    public event EventHandler ThresholdReached;

    protected virtual void OnThresholdReached(EventArgs e)
    {
        EventHandler handler = ThresholdReached;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    private int total;

    public void Add(int x)
    {
        total += x;

        Console.WriteLine("Count: "+ total);
        if (total == 7)
        {
            Console.WriteLine("Event raised...");
            OnThresholdReached(EventArgs.Empty);
        }
    }
}
```

It contains a class named `Counter` that has an event named `ThresholdReached`. This event is raised when a counter value equals to `7`. When the event is raised, it will be handled by the following method.

```csharp
static void c_ThresholdReached(object sender, EventArgs e)
{
    Console.WriteLine("Event received.");
}
```

The above example shows an event handler method named `c_ThresholdReached` that matches the signature for the `EventHandler` delegate.

The following code registers the `ThresholdReached` event and starts the counter and increment it in a `for` loop.

```csharp
Counter c = new Counter();
c.ThresholdReached += c_ThresholdReached;

for (int i = 0; i < 10; i++)
{
    c.Add(1);
}
```

Let's run the above code and you will see the following code.

```csharp
Count: 1
Count: 2
Count: 3
Count: 4
Count: 5
Count: 6
Count: 7
Event raised...
Event received.
Count: 8
Count: 9
Count: 10
```

For more information about events, visit [https://docs.microsoft.com/en-us/dotnet/standard/events/](https://docs.microsoft.com/en-us/dotnet/standard/events/)

All the examples related to the events are available in the `Events.cs` file of the source code. Download the source code and try out all the examples for better understanding.
