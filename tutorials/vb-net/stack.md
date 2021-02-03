---
PermaID: 100028
Name: Stack
---

# Stack

The `Stack` class represents a simple last-in-first-out (LIFO) non-generic collection of objects.

 - The capacity of a Stack is the number of elements the Stack can hold. 
 - As elements are added to a `Stack`, the capacity is automatically increased as required through reallocation.

## Methods

The following are basic methods of the `Stack` class. 

| Method            | Description                                                        |
| :-----------------| :------------------------------------------------------------------|
| `Clear()`        | Removes all objects from the `Stack`.                                |
| `Clone()`        | Creates a shallow copy of the `Stack`.                               |
| `Contains(Object)` | Determines whether an element is in the `Stack`.                  |
| `CopyTo(Array, Int32)` | Copies the Stack to an existing one-dimensional Array, starting at the specified array index. |
| `Equals(Object)` | Determines whether the specified object is equal to the current object. <br> (Inherited from `Object`) |
| `GetEnumerator()`| Returns an IEnumerator for the `Stack`.                             |
| `GetHashCode()`  | Serves as the default hash function. <br> (Inherited from `Object`) |
| `GetType()`      | Gets the Type of the current instance. <br> (Inherited from `Object`) |
| `MemberwiseClone()` | Creates a shallow copy of the current Object. <br> (Inherited from `Object`) |
| `Peek()`         | Returns the object at the top of the `Stack` without removing it.            |
| `Pop()`          | Removes and returns the object at the top of the `Stack`.             |
| `Push(Object)`  | Inserts an object at the top of the `Stack`.                           |
| `Synchronized(Stack)` | Returns a synchronized (thread safe) wrapper for the `Stack`.   |
| `ToArray()`     | Copies the Stack to a new array.                                     |
| `ToString()`    | Returns a string that represents the current object. <br> (Inherited from `Object`) |

The following example shows how to create and add values to a Stack and how to display its values.

```csharp
Public Sub Example()
    Dim myStack As Stack = New Stack()
    myStack.Push("Hello")
    myStack.Push("World")
    myStack.Push("!")
    Console.WriteLine("myStack")
    Console.WriteLine(vbTab & "Count:    {0}", myStack.Count)
    Console.Write(vbTab & "Values:")

    For Each obj In myStack
        Console.Write("    {0}", obj)
    Next
End Sub
```

Let's run the above code and you will see the following output.

```csharp
myStack
        Count:    3
        Values:    !    World    Hello
```

If `Count` is less than the capacity of the stack, `Push` is an `O(1)` operation. 

 - If the capacity needs to be increased to accommodate the new element, `Push` becomes an `O(n)` operation, where `n` is `Count`. 
 - `Pop` is an `O(1)` operation.