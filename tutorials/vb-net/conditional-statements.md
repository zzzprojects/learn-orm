---
PermaID: 100030
Name: Conditional Statements
---

# Conditional Statements

The `If...Then` and `If...Then...Else` are conditional control statements. Using conditional statements, the program can behave differently based on a defined condition checked during the statement's execution.

## If...Then

The `If...Then` is the simplest form of control statement, frequently used in decision making and changing the control flow of the program execution.

The basic syntax of the `If...Then` statement is shown below.

```csharp
If condition Then 
    [Statement(s)]
End If
```

An `If...Then` statement consists of an expression that determines whether a program statement or
statements execute.

The following example shows the usage of a simple `If...Then` statement.

```csharp
Dim num1 As Integer = 7
Dim num2 As Integer = -1

If num1 > 0 Then
    Console.WriteLine("num1 is valid.")
End If

If num2 < 0 Then
    Console.WriteLine("num2 is not valid.")
End If
```

## If...Then...Else

In an `If...Then...Else` statement, if the condition evaluates to `true`, the **Body of the conditional statement** runs. If the condition is `false`, the else-statement runs. 

The basic syntax of the `If...Then...Else` statement is shown below.

```csharp
If condition Then
    [ statement(s) ]
Else
    [ elsestatement(s) ]
End If
```

It conditionally executes a group of statements, depending on the value of an expression.

The following example shows the usage of a simple `If...Then...Else` statement.

```csharp
Public Sub Example2()
    Dim randomizer As New Random()
    Dim count As Integer = randomizer.Next(0, 5)

    Dim message As String

    If count = 0 Then
        message = "There are no items."
    Else
        message = $"There are {count} items."
    End If

    Console.WriteLine(message)
End Sub
```

## Multiple If...Then...Else Statements

In some cases, we need to use a sequence of `If...Then` structures or multiple `If...Then...Else` statements, where the `Else` clause is a new `If` structure. 

 - If we use nested `If` structures, the code would be pushed too far to the right. 
 - In such situations, it is allowed to use a new `If` right after the `Else` and it is considered a good practice. 

```csharp
Public Sub Example3()
    Dim marks As Integer = 79

    If marks >= 90 Then
        Console.WriteLine("A+")
    ElseIf marks >= 80 Then
        Console.WriteLine("A")
    ElseIf marks >= 70 Then
        Console.WriteLine("B")
    ElseIf marks >= 60 Then
        Console.WriteLine("C")
    ElseIf marks >= 50 Then
        Console.WriteLine("D")
    Else
        Console.WriteLine("F")
    End If
End Sub
```

In the above example, a series of comparisons of a variable `marks` to check `If...Then`, it is one of the grades (such as A+, A, B, C, or D). Every following comparison is done only in the case that the previous comparison was not `true`. In the end, if none of the `If...Then` conditions are not fulfilled, the last `Else` clause is executed. 

The result of the above example is shown below.

```csharp
B
```
