---
PermaID: 100013
Name: Span\<T\> and Memory\<T\>
---

# Span\<T\> and Memory\<T\>

.NET Core 2.1 includes some new types that make working with arrays and other types of memory much more efficient. The new types include:

 - **`System.Span<T>`**: Provides a type- and memory-safe representation of a contiguous region of arbitrary memory.
 - **`System.ReadOnlySpan<T>`**: Provides a type-safe and memory-safe read-only representation of a contiguous region of arbitrary memory.
 - **`System.Memory<T>`**: Represents a contiguous region of memory.
 - **`System.ReadOnlyMemory<T>`**: Represents a contiguous region of memory, similar to `ReadOnlySpan<T>`. Unlike `ReadOnlySpan<T>`, it is not a by ref like type.

Without these types, when passing such items as a portion of an array or a section of a memory buffer, you have to make a copy of some portion of the data before passing it to a method. These types provide a virtual view of that data that eliminates the need for additional memory allocation and copy operations.

The following example uses a `Span<T>` and `Memory<T>` instance to provide a virtual view of 10 elements of an array.

```csharp
int[] numbers = new int[100];
for (int i = 0; i < 100; i++)
{
    numbers[i] = i * 2;
}

var part = new Span<int>(numbers, start: 10, length: 10);

foreach (var value in part)
{
    Console.Write($"{value}  ");
}
```

When you run the above example, you will see the following output.

```csharp
20  22  24  26  28  30  32  34  36  38
```
