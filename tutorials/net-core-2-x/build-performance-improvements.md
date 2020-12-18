---
PermaID: 100006
Name: Build Performance Improvements
---

# Build Performance Improvements

A major focus of .NET Core 2.1 is improving build-time performance, particularly for incremental builds. These performance improvements apply to both command-line builds using dotnet build and to builds in Visual Studio. 

Some individual areas of improvement include:

 - For package asset resolution, resolving only assets used by a build rather than all assets.
 - Caching of assembly references.
 - Use of long-running SDK build servers, which are processes that span across individual `dotnet build` invocations. 
 - They eliminate the need to JIT-compile large blocks of code every time `dotnet build` is run. 

Build server processes can be automatically terminated with the following command:

```csharp
dotnet buildserver shutdown
```
