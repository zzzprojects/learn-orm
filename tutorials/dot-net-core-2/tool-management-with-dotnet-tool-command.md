---
PermaID: 100009
Name: Tool Management With Dotnet Tool Command
---

# Tool Management with the `dotnet tool` command

In .NET Core 2.1 SDK, all tools operations use the `dotnet tool` command. The following options are available.

 - [`dotnet tool install`](#dotnet-tool-install)
 - [`dotnet tool update`](#dotnet-tool-update)
 - [`dotnet tool list`](#dotnet-tool-list)
 - [`dotnet tool uninstall`](#dotnet-tool-uninstall)

## `dotnet tool install`

The `dotnet tool install` command provides a way for you to install .NET tools on your machine. To use the command, you specify one of the following installation options:

 - To install a global tool in the default location, use the `--global` option.
 - To install a global tool in a custom location, use the `--tool-path` option.
 - To install a local tool, omit the `--global` and `--tool-path` options.

### Examples

To install the `dotnetsay` global tool in the default location, use the following command.

```csharp
dotnet tool install -g dotnetsay
```

To install the `dotnetsay` global tool located in a specific Windows directory.

```csharp
dotnet tool install dotnetsay --tool-path c:\global-tools
```

## `dotnet tool update`

The `dotnet tool update` command provides a way for you to update .NET tools on your machine to the latest stable version of the package. The command uninstalls and reinstalls a tool, effectively updating it. To use the command, you specify one of the following options:

 - To update a global tool that was installed in the default location, use the `--global` option.
 - To update a global tool that was installed in a custom location, use the `--tool-path` option.
 - To update a local tool, use the `--local` option.

### Examples

To update the `dotnetsay` global tool, use the following command.

```csharp
dotnet tool update -g dotnetsay
```

To update the `dotnetsay` global tool located in a specific Windows directory.

```csharp
dotnet tool update dotnetsay --tool-path c:\global-tools
```

## `dotnet tool list`

The `dotnet tool list` command provides a way for you to list all .NET global, tool-path, or local tools installed on your machine. The command lists the package name, the version installed, and the tool command. To use the command, you specify one of the following:

 - To list global tools installed in the default location, use the `--global` option
 - To list global tools installed in a custom location, use the `--tool-path` option.
 - To list local tools, use the `--local` option or omit the `--global`, `--tool-path`, and `--local` options.

### Examples

To list all global tools installed user-wide on your machine (current user profile).

```csharp
dotnet tool list -g
```

To list the global tools from a specific Windows directory.

```csharp
dotnet tool list --tool-path c:\global-tools
```

## `dotnet tool uninstall`

The `dotnet tool uninstall` command provides a way for you to uninstall .NET tools from your machine. To use the command, you specify one of the following options:

 - To uninstall a global tool that was installed in the default location, use the `--global` option.
 - To uninstall a global tool that was installed in a custom location, use the `--tool-path` option.
 - To uninstall a local tool, omit the `--global` and `--tool-path` options.

### Examples

To uninstalls the `dotnetsay` global tool.

```csharp
dotnet tool uninstall -g dotnetsay
```

To uninstalls the `dotnetsay` global tool from a specific Windows directory.

```csharp
dotnet tool uninstall dotnetsay --tool-path c:\global-tools
```
