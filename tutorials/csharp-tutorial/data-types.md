---
PermaID: 100003
Name: Data Types
---

# Data Types

C# is a strongly-typed language and we must declare the type of a variable that indicates the kind of values it is going to store, such as integer, float, decimal, text, etc.

The types of C# language are divided into two main categories.

 - Value types
 - Reference types. 
 
## Value Types

A value type holds a data value within its own memory space and it directly contains the values. Let's take the following example 

```csharp
int num = 99;
```

The system will stores 99 in the memory space allocated for the variable `num`.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/csharp-tutorial/images/data-type-1.png">

The value types include simple types such as, `int`, `float`, `bool`, and `char`, `enum`, `struct`, and Nullable value types. These data types are called primitive (built-in types), because they are embedded in C# language at the lowest level.

| Data Type              | Description                                          | Range                                 |
|:-----------------------|:-----------------------------------------------------|:--------------------------------------|
| byte	                 | 8-bit unsigned integer                               | 0 to 255                              |	
| sbyte	                 | 8-bit signed integer                                 | -128 to 127                           |	
| short                  | 16-bit signed integer                                | -32,768 to 32,767                     |
| ushort                 | 16-bit unsigned integer                              | 0 to 65,535                           |
| int                    | 32-bit signed integer                                | -2,147,483,648 to 2,147,483,647       |
| uint                   | 32-bit unsigned integer                              | 0 to 4,294,967,295                    |
| long                   | 64-bit signed integer                                | -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 |
| ulong                  | 64-bit unsigned integer                              | 0 to 18,446,744,073,709,551,615       |
| float                  | 32-bit Single-precision floating point type          | -3.402823e38 to 3.402823e38           |
| double                 | 64-bit double-precision floating point type          | -1.79769313486232e308 to 1.79769313486232e308 |
| decimal                | 128-bit decimal type for financial and monetary calculations | (+ or -)1.0 x 10e-28 to 7.9 x 10e28   |
| char                   | 16-bit single Unicode character                      | Any valid character, e.g. a,*, \x0058 (hex), or\u0058 (Unicode) |
| bool                   | 8-bit logical true/false value                       | True or False	                        |
| object                 | Base type of all other types.                        |                                       |
| string                 | A sequence of Unicode characters                     |                                       |
| DateTime               | Represents date and time	                            | 0:00:00am 1/1/01 to 11:59:59pm 12/31/9999 |

## Reference Types

The reference type contains a pointer to another memory location that holds the data. It doesn't store its value directly unlike value types, but it stores the address where the value is being stored. The reference types include class, interface, delegate, and array types. 

```csharp
string message = "Welcome to C# Tutorial.";
```

The system will select a random location in memory for the variable `message`. The value of a variable `message` is the memory address of the actual data value. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/csharp-tutorial/images/data-type-2.png">

Thus, reference type stores the address of the location where the actual value is stored instead of the value itself.

