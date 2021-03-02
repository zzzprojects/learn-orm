---
PermaID: 100022
Name: Maps
---

# Maps

A map is a special kind of set, it associates keys with values. A map is created similarly as a set.

```csharp
let capitals =
    Map.empty.
        Add("Canada", "Ottawa").
        Add("China", "Beijing").
        Add("Russia", "Moscow").
        Add("USA", "Washington D.C.");
```

The `FSharp.Collections.Map` module contains a variety of useful methods for working with maps. 

| Function                    | Description                                                                     |
| :---------------------------| :-------------------------------------------------------------------------------|
| Add(key, value)             | Returns a new map with the binding added to the given map. If a binding with the given key already exists in the input map, the existing binding is replaced by the new binding in the resulting map. |
| Change(key, f)              | Returns a new map with the value stored under key changed according to `f`. |
| ContainsKey(key)            | Tests if an element is in the domain of the map. |
| Count                       | The number of bindings on the map. |
| IsEmpty                     | Returns true if there are no bindings in the map. |
| [key]                       | Lookup an element in the map. Raise `KeyNotFoundException` if no binding exists in the map.  |
| Remove(key)                 | Removes an element from the domain of the map. No exception is raised if the element is not present. |
| TryFind(key)                | Lookup an element in the map, returning a Some value if the element is in the map domain and None if not. |
| TryGetValue(key, value)     | Lookup an element in the map, assigning to value if the element is in the map domain and returning false if not. |

The following example uses the `.[key]` to access elements in the map.

```csharp
let capital = capitals.["Canada"];

Console.WriteLine("The capital of Canada is {0}", capital)
```

You can also convert the list to a map using the following syntax.

```csharp
let capitals1 = 
    [("Canada", "Ottawa"); ("China", "Beijing");
        ("Denmark", "Copenhagen"); ("Egypt", "Cairo"); 
        ("France", "Paris"); ("Germany", "Berlin"); 
        ("Japan", "Tokyo"); ("Russia", "Moscow");
        ("Spain", "Madrid"); ("Sweden", "Stockholm");
        ("Taiwan", "Taipei"); ("USA", "Washington D.C.")]
    |> Map.ofList
```

You can also use the `TryFind` method to get the value of a particular key.

```csharp
let found = capitals1.TryFind "France"
match found with
| Some x -> printfn "Found %s." x
| None -> printfn "Did not find the specified value."
```
