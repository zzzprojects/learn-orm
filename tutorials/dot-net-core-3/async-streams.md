---
PermaID: 100019
Name: Async Streams
---

# Async Streams

C# has support for iterator methods and async methods. Still, no support for a method that is both an iterator and an async method, or you can say iterate a collection asynchronously. In C# 8.0, you can create and consume streams asynchronously. A method that returns an asynchronous stream has the following properties.

 - It is declared with the `async` modifier.
 - It returns an `IAsyncEnumerable<T>`, it is similar to the `IEnumerable<T>` method used to iterate over a collection, except that `IAsyncEnumerable<T>` allows us to move through the collection asynchronously.
 - The `IAsyncEnumerable<T>` allows us to wait for the next element in the collection without blocking a thread.
 - The method contains `yield` return statements to return successive elements in the asynchronous stream.

Let's consider the following simple method, which creates and consume an asynchronous stream and returns `IAsyncEnumerable<T>`.

```csharp
private static async IAsyncEnumerable<int> GenerateEvenSequence()
{
    for (int i = 0; i <= 50; i = i + 2)
    {
        await Task.Delay(100);
        yield return i;
    }
}
```

The above example generates a sequence of even numbers from 0 to 50, waiting 100 ms between generating each even number. You would enumerate the sequence using the `await foreach` statement, as shown below.

```csharp
public static async Task PrintEvenSequenceAsync()
{
    await foreach (var number in GenerateEvenSequence())
    {
        Console.WriteLine(number);
    }
}
```

The `GenerateEvenSequence()` method is asynchronous. It will return all of these numbers at once, not one by one as they are generated. The `yield` keyword can perform stateful iteration and return each collection element one by one. 

