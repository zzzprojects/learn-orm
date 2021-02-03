Public Module Subs
    Sub CalculateArea(length As Double, width As Double)
        Dim area As Double
        If length = 0 Or width = 0 Then
            ' If either argument = 0 then exit Sub immediately.
            Exit Sub
        End If

        area = length * width
        ' Print area to Immediate window.
        Console.WriteLine(area)
    End Sub
End Module
