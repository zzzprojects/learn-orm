---
PermaID: 100015
Name: Indexing Fixed Fields Without Pinning
---

# Indexing Fixed Fields Without Pinning

The `fixed` statement prevents the garbage collector from relocating a movable variable. The `fixed` statement is only permitted in an `unsafe` context. 

You can also use the `fixed` keyword to create fixed-size buffers as shown below.

```csharp
unsafe struct MyStructure
{
    public fixed int myFixedField[10];
}
```

Before C# 7.3, we used the `fixed` statement to set a managed variable to a pointer and _pins_ that variable during the execution of the statement.

Let's consider the following example in which we have created two variables of type `MyStructure`. The `numbers` variable contains values from 0 to 9 and the `cubes` variable contains their cube values.

```csharp
MyStructure numbers = new MyStructure();
MyStructure cubes = new MyStructure();

public unsafe void PrintArrayUsingPinning()
{
    for (int i = 0; i < 10; i++)
    {
        fixed (int* ptrNumbers = numbers.myFixedField)
        fixed (int* ptrCubes = cubes.myFixedField)
        {
            ptrNumbers[i] = i;
            ptrCubes[i] = i * i * i;
        }
    }

    for (int i = 0; i < 10; i++)
    {
        fixed (int* ptrNumbers = numbers.myFixedField)
        fixed (int* ptrCubes = cubes.myFixedField)
        {
            Console.WriteLine(ptrNumbers[i] + " cube " + ptrCubes[i]);
        }
    }
}

```

Pointers to movable managed variables are useful only in a `fixed` context. Without a `fixed` context, garbage collection could relocate the variables unpredictably. The C# compiler only lets you assign a pointer to a managed variable in a `fixed` statement.

 - Basically, you need to take a reference to the `fixed` field and save it into a pointer. 
 - Then inside the `fixed` statement body you can use the pointer to make changes to the particular variable.
 - Similarly, you can use the same syntax to access elements of the fixed array.

Now in C# 7.3, this new feature allows you to index fixed fields without doing any pinning. 

```csharp
public unsafe void PrintArrayWithoutPinning()
{
    for (int i = 0; i < 10; i++)
    {
        numbers.myFixedField[i] = i;
        cubes.myFixedField[i] = i * i * i;
    }

    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(numbers.myFixedField[i] + " cube " + cubes.myFixedField[i]);
    }
}
```

As you can see that we do not need to use the `fixed` statement anymore to access those fields.