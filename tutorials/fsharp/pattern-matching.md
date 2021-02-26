---
PermaID: 100031
Name: Pattern Matching
---

# Pattern Matching

Pattern matching is used for control flow and for transforming input data. It allows you to look at a value, test it against a series of conditions, and perform certain computations depending on whether that condition is met. 

 - The pattern matching is conceptually similar to a series of `if ... then` statements in other languages. 
 - F#'s pattern matching is much more flexible and powerful.

The basic syntax of pattern matching is as follows.

```csharp
match expr with
    | pattern1 -> result1
    | pattern2 -> result2
    | pattern3 [ when condition ] -> result3
    | _ -> defaultResult
```

 - Each `|` defines a condition. 
 - The `->` means if the condition is true, return this value. 
 - The `_` is the default pattern, meaning that it matches anything, sort of like a wildcard.

The following example shows the usage of pattern matching.

```csharp
type Category =
   | Sports = 0
   | Arts = 1
   | Clothing = 2
   | Electronics = 3
   | HealthCare = 4

let printCategoryName (category:Category) =
    match category with
    | Category.Sports -> Console.WriteLine("Selected Category: Sports")
    | Category.Arts -> Console.WriteLine("Selected Category: Arts")
    | Category.Clothing -> Console.WriteLine("Selected Category: Clothing")
    | Category.Electronics -> Console.WriteLine("Selected Category: Electronics")
    | Category.HealthCare -> Console.WriteLine("Selected Category: HealthCare")
    | _ -> ()

printCategoryName Category.Arts
printCategoryName Category.HealthCare
printCategoryName Category.Electronics
```

You can also chain together multiple conditions which return the same value as shown below.

```csharp
let greeting name =
    match name with
    | "Steve" | "Kristina" | "Matt" -> Console.WriteLine("Hello! {0}", name)
    | "Carlos" | "Maria" -> Console.WriteLine("Hola! {0}", name)
    | "Worf" -> Console.WriteLine("nuqneH! {0}", name)
    | "Pierre" | "Monique" -> Console.WriteLine("Bonjour! {0}", name)
    | _ -> Console.WriteLine("DOES NOT COMPUTE! {0}", name)

greeting "Monique"
greeting "Kristina"
greeting "Sakura"
```

It will print the following output on the console.

```csharp
Bonjour! Monique
Hello! Kristina
DOES NOT COMPUTE! Sakura
```
