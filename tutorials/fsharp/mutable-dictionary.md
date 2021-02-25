---
PermaID: 100027
Name: Mutable Dictionary
---

# Mutable Dictionary

You may already know the `System.Collections.Generic.Dictionary` type from C# or VB.NET. The `Dictionary<'TKey, 'TValue>` class acts as a standard lookup collection, allowing fast retrieval of values based on a unique key. 

 - It is the mutable analog of the F# map data structure and contains many of the same functions.
 - The .NET (mutable) dictionaries are created using the `new` keyword.

The following example creates a dictionary by calling its constructor as shown below.

```csharp
let myDictionary = new Dictionary<string, string>()

myDictionary.Add("txt", "notepad.exe");
myDictionary.Add("bmp", "paint.exe");
myDictionary.Add("dib", "paint.exe");
myDictionary.Add("rtf", "wordpad.exe");

printfn "Dictionary: %A" myDictionary
```

The following are the most commonly used properties in the `Dictionary<'TKey, 'TValue>` class.

| Property               | Description                                                                                       |
| :----------------------| :-------------------------------------------------------------------------------------------------|
| Comparer               | Gets the `IEqualityComparer<T>` that is used to determine equality of keys for the dictionary.      |
| Count                  | Gets the number of key/value pairs contained in the `Dictionary<TKey,TValue>`.                      |
| Item[TKey]             | Gets or sets the value associated with the specified key.                                         |
| Keys                   | Gets a collection containing the keys in the `Dictionary<TKey,TValue>`.                             |
| Values                 | Gets a collection containing the values in the `Dictionary<TKey,TValue>`.                           |

The following are the most commonly used functions in the `Dictionary<'TKey, 'TValue>` class.

| Function               | Description                                                                                       |
| :----------------------| :-------------------------------------------------------------------------------------------------|
| Add                    | Adds the specified key and value to the dictionary.                        |
| Clear                  | Removes all keys and values from the `Dictionary(TKey, TValue)`.         |
| ContainsKey            | Determines whether the `Dictionary(TKey, TValue)` contains the specified key. |
| ContainsValue          | Determines whether the `Dictionary(TKey, TValue)` contains a specific value.  |
| Equals                 | Determines whether the specified object is equal to the current object. |
| Finalize               | Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection. |
| Remove                 | Removes the value with the specified key from the `Dictionary(TKey, TValue)`. |
| ToString               | Returns a string that represents the current object. 
| TryGetValue            | Gets the value associated with the specified key.

The following example uses some of these properties functions.

```csharp
let capitals = new Dictionary<string, string>()

capitals.Add("Canada", "Ottawa")
capitals.Add("China", "Beijing")
capitals.Add("Russia", "Moscow")
capitals.Add("USA", "Washington D.C.")

printfn"Total %d capitals" capitals.Count
printfn "Capitals: %A" capitals

let capitalOfRussia = capitals.["Russia"]

//printfn ""
printfn "Capital of Russia: %s" capitalOfRussia
//printfn ""

capitals.Remove("China") |> ignore

printfn"Total %d capitals" capitals.Count
printfn "Capitals: %A" capitals
```
