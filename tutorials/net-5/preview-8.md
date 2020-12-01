---
PermaID: 100008
Name: Preview 8
---

# Preview 8

.NET 5.0 includes many improvements, notably single file applications, smaller container images, more capable JsonSerializer APIs, a complete set of nullable reference type annotations, and support for Windows ARM64. 

 - Performance has been greatly improved, in the NET libraries, in the GC, and the JIT. 
 - ARM64 was a key focus for performance investment, resulting in much better throughput and smaller binaries. 
 - .NET 5.0 includes new language versions, C# 9 and F# 5.0.

## Languages

C# 9 and F# 5 are part of the .NET 5.0 release and included in the .NET 5.0 SDK. 

 - Visual Basic is also included in the 5.0 SDK. 
 - It does not include language changes but has improvements to support the Visual Basic Application Framework on .NET Core.

[C# Source Generators](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/) are an important new C# compiler feature that isn't technically part of C# 9 since it doesn't have any language syntax. See [New C# Source Generator Samples](https://devblogs.microsoft.com/dotnet/new-c-source-generator-samples/) to help you get started using this new feature.

### C# 9

C# 9 is a significant release of the language, focused on program simplicity, data immutability, and more patterns. In this post, we'll stick to what might be the crowd favorites.

#### Top-level programs

Top-level programs offer a simpler syntax for programs, with much less ceremony. 

 - This syntax will help people learning the language in the first place. 
 - We expect the top-level program syntax to get simpler in subsequent releases, like the removal of default using statements.

The following is the C# 9 version of "hello world".

```csharp
using System;

Console.WriteLine("Hello World!");
```

Top-level programs can be extended to use more functionality, such as defining and calling a method or class within the same file.

```csharp
using System;
using System.Runtime.InteropServices;

Console.WriteLine("Hello World!");
FromWhom();
Show.Excitement("Top-level programs can be brief, and can grow as slowly or quickly in complexity as you'd like", 8);

void FromWhom()
{
    Console.WriteLine($"From {RuntimeInformation.FrameworkDescription}");
}

internal class Show
{
    internal static void Excitement(string message, int levelOf)
    {
        Console.Write(message);

        for (int i = 0; i < levelOf; i++)
        {
            Console.Write("!");
        }

        Console.WriteLine();
    }
}
```

This program produces the following output.

```csharp
Hello World!
From .NET 5.0.0-preview.8
Top-level programs can be brief, and can grow as slowly or quickly in complexity as you'd like!!!!!!!!
```

#### Pattern matching

Patterns test that a value has a certain shape, and can extract information from the value when it has the matching shape. New pattern matching improvements have been added in the last few versions of C#.

I'll share two examples. The first demonstrates property patterns. It checks for null (with is) before comparing the context object to a specific pattern.

```csharp
if (context is {IsReachable: true, Length: > 1 })
{
    Console.WriteLine(context.Name);
}
```

This is equivalent to:

```csharp
if (context is object && context.IsReachable && context.Length > 1 )
{
    Console.WriteLine(context.Name);
}
```

Also equivalent to:

```csharp
if (context?.IsReachable && context?.Length > 1 )
{
    Console.WriteLine(context.Name);
}
```

The following example uses relational patterns (like <, <=), and logical ones (like and, or and not). The following code produces the highway toll (as a decimal) for a delivery truck based on its gross weight. For those not familiar, m after a numeric literal tells the compiler then the number is a decimal and not a double.

```csharp
DeliveryTruck t when t.GrossWeightClass switch
{
    < 3000 => 8.00m,
    >= 3000 and <= 5000 => 10.00m,
    > 5000 => 15.00m,
},
```

#### Target-typed new expressions

Target-typed new expressions are a new way to remove type duplication when constructing objects/values.

The following examples are all equivalent, with the new syntax being the middle one.

```csharp
List<string> values = new List<string>();
List<string> values = new();
var values = new List<string>();
```

Many people will prefer this new syntax over `var` for two reasons. 

many people read left-to-right and want the type information on the left-hand side of =, and (likely more importantly) the left side is solely dedicated to type information and not distracted by the complexity or nuance of a particular constructor (on the right-hand side).

### F# 5

Building on updates to the F# 5 preview released earlier this year, this final update to F# 5 wraps up language support and adds two new features, Interpolated Strings, and Open Type Declarations. Here's a sneak peek at what you can do with them:

#### Interpolated Strings

Interpolated strings in F# are one of the most highly-requested features. People familiar with them in C# and JavaScript have come to love them in those languages. 

In F#, the interpolated strings are introduced in an untyped fashion as they exist in other languages, but also with typed interpolated holes where the expression in an interpolated context must match a type given by a string format specifier.

```csharp
// Basic interpolated string
let name = "Phillip"
let age = 29
let message = $"Name: {name}, Age: {age}"

// Typed interpolation
// '%s' requires the interpolation to be of type string
// '%d' requires the interpolation to be an integer
let message2 = $"Name: %s{name}, Age: %d{age}"
```

#### Open Type Declarations

Open Type Declarations in F# are similar to the ability to open static classes in C#, but with a slightly different syntax. They are also extended to allow opening F# specific types.

```csharp
open type System.Math

let x = Min(1.0, 2.0)

module M =
    type DU = A | B | C

    let someOtherFunction x = x + 1

// Open only the type inside the module
open type M.DU

printfn "%A" A
```

Stay tuned for a blog post that goes over the details.

## Tools

Here are some of the improvements to the runtime diagnostic tools.

### Microsoft.Extensions.Logging

The team has made improvements to the console log provider in the `Microsoft.Extensions.Logging` library. 

 - Developers can now implement a custom `ConsoleFormatter` to exercise complete control over formatting and colorization of the console output. 
 - The formatter APIs allow for rich formatting by implementing a subset of the VT-100 (supported by most modern terminals) escape sequences. The console logger can parse out escape sequences on unsupported terminals allowing you to author a single formatter for all terminals.

Besides, to support custom formatters, a built-in JSON formatter is also added that emits structured JSON logs to the console. 

### Dump debugging

Debugging managed code requires special knowledge of managed objects and constructs. The Data Access Component (DAC) is a subset of the runtime execution engine that has knowledge of these constructs and can access these managed objects without a runtime. 

 - Starting with Preview 8, we have started to compile the Linux DAC against Windows. 
 - .NET Core process dumps collected on Linux can now be analyzed on Windows using WinDBG or `dotnet dump analyze`.

In Preview 8, the support for capturing ELF dumps from .NET processes running on macOS is also added. a

 - Since ELF is not the native executable file format on macOS, we have made this an opt-in feature. 
 - To enable support for dump collection on macOS, set the environment variable `COMPlus_DbgEnableElfDumpOnMacOS=1`. 
 - The resulting dumps can be analyzed using `dotnet dump analyze`.

### Assembly load diagnostics added to event pipe

The assembly load information is added to the event pipe. You can think of this as a replacement to the [Fusion Log Viewer](https://docs.microsoft.com/en-us/dotnet/framework/tools/fuslogvw-exe-assembly-binding-log-viewer). You can now use dotnet-trace to collect this information, using the following command:

```csharp
dotnet-trace collect --providers Microsoft-Windows-DotNETRuntime:4:4 --process-id [process ID]
```

The workflow is described in Trace Assembly Loading with Event Pipe.

### Printing environment information

As .NET has extended support for new operating systems and chip architectures, people sometimes want a way to print environment information. We created a simple .NET tool that does this, called dotnet-runtimeinfo.

You can install and run the tool with the following commands.

```csharp
dotnet tool install -g dotnet-runtimeinfo
dotnet-runtimeinfo
```
The tool produces output in the following form for your environment.

```csharp
.NET information
Version: 5.0.0
FrameworkDescription: .NET 5.0.0-preview.8.20407.11
Libraries version: 5.0.0-preview.8.20407.11
Libraries hash: bf456654f9a4f9a86c15d9d50095ff29cde5f0a4

**Environment information
OSDescription: Linux 5.8.3-2-MANJARO-ARM #1 SMP Sat Aug 22 21:00:07 CEST 2020
OSVersion: Unix 5.8.3.2
OSArchitecture: Arm64
ProcessorCount: 6

**CGroup info
cfs_quota_us: -1
memory.limit_in_bytes: 9223372036854771712
memory.usage_in_bytes: 2945581056
```

### Library APIs

Many new APIs were added and improved in .NET 5.0. The following are important changes.

#### Nullable Annotations

Nullable reference types were an important feature of C# 8 and .NET Core 3.0. It was released with a lot of promise but was missing exhaustive platform annotations to make it truly useful and practical. 

 - The platform is now 80% annotated for nullability and the team is looking into whether we can annotate the remaining 20% before we ship .NET 5.0 RTM. If not, then it is going to finish the remaining annotations early in .NET 6.0.
 - This also means that your existing .NET Core 3.1 code might generate new diagnostics (if you have nullability enabled) when you retarget it to .NET 5.0. If that happens, you can thank us for helping you avoid nulls.

#### Regular expression performance improvements

The team has invested a lot to improve the Regex engine. With these improvements, the throughput is improved by 3-6x, and in some cases, much more. The changes we’ve made in System.Text.RegularExpressions have had a measurable impact on our uses, and we hope these improvements will result in measurable wins in your libraries and apps, as well.

