---
PermaID: 100016
Name: Fixed Pattern
---

# Fixed Pattern

In C# 7.3, the `fixed` statement operates on additional types beyond arrays, strings, fixed-size buffers, or `unmanaged` variables. Any type that implements a method named `GetPinnableReference` can be pinned. The `GetPinnableReference` must return a `ref` variable of an `unmanaged` type.

Let's consider the following simple class which contains the implementation of the `GetPinnableReference` method.

```csharp
public class MyData
{
    private readonly int _value;

    public MyData(int value)
    {
        _value = value;
    }

    public ref readonly int GetPinnableReference()
    {
        return ref _value;
    }        
}
```

For the type to implement the fixed pattern, it must declare a parameterless method `GetPinnableReference` that returns the value of the unmanaged type by reference or read-only reference.

Now you can pin the above class in the `fixed` statement as shown below.

```csharp
var myData = new MyData(39);
fixed (int* ptr = myData)
{
    Console.WriteLine(*ptr); 
}
```

The .NET types `Span<T>` and `ReadOnlySpan<T>` introduced in .NET Core 2.0 make use of this pattern and can be pinned as shown below.

```csharp
int[] PascalsTriangle = {
              1,
            1,  1,
          1,  2,  1,
        1,  3,  3,  1,
      1,  4,  6,  4,  1,
    1,  5,  10, 10, 5,  1
};

Span<int> RowFive = new Span<int>(PascalsTriangle, 10, 5);

fixed (int* ptrToRow = RowFive)
{
    var sum = 0;
    for (int i = 0; i < RowFive.Length; i++)
    {
        sum += *(ptrToRow + i);
    }
    Console.WriteLine(sum);
}
``` 

You can also initialize multiple pointers of the same type in one statement as shown below.

```csharp
var myData1 = new MyData(100);
var myData2 = new MyData(200);

fixed (int* ptr1 = myData1, ptr2 = myData2)
{
    Console.WriteLine(*ptr1);
    Console.WriteLine(*ptr2);
}
```

After the code in the statement is executed, any pinned variables are unpinned and subject to garbage collection. Therefore, do not point to those variables outside the `fixed` statement. The variables declared in the `fixed` statement are scoped to that statement, making this easier.

Pointers that are initialized in `fixed` statements are `readonly` variables, and you can not modify them. If you want to modify the pointer value, you must declare a second pointer, and modify that as shown below. 

```csharp
var myData = new MyData(72);
fixed (int* ptr = myData)
{
    Console.WriteLine(*ptr);

    int* newPtr = ptr;
    newPtr = newPtr + 10;
    Console.WriteLine(*newPtr);

    //ptr = ptr + 10;            //Error
}
```

Now, if you try to modify the variable declared in a `fixed` statement, you will get the following error.

```csharp
Error CS1656 Cannot assign to 'ptr' because it is a 'fixed variable'
``` 