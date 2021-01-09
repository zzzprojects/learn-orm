---
PermaID: 100004
Name: Strings
---

# Strings

A string is an object of type `System.String` whose value is text. Internally, the text is stored as a sequential read-only collection of `Char` objects. 

 - In C#, the `string` keyword is an alias for `System.String`, so, `String` and `string` are equivalent, and you can use whichever naming convention you prefer.
 - A string can contain any number of embedded null characters ('\0'), because there is no null-terminating character at the end of a string. 
 - The `Length` of a string represents the number of Char objects it contains, not the number of Unicode characters.

## String Declaration and Initialization

The string declaration and initialization can be done in different ways.

You can declare the string variable without initialization as shown below.

```csharp
string str1;
```

You can declare and initialize a string variable to `null`.

```csharp
string str2 = null;
```

You can also declare and initialize a string variable to an empty string, use the `Empty` constant instead of the literal "".

```csharp
string str3 = string.Empty;
```

To declare and initialize a string variable with a regular string literal.

```csharp
string sqlServerPath = "C:\\Program Files (x86)\\Microsoft SQL Server";
```

To declare and initialize a string variable with a verbatim string literal.

```csharp
string vsPath = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community";
```

In local variables you can use implicit typing.

```csharp
var str4 = "It is sample message of a strongly-typed System.String!";
```

You can use a const string to prevent if from being used to store another string value.

```csharp
const string str5 = "You can't change me now";
```

If you try to assign another value to the `str5` which is constant, you will see an error.

You can use the `String` constructor only when creating a string from a char*, char[], or sbyte*. 

```csharp
char[] letters = { 'A', 'B', 'C' };
string alphabet = new string(letters);
```

You can concatinate multiple string variables using `+` operator.

```csharp
string firstName = "John ";
string lastName = "Doe";
string name = firstName + lastName;
```

## Special Characters

A text in the real world can include any character such as, double quote ("), single quote (') etc. In C#, a string is surrounded with double quotes, you can't include these special characters include in a string directly. To use them in a string you will need to include escaping character `\` (backslash) before these special characters.

| Escape sequence   | Character       |
|:------------------|:----------------|
| \'                | Single quote    |
| \"                | Double quote    |
| \\                | Backslash       |
| \0                | Null            |
| \a                | Alert           |
| \b                | Backspace       |
| \f                | Form feed       |
| \n                | New line        |
| \r                | Carriage return |
| \t                | Horizontal tab  |
| \v                | Vertical tab    |

```csharp
string text = "This is a \"string\" in C#.";
```
For more information about strings, visit [https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/)

All the examples related to the strings are available in the `Strings.cs` file of the source code. Download the source code and try out all the examples for better understanding.
