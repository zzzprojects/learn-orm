---
PermaID: 100004
Name: Target-typed Conditional Expressions
---

# Target-typed Conditional Expressions

C# 9 brings also some improvements with target-typed conditional operators, such as ternary statements. The goal of this new feature is to create a better conversion from expressions.

Let's consider the following conditional expression.

```csharp
condition ? expr1 : expr2
```

You can see there is no common type between two expressions when they are evaluated, or, in the case that there is a common type for one of the expressions, but there is no implicit cast for the type.

Let's consider the following example.

```csharp
public static void Main(string[] args)
{
    var status = true;
    Print(status ? 1 : 2);
}

private static void Print(long number)
{
    Console.WriteLine("{0}: {1}", number.GetType(), number);
}
```

In the above code, the `Print()` method is executed and passed the 1 or 2 depending on the value of the `status` variable, but in this case, it will be 1.
 

Now if you change the `Print()` method signature by replacing the `long` with `short` as shown below.

```csharp
private static void Print(short number)
{
    Console.WriteLine("{0}: {1}", number.GetType(), number);
}
```

Now you will see the following error.

```csharp
CS1503	Argument 1: cannot convert from 'int' to 'short'

```

In the C # 9 specification, this problem is solved. So the following code is completely valid and will resolve correctly.

```csharp
public static void Main(string[] args)
{
    var status = true;
    Print(status ? 1 : 2);
}

private static void Print(short number)
{
    Console.WriteLine("{0}: {1}", number.GetType(), number);
}
```

Similarly, if the `Print()` method has a parameter of type `long`, it will also be resolved correctly.
