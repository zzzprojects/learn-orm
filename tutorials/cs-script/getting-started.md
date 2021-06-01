---
PermaID: 100000
Name: Getting Started
---

# Getting Started

**CS-Script** is a CLR-based scripting system that uses ECMA-compliant C# as a programming language.

 - It is one of the most mature C# scripting solutions and it was the first comprehensive scripting platform for .NET.
 - It supports both hosted and standalone (CLI) execution model that makes it possible to use the script engine as a pure C# alternative for PowerShell. 
 - It also extends the .NET applications with C# scripts executed at runtime by the hosted script engine.
 
## Features

 - CS-Script allows seamlessly switching underlying compiling technology without affecting the codebase. 
 - It can be run on Windows and Linux. 
 - Class library for hosting the script engine is compiled for **.NET Standard**, so it can be hosted by any managed application.
 - The library is built against .NET Standard 2.0 so it can be hosted on any edition of runtime. 
 - However, the script evaluation is done via .NET 5 toolchain so it needs to be installed on the host PC even if the application is implemented with the older framework (e.g. .NET Framework).
 - It allows you to execute a complete C# module (C# file).
 - You can also execute the C# file as an external process e.g. from command-prompt.
 - You can link multiple inter-dependent C# files at runtime and execute them as a single unit.
 - You can easily reference the dependency assemblies.
 - It also supports debugging scripts.

## Installation

You can easily install it from the **Package Manager Console** window by running the following command.

```csharp
PM> Install-Package CS-Script
```

