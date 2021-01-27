---
PermaID: 100014
Name: Do Loop
---

# Do Loop

The `Do Loop` which is also known as `do-while` repeats a block of statements while a `Boolean` condition is `True` or until the condition becomes `True`. The `do-while` loop is the same as the `while` loop, but the only difference is `while` loop will execute the statements only when the defined condition returns true. Still, the `do-while` loop will execute the statements at least once because it will first execute the block of statements and then check the condition.

 - Use a `Do Loop` structure when you want to repeat a set of statements an indefinite number of times until a condition is satisfied. 
 - You can use either `While` or `Until` to specify conditions, but not both.
 - You can test the condition only one time, at either the start or the end of the loop. 
 - If you test conditions at the start of the loop, the loop might not run even once. 
 - If you test at the end of the loop, the loop always runs at least one time.

The following example shows the `Do Loop` by using the `While` to specify the condition.

```csharp
Dim index As Integer = 0
Do
    Console.WriteLine(index.ToString & " ")
    index += 1
Loop While index <= 10
```

The following example behaves in the same way but uses an `Until` clause instead of a `While` clause.

```csharp
Dim index As Integer = 0
Do
    Console.WriteLine(index.ToString & " ")
    index += 1
Loop Until index > 10
```

In the following example, the condition stops the loop when the index variable is greater than 100. However, the If statement in the loop causes the Exit Do statement to stop the loop when the index variable is greater than 10.

```csharp
Dim index As Integer = 0
Do While index <= 100
    If index > 10 Then
        Exit Do
    End If

    Console.WriteLine(index.ToString & " ")
    index += 1
Loop
```
