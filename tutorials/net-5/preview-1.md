---
PermaID: 100001
Name: Preview 1
---

# Preview 1

In .NET 5 Preview 1 which is the first iteration becomes one framework to handle all .NET development projects. From .NET Core 3.1 to .NET 5, it has significant changes and improvements such as, 

 - The traditional Windows-only .NET Framework and focus on unifying everything under one cross-platform. 
 - Open-source.
 - Game-changing" platform based on one single Base Class Library (BCL). 

## Application Types

.NET 5 is the future of .NET and has become a single unified platform for building any type of application. Xamarin mobile development platform is shifted from Mono BCL to the .NET Core BCL and Xamarin mobile development will be folded into .NET 5. So for the first time, one BCL-based framework will handle all application models. 

 - ASP.NET Core
 - Entity Framework Core
 - WinForms
 - WPF
 - Xamarin
 - ML.NET

## Framework Improvements

In Preview 1, many areas of the framework are improved, and some of them are as follows.

### Regular expression performance improvements

Significant improvements are made to the Regex engine. With these improvements, the throughput is improved by 3-6x, and in some cases, much more. 

### Code quality improvements in RyuJIT

Every release includes a set of performance improvements to the code that the JIT generates. We refer to these types of improvements as “CQ” or code quality. In most cases, these improvements also apply to the code generated for ready-to-run images.

You can see the following improvements in preview 1:

 - **Improvements for null check folding:** Remove the need to generate null checks in more cases by observing more patterns where null checks are probably unnecessary.
 - **Tuned common subexpression evaluation (CSE):** The JIT looks for and collapses duplicate expressions that only need to be evaluated once (wiki).
 - **Optimizing "constant_string".Length:** Optimizing this pattern and collapsing the code down to the correct integer value.
 - **JIT: build basic block pred lists before morph:** Re-order phases in the JIT to allow key optimizations to be used earlier, resulting in better code quality and less work for the following phases, which increases JIT throughput (“TP” in the referenced PR).

## Added Assembly Load Diagnostics to Event Pipe

In preview 1, the assembly load information is also added to the event pipe. 

 - It is the start of making similar diagnostics functionality available as is part of .NET Framework with the **Fusion Log Viewer**. 
 - You can now use the `dotnet-trace` command to collect this information as shown below.

```csharp
dotnet-trace collect --providers Microsoft-Windows-DotNETRuntime:4:4 --process-id [process ID]
```

You can view the trace file in [PerfView](https://github.com/microsoft/perfview) for Windows.

## Event Pipe Profiler APIs

Event pipe APIs are in .NET Core 2.2 to make it possible to perform performance and other diagnostic investigations on any operating system. 

 - In .NET 5.0, the event pipe has been extended to enable profilers to write event pipe events. 
 - It is critical for instrumenting profilers that previously relied on ETW to monitor application behavior and performance.

## GitHub Repo Consolidation

In .NET 5, the number of GitHub Repos is reduced to build and package .NET. 

 - Repo boundaries have a significant impact on many aspects of a project, including builds and issue management. 
 - In .NET Core 1.0, there were more than 100 repos across ASP.NET, EF, and .NET Core. 
 - In .NET 5, you can now count the primary repos on one hand and nearly all the repos are moved to the dotnet org.

## Future High-Level Goals

Microsoft also provided more information about the ongoing development of .NET 5, listing its future high-level goals as:

 - Unified .NET SDK experience:
 - Native Applications supporting multiple platforms
 - Web Applications supporting multiple platforms
 - Cloud-Native Applications
 - Continuous Improvements, such as faster algorithms in the BCL, better support for containers in the runtime, and support for HTTP3.

