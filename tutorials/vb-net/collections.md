---
PermaID: 100035
Name: Collections
---

# Collections

In many applications, you will need to manage groups of related objects. There are two ways to group objects: by creating arrays of objects, and by creating collections of objects.

 - Arrays are most useful for creating and working with a fixed number of strongly typed objects. For information about arrays, see Arrays.
 - Collections provide a more flexible way to work with groups of objects. Unlike arrays, the group of objects you work with can grow and shrink dynamically as the needs of the application change. 

For some collections, you can assign a key to any object that you put into the collection so that you can quickly retrieve the object by using the key.

A collection is a class, so you must declare an instance of the class before you can add elements to that collection.

## Types

Many common collections are provided by the .NET Framework. Each type of collection is designed for a specific purpose.

Some of the common collection classes are described in this section:

 - [System.Collections.Generic classes](#systemcollectionsgeneric-classes)
 - [System.Collections classes](#systemcollections-classes)
 - [System.Collections.Concurrent classes](#systemcollectionsconcurrent-classes)
 - [Visual Basic Collection class](#visual-basic-collection-class)

### System.Collections.Generic Classes

You can create a generic collection by using one of the classes in the `System.Collections.Generic` namespace. 

 - A generic collection is useful when every item in the collection has the same data type. 
 - It enforces strong typing by allowing only the desired data type to be added.

The following table lists some of the frequently used classes of the System.Collections.Generic namespace:

| Class                 | Description                                                                     |
| :---------------------| :-------------------------------------------------------------------------------|
| Dictionary<TKey,TValue> | Represents a collection of key/value pairs that are organized based on the key.|
| List<T>               | Represents a list of objects that can be accessed by index. Provides methods to search, sort, and modify lists. |
| Queue<T>              | Represents a first-in, first-out (FIFO) collection of objects.|
| SortedList<TKey,TValue> | Represents a collection of key/value pairs that are sorted by key based on the associated IComparer<T> implementation. |
| Stack<T>              | Represents a last-in, first-out (LIFO) collection of objects. |

The following example shows how to create and initialize a `List` and how to display its values.

```csharp
Dim customers As List(Of Customer) = New List(Of Customer)()
customers.Add(New Customer With {
    .Id = 1,
    .Name = "John"
})
customers.Add(New Customer With {
    .Id = 2,
    .Name = "Mark"
})
customers.Add(New Customer With {
    .Id = 3,
    .Name = "Stella"
})

For Each customer In customers
    Console.WriteLine("{0}, {1}", customer.Id, customer.Name)
Next
```

### System.Collections Classes

The classes in the `System.Collections` namespace do not store elements as specifically typed objects but as objects of type `Object`.

The following table lists some of the frequently used classes in the `System.Collections` namespace:

| Class                 | Description                                                                     |
| :---------------------| :-------------------------------------------------------------------------------|
| ArrayList             | Represents an array of objects whose size is dynamically increased as required. |
| Hashtable             | Represents a collection of key/value pairs that are organized based on the hash code of the key. |
| Queue                 | Represents a first-in, first-out (FIFO) collection of objects.                  |
| Stack                 | Represents a last-in, first-out (LIFO) collection of objects.                   |

The following example shows how to create and initialize an `ArrayList` and how to display its values.

```csharp
Dim myAL As ArrayList = New ArrayList()
myAL.Add("Hello")
myAL.Add("World")
myAL.Add("!")
Console.WriteLine("myAL")
Console.WriteLine("    Count:    {0}", myAL.Count)
Console.WriteLine("    Capacity: {0}", myAL.Capacity)
Console.Write("    Values:")

For Each obj As Object In myAL
    Console.Write("   {0}", obj)
Next
```

### System.Collections.Concurrent Classes

The collections in the `System.Collections.Concurrent` namespace provide efficient thread-safe operations for accessing collection items from multiple threads.

 - The classes in the `System.Collections.Concurrent` namespace should be used instead of the corresponding types in the `System.Collections.Generic` and `System.Collections` namespaces whenever multiple threads are accessing the collection concurrently. 
 - Some classes included in the `System.Collections.Concurrent` namespace are `BlockingCollection<T>`, `ConcurrentDictionary<TKey,TValue>`, `ConcurrentQueue<T>`, and `ConcurrentStack<T>`.

### Visual Basic Collection Class

A Visual Basic Collection is an ordered set of items that can be referred to as a unit. It can be used to access a collection item by using either a numeric index or a String key. 

 - You can add items to a collection object either with or without specifying a key. 
 - If you add an item without a key, you must use its numeric index to access it.
 - It stores all its elements as the type `Object`, so you can add an item of any data type. 
 - When you use the Visual Basic Collection class, the first item in a collection has an index of 1. 
 - This differs from the .NET Framework collection classes, for which the starting index is 0.

The following example shows how to create and initialize a `Microsoft.VisualBasic.Collection` and how to display its values.

```csharp
Dim customers As New Microsoft.VisualBasic.Collection()
customers.Add(New Customer With {
    .Id = 1,
    .Name = "John"
}, "1")
customers.Add(New Customer With {
    .Id = 2,
    .Name = "Mark"
}, "2")
customers.Add(New Customer With {
    .Id = 3,
    .Name = "Stella"
}, "3")

For Each customer In customers
    Console.WriteLine("{0}, {1}", customer.Id, customer.Name)
Next
```

Whenever possible, you should use the generic collections in the System.Collections.Generic namespace or the System.Collections.Concurrent namespace instead of the Visual Basic Collection class. 