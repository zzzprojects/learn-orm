---
PermaID: 100022
Name: Continue Statement
---

# Continue Statement

A `Continue` statement can be included in any kind of loop to immediately terminate that particular iteration of the loop when a test condition is met. 

 - The `Continue` statement allows the loop to proceed to the next iteration.
 - It stops the current iteration of the inner loop, without terminating the loop. 
 - You can transfer from inside a `Do`, `For`, or `While` loop to the next iteration of that loop. 
 - Control passes immediately to the loop condition test, which is equivalent to transferring to the `For` or `While` statement, or to the `Do` or `Loop` statement that contains the `Until` or `While` clause.
 - You can use `Continue` at any location in the loop that allows transfers. 

In the following example, a counter is initialized to count from 0 to 10. The `Continue For` statement is executed when the boolean expression `If i > 3 AndAlso i < 8 Then` is `true`. 

```csharp
Public Sub Example1()
    For i As Integer = 0 To 10
        If i > 3 AndAlso i < 8 Then
            Continue For
        End If
        Console.WriteLine("Counter: {0}", i)
    Next
End Sub
```

The statements inside the `For Loop` after the `Continue For` statement are skipped in the iterations where `i` is greater than 3 and `i` is less than 8. 

Let's run the above code and it will print the following output on the console window.

```csharp
Counter: 0
Counter: 1
Counter: 2
Counter: 3
Counter: 8
Counter: 9
Counter: 10
```

Let's consider another simple example of `Continue While` statement.

```csharp
Public Sub Example2()
    Dim i As Integer = 0
    While i < 10
        If i = 6 Then
            Console.WriteLine(" Skipped number is {0}", i)
            i += 1
            Continue While
        End If
        Console.WriteLine(" Value of i is {0}", i)
        i += 1
    End While
End Sub
```

Let's run the above code and it will print the following output on the console window.

```csharp
Value of i is 0
Value of i is 1
Value of i is 2
Value of i is 3
Value of i is 4
Value of i is 5
Skipped number is 6
Value of i is 7
Value of i is 8
Value of i is 9
```