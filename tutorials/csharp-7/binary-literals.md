---
PermaID: 100004
Name: Binary Literals
---

# Binary Literals

## What is Literal?

Literal is a fixed value that is used by the variables. Before C# 7.0, the following literal types were available.

 - Integer 
 - Floating-point
 - Character
 - String
 - Null
 - Boolean

In C# 7.0, one more literal is introduced, known as binary literal. It allows the developer to assign a binary value to the variable. You can define the binary literal, as shown below.  

```csharp
var value1 = 0b1001;
```

Syntactically and semantically binary literals are identical to hexadecimal literals, except for using `b/B` instead of `x/X`, having only 0s and 1s, and being interpreted in base 2 instead of 16. 

Let's consider another simple example.

```csharp
var value1 = 0b1001;
var value2 = 0b01001001;
var value3 = 0b01001111;

Console.WriteLine("Value of value1 is: {0}", value1);
Console.WriteLine("Value of value2 is: {0}", value2);
Console.WriteLine("Value of value3 is: {0}", value3);

Console.WriteLine("Char value of value2 is: {0}", Convert.ToChar(value2));
Console.WriteLine("Char value of value3 is: {0}", Convert.ToChar(value3));
```

When you execute the above code, you will see the following output.

```csharp
Value of value1 is: 9
Value of value2 is: 73
Value of value3 is: 79
Char value of value2 is: I
Char value of value3 is: O
```

Binary literals make it easy to work with bits.
