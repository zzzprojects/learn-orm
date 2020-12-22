---
PermaID: 100011
Name: Self-contained Application Servicing
---

# Self-contained Application Servicing

The `dotnet publish` command now publishes self-contained applications with a serviced runtime version. 

 - Your application includes the latest serviced runtime version known by that SDK when you publish a self-contained application with the .NET Core 2.1 SDK (v 2.1.300).
 - When you upgrade to the latest SDK, you'll publish with the latest .NET Core runtime version. 
 - This applies for .NET Core 1.0 runtimes and later.

Self-contained publishing relies on runtime versions on NuGet.org. You do not need to have the serviced runtime on your machine.

 - Using the .NET Core 2.0 SDK, self-contained applications are published with the .NET Core 2.0.0 runtime unless a different version is specified via the `RuntimeFrameworkVersion` property. 
 - With this new behavior, you will no longer need to set this property to select a higher runtime version for a self-contained application. 
 - The easiest approach going forward is to always publish with .NET Core 2.1 SDK (v 2.1.300).

## Self-contained Deployment Runtime Roll Forward

.NET Core self-contained application deployments include both the .NET Core libraries and the .NET Core runtime. 

 - Starting in .NET Core 2.1 SDK (version 2.1.300), a self-contained application deployment publishes the highest patch runtime on your machine. 
 - By default, `dotnet publish` for a self-contained deployment selects the latest version installed as part of the SDK on the publishing machine. 
 - This enables your deployed application to run with security fixes, and other fixes available during publish. 
 - The application must be republished to obtain a new patch. 
 - Self-contained applications are created by specifying `-r` <RID> on the `dotnet publish` command or by specifying the runtime identifier (RID) in the project file `.csproj` / `.vbproj` or on the command line.

## Patch Version Roll Forward Overview

The `restore`, `build`, and `publish` are dotnet commands that can run separately. The runtime choice is part of the `restore` operation, not `publish` or `build`. 

 - If you call `publish`, the latest patch version will be chosen. 
 - If you call publish with the --no-restore argument. You may not get the desired patch version because a prior restore may not have been executed with the new self-contained application publishing policy. 
 - In this case, the following build error is generated.

`
"The project was restored using Microsoft.NETCore.App version 2.0.0, but with current settings, version 2.0.6 would be used instead. To resolve this issue, make sure the same settings are used to restore and for subsequent operations such as build or publish. Typically this issue can occur if the RuntimeIdentifier property is set during build or publish but not during restore."
`
