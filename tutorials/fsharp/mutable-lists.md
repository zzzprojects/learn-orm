---
PermaID: 100026
Name: Mutable Lists
---

# Mutable Lists

The `List<'T>` class represents a strongly typed list of objects that can be accessed by index. It is a mutable counterpart of the List class.

 - Conceptually, the `List<'T>` class similar to arrays, but unlike arrays, lists can be resized and don't need to have their size specified on the declaration.
 - The NET lists are created using the `new` keyword.

The following example creates a list by calling its constructor as shown below.

```csharp
let myList = new List<string>()

myList.Add("one")
myList.Add("two")
myList.Add("three")

myList |> Seq.iteri (fun index item -> Console.WriteLine("{0}: {1}", index, myList.[index]))
```

The `List<'T>` class is just a fancy wrapper for an array. 

 - When a `List<'T>` is constructed, it creates a 4-element array in memory. 
 - Adding the first 4 items is an `O(1)` operation. 
 - However, as soon as the 5th element needs to be added, the list doubles the size of the internal array, which means it has to reallocate new memory and copy elements in the existing list. 
 - It is an `O(n)` operation, where `n` is the number of items in the list.

The following are the most commonly used functions in the `List<'T>` class.

| Function               | Description                                                                                       |
| :----------------------| :-------------------------------------------------------------------------------------------------|
| Add                    | Adds an object to the end of the list. |
| AddRange               | Adds the elements of the specified collection to the end of the list. |
| Clear                  | Removes all elements from the list. |
| Contains               | Determines whether an element is in the list. |
| ConvertAll             | Converts the elements in the current list to another type, and returns a list containing the converted elements. |
| CopyTo                 | Copies the entire list to a compatible one-dimensional array, starting at the beginning of the target array. |
| Equals                 | Determines whether the specified object is equal to the current object. |
| Exists                 | Determines whether the list contains elements that match the conditions defined by the specified predicate. |
| Find                   | Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire list.
| FindAll                | Retrieves all the elements that match the conditions defined by the specified predicate.
| ForEach                | Performs the specified action on each element of the list. |
| IndexOf                | Searches for the specified object and returns the zero-based index of the first occurrence within the entire list. |
| Insert                 | Inserts an element into the list at the specified index. |
| InsertRange            | Inserts the elements of a collection into the list at the specified index. |
| Remove                 | Removes the first occurrence of a specific object from the list. |
| RemoveAll              | Removes all the elements that match the conditions defined by the specified predicate. |
| RemoveAt               | Removes the element at the specified index of the list. |
| RemoveRange            | Removes a range of elements from the list. |
| Reverse                | Reverses the order of the elements in the entire list. |
| Sort                   | Sorts the elements in the entire list using the default comparer. |
| ToArray                | Copies the elements of the list to a new array. |
| ToString               | Returns a string that represents the current object. |

The following example uses some of these functions.

```csharp
let months = new List<string>()

months.Add("January")
months.Add("February")
//months.Add("March")
months.Add("April")
months.Add("May")
months.Add("June")
months.Add("July")
months.Add("August")
months.Add("September")
months.Add("October")
months.Add("November")
months.Add("December")

printfn"Total %d months" months.Count
months |> Seq.iteri (fun index item -> printfn "%i: %s" index months.[index])
months.Insert(2, "March")

printfn("after inserting at index 2")
printfn"Total %d months" months.Count

months |> Seq.iteri (fun index item -> printfn "%i: %s" index months.[index])
months.RemoveAt(3)

printfn("after removing from index 3")
printfn"Total %d months" months.Count

months |> Seq.iteri (fun index item -> printfn "%i: %s" index months.[index])
```
