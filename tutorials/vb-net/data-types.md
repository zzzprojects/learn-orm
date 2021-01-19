---
PermaID: 100005
Name: Data Types
---

# Data Types

Data types refer to an extensive system used for declaring variables or functions of different types. 

 - In VB.NET, a data type is used to define the type of a variable or function in a program.
 - Data types determine the type of data that any variable can store. 
 - Variables belonging to different data types are allocated different amounts of space in the memory. 

VB.Net provides a wide range of data types. The following table shows the Visual Basic data types, their supporting common language runtime types, their nominal storage allocation, and their value ranges.

| Visual Basic Type    | CLR Type Structure          | Nominal Storage Allocation        | Value range                         |
| :--------------------| :---------------------------| :---------------------------------| :-----------------------------------|
| Boolean              | Boolean                     | Depends on implementing platform  | `True` or `False`                  | 
| Byte                 | Byte                        | 1 byte                            | 0 through 255 (unsigned)            | 
| Char                 | Char                        | 2 bytes                           | 0 through 65535 (unsigned)          |
| Date                 | DateTime                    | 8 bytes                           | 0:00:00 (midnight) on January 1, 0001 through 11:59:59 PM on December 31, 9999 |
| Decimal              | Decimal                     | 16 bytes                          | 0 through +/-79,228,162,514,264,337,593,543,950,335 (+/-7.9...E+28) with no decimal point; <br><br> 0 through +/-7.9228162514264337593543950335 with 28 places to the right of the decimal; <br><br> smallest nonzero number is +/-0.0000000000000000000000000001 (+/-1E-28)|
| Double               | Double	                     | 8 bytes                           | -1.79769313486231570E+308 through -4.94065645841246544E-324, for negative values; <br><br> 4.94065645841246544E-324 through 1.79769313486231570E+308 † for positive values |
| Integer              | Int32                       | 4 bytes                           | -2,147,483,648 through 2,147,483,647 (signed) |
| Long                 | Int64                       | 8 bytes                           | -9,223,372,036,854,775,808 through 9,223,372,036,854,775,807 (9.2...E+18) (signed) |
| Object               | Object                      | 4 bytes on 32-bit platform <br><br> 8 bytes on 64-bit platform | Any type can be stored in a variable of type Object |
| SByte                | SByte                       | 1 byte                            | -128 through 127 (signed) |
| Short                | Int16                       | 2 bytes                           | -32,768 through 32,767 (signed) |
| Single               | Single                      | 4 bytes                           | -3.4028235E+38 through -1.401298E-45 for negative values; <br><br> 1.401298E-45 through 3.4028235E+38 † for positive values |
| String               | String                      | Depends on implementing platform  | 0 to approximately 2 billion Unicode characters |
| UInteger             | UInt32                      | 4 bytes                           | 0 through 4,294,967,295 (unsigned) |
| ULong                | UInt64                      | 8 bytes                           | 0 through 18,446,744,073,709,551,615 (1.8...E+19) (unsigned) |
| User-Defined (structure) | (inherits from ValueType) | Depends on implementing platform| Each member of the structure has a range determined by its data type and independent of the ranges of the other members |
| UShort               | UInt16                      | 2 bytes                           | 0 through 65,535 (unsigned) |

A **Data Type** refers to which type of data or value is assigning to a variable or function so that a variable can hold a defined data type value. The basic syntax of declaring a variable is as follows:

```csharp
Dim VarName as DataType
```

 - **VarName:** It defines the name of the variable that you assign to store values.
 - **DataType:** It represents the name of the data type that you assign to a variable.

