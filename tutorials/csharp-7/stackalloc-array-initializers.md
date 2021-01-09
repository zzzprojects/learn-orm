---
PermaID: 100018
Name: Stackalloc Array Initializers
---

# Stackalloc Array Initializers

In C#, a `stackalloc` keyword is used to allocate a block of memory on the stack. It is only used in an unsafe code context. 

 - A stack-allocated memory block created during the method execution is automatically discarded when that method returns. 
 - You cannot explicitly free the memory allocated with stackalloc. 
 - A stack-allocated memory block is not subject to garbage collection and doesn't have to be pinned with a fixed statement.
 - It is used as a way of manually allocated memory buffers that can be used without type safety checks.

Starting with C# 7.2, you can assign the result of a `stackalloc` expression to either `System.Span<T>` or `System.ReadOnlySpan<T>` without using an unsafe context.

```csharp
Span<int> evenNumbers = stackalloc int[10];

for (int i = 0; i < 10; i++)
{
    evenNumbers[i] = i*2;
}

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(evenNumbers[i]);
}
```

You can use a `stackalloc` expression in conditional or assignment expressions as shown below.

```csharp
int length = 250;
Span<byte> bytes = length <= 256 ? stackalloc byte[length] : new byte[length];
```


```csharp
public unsafe static void Example3()
{
    int* oddNumbers = stackalloc int[5] { 1, 3, 5, 7, 9 };

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine(oddNumbers[i]);
    }
}
```

In C# 7.3, you can also use a pointer type for initializing arrays in an unsafe context as shown below.

```csharp
int* oddNumbers = stackalloc int[5] { 1, 3, 5, 7, 9 };

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(oddNumbers[i]);
}
```