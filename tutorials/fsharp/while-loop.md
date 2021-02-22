---
PermaID: 100011
Name: While Loop
---

# While Loop

The `while...do` expression is used to perform iterative execution while a specified test condition is true.

The basic syntax of the `while...do` loop is as follows.

```csharp
while test-expression do
    body-expression
```

The `test-expression` is evaluated; if it is `true`, the `body-expression` is executed, and the test expression is re-evaluated. The `body-expression` must have the type `unit`. If the test expression is `false`, the iteration ends.

The following example shows the usage of the `while...do` expression.

```csharp
let mutable aa = 10
while (aa < 20) do
   printfn "value of aa: %d" aa
   aa <- aa + 1
```

When you execute the above code, you will see the following output.

```csharp
value of aa: 11
value of aa: 12
value of aa: 13
value of aa: 14
value of aa: 15
```

## Nested While Loop

F# programming language allows you to use one loop inside another loop which is known as a nested loop.

```csharp
let mutable a=1;      
while(a<=3) do    
    let mutable b = 1;    
    while (b <= 3)  do  
        Console.WriteLine("{0}   {1}", a, b)     
        b<- b+1  
    a<- a+1  
```

When you execute the above code, you will see the following output.

```csharp
1   1
1   2
1   3
2   1
2   2
2   3
3   1
3   2
3   3
```
