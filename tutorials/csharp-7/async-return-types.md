---
PermaID: 100006
Name: Async Reutrn Types
---

# Async Reutrn Types

Before C# 7.0, the async methods supported the following return types.

 - **Task:** Used for an async method that performs an operation but returns no value.
 - **Task\<TResult\>:** Used for an async method that returns a value.
 - **Void:** Used for an event handler.

From C# 7.0, an async method can return any type that has an accessible `GetAwaiter` method. The object returned by the `GetAwaiter` method must implement the `ICriticalNotifyCompletion` interface.

Returning a `Task` object from async methods can introduce performance bottlenecks in certain paths. `Task` is a reference type, so using it means allocating an object. 

 - In cases where a method declared with the async modifier returns a cached result or completes synchronously, the extra allocations can become a significant time cost in performance-critical code sections. 
 - It can become costly if those allocations occur in tight loops.

Starting with C# 7.0, an asynchronous method also can return `ValueTask` or ValueTask<TResult>. 

 - The .NET provides the `ValueTask<TResult>` structure as a lightweight implementation of a generalized `Task<TResult>` value. 
 - To use the `ValueTask<TResult>` type, you must add the `System.Threading.Tasks.Extensions` NuGet package to your project.

The following example uses the `ValueTask<TResult>` structure to retrieve the value.

```csharp
static readonly Random random = new Random();
public static async void PrintRandomNumberUsingValueTask()
{
    int number = await GetNumber();
    Console.WriteLine("Random number: {0}", number);
}

public static async ValueTask<int> GetNumber()
{            
    await Task.Delay(1);
    return random.Next(1, 1000);
}
```

The `ValueTask` and `ValueTask<TResult>` are wrappers around `Task` and `Task<TResult>` with the distinction that they are defined using a `struct` instead of a `class`.

## When to Use ValueTask?

There is a major difference between `Task` and `ValueTask`. 

 - The `Task` is a reference type and requires heap allocation. 
 - The `ValueTask` is a value type and is returned by value and required no heap allocation. 
 - It is recommended to use `ValueTask` when there is a high probability that a method won't have to wait for `async` operations. 
 - For example, if a method returns cached or predefined results, it can significantly reduce the number of allocations and result in big performance improvement.
