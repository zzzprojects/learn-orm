---
PermaID: 100028
Name: Basic I/O
---

# Basic I/O

Input and output, also called I/O, refers to any kind of communication between two hardware devices or between the user and the computer. It includes printing text out to the console, reading and writing files to disk, etc.

## Print on Console

In F#, the [Printf module](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-printfmodule.html) provides various methods, such as, `printf`, `printfn`, `sprintf` etc. which are used to printf-style printing and formatting using `%` markers as placeholders.

The following tables show various methods provided in the [Printf module](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-printfmodule.html)

| Function               | Description                                                                                       |
| :----------------------| :-------------------------------------------------------------------------------------------------|
| `bprintf`                | Print to a StringBuilder                                                                          |
| `eprintf`                | Formatted printing to stderr                                                                      |
| `eprintfn`               | Formatted printing to stderr, adding a newline                                                    | 
| `failwithf`              | Print to a string buffer and raise an exception with the given result. Helper printers must return strings. |
| `fprintf`                | Print to a text writer.                                                                           |
| `fprintfn`               | Print to a text writer, adding a newline                                                          |
| `kbprintf`               | `bprintf`, but call the given 'final' function to generate the result.                           |
| `kfprintf`               | `fprintf`, but call the given 'final' function to generate the result.                           |
| `kprintf`                | `printf`, but call the given 'final' function to generate the result. For example, these let the printing force flush after all output has been entered onto the channel, but not before. |
| `ksprintf`               | `sprintf`, but call the given 'final' function to generate the result.                           |
| `printf`                 | Formatted printing to stdout                                                                      |
| `printfn`                | Formatted printing to stdout, adding a newline.                                                   |
| `sprintf`                | Print to a string via an internal string buffer and return the result as a string. Helper printers must return strings. |

The following example uses the `printfn` to print a formatted string on the console.

```csharp
printfn "Hi, I'm %s, %i old and I'm a %s" "Mark" 25 "Scorpio";
```

All the methods in the [Printf module](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-printfmodule.html) are type-safe, if you substitute an `int` placeholder with a string results, you will get a compilation error.

Let's replace the `25` with `"25"` as shown below.

```csharp
printfn "Hi, I'm %s, %i old and I'm a %s" "Mark" "25" "Scorpio";
```

You will see the following error.

```csharp
Error FS0001: The type 'string' is not compatible with any of the types byte,int16,int32,int64,sbyte,uint16,uint32,uint64,nativeint,unativeint, arising from the use of a printf-style format string.
```

The format specifications are strings with `%` markers indicating format placeholders, they are used for formatting the input or output, according to your need.

The following tables show different types of placeholders.

| Type        | Description                                                     |
| :-----------| :---------------------------------------------------------------|
| `%b`        | Formats a bool, formatted as true or false.                     |
| `%c`        | Formats a character.                                            |
| `%s`        | Formats a string, formatted as its contents, without interpreting any escape characters. |
| `%d`, `%i`  | Formats any basic integer type formatted as a decimal integer, signed if the basic integer type is signed. |
| `%u`        |Formats any basic integer type formatted as an unsigned decimal integer. |
| `%x`        | Formats any basic integer type formatted as an unsigned hexadecimal integer, using lowercase letters a through f. |
| `%X`        | Formats any basic integer type formatted as an unsigned hexadecimal integer, using uppercase letters A through F. |
| `%o`        | Formats any basic integer type formatted as an unsigned octal integer. |
| `%e`, `%E`, `%f`, `%F`, `%g`, `%G` | Formats any basic floating-point type (float, float32) formatted using c-style floating-point format specifications. |
| `%e`, `%E`  | Formats a signed value having the form `[-]d.dddde[sign]ddd` where `d` is a single decimal digit, `dddd` is one or more decimal digits, `ddd` is exactly three decimal digits, and the sign is `+` or `-`. |
| `%f`        | Formats a signed value having the form `[-]dddd.dddd`, where `dddd` is one or more decimal digits. The number of digits before the decimal point depends on the magnitude of the number, and the number of digits after the decimal point depends on the requested precision. |
| `%g`, `%G`  | Formats a signed value printed in f or e format, whichever is more compact for the given value and precision. |
| `%M`        | Formats a Decimal value. |
| `%O`        | Formats any value, printed by boxing the object and using its `ToString` method. |
| `%A`, `%+A` | Formats any value, printed with the default layout settings. Use `%+A` to print the structure of discriminated unions with internal and private representations. |
| `%a`        | A general format specifier, requires two arguments. The first argument is a function that accepts two arguments: first, a context parameter of the appropriate type for the given formatting function. The second argument is the particular value to print. |
| `%t`        | A general format specifier, requires one argument: a function that accepts a context parameter of the appropriate type for the given formatting function. |

## I/O using .NET

The .NET includes its notation for format specifiers. .NET format strings are untyped and designed to be extensible, meaning that a programmer can implement their custom format strings.

```csharp
System.String.Format("Hi, I'm {0}, {1} old and I'm a {2}", "Mark", 25, "Scorpio")
```

You can also read and write to the console using the `System.Console` class.

```csharp
let name = Console.ReadLine()
Console.WriteLine("Hi, I'm {0}, {1} old and I'm a {2}", name, 25, "Scorpio")
```

## System.IO

The `System.IO` namespace contains a variety of useful classes for performing basic I/O.

The following classes are useful for interrogating the host file system.

| Class              | Description                                                     |
| :------------------| :---------------------------------------------------------------|
| `System.IO.File` | Exposes several useful members for creating, appending, and deleting files.  |
| `System.IO.Directory` | Exposes methods for creating, moving, and deleting directories. |
| `System.IO.Path` | Performs operations on strings that represent file paths.           |
| `System.IO.FileSystemWatcher` | Allows users to listen to a directory for changes.     |

A stream is a sequence of bytes. .NET provides some classes which allow programmers to work with streams.

| Class              | Description                                                     |
| :------------------| :---------------------------------------------------------------|
| `System.IO.StreamReader` | It is used to read characters from a stream.            |
| `System.IO.StreamWriter` | It is used to write characters to a stream.            | 
| `System.IO.MemoryStream` | It creates an in-memory stream of bytes.               |

In the following example write text to the file and then read it from the file.

```csharp
System.IO.File.WriteAllText("myFile.txt", "Welcome to the F# Tutorial.\n You are learning basic I/O.")
let msg = System.IO.File.ReadAllText("myFile.txt")

Console.WriteLine(msg)
```
