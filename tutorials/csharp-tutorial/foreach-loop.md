---
PermaID: 100016
Name: Foreach Loop
---

# Foreach Loop

C# provides a special `foreach-loop` statement that allows you to easily traverse all elements in an array to access all stored values.

 - The `foreach-loop` which is extended `for-loop` is new for the C/C++/C# family of languages but is well known for the VB and PHP programmers. 
 - It iterates over all elements of an array, list, or other collection of elements (`IEnumerable`). 
 - It passes through all the elements of the specified collection even if the collection is not indexed.

Here is how a foreach loop looks like:

```csharp
foreach (type variable in collection)
{
    statements;
}
```

As you can see, it is significantly simpler than the standard `for-loop` and therefore is very often preferred by developers because it saves writing when you need to go through all the elements of a given collection.

## Example

Let's consider a very simple example of using the `for` loop. 

```csharp
string[] websites = new string[5] { "Google", "YouTube", "Facebook", "Baidu", "Yahoo!" };

foreach (string site in websites)
{
    Console.WriteLine(site);
}
```

In the above example, an array of website names (strings) is created and iterate over elements, and print them on the console.


Let's run the above code and it will print the following output on the console window.

```csharp
Google
YouTube
Facebook
Baidu
Yahoo!
```

Here is another example that is a little bit more complicated. A `foreach` statement can also be used to traverse all the elements of a C# `Dictionary` that contains key-value pairs. 
The data types of the key and value must be specified as a comma-separated pair within `<>` (angled brackets) in the declaration.

```csharp
Dictionary<int, string> numberNames = new Dictionary<int, string>();

numberNames.Add(1, "One"); 
numberNames.Add(2, "Two");
numberNames.Add(3, "Three");

foreach (KeyValuePair<int, string> item in numberNames)
{
    Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
}
```

Let's run the above example and you will see the iterator display the dictionary's key-value pair.


```csharp
Key: 1, Value: One
Key: 2, Value: Two
Key: 3, Value: Three
```

All the examples related to the `foreach` loop are available in the `ForeachLoop.cs` file of the source code. Download the source code and try out all the examples for better understanding.
