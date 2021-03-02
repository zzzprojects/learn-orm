---
PermaID: 100029
Name: Delegates
---

# Delegates

A delegate represents a function call as an object. A delegate is a reference type variable that holds the reference to a method. The reference can be changed at runtime.

The basic syntax of Delegate in F# is as follows.

```csharp
type delegate-typename = delegate of type1 -> type2
```

The `type1` represents the argument type or types, and `type2` represents the return type. The argument types that are represented by `type1` are automatically curried.

The following code shows a simple usage of a delegate.


```csharp
type Deligate() =  
    static member add(a : int, b : int) =  
        a + b  
    member x.Add(a : int, b : int) =  
        a + b  

type Multiply = delegate of (int * int) -> int  

let getIt (d : Multiply) (a : int) (b: int) =  
   d.Invoke(a, b)  

let d : Multiply = new Multiply( Deligate.add )  

for (a, b) in [(5, 8) ] do  
  printfn "%d + %d = %d" a b (getIt d a b)
```

The following code shows some of the different ways you can work with delegates.

```csharp
type Delegate1 = delegate of int * char -> string

let replicate n c = String.replicate n (string c)

let function1 = replicate

let delObject = Delegate1(function1)

let functionValue = delObject.Invoke

List.map (fun c -> functionValue(5,c)) ['a'; 'b'; 'c']|> List.iter (printfn "%s")

let replicate' n c =  delObject.Invoke(n,c)

let stringArray = System.Array.ConvertAll([|'a';'b'|], fun c -> replicate' 3 c)
printfn "%A" stringArray
```
