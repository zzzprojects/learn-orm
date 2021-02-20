---
PermaID: 100015
Name: Options
---

# Options

The option type in F# is used when an actual value might not exist for a named value or variable. An option has an underlying type and can hold a value of that type, or it might not have a value.

The following code shows a function that generates an option type.

```csharp
let keepIfPositive (a : int) = 
    if a > 0 then 
        Some(a) 
    else 
        None

Console.WriteLine(keepIfPositive 3) 
```

As you can see, if the input `a` is greater than `0`, `Some(a)` is generated. Otherwise, `None` is generated.

 - The value `None` is used when an option does not have an actual value. 
 - Otherwise, the expression `Some(...)` gives the option a value. 
 - The values `Some` and `None` are useful in pattern matching. 

The following `exists` function returns `true` if the option has a value and `false` if it does not.

```csharp
let exists (x : int option) =
    match x with
    | Some(x) -> true
    | None -> false

Console.WriteLine(exists (Some (11)))
Console.WriteLine(exists (Some (30)))
Console.WriteLine(exists None) 
```

## Option Properties and Methods

The option type supports the following properties and methods.

| Property or Method | Type           | Description                              |
| :------------------| :--------------| :----------------------------------------|
| None               | `'T option`   | A static property that enables you to create an option value that has the `None` value. |
| IsNone             | `bool`        | Returns true if the option has the `None` value. |
| IsSome             | `bool`        | Returns true if the option has a value that is not `None`. |
| Some               | `'T option`   | A static member that creates an option that has a value that is not `None`. |
| Value              | `'T`          | Returns the underlying value, or throws a System.NullReferenceException if the value is `None`. |

## Using Options

Options are commonly used when a search does not return a matching result, as shown in the following code.

```csharp
let rec tryFindMatch pred list =
    match list with
    | head :: tail -> if pred(head)
                        then Some(head)
                        else tryFindMatch pred tail
    | [] -> None

let result1 = tryFindMatch (fun elem -> elem = 100) [ 200; 100; 50; 25 ]
let result2 = tryFindMatch (fun elem -> elem = 26) [ 200; 100; 50; 25 ]

Console.WriteLine(result1) 
Console.WriteLine(result2) 
```
