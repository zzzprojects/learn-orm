---
PermaID: 100041
Name: Events
---

# Events

Events enable you to associate function calls with user actions and are important in GUI programming. Events can also be triggered by your applications or by the operating system.

 - Events allow objects to communicate with one another through a kind of synchronous message passing. 
 - Events are simply hooks to other functions: objects register callback functions to an event, and these callbacks will be executed when (and if) the event is triggered by some object.
 - In GUI, events are user actions like a keypress, clicks, mouse movements, etc., or some occurrence like system generated notifications. Applications need to respond to events when they occur.

## Defining Events

In F#, you can create and use events through F#'s [Event](https://docs.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2010/ee370608(v=vs.100)?redirectedfrom=MSDN) class. 

The following example creates an event using the `Event` constructor.

```csharp
type Author(name : string) =
    let mutable _name = name;
    let nameChanged = new Event<string>()
    
    member this.Name
        with get() = _name
        and set(value) = _name <- value
```

To allow listeners to hook onto your event, we need to expose the `nameChanged` field as a public member using the event's `Publish` property as shown below.

```csharp
type Author(name : string) =
    let mutable _name = name;

    //creates event
    let nameChanged = new Event<unit>()
    
    //exposed event handler
    member this.NameChanged = nameChanged.Publish
    
    member this.Name
        with get() = _name
        and set(value) =
            _name <- value

            //invokes event handler
            nameChanged.Trigger()
```

Now, any object can listen to the changes in the author's method.

## How to Add Callbacks to Event Handlers

It is very easy to add callbacks to event handlers. Each event handler has the type `IEvent<'T>` which exposes several methods.

```csharp
let p = new Author("Mark")
p.NameChanged.Add(fun () -> printfn "-- Name changed! New name: %s" p.Name)

printfn "Event handling is easy"
p.Name <- "Andy"

printfn "It handily decouples objects from one another"
p.Name <- "John"

p.NameChanged.Add(fun () -> printfn "-- Another handler attached to NameChanged!")

printfn "It's also causing programs to behave non-deterministically."
p.Name <- "Mike"

printfn "The function NameChanged is invoked effortlessly."
```

Now when you execute the above code you will see the following output.

```csharp
Event handling is easy
-- Name changed! New name: Andy
It handily decouples objects from one another
-- Name changed! New name: John
It's also causing programs to behave non-deterministically.
-- Name changed! New name: Mike
-- Another handler attached to NameChanged!
The function NameChanged is invoked effortlessly.
```

When multiple callbacks are connected to a single event, they are executed in the order they are added. However, in practice, you should not write code with the expectation that events will trigger in a particular order, as doing so can introduce complex dependencies between functions.
