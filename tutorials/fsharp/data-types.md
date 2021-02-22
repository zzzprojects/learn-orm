---
PermaID: 100005
Name: Data Types
---

# Data Types

Some types are considered primitive types, such as the Boolean type `bool` and integral and floating-point types of various sizes, including types for bytes and characters, etc. These types are described in Primitive Types. Other types built into the language include tuples, lists, arrays, sequences, records, and discriminated unions.

 - If you have experience with other .NET languages and are learning F#, you should read the topics for each of these types. 
 - These F#-specific types support styles of programming that are common to functional programming languages.
 - Many of these types have associated modules in the F# library that support common operations on these types.

The following table contains the basic types that are the most fundamental in F# and are a superset of .NET primitive types.

| Type       | .NET Type         | Description                                             | 
| :----------| :-----------------| :-------------------------------------------------------| 
| bool       | Boolean           | Possible values are `true` and `false`.                | 
| byte       | Byte              | Values from 0 to 255. Example: 1uy                      |
| sbyte      | SByte             | Values from -128 to 127. Example: 1y                    |
| int16      | Int16             | Values from -32768 to 32767. Example: 1s                |                  
| uint16     | UInt16            | Values from 0 to 65535. Example: 1us                    |
| int        | Int32             | Values from -2,147,483,648 to 2,147,483,647. Example: 1 |
| uint       | UInt32            | Values from 0 to 4,294,967,295. Example: 1u             |
| int64      | Int64             | Values from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807. Example: 1L |
| uint64     | UInt64            | Values from 0 to 18,446,744,073,709,551,615. Example: 1UL |
| nativeint  | IntPtr            | A native pointer as a signed integer. Example: nativeint 1 |
| unativeint | UIntPtr           | A native pointer as an unsigned integer. Example: unativeint 1 |
| decimal    | Decimal           | A floating point data type that has at least 28 significant digits. Example: 1.0 |
| float, double  | Double        | A 64-bit floating point type. Example: 1.0              |
| float32, single| Single        | A 32-bit floating point type. Example: 1.0f             |
| char       | Char              | Unicode character values. Example: 'c'                  |
| string     | String            | Unicode text. Example: "str"                            |
| unit       | not applicable    | Indicates the absence of an actual value. The type has only one formal value, which is denoted `()`. The unit value, `()`, is often used as a placeholder where a value is needed but no real value is available or makes sense.	 Example: `()` |

Let's consider the following example.

```csharp
let myInt = 5
let myFloat = 3.14
let myString = "hello"
```
