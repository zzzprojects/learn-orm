---
PermaID: 100008
Name: Null-coalescing Assignment
---

# Null-coalescing Assignment

The null-coalescing operator `??` returns the value of its left-hand operand if it is not a `null` value. If it is a null, then it evaluates the right-hand operand and returns its result. 

 - In C# 8.0, a new null-coalescing assignment operator `??=` assigns the value of its right-hand operand to its left-hand operand only if the left-hand operand evaluates to null. 
 - The `??=` operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.
 - The left-hand operand of the `??=` operator must be a variable, a property, or an indexer element.

```csharp
List<int> numList = null;
numList ??= new List<int>() { 34, 71};

Console.WriteLine(string.Join(" ", numList));  // output: 34 71

int? val = null;
numList.Add(val ??= 120);

Console.WriteLine(string.Join(" ", numList));  // output: 34 71 120
Console.WriteLine(val);                        // output: 120
```

Before C# 8, the type of the left-hand operand of the `??` operator must be either a reference type or a nullable value type. In C# 8.0, the requirement is changed and now the type of the left-hand operand of the `??` and `??=` operators cannot be a non-nullable value type. 

You can use the null-coalescing operators with unconstrained type parameters.

```csharp
private static void Display<T>(T value, T backup)
{
    Console.WriteLine(value ?? backup);
}

public static void Example2()
{
    Display<string>("value", "backup value");       // value
    Display<string>(null, "backup value");          // backup value
}
```

In expressions with the null-conditional operators `? and `?[]`, you can use the `??` operator to provide an alternative expression to evaluate in case the result of the expression with null-conditional operations is `null`.

```csharp
private static double SumNumbers(List<double[]> numList, int index)
{
    return numList?[index]?.Sum() ?? double.NaN;
}

public static void Example3()
{
    double[] values1 = { 10.0, 20.0 };
    double[] values2 = { 30.0, 40.0 };
    double[] values3 = { 50.0, 60.0 };

    List<double[]> numList = new List<double[]>() { values1, values2, values3 };

    Console.WriteLine(SumNumbers(numList, 1));   // 70
    Console.WriteLine(SumNumbers(null, 0));      // NaN
}
```

## Note

The operators `??` and `??=` cannot be overloaded.