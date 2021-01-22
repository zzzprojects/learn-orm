---
PermaID: 100015
Name: For Next Loop
---

# For Next Loop

The `For Next Loop` is used to repeatedly execute a sequence of code or a block of code until a given condition is satisfied. It is useful in such a case when we know how many times a block of code has to be executed.

You use a `For Next Loop` when you want to repeat some statements a set number of times.

In the following example, the `index` variable starts with a value of 1 and is incremented with each iteration of the loop, ending after the value of index reaches 10.

```csharp
Public Sub Example1()
    For index As Integer = 1 To 10
        Console.Write(index.ToString & ", ")
    Next

    Console.WriteLine("")
End Sub

```

Let's consider another example in which the `number` variable starts at 5 and is reduced by 0.5 on each iteration of the loop, ending after the value of `number` reaches 0. The `Step` argument of -.5 reduces the value by 0.5 on each iteration of the loop.

```csharp
Public Sub Example2()
    For number As Double = 5 To 0 Step -0.5
        Console.Write(number.ToString & ", ")
    Next
    Console.WriteLine("")
End Sub

```

## Nesting Loops

You can also nest `For Next` loops by putting one loop within another. 

The following example shows nested `For Next` loops that have different step values. 

```csharp
Public Sub Example3()
    For indexA = 1 To 3
        Dim sb As New System.Text.StringBuilder()
        For indexB = 20 To 1 Step -2
            sb.Append(indexB.ToString)
            sb.Append(" ")
        Next indexB

        Console.WriteLine(sb.ToString)
    Next indexA
End Sub
```

The outer loop creates a string for every iteration of the loop. The inner loop decrements a loop counter variable for every iteration of the loop.

When nesting loops, each loop must have a unique counter variable.

## Exit For and Continue For

The `Exit For` statement immediately exits the `For Next` loop and transfers control to the statement that follows the `Next` statement.

The `Continue For` statement transfers control immediately to the next iteration of the loop. 

The following example shows the use of the `Continue For` and `Exit For` statements.

```csharp
Public Sub Example4()
    For index As Integer = 1 To 100000

        If index >= 5 AndAlso index <= 8 Then
            Continue For
        End If

        Console.Write(index.ToString & " ")

        ' If index is 10, exit the loop.
        If index = 10 Then
            Exit For
        End If
    Next
    Console.WriteLine("")
End Sub
```

You can put any number of `Exit For` statements in a `For Next` loop. When used within nested `For Next` loops, `Exit For` exits the innermost loop and transfers control to the next higher level of nesting.

`Exit For` is often used after you evaluate some condition such as, an `If...Then...Else` structure. 