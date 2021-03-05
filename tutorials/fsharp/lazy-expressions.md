---
PermaID: 100045
Name: Lazy Expressions
---

# Lazy Expressions

Lazy expressions are expressions that are not evaluated immediately but are evaluated when the result is needed. 

 - It enables you to improve performance by restricting the execution of an expression to only those situations in which a result is needed.
 - This can help to improve the performance of your code.

The basic syntax of the laze expressions is as follows.

```csharp
let identifier = lazy ( expression )
```

 - The `expression` is a code that is evaluated only when a result is required, and `identifier` is a value that stores the result.
 - The value is of type `Lazy<'T>`, where the actual type that is used for `'T` is determined from the result of the expression.

## How to Execute the Expression

To force the expressions to be performed, you will need to call the `Force` method. 

 - The `Force` method causes the execution to be performed only one time. 
 - Subsequent calls to `Force` return the same result but do not execute any code.

The following example shows the usage of lazy expressions and the use of the `Force` method. 

```csharp
let input = 39.6
let result = lazy (input * 10.0/12.0)
printfn "%f" (result.Force())
```

In the above code, the type of result is `Lazy<float>`, and the `Force` method returns a `float`.
