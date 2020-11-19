---
PermaID: 100013
Name: Conditional Ref Expressions
---

# Conditional Ref Expressions

The conditional operator `?:` also known as the ternary conditional operator, evaluates a boolean expression and returns the result of one of the two expressions, depending on whether the boolean expression evaluates to `true` or `false`.

```csharp
condition ? consequent : alternative
```

The condition expression must evaluate to `true` or `false`. 

 - If the condition evaluates to `true`, the consequent expression is evaluated, and its result becomes the result of the operation. 
 - If the condition evaluates to `false`, the alternative expression is evaluated, and its result becomes the result of the operation. 
 - Only consequent or alternative is evaluated.

Before C# 7.2, the pattern of binding a `ref` variable to one or another expression conditionally was not expressible.

The typical workaround was to use a method as shown below.

```csharp
ref T GetChoice(bool condition, ref T consequence, ref T alternative)
{
    if (condition)
    {
         return ref consequence;
    }
    else
    {
         return ref alternative;
    }
}
```

It is not an exact replacement of a ternary since all arguments must be evaluated at the call site. The following example will not work as you expect.

```csharp
ref var result = ref GetChoice(arr != null, ref arr[0], ref otherArr[0]);
```
       
It will crash if `arr[0] = null` because `arr[0]` will be executed unconditionally.

Now in C# 7.2, you can use syntax like this.

```csharp
<condition> ? ref <consequence> : ref <alternative>;
```

The above condition using `GetChoice` can be correctly written using `ref` ternary as shown below.

```csharp
ref var result = ref (arr != null ? ref arr[0]: ref otherArr[0]);
```

In the case of a conditional ref expression, the type of `consequent` and `alternative` must be the same. Conditional ref expressions are not target-typed.

Let's consider the following example that shows how you can use it.

```csharp
var array1 = new int[] { 21, 37, 19, 93, 5 };
var array2 = new int[] { 19, 17, 15, 13, 11, 9, 7, 5, 3, 1 };

int index = 3;
ref int refValue = ref index < 5 ? ref array1[index] : ref array2[index];
refValue = 100000;

index = 6;
refValue = ref index < 5 ? ref array1[index] : ref array2[index];
refValue = 100000;

Console.WriteLine(string.Join(" ", array1));
Console.WriteLine(string.Join(" ", array2));
```

Let's run the above example and you will see the following output.
 
```csharp
21 37 19 100000 5
19 17 15 13 11 9 100000 5 3 1
```

You can also use nested ternary by including a conditional ref expression as a second statement.

```csharp
var array1 = new int[] { 21, 37, 19, 93, 5 };
var array2 = new int[] { 19, 17, 15, 13, 11, 9, 7, 5, 3, 1 };

int index = 3;
ref int refValue = ref index < 5 ? ref array1[index] : ref array2[index];
refValue = 100000;

index = 12;
refValue = ref index < 5 ? ref array1[index] : ref index < 10 ? ref array2[index] : ref array2[index - 10];
refValue = 100000;

Console.WriteLine(string.Join(" ", array1));
Console.WriteLine(string.Join(" ", array2));
```

Let's run the above example and you will see the following output.
 
```csharp
21 37 19 100000 5
19 17 100000 13 11 9 7 5 3 1
```