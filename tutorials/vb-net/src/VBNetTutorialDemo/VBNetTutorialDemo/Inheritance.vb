Module Inheritance
    Class Animal
        Public Property Name As String

        Public Sub New(ByVal name As String)
            name = name
        End Sub

        Public Sub PrintName()
            Console.WriteLine(Name)
        End Sub
    End Class

    Class Cat
        Inherits Animal

        Public Sub New(ByVal name As String)
            MyBase.New(name)
        End Sub

        Public Sub Meow()
            Console.WriteLine("Meow!")
        End Sub
    End Class

    Class Dog
        Inherits Animal

        Public Sub New(ByVal name As String)
            MyBase.New(name)
        End Sub

        Public Sub Bark()
            Console.WriteLine("Bark!")
        End Sub
    End Class

    Public Sub Example1()
        Dim cat As Cat = New Cat("Stanley")
        Dim dog As Dog = New Dog("Jackie")
        cat.PrintName()
        cat.Meow()
        dog.PrintName()
        dog.Bark()
    End Sub
End Module
