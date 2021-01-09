---
PermaID: 100010
Name: Readonly References
---

# Readonly References

Before C# 7.2, we did not have an efficient way of expressing a desire to pass struct variables into method calls for readonly purposes with no intention of modifying. 

 - When you pass an argument by-value, it will create another copy which adds unnecessary costs. 
 - To pass by-ref argument rely on documentation to indicate that the data is not supposed to be mutated by the callee. 

In C# 7.2, a new parameter passing mode called the `in` parameter is introduced. It provides mechanisms that enable safe efficient code using references to value types. Use these features wisely to minimize both allocations and copy operations.

 - The `in` keyword complements the existing `ref` and `out` keywords to pass arguments by reference. 
 - The `in` keyword specifies passing the argument by reference, but the called method doesn't modify the value.

```csharp
private static void Print(in int val)
{
    int y = val;
    Console.WriteLine(y);

    y = y + 10;
    Console.WriteLine(y);
    Console.WriteLine(val);
}
```

As you can see that the variable `val` is passed as the `in` parameter and it is used by the `Print` function without any modification and used as `readonly`. Now if you try to modify the `val` inside the `Print` function as shown below.

```csharp
private static void Print(in int val)
{
    int y = val;
    Console.WriteLine(y);          

    y = y + 10;
    Console.WriteLine(y);

    val = val + 10;              //Error
    Console.WriteLine(val);        
}
```

You will see the following error.

```csharp
Error CS8331 Cannot assign to variable 'in int' because it is a readonly variable
```

