---
PermaID: 100038
Name: Events Handling
---

# Events Handling

An event is a signal that informs an application that something important has occurred. For example, when a user clicks a control on a form, the form can raise a `Click` event and call a procedure that handles the event. Events also allow separate tasks to communicate. 

## Declaring Events

You declare events within classes, structures, modules, and interfaces using the `Event` keyword as shown below.

```csharp
Public Event AnEvent()
```

## Raising Events

An event is like a message announcing that something important has occurred. The act of broadcasting the message is called raising the event. In Visual Basic, you raise events with the `RaiseEvent` statement.

```csharp
RaiseEvent AnEvent()
```

Events must be raised within the scope of the class, module, or structure where they are declared. For example, a derived class cannot raise events inherited from a base class.

## Event Senders

Any object capable of raising an event is an event ***sender***, also known as an ***event source***. Forms, controls, and user-defined objects are examples of event senders.

## Event Handlers

Event handlers are procedures that are called when a corresponding event occurs. You can use any valid subroutine with a matching signature as an event handler. You cannot use a function as an event handler, however, because it cannot return a value to the event source.

Visual Basic uses a standard naming convention for event handlers that combines the name of the event sender, an underscore, and the name of the event. For example, the `Click` event of a button named `button1` would be named `Sub button1_Click`.

## Associating Events with Event Handlers

The event handler becomes usable when you associate it with an event by using either the `Handles` or `AddHandler` statement.

```csharp
Dim WithEvents ec As New EventClass
```

### AddHandler and RemoveHandler

The `AddHandler` statement allows you to specify an event handler and `RemoveHandler` removes the event handler. 

 - The `AddHandler`, used with `RemoveHandler`, provides greater flexibility by allowing you to dynamically add, remove, and change the event handler associated with an event. 
 - If you want to handle shared events or events from a structure, you must use `AddHandler`.

The following example shows how an event handler is associated with an event, and the event is raised. The event handler catches the event and displays a message.

```csharp
Module EventsHandling
    Sub Example1()
        Dim ec As New EventClass

        ' Associate an event handler with an event.
        AddHandler ec.AnEvent, AddressOf EventHandler1

        ' Call a method to raise the event.
        ec.CauseTheEvent()

        ' Stop handling the event.
        RemoveHandler ec.AnEvent, AddressOf EventHandler1

        ' Now associate a different event handler with the event.
        AddHandler ec.AnEvent, AddressOf EventHandler2

        ' Call a method to raise the event.
        ec.CauseTheEvent()

        ' Stop handling the event.
        RemoveHandler ec.AnEvent, AddressOf EventHandler2

        ' This event will not be handled.
        ec.CauseTheEvent()
    End Sub

    Sub EventHandler1()
        ' Handle the event.
        Console.WriteLine("EventHandler1 caught event.")
    End Sub

    Sub EventHandler2()
        ' Handle the event.
        Console.WriteLine("EventHandler2 caught event.")
    End Sub

    Public Class EventClass
        ' Declare an event.
        Public Event AnEvent()
        Sub CauseTheEvent()
            ' Raise an event.
            RaiseEvent AnEvent()
        End Sub
    End Class
End Module
```

Once the event is raised then the first event handler is removed and a different event handler is associated with the event. When the event is raised again, a different message is displayed.

Finally, the second event handler is removed and the event is raised for the third time. Because there is no longer an event handler associated with the event, no action is taken.