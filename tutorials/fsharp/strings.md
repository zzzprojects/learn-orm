---
PermaID: 100014
Name: Strings
---

# Strings

The string type represents immutable text as a sequence of Unicode characters. The `string` is an alias for `System.String` in .NET.

## String Declaration and Initialization

The string declaration and initialization can be done in different ways.

You can declare the string variable as shown below.

```csharp
let str1:string = ""
```

You can declare and initialize a string variable to `null`.

```csharp
let str2:string = null
```

To declare and initialize a string variable with a regular string literal.

```csharp
let sqlServerPath:string = "C:\\Program Files (x86)\\Microsoft SQL Server";
```

To declare and initialize a string variable with a verbatim string literal.

```csharp
let vsPath:string = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community";
```

In local variables, you can use implicit typing.

```csharp
let str3 = "It is a sample message of a strongly-typed System.String!";
```

## Concatenation

You can concatenate multiple string variables using the `+` operator.

```csharp
let firstName = "John "
let lastName = "Doe"
let fullName = firstName + lastName

Console.WriteLine(fullName)
```

## Substrings

You can extract a substring from any string by specifying starting and end index as shown below.

```csharp
let str4 = "It is a sample message of a strongly-typed System.String!";

Console.WriteLine(str4.[0..21])// Substring from index 0 to 21  
Console.WriteLine(str4.[43..56])// Substring from index 43 to 56  
```

It will display the following substring on the console.

```csharp
It is a sample message
System.String!
```

## String Comparision

You can use the `Equals()` method or comparison (`=`) operator to compare two strings.

```csharp
let s1:string = "Hello";    
let s2:string = "World";    
let s3:string = "Hello";

Console.WriteLine(s1.Equals(s2))  
Console.WriteLine(s1.Equals(s3))  
printfn "%b" (s1=s2)  
printfn "%b" (s1=s3)
```

## Special Characters

String literals are delimited by the quotation mark (`"`) character. 

 - The backslash character (`\`) is used to encode certain special characters. 
 - The backslash and the next character together are known as an escape sequence. 

Escape sequences supported in F# string literals are shown in the following table.

| Character      | Escape Sequence |
| :--------------| :---------------|
| Alert          | `\a`           |
| Backspace      | `\b`           |
| Form feed      | `\f`           |
| Newline        | `\n`           |
| Carriage return| `\r`           |
| Tab            | `\t`           |
| Vertical tab   | `\v`           |
| Backslash      | `\\`           |
| Quotation mark | `\"`           |
| Apostrophe     | `\'`           |

