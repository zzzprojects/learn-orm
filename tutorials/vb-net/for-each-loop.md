---
PermaID: 100018
Name: For Each Loop
---

# For Each Loop

The `For Each Loop` allows you to easily traverse all elements in an array to access all stored values.

 - It iterates over all elements of an array, list, or other collection of elements. 
 - It passes through all the elements of the specified collection even if the collection is not indexed.

Here is how a foreach loop looks like:

```csharp
For Each item As String In list
    'statements
Next
```

As you can see, it is significantly simpler than the standard `For Next Loop` and therefore is very often preferred by developers because it saves writing when you need to go through all the elements of a given collection.

## Example

Let's consider a very simple example of using the `For Each Loop` 

```csharp
Public Sub Example1()
    Dim websites As String() = New String(4) {"Google", "YouTube", "Facebook", "Baidu", "Yahoo"}

    For Each site As String In websites
        Console.WriteLine(site)
    Next
End Sub
```

In the above example, an array of website names (strings) is created and iterate over elements, and print on the console.


Let's run the above code and it will print the following output on the console window.

```csharp
Google
YouTube
Facebook
Baidu
Yahoo!
```

Here is another example that is a little bit more complicated. A `For Each Loop` can also be used to traverse all the elements of a `Dictionary` that contains key-value pairs. 

The data types of the key and value must be specified as a comma-separated pair within `<>` (angled brackets) in the declaration.

```csharp
Public Sub Example2()
    Dim numberNames As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)()
    numberNames.Add(1, "One")
    numberNames.Add(2, "Two")
    numberNames.Add(3, "Three")

    For Each item As KeyValuePair(Of Integer, String) In numberNames
        Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value)
    Next
End Sub
```

Let's run the above example and you will see the iterator display the dictionary's key-value pair.


```csharp
Key: 1, Value: One
Key: 2, Value: Two
Key: 3, Value: Three
```
