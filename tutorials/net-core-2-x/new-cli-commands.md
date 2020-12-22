---
PermaID: 100007
Name: New CLI Commands
---

# New CLI Commands

Several tools available only on a per-project basis using DotnetCliToolReference are now available as part of the .NET Core SDK. These tools include:

## `dotnet watch`

`dotnet watch` provides a file system watcher that waits for a file to change before executing a designated set of commands. For example, the following command automatically rebuilds the current project and generates verbose output whenever a file in it changes:

.NET Core CLI

```csharp
dotnet watch -- --verbose build
```

 - The `--` option that precedes the `--verbose` option delimits the options passed directly to the `dotnet watch` command from the arguments passed to the child dotnet process. 
 - Without the `--` option, the `--verbose` option applies to the `dotnet watch` command, not the `dotnet build` command.


## `dotnet-watch` configuration

Some configuration options can be passed to dotnet watch through environment variables. The available variables are:

| Setting               | Description                                                         |
|:----------------------|:--------------------------------------------------------------------|
| `DOTNET_USE_POLLING_FILE_WATCHER`       | If set to `1` or `true`, `dotnet watch` uses a polling file watcher instead of CoreFx's `FileSystemWatcher`. Used when watching files on network shares or Docker mounted volumes. |
| `DOTNET_WATCH_SUPPRESS_MSBUILD_INCREMENTALISM`   | By default, `dotnet watch` optimize the build by avoiding certain operations such as running restore or re-evaluating the set of watched files on every file change. If set to `1` or `true`, these optimizations are disabled. |
| `DOTNET_WATCH_SUPPRESS_LAUNCH_BROWSER`    | `dotnet watch` run attempts to launch browsers for web apps with launchBrowser configured in `launchSettings.json`. If set to `1` or `true`, this behavior is suppressed. |
| `DOTNET_WATCH_SUPPRESS_BROWSER_REFRESH`   | `dotnet watch` run attempts to refresh browsers when it detects file changes. If set to `1` or `true`, this behavior is suppressed. This behavior is also suppressed if `DOTNET_WATCH_SUPPRESS_LAUNCH_BROWSER` is set. |

## `dotnet dev-certs`

`dotnet dev-certs` generates and manages certificates used during development in ASP.NET Core applications.

## `dotnet user-secrets`

`dotnet user-secrets` manages the secrets in a user secret store in ASP.NET Core applications.

## `dotnet sql-cache`

`dotnet sql-cache` creates a table and indexes in a Microsoft SQL Server database to be used for distributed caching.

## `dotnet ef`

`dotnet ef` is a tool for managing databases, DbContext objects, and migrations in Entity Framework Core applications. 

 - The command-line interface (CLI) tools for Entity Framework Core perform design-time development tasks. 
 - For example, they create migrations, apply migrations, and generate code for a model based on an existing database. 
 - The commands are an extension to the cross-platform `dotnet` command, which is part of the .NET Core SDK. 
 - These tools work with .NET Core projects.

