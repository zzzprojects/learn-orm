---
PermaID: 100021
Name: Exit Statement
---

# Exit Statement

The `Exit` statement exits a procedure or block and transfers control immediately to the statement following the procedure call or the block definition.

The basic syntax of the `Exit` statement looks like as shown below.

```csharp
Exit { Do | For | Function | Property | Select | Sub | Try | While }
```

## Statements

### Exit Do

 - It immediately exits the `Do` loop in which it appears. 
 - The execution continues with the statement following the Loop statement. 
 - The `Exit Do` can be used only inside a `Do` loop. 
 - When used within nested `Do` loops, `Exit Do` exits the innermost loop and transfers control to the next higher level of nesting.

### Exit For

 - It immediately exits the `For` loop in which it appears.
 - The execution continues with the statement following the `Next` statement. 
 - The `Exit For` can be used only inside a `For...Next` or `For Each...Next` loop. 
 - When used within nested `For` loops, `Exit For` exits the innermost loop and transfers control to the next higher level of nesting.

### Exit Function

 - It immediately exits the `Function` procedure in which it appears. 
 - The execution continues with the statement following the statement that is called the `Function` procedure. 
 - The `Exit Function` can be used only inside a `Function` procedure.
 - To specify a return value, you can assign the value to the function name on a line before the `Exit Function` statement. 
 - To assign the return value and exit the function in one statement, you can instead use the `Return` Statement.

### Exit Property

 - It immediately exits the `Property` procedure in which it appears. 
 - The execution continues with the statement that is called the `Property` procedure, that is, with the statement requesting or setting the property's value. 
 - The `Exit Property` can be used only inside a property's `Get` or `Set` procedure.
 - To specify a return value in a Get procedure, you can assign the value to the function name on a line before the Exit Property statement. To assign the return value and exit the Get procedure in one statement, you can instead use the Return statement.
 - In a `Set` procedure, the `Exit Property` statement is equivalent to the `Return` statement.

### Exit Select

 - It immediately exits the `Select Case` block in which it appears. 
 - The execution continues with the statement following the End Select statement. Exit Select can be used only inside a Select Case statement.

### Exit Sub

 - It immediately exits the Sub procedure in which it appears. 
 - The execution continues with the statement following the statement that is called the `Sub` procedure. 
 - The `Exit Sub` can be used only inside a `Sub` procedure.
 - In a `Sub` procedure, the `Exit Sub` statement is equivalent to the `Return` statement.

### Exit Try

 - It immediately exits the `Try` or `Catch` block in which it appears. 
 - The execution continues with the `Finally` block if there is one, or with the statement following the `End Try` statement otherwise. 
 - The `Exit Try` can be used only inside a Try or Catch block, and not inside a Finally block.

### Exit While

 - It immediately exits the `While` loop in which it appears. 
 - The execution continues with the statement following the `End While` statement. 
 - The `Exit While` can be used only inside a `While` loop. 
 - When used within nested `While` loops, the `Exit While` transfers control to the loop that is one nested level above the loop where `Exit While` occurs.

The following example shows that the loop stops using the `Exit Do` statement when the `index` variable is greater than 10. 

```csharp
Public Sub Example1()
    Dim index As Integer = 0
    Do While index <= 100
        If index > 10 Then
            Exit Do
        End If

        Console.Write(index.ToString & " ")
        index += 1
    Loop
End Sub
```

The following example assigns the return value to the function name Subtract, and then uses `Exit Function` to return from the function.

```csharp
Function Subtract(num1 As Integer, num2 As Integer) As Integer
    Subtract = num1 - num2
    Exit Function
End Function
```
