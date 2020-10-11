---
PermaID: 100005
Name: Numbers
---

# Numbers

In C#, you can divide numbers into two types.

 - Integer
 - Floating

## Integer Type

Integer is a whole number without decimal points, it can be positive or negative numbers. In C# there are eight integer data types either signed or unsigned. Depending on the amount of bytes allocated for each type, different value ranges are determined. Here are descriptions of the types: 

| Type            | Size                   | Range                                        |
|:----------------|:-----------------------|:---------------------------------------------|
| sbyte           | 8 bits                 | -128 to 127                                  |
| byte            | 8 bits                 | 0 to 255                                     |
| short           | 16 bits                | -32,768 to 32,767                            | 
| ushort          | 16 bits                | 0 to 65,535                                  |
| int             | 32 bits                | -2,147,483,648 ÷ 2,147,483,647               |
| uint            | 32 bits                | 0 to 4,294,967,295                           |
| long            | 64 bits                | –9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 |
| ulong           | 64 bits                | 0 ÷ 18,446,744,073,709,551,615               |

### byte/sbyte

The byte data type stores numbers from 0 to 255, the sbyte is the same as byte, but it can store negative numbers from -128 to 127. 

```csharp
byte byte1 = 255;
byte byte2 = 0;
byte byte3 = -128;    // compile-time error

sbyte sbyte1 = -128; 
sbyte sbyte2 = 127;
sbyte sbyte3 = 130;   // compile-time error
```

### short/ushort

The short data type is a signed integer that can store numbers from -32,768 to 32,767, while the ushort data type is an unsigned integer and it can store only positive numbers from 0 to 65,535. It occupies 16-bit memory. 

```csharp
short short1 = -32768;
short short2 = 32767;
short short3 = 33000; //Compile-time error:

ushort ushort1 = 65535;
ushort ushort2 = 65535;
ushort ushort3 = -32000; //Compile-time error:
```

### int/uint

The int data type is 32-bit signed integer and it can store numbers from -2,147,483,648 to 2,147,483,647, while the uint is a 32-bit unsigned integer and it can store positive numbers from 0 to 4,294,967,295.

```csharp
int int1 = -2147483648;
int int2 = 2147483647;
int int2 = 4294967295; //Compile-time error

uint uint1 = 0;
uint uint2 = 4294967295;
uint uint3 =-1; //Compile-time error:
```

## long/ulong

The long type is 64-bit signed integers and it can store numbers from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807, while the ulong type stores positive numbers from 0 to 18,446,744,073,709,551,615. 

```csharp
long l1 = -9223372036854775808;
long l2 = 9223372036854775807;

ulong ul1 = 18223372036854775808ul;
ulong ul2 = 18223372036854775808UL;
```


## Floating Type

The floating numbers are positive or negative numbers with one or more decimal points. It includes three data types

 - float
 - double
 - decimal

| Type        | Size                | Range                                              |Significant Digits            |
|:------------|:--------------------|:---------------------------------------------------|:-----------------------------|
| float       | 32 bits             | ±1.5 × 10e−45 ÷ ±3.4 × 10e38                       | 7                            |
| double      | 64 bits             | ±5.0 × 10e−324 ÷ ±1.7 × 10e308                     | 15-16                        |
| decimal     | 128 bits            | (-7.9 x 10e28 to 7.9 x 10e28) / 10e0 to 28         | 28-29                        |

### float

The float data type can store fractional numbers from -3.402823e38 to 3.402823e38. 

```csharp
float f1 = 123.4F;
float f2 = 9.8765f;
```

### double

The double data type can store fractional numbers from -1.79769313486232e308 to 1.79769313486232e308. It occupies 8 bytes in the memory.

```csharp
double d1 = 12345678912345.5d;
double d2 = 1.123456789123456d;
```

### decimal

The decimal data type can store fractional numbers from ±1.0 x 10-28 to ±7.9 x 1028. It occupies 16 bytes in the memory. The decimal type has more precision and a smaller range than both float and double, and so it is appropriate for financial and monetary calculations.

```csharp
decimal d1 = 123456789123456789123456789.5m;
decimal d2 = 1.1234567891345679123456789123m;
```
