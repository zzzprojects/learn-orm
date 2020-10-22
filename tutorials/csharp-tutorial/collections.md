---
PermaID: 100037
Name: Collections
---

# Collections

In C#, the collections represent the `System.Collections` namespace which contains interfaces and classes that define various collections of objects, such as `ArrayList`, `Stack`, `Hashable and `Queue`, etc.

 - For many applications, you want to create and manage groups of related objects.
 - Collections provide a more flexible way to work with groups of objects.
 - The classes in the `System.Collections` namespace do not store elements as specifically typed objects but as objects of type `Object`.

The following table lists some of the frequently used classes in the `System.Collections` namespace.

| Class           | Description                                                                |
|:----------------|:---------------------------------------------------------------------------|
| ArrayList       | Represents an array of objects whose size is dynamically increased as required. |
| Hashtable       | Represents a collection of key/value pairs that are organized based on the hash code of the key. |
| Queue           | Represents a first-in, first-out (FIFO) collection of objects.                |
| SortedList      | Represents a collection of key/value pairs that are sorted by the keys and are accessible by key and by index. |
| Stack           | Represents a last-in, first-out (LIFO) collection of objects.                |

In `System.Collections` classes, each element can represent a value of a different type. The collection size is not fixed. Items from the collection can be added or removed at runtime. 

The following example shows how to create and initialize an ArrayList and how to display its values.

```csharp
// Creates and initializes a new ArrayList.
ArrayList myArrayList = new ArrayList();

myArrayList.Add("This is a C# Tutorial.");
myArrayList.Add(DateTime.Today);
myArrayList.Add(2);

// Display the values of the ArrayList.
foreach (Object obj in myArrayList)
{
    Console.WriteLine("{0}", obj);
}
```

As you can see that we have added different types of data to the array list. The first data is `string`, then we have added `DataTime` object and the last one is an integer.

Let's run the above code and you will see the following code.

```csharp
This is a C# Tutorial.
10/21/2020 12:00:00 AM
2
```

Let's take a look at the following example, it shows how to create and add values to a Stack and how to display its values.

```csharp
Stack myStack = new Stack();

myStack.Push("Mark");
myStack.Push("John");
myStack.Push("Andy");

while (myStack.Count != 0)
{
    Console.WriteLine("{0}", myStack.Pop());
}
```

Let's run the above code and you will see the following code.

```csharp
Andy
John
Mark
```

Let's consider another example of a hash table`, it is similar to an array list but represents the items as a combination of a key and value.

```csharp
Hashtable tutorials = new Hashtable();

tutorials.Add("1", "C# Tutorial");
tutorials.Add("2", "SQL Server Tutorial");
tutorials.Add("3", "EF Tutorial");

foreach (DictionaryEntry tutorial in tutorials)
{
    Console.WriteLine(tutorial.Key + ", " + tutorial.Value);

}
```

Let's run the above code and you will see the following code.

```csharp
1, C# Tutorial
2, SQL Server Tutorial
3, EF Tutorial
```

For more information about collections, visit [https://docs.microsoft.com/en-us/dotnet/api/system.collections](https://docs.microsoft.com/en-us/dotnet/api/system.collections)

All the examples related to the collections are available in the `Collections.cs` file of the source code. Download the source code and try out all the examples for better understanding.
