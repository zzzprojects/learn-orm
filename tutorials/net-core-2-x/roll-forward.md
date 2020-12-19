---
PermaID: 100009
Name: Roll Forward
---

# Roll Forward

All .NET Core applications starting with .NET Core 2.0 automatically roll forward to the latest minor version installed on a system.

 - Starting with .NET Core 2.0, if the version of .NET Core that an application was built with is not present at run time, the application automatically runs against the latest installed minor version of .NET Core. 
 - If an application is built with .NET Core 2.0, and .NET Core 2.0 is not present on the host system but .NET Core 2.1 is, the application runs with .NET Core 2.1.

## Modification Options

You can modify this behavior by changing the setting for the roll-forward on no candidate shared framework. The available settings are:

 - **`0`:** disable minor version roll-forward behavior. With this setting, an application built for .NET Core 2.0.0 will roll forward to .NET Core 2.0.1, but not to .NET Core 2.2.0 or .NET Core 3.0.0.
 - **`1`:** enable minor version roll-forward behavior. This is the default value for the setting. With this setting, an application built for .NET Core 2.0.0 will roll forward to either .NET Core 2.0.1 or .NET Core 2.2.0, depending on which one is installed, but it will not roll forward to .NET Core 3.0.0.
 - **`2`:** enable minor and major version roll-forward behavior. If set, even different major versions are considered, so an application built for .NET Core 2.0.0 will roll forward to .NET Core 3.0.0.

The roll-forward behavior does not apply to preview releases. By default, it also does not apply to major releases, but this can be changed with the above settings.

## Settings

You can change the setting in any of the following ways.

 - Set the `DOTNET_ROLL_FORWARD_ON_NO_CANDIDATE_FX` environment variable to the desired value.
 - Add the following line with the desired value to the .runtimeconfig.json file:

```csharp
"rollForwardOnNoCandidateFx" : 0
```

 - When using the .NET Core CLI, add the following option with the desired value to a .NET Core command such as run:

```csharp
dotnet run --rollForwardOnNoCandidateFx=0
```

Patch version roll forward is independent of this setting and is done after any potential minor or major version roll forward is applied.