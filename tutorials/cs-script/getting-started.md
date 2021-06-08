---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**CS-Script** is a CLR-based scripting system that uses ECMA-compliant C# as a programming language.

 - It is one of the most mature C# scripting solutions, and it was the first comprehensive scripting platform for .NET.
 - It supports both hosted and standalone (CLI) execution model that makes it possible to use the script engine as a pure C# alternative for PowerShell. 
 - It also extends the .NET applications with C# scripts executed at runtime by the hosted script engine.
 
## Features

 - Including (referencing) dependency scripts from the main script
 - Automatic referencing external assemblies based on analyses of the script imported namespaces.
 - Automatic resolving (downloading and referencing) NuGet packages
 - Possibility to plug in external compiling services for supporting alternative script syntax (e.g. VB, C++)
 - Scripts can be executed on Windows, Linux, and OS X (the last two will require Mono)
 - Full integration with Windows, Visual Studio and Notepad++ (CS-Script extension for Notepad++ brings true Intellisense to the 'peoples editor').
 - It allows you to execute a complete C# module (C# file).
 - You can also execute the C# file as an external process e.g. from command-prompt.
 - You can link multiple inter-dependent C# files at runtime and execute them as a single unit.
 - You can easily reference the external dependency assemblies.
 - It also supports debugging scripts.

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package CS-Script
```

