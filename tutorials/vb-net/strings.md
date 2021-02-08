---
PermaID: 100032
Name: Strings
---

# Strings

A string is an object of type `System.String` whose value is text. Internally, the text is stored as a sequential read-only collection of `Char` objects. 

 - A string can contain any number of embedded null characters ('\0') because there is no null-terminating character at the end of a string. 
 - The `Length` of a string represents the number of `Char` objects it contains, not the number of Unicode characters.

## String Declaration and Initialization

The string declaration and initialization can be done in different ways.

You can declare the string variable without initialization, as shown below.

```csharp
Dim str1 As String
```

You can declare and initialize a string variable to `Nothing`.

```csharp
Dim str2 As String = Nothing
```

You can also declare and initialize a string variable to an empty string, use the `Empty` constant instead of the literal "".

```csharp
Dim str3 As String = String.Empty
```

To declare and initialize a string variable with a regular string literal.

```csharp
Dim sqlServerPath As String = "C:\Program Files (x86)\Microsoft SQL Server"
```

To declare and initialize a string variable with a verbatim string literal.

```csharp
Dim vsPath As String = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community"

```

In local variables, you can use implicit typing.

```csharp
Dim str4 = "It is a sample message of a strongly-typed System.String!"
```

You can use a const string to prevent it from being used to store another string value.

```csharp
Const str5 As String = "You can't change me now"
```

If you try to assign another value to the `str5` which is constant, you will see an error.

You can use the `String` constructor only when creating a string from a char*, char[], or sbyte*. 

```csharp
Dim letters As Char() = {"A", "B", "C"}
Dim alphabet As String = New String(letters)
```

You can concatenate multiple string variables using the `&` operator.

```csharp
Dim firstName As String = "John "
Dim lastName As String = "Doe"
Dim name As String = firstName & lastName
```

## Special Characters

A text in the real world can include any character such as double quote ("), single quote ('), etc. In C#, a string is surrounded with double quotes, you can't include these special characters include in a string directly. To use them in a string, you will need to include escaping character `\` (backslash) before these special characters.

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
Dim text As String = "This is a ""string"" in C#."
```
