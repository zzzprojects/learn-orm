---
PermaID: 100029
Name: Queue
---

# Queue

The `Queue` class represents a first-in, first-out collection of objects. It implements a queue as a circular array. Objects stored in a Queue are inserted at one end and removed from the other.

Three main operations can be performed on a Queue and its elements:

 - **Enqueue** adds an element to the end of the Queue.
 - **Dequeue** removes the oldest element from the start of the Queue.
 - **Peek** returns the oldest element at the start of the Queue but does not remove it from the Queue.

The capacity of a Queue is the number of elements the Queue can hold. As elements are added to a Queue, the capacity is automatically increased as required through reallocation.

## Methods

The following are basic methods of the `Queue` class. 

| Method            | Description                                                        |
| :-----------------| :------------------------------------------------------------------|
| `Clear()`        | Removes all objects from the Queue.                                |
| `Clone()`        | Creates a shallow copy of the Queue.                               |
| `Contains(Object)`      | Determines whether an element is in the Queue.             |
| `CopyTo(Array, Int32)` | Copies the Queue elements to an existing one-dimensional Array, starting at the specified array index. |
| `Dequeue()`      | Removes and returns the object at the beginning of the Queue.      |
| `Enqueue(Object)` | Adds an object to the end of the Queue.                          |
| `Equals(Object)`  | Determines whether the specified object is equal to the current object. <br> (Inherited from `Object`) |
| `GetEnumerator()` | Returns an enumerator that iterates through the Queue.           |
| `GetHashCode()`   | Serves as the default hash function. <br> (Inherited from `Object`)|
| `GetType()`       | Gets the Type of the current instance. <br> (Inherited from `Object`) |
| `MemberwiseClone()` | Creates a shallow copy of the current Object. <br> (Inherited from `Object`) |
| `Peek()`          | Returns the object at the beginning of the Queue without removing it. |
| `Synchronized(Queue)` | Returns a new Queue that wraps the original queue, and is thread-safe. |
| `ToArray()`       | Copies the Queue elements to a new array.                         |
| `ToString()`      | Returns a string that represents the current object. <br> (Inherited from `Object`) |
| `TrimToSize()`    | Sets the capacity to the actual number of elements in the Queue.  |

The following example shows how to create and add values to a Queue and how to print out its values.

```csharp
Public Sub Example()
    Dim myQ As Queue = New Queue()
    myQ.Enqueue("Hello")
    myQ.Enqueue("World")
    myQ.Enqueue("!")
    Console.WriteLine("myQ")
    Console.WriteLine(vbTab & "Count:    {0}", myQ.Count)
    Console.Write(vbTab & "Values:")

    For Each obj As Object In myQ
        Console.Write("    {0}", obj)
    Next

    Console.WriteLine()
End Sub
```

Let's run the above code, and you will see the following output.

```csharp
myQ
        Count:    3
        Values:    Hello    World    !
```
