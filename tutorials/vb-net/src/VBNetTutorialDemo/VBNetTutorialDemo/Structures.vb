Module Structures
    Public Structure Point3D
        Public X As Integer
        Public Y As Integer
        Public Z As Integer
    End Structure

    Public Structure CustomerInfo
        Public Id As Integer
        Public Name As String
        Public Address As String

        Public Sub New(ByVal id As Integer, ByVal name As String, ByVal address As String)
            Me.Id = id
            Me.Name = name
            Me.Address = address
        End Sub

        Public Sub Print()
            Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", Me.Id, Me.Name, Me.Address)
        End Sub

    End Structure

    Public Sub Example1()
        Dim point1 As Point3D
        Dim point2 As Point3D = New Point3D()
        point1.X = 10
        point1.Y = 20
        point1.Z = 30
        point2.X = 40
        point2.Y = 50
        point2.Z = 60
        Console.WriteLine("X: {0}, Y: {1}, Z: {2}", point1.X, point1.Y, point1.Z)
        Console.WriteLine("X: {0}, Y: {1}, Z: {2}", point2.X, point2.Y, point2.Z)
    End Sub

    Public Sub Example2()
        Dim customer As CustomerInfo = New CustomerInfo(1, "Mark", "22 wall street")
        Console.WriteLine("Id: {0}, Name: {1}, Address: {2}", customer.Id, customer.Name, customer.Address)
    End Sub

    Public Sub Example3()
        Dim customer As CustomerInfo = New CustomerInfo(1, "Mark", "22 wall street")
        customer.Print()
    End Sub
End Module
