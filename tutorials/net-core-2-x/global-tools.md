---
PermaID: 100008
Name: Global Tools
---

# Global Tools

A .NET tool is a special NuGet package that contains a console application. The tool binaries are installed in a default directory that is added to the `PATH` environment variable. 

 - You can invoke the tool from any directory on the machine without specifying its location. 
 - One version of a tool is used for all directories on the machine.

You can also install it as a global tool in a custom location (also known as a tool-path tool).

 - The tool binaries are installed in a location that you specify. 
 - You can invoke the tool from the installation directory or provide the directory with the command name or by adding the directory to the `PATH` environment variable. 

.NET Core 2.1 supports Global Tools that are available globally from the command line. The extensibility model in previous versions of .NET Core made custom tools available on a per-project basis only by using `DotnetCliToolReference`.

## Install a Global Tool

To install a tool as a global tool, use the `-g` or `--global` option of dotnet tool install, as shown in the following example:

```csharp
dotnet tool install -g dotnetsay
```

The output shows the command used to invoke the tool and the version installed, similar to the following example:

```csharp
You can invoke the tool using the following command: dotnetsay
Tool 'dotnetsay' (version '2.1.4') was successfully installed.
```

The default location for a tool's binaries depends on the operating system:

| OS              | Path                            |
|:----------------|:--------------------------------|
| Linux/macOS     | `$HOME/.dotnet/tools`         |
| Windows         | `%USERPROFILE%\.dotnet\tools`|

## Install a Global Tool in a Custom Location

To install a tool as a global tool in a custom location, use the --tool-path option of dotnet tool install, as shown in the following examples.

**On Windows**

```csharp
dotnet tool install dotnetsay --tool-path c:\dotnet-tools
```

**On Linux or macOS**

```csharp
dotnet tool install dotnetsay --tool-path ~/bin
```

The .NET SDK doesn't add this location automatically to the PATH environment variable. To invoke a tool-path tool, you have to make sure the command is available by using one of the following methods:

 - Add the installation directory to the PATH environment variable.
 - Specify the full path to the tool when you invoke it.
 - Invoke the tool from within the installation directory.

Once installed, the tool can be run from the command line by specifying the tool name.

## Tool Management with the `dotnet tool` command

In .NET Core 2.1 SDK, all tools operations use the `dotnet tool` command. The following options are available.

 - `dotnet tool install` to install a tool.
 - `dotnet tool update` to uninstall and reinstall a tool, which effectively updates it.
 - `dotnet tool list` to list currently installed tools.
 - `dotnet tool uninstall` to uninstall currently installed tools.
