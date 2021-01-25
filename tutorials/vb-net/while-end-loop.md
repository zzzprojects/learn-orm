---
PermaID: 100017
Name: While End Loop
---

# While End Loop

In programming, developers often require a repeated execution of a sequence of operations. A loop is a basic programming construct that allows repeated execution of a fragment of source code. 

In a `While End Loop`, the code is repeated a fixed number of times or it repeats until a given condition is `true`.

Here is how a while end loop looks like:

```csharp
While condition
    'statements
End While
```

 - The while statement executes a statement or a block of statements while a specified condition evaluates to true.
 - The condition is evaluated before each execution of the loop, a while loop executes zero or more times. 

Let's consider a very simple example of using the while loop. 

```csharp
Public Sub Example1()
    Dim index As Integer = 0
    While index <= 10
        Console.Write(index.ToString & " ")
        index += 1
    End While

    Console.WriteLine("")
End Sub
```

The following example shows the use of the `Continue While` and `Exit While` statements.

```csharp
Public Sub Example2()
    Dim index As Integer = 0
    While index < 100000
        index += 1

        If index >= 5 And index <= 8 Then
            Continue While
        End If

        Console.Write(index.ToString & " ")

        If index = 10 Then
            Exit While
        End If
    End While
End Sub
```

