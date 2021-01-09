---
PermaID: 100002
Name: macOS appHost and Notarization
---

# macOS appHost and Notarization

By default, non-notarized versions of the .NET Core SDK 3.0 and above produce a native Mach-O executable (known as the appHost) when your project compiles, publishes, or is run. 

 - When the appHost setting is enabled, .NET Core generates a native Mach-O executable when you build or publish. 
 - Your app runs in the context of the appHost when it is run from source code with the `dotnet run` command, or by starting the Mach-O executable directly.
 - Without the appHost, the only way a user can start a framework-dependent app is with the `dotnet <filename.dll> command`. 

You can turn on appHost generation with the UseAppHost boolean setting in the project file as shown below.

```csharp
<PropertyGroup>
  <UseAppHost>true</UseAppHost>
</PropertyGroup>
```

You can also toggle the appHost with the `-p:UseAppHost` parameter on the command line for the specific dotnet command you run as shown below.

```csharp
dotnet run -p:UseAppHost=true
```

An appHost is always created when you publish your app self-contained.

## Context of the appHost

When the appHost is enabled in your project, and you use the `dotnet run` command to run your app, the app is invoked in the context of the appHost and not the default host. 

 - If the appHost is disabled in your project, the `dotnet run` command runs your app in the context of the default host. 
 - Even if the appHost is disabled, publishing your app as self-contained generates an appHost executable, and users use that executable to run your app. 
 - Running your app with `dotnet <filename.dll>` invokes the app with the default host, the shared runtime.

When an app using the appHost is invoked, the certificate partition accessed by the app is different from the notarized default host. If your app must access the certificates installed through the default host, use the `dotnet run` command to run your app from its project file, or use the `dotnet <filename.dll>` command to start the app directly.
