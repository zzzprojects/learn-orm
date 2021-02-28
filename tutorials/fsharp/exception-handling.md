---
PermaID: 100032
Name: Exception Handling
---

# Exception Handling

Exception handling is the standard way of handling error conditions in the .NET Framework. Thus, any .NET language must support this mechanism, including F#. 

 - An exception is an object that encapsulates information about an error. 
 - When errors occur, exceptions are raised and regular execution stops. 
 - The `try...with` expression is used for exception handling in the F# language.
 - The `try...finally` expression enables you to execute clean-up code even if a block of code throws an exception.

## `try...with` Expression

The basic syntax of the `try...with` expression is as follows.

```csharp
try
    expression1
with
| pattern1 -> expression2
| pattern2 -> expression3
...
```

The `try...with` expression is used to handle exceptions in F#. It is similar to the `try...catch` statement in C#.

 - In the above syntax, the code in `expression1` might generate an exception. 
 - The `try...with` expression returns a value, if no exception is thrown, the whole expression returns the value of `expression1`. 
 - If an exception is thrown, each pattern is compared in turn with the exception, and for the first matching pattern, the corresponding expression, known as the exception handler, for that branch is executed, and the overall expression returns the value of the expression in that exception handler.

The following example shows the usage of the `try...with` expression.

```csharp
let divide1 x y =
   try
      Some (x / y)
   with
      | :? System.DivideByZeroException -> printfn "Division by zero!"; None

let result1 = divide1 100 0
```

Exceptions can be .NET exceptions, or they can be F# exceptions. You can define F# exceptions by using the `exception` keyword.

You can use a variety of patterns to filter on the exception type and other conditions as shown below.

| Pattern               | Description                                                                                |
| :---------------------| :------------------------------------------------------------------------------------------|
| `:? exception-type` | Matches the specified .NET exception type.                                                 |
| `:? exception-type as identifier` | Matches the specified .NET exception type, but gives the exception a named value. |
| `exception-name(arguments)` | Matches an F# exception type and binds the arguments.                             |
| `identifier`         | Matches any exception and binds the name to the exception object. Equivalent to `:? System.Exception as identifier` |
| `identifier when condition` | Matches any exception if the condition is true. |

The following example shows the use of the `as` keyword to assign a name to a .NET exception.

```csahrp
let divide2 x y =
  try
    Some( x / y )
  with
    | :? System.DivideByZeroException as ex -> printfn "Exception! %s " (ex.Message); None

let result2 = divide1 100 0
```

The following example shows the use of a condition to branch to multiple paths with the same exception.

```csharp
let divide3 x y flag =
  try
     x / y
  with
     | ex when flag -> printfn "TRUE: %s" (ex.ToString()); 0
     | ex when not flag -> printfn "FALSE: %s" (ex.ToString()); 1

let result2 = divide3 100 0 true
```

You can also use the F# exceptions as shown in the below example.

```csharp
exception Error1 of string
exception Error2 of string * int

let function1 x y =
   try
      if x = y then raise (Error1("x"))
      else raise (Error2("x", 10))
   with
      | Error1(str) -> printfn "Error1 %s" str
      | Error2(str, i) -> printfn "Error2 %s %d" str i

function1 10 10
function1 9 2
```

## `try...finally` Expression

The basic syntax of the `try...finally` expression is as follows.

```csharp
try
    expression1
finally
    expression2
```

The `try...finally` expression can be used to execute the code in `expression2` regardless of whether an exception is generated during the execution of `expression1`.

The following example shows the usage of the `try...finally` expression.

```csharp
let divide x y =
   let stream : System.IO.FileStream = System.IO.File.Create("test.txt")
   let writer : System.IO.StreamWriter = new System.IO.StreamWriter(stream)
   try
      writer.WriteLine("test1");
      Some( x / y )
   finally
      writer.Flush()
      printfn "Closing stream"
      stream.Close()

let result =
  try
     divide 100 0
  with
     | :? System.DivideByZeroException -> printfn "Exception handled."; None
```

The `try...with` is a separate construct from the `try...finally` construct. Therefore, if your code requires both, you have to nest the two constructs as shown below.

```csharp
exception InnerError of string
exception OuterError of string

let function2 x y =
   try
     try
        if x = y then raise (InnerError("inner"))
        else raise (OuterError("outer"))
     with
      | InnerError(str) -> printfn "Error1 %s" str
   finally
      printfn "Always print this."


let function3 x y =
  try
     function2 x y
  with
     | OuterError(str) -> printfn "Error2 %s" str

function3 100 100
function3 100 10
```
