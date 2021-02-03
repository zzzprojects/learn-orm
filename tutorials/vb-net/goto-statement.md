---
PermaID: 100023
Name: GoTo Statement
---

# GoTo Statement

The `GoTo` statement transfers control unconditionally to a specified line in a procedure.

 - The `GoTo` statement can branch only to lines in the procedure in which it appears. 
 - The line must have a line label that `GoTo` can refer to.

The basic syntax of the `GoTo` statement looks like as shown below.

```csharp
GoTo line
```

## Label a Line

Place an identifier, followed by a colon, at the beginning of the line of source code.

```csharp
Line1:
```
Labels can be used only on executable statements inside methods.

You cannot use a `GoTo` statement to branch from outside a `For...Next`, `For Each...Next`, `SyncLock...End SyncLock`, `Try...Catch...Finally`, `With...End With`, or `Using...End Using` construction to a label inside.

## Branching and Try Constructions

Within a `Try...Catch...Finally` construction, the following rules apply to branching with the `GoTo` statement.


| Block or region    | Branching in from outside                 | Branching out from inside                 |
| :------------------| :-----------------------------------------| :-----------------------------------------|
| **Try block**      | Only from a `Catch` block of the same construction | Only to outside the whole construction |
| **Catch block**    | Never allowed                             | Only to outside the whole construction, or to the `Try` block of the same construction |
| **Finally block**  | Never allowed                             | Never allowed                                  |


The following example uses the `GoTo` statement to branch to line labels.

```csharp
Module GoToStatement
    Public Sub Example1()
        Dim number As Integer = 1
        Dim sampleString As String

        If number = 1 Then
            GoTo Line1
        Else
            GoTo Line2
        End If
Line1:
        sampleString = "Number equals 1"
        GoTo LastLine
Line2:
        sampleString = "Number equals 2"
LastLine:
        Console.WriteLine(sampleString)
    End Sub
End Module
```