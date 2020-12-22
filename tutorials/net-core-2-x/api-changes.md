---
PermaID: 100004
Name: API Changes
---

# API Changes

## Support for .NET Standard 2.0

.NET Standard defines a versioned set of APIs that must be available on .NET implementations that comply with that version of the standard. .NET Standard is targeted at library developers. 

 - It aims to guarantee the available functionalty to a library that targets a version of the .NET Standard on each .NET implementation. 
 - .NET Core 1.x supports .NET Standard version 1.6; .NET Core 2.0 supports the latest version, .NET Standard 2.0. 

.NET Standard 2.0 includes over 20,000 more APIs than were available in .NET Standard 1.6. Much of this expanded surface area results from incorporating APIs that are common to the .NET Framework and Xamarin into .NET Standard.

 - .NET Standard 2.0 class libraries can also reference .NET Framework class libraries, provided that they call APIs that are present in .NET Standard 2.0. 
 - No recompilation of the .NET Framework libraries is required.

## Expanded Surface Area

The total number of APIs available on .NET Core 2.0 has more than doubled compared with .NET Core 1.1.

And with the Windows Compatibility Pack porting from .NET Framework has also become much simpler.

 - Some of the most common issues found when porting existing code to .NET Core are dependencies on APIs and technologies only found in .NET Framework. 
 - The Windows Compatibility Pack provides many of these technologies, so it is much easier to build .NET Core applications and .NET Standard libraries.

### Package Contents

The Windows Compatibility Pack is provided via the [Microsoft.Windows.Compatibility](https://www.nuget.org/packages/Microsoft.Windows.Compatibility) NuGet package and can be referenced from projects that target .NET Core or .NET Standard.

It provides about 20,000 APIs, including Windows-only as well as cross-platform APIs from the following technology areas:

 - Code Pages
 - CodeDom
 - Configuration
 - Directory Services
 - Drawing
 - ODBC
 - Permissions
 - Ports
 - Windows Access Control Lists (ACL)
 - Windows Communication Foundation (WCF)
 - Windows Cryptography
 - Windows EventLog
 - Windows Management Instrumentation (WMI)
 - Windows Performance Counters
 - Windows Registry
 - Windows Runtime Caching
 - Windows Services

## Support for .NET Framework Libraries

.NET Core code can reference existing .NET Framework libraries, including existing NuGet packages. Note that the libraries must use APIs that are found in .NET Standard.

