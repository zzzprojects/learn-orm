---
PermaID: 100021
Name: Sets
---

# Sets

A set in F# is just a container for items. Sets do not preserve the order in which items are inserted, nor do they allow duplicate entries to be inserted into the collection.

The `Set` module contains a useful function `Set.empty` which returns an empty set to start with and you can add an item to that empty set using the `Add` function.

```csharp
let set1 = Set.empty.Add('a').Add('b').Add('c')

Console.WriteLine(set1)
```

Conveniently, all instances of sets have an `Add` function. The `Add` returns a new set containing a new item, which makes it easy to add items together in this fashion.

You can convert lists and sequences into sets using use `Set.ofList` and `Set.ofSeq` to convert an entire collection into a set.

```csharp
let months = Set.ofList ["January"; "February"; "March"; "April"; "May"; "June"; "July"; "August"; "September"; "October"; "November"; "December"]
let numbers = Set.ofSeq [ 1 .. 2.. 10 ]
```

The `FSharp.Collections.Set` module contains a variety of useful methods for working with sets. 


| Function                    | Description                                                                     |
| :---------------------------| :-------------------------------------------------------------------------------|
| Add                         | Add the value to the set.                                                       |
| Contains                    | Returns `True` if the set contains a value, otherwise `False`.                   |
| Count                       | The number of elements in the set.                       |
| IsEmpty                     | Returns `True` if the set is empty, otherwise `False`. |
| IsProperSubsetOf            | Evaluates to `true` if all elements of the first set are in the second, and at least one element of the second is not in the first. |
| IsProperSupersetOf          | Evaluates to `true` if all elements of the second set are in the first, and at least one element of the first is not in the second. |
| IsSubsetOf                  | Evaluates to `true` if all elements of the first set are in the second.                          |
| IsSupersetOf                | Evaluates to `true` if all elements of the second set are in the first.                          |
| MaximumElement              | Returns the highest element in the set according to the ordering being used for the set.          |
| MinimumElement              | Returns the lowest element in the set according to the ordering being used for the set.           |
| Remove                      | Remove the value from the set.                                                                    |

The following example shows some of the methods.

```csharp
let a = Set.ofSeq [ 1 .. 10 ]
let b = Set.ofSeq [ 5 .. 15 ]

let c = Set.intersect a b
let d = Set.union a b
let e = Set.difference a b
```
 