---
PermaID: 100028
Name: Select Case
---

# Select Case

The `Select...Case` allows you to test a variable for equality against a set of values. 

 - Each value is referred to as a case, and a variable that is being switched on should be checked for all the select cases.
 - It executes one of several groups of statements, depending on the value of an expression.
 - It is only suitable for use when a variable in question has only a limited number of options.

The basic syntax of the `Select...Case` statement is shown below.

```csharp
Select [ Case ] testexpression  
    [ Case expressionlist  
        [ statements ] ]  
    [ Case Else  
        [ elsestatements ] ]  
End Select
```

## Terms

### `testexpression`	

It is a required expression and must evaluate to one of the elementary data types such as `Boolean`, `Byte`, `Char`, `Date`, `Double`, `Decimal`, `Integer`, `Long`, `Object`, `SByte`, `Short`, `Single`, `String`, `UInteger`, `ULong`, and `UShort`.
 
### `expressionlist`	

It is required in a `Case` statement. The list of expression clauses representing match values for `testexpression`. Multiple expression clauses are separated by commas. Each clause can take one of the following forms.

 - `expression1 To expression2`
 - [`Is`] comparisonoperator expression
 - `expression`

### `statements`

It is an optional and one or more statements following `Case` that run if `testexpression` matches any clause in `expressionlist`.

### `elsestatements`

It is also an optional and one or more statements following `Case Else` that run if `testexpression` does not match any clause in the `expressionlist` of any of the `Case` statements.

Let's consider the following simple example of a `Select...Case` statement.

```csharp
Public Sub Example1()
    Dim caseSwitch As Integer = 1

    Select Case caseSwitch
        Case 1
            Console.WriteLine("Case 1")
        Case 2
            Console.WriteLine("Case 2")
        Case Else
            Console.WriteLine("Default case")
    End Select
End Sub
```

You can also use multiple expressions or ranges in each `Case` clause as shown below.

```csharp
Case 1 To 4, 7 To 9, 11, 13, Is > maxNumber
```

The following example uses a `Select Case` to write a message based on the value of the variable `number`. 

```csharp
Public Sub Example2()
    Dim number As Integer = 8
    Select Case number
        Case 1, 2, 3
            Debug.WriteLine("Between 1 and 3")
        Case 4 To 8
            Debug.WriteLine("Between 4 and 8")
        Case Is <= 15
            Debug.WriteLine("Between 9 and 15")
        Case Else
            Debug.WriteLine("Greater than 15")
    End Select
End Sub
Module
```

