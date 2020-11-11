---
PermaID: 100010
Name: Stackalloc in Nested Expressions
---

# Stackalloc in Nested Expressions

The `stackalloc` operator allocates a memory block in the stack. A memory block is created during the execution of the method and it is automatically deleted when the method is returned.

 - The `Span<T>`, `ReadOnlySpan<T>`, and `Memory<T>` are `ref` `struct` instances that are guaranteed to be allocated on the stack, and therefore won't affect the garbage collector. 
 - Using `Span`, it was also possible to avoid declaring the stackalloc statements that are directly assigned to `Span` or `ReadOnlySpan` as `unsafe`.

In C# 8.0, if the result of a `stackalloc` expression is `Span<T>` or `ReadOnlySpan<T>`, you can use the stackalloc expression in other expressions as shown in the below example.

```csharp
Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };

var index = numbers.IndexOfAny(stackalloc[] { 4, 8, 12 });

Console.WriteLine(index);   // output: 3  
```

As you can see the nested `stackalloc` in the above code. Let's consider another example simple example.

```csharp
string input = "This is a simple string \r\n";
ReadOnlySpan<char> trimmedChar = input.AsSpan().Trim(stackalloc[] { ' ', '\r', '\n' });

Console.WriteLine(trimmedChar.ToString());
``` 

In the above example, it trims the input string from three special characters.