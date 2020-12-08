---
PermaID: 100009
Name: Local Tools
---

# .NET Tools

A .NET tool is a special NuGet package that contains a console application. You can install a tool on your machine in the following ways.

 - [Global Tool](#global-tool)
 - [Local Tool](#local-tool)

## Global Tool

The tool binaries are installed in a default directory that is added to the `PATH` environment variable. 

 - You can invoke the tool from any directory on the machine without specifying its location. 
 - One version of a tool is used for all directories on the machine.

You can also install it as a global tool in a custom location (also known as a tool-path tool).

 - The tool binaries are installed in a location that you specify. 
 - You can invoke the tool from the installation directory or by providing the directory with the command name or by adding the directory to the `PATH` environment variable. 

## Local Tool

In .NET Core 3.0, local tools are introduced. The local tool applies to .NET Core SDK 3.0 and later. The tool binaries are installed in a default directory. You invoke the tool from the installation directory or any of its subdirectories. 

 - Different directories can use different versions of the same tool.
 - The .NET CLI uses manifest files to keep track of which tools are installed as local to a directory. 
 - When the manifest file is saved in the root directory of a source code repository, a contributor can clone the repository and invoke a single .NET CLI command that installs all of the tools listed in the manifest files.

Local tools are similar to global tools but are associated with a particular location on disk. Local tools are not available globally and are distributed as NuGet packages.

 - Local tools rely on a manifest file name `dotnet-tools.json` in your current directory. 
 - This manifest file defines the tools to be available in that folder and below. 
 - You can distribute the manifest file with your code to ensure that anyone who works with your code can restore and use the same tools.

For both global and local tools, a compatible version of the runtime is required. Many tools currently on NuGet.org target .NET Core Runtime 2.1.

### Install a Local Tool

To install a tool for local access only for the current directory and subdirectories, it has to be added to a tool manifest file. To create a tool manifest file, run the dotnet new tool-manifest command:

```csharp
dotnet new tool-manifest
```

This command creates a manifest file named `dotnet-tools.json` under the `.config` directory. To add a local tool to the manifest file, use the dotnet tool install command and omit the `--global` and `--tool-path` options as shown below. 

```csharp
dotnet tool install dotnetsay
```

The command output shows which manifest file the newly installed tool is in, similar to the following example.

```csharp
You can invoke the tool from this directory using the following command:
dotnet tool run dotnetsay
Tool 'dotnetsay' (version '2.1.4') was successfully installed.
Entry is added to the manifest file /home/name/botsay/.config/dotnet-tools.json.
```