---
PermaID: 100004
Name: Assembly Linking
---

# Assembly Linking

The .NET core 3.0 SDK provides a tool that can reduce the size of applications by analyzing IL and trimming unused assemblies.

 - Self-contained apps include everything needed to run your code, without requiring .NET to be installed on the host computer. 
 - However, many times the app only requires a small subset of the framework to function, and other unused libraries could be removed.

## IL Linker

The IL Linker is a tool one can use to only ship the minimal possible IL code and metadata that a set of programs might require to run as opposed to the full libraries.

 - .NET Core now includes a setting that will use the IL linker tool to scan the IL of your app. 
 - This tool detects what code is required, and then trims unused libraries. 
 - This tool can significantly reduce the deployment size of some apps.

To enable this tool, add the `<PublishTrimmed>` setting in your project and publish a self-contained app.

```csharp
<PropertyGroup>
  <PublishTrimmed>true</PublishTrimmed>
</PropertyGroup>
```

Or you can run the following from the command line as shown below.

```csharp
dotnet publish -r <rid> -c Release
```

As an example, the basic "hello world" new console project template that is included, when published, hits about 70 MB in size. By using `<PublishTrimmed>`, that size is reduced to about 30 MB.

 - It is important to consider that applications or frameworks (including ASP.NET Core and WPF) that use reflection or related dynamic features, will often break when trimmed. 
 - This breakage occurs because the linker doesn't know about this dynamic behavior and can't determine which framework types are required for reflection. 
 - The IL Linker tool can be configured to be aware of this scenario.

Make sure to test your application after trimming.