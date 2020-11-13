---
PermaID: 100005
Name: Digit Separators
---

# Digit Separators

The digit separator feature is also introduced in C# 7.0. You can separate the large number into small parts which makes your code more readable using the digit separator. 

 - The underscore (`_`) is used as a digit separator. 
 - When you use digit separator in your code they are ignored by the compiler.

Let's consider the following simple example without using digit separators.

```csharp
long num1 = 1000000000000;
long num2 = 1000500000;

Console.WriteLine(num1);
Console.WriteLine(num2);
```

As you can that it is very difficult to read the exact value of `num1` and `num2` due to the large numerical literals. Now let's add the digit separators to the above example and see the readability.

```csharp
long num1 = 1_000_000_000_000;
long num2 = 10_00_50_00_00;

Console.WriteLine(num1);
Console.WriteLine(num2);
```

As you can see that by adding the digit separator have a great readability impact and have no significant downside.

 - The digit separator can appear anywhere in the constant, the different groupings may make sense in different scenarios and especially for different numeric bases.
 - Any sequence of digits may be separated by one or more underscores. 
 - The `_` is allowed in decimals as well as exponents.

You can use this separator with other numbers as well. 

```csharp
int bin = 0b1001__1010__0001__0100;
int hex = 0x1b_a0_44_fe;
int dec = 33_554_432;
double real = 1_000.111_1e-3;
ushort shortVal = 0b1011_1100_1011_0011;

Console.WriteLine(bin);
Console.WriteLine(hex);
Console.WriteLine(dec);
Console.WriteLine(real);
Console.WriteLine(shortVal);
```

## Avoid Digit Separator

The digit separator should not be used in the following places.

 - At the start of any value. For example, `_1000_0000`
 - At the end of the value such as `1000_0000_`
 - Before or after the decimal such as, `10_00_.03_33`
 - Before or after the exponent character, e.g. `1.1e_1`
 - Before or after the type specifier `10_f`
 - Immediately after the 0x or 0b in binary and hexadecimal literals e.g. `0b_1001_1000`
