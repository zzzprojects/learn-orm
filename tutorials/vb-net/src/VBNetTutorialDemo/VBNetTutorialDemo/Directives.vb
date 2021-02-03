Module Directives
#Const MyLocation = "USA"
#Const Version = 10.0
    Sub ConstDirective()
#If Version > 9.0 Then
        Console.WriteLine("Latest version installed")
#Else
        Console.WriteLine("Latest version not installed")
#End If

    End Sub

    Sub ExternalSourceDirective()

#ExternalSource ("c:\vbprogs\directives.vb", 5)
        Console.WriteLine("This is External Code. ")
#End ExternalSource

    End Sub
End Module
