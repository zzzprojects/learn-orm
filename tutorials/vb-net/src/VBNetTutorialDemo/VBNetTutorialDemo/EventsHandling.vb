Module EventsHandling
    Dim WithEvents ec As New EventClass
    Sub Example1()

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
