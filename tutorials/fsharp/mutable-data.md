---
PermaID: 100024
Name: Mutable Data
---

# Mutable Data

By default, all of the data types and values in F# are immutable which means that cannot be changed throughout a program's execution.

 - You can use the keyword mutable to specify a variable that can be changed. 
 - Mutable variables in F# should generally have a limited scope, either as a field of a type or as a local value. 
 - Mutable variables with the limited scope are easier to control and are less likely to be modified in incorrect ways.

The simplest mutable variables in F# are declared using the `mutable` keyword. You can assign an initial value to a mutable variable by using the `let` keyword in the same way as you would define a value.

```csharp
let mutable x = 1
x <- x + 1
```

The `<-` operator is used to assign a mutable variable a new value. The `mutable` keyword is frequently used with record types to create mutable records as shown in the following example

```csharp
type productData =
   { ID : int;
      mutable IsAvailable : bool;
      mutable Description : string; }

let getProduct id =
   { ID = id;
      IsAvailable = false;
      Description = null; }

let availableProducts (products : productData list) =
   products |> List.iter(fun st ->
      st.IsAvailable <- true
      st.Description <- sprintf "In Stock "

      Threading.Thread.Sleep(1000) (* Putting thread to sleep for 1 second to simulate processing overhead. *))

let printData (products : productData list) =
   products |> List.iter (fun x -> printfn "%A" x)

let main() =
   let products = List.init 4 getProduct

   printfn "Before Product Availability:"
   printData products

   printfn "After Product Availability:"
   availableProducts products
   printData products

   Console.ReadKey(true) |> ignore

main()
```

It will print the following data on the console.

```csharp
Before Product Availability:
{ ID = 0
  IsAvailable = false
  Description = null }
{ ID = 1
  IsAvailable = false
  Description = null }
{ ID = 2
  IsAvailable = false
  Description = null }
{ ID = 3
  IsAvailable = false
  Description = null }
After Product Availability:
{ ID = 0
  IsAvailable = true
  Description = "In Stock " }
{ ID = 1
  IsAvailable = true
  Description = "In Stock " }
{ ID = 2
  IsAvailable = true
  Description = "In Stock " }
{ ID = 3
  IsAvailable = true
  Description = "In Stock " }
```
