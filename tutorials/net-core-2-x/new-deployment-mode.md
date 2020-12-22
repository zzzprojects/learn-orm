---
PermaID: 100017
Name: New Deployment Mode
---

# New Deployment Mode

Starting with .NET Core 2.2, you can deploy framework-dependent executables, which are .exe files instead of .dll files. Functionally similar to framework-dependent deployments, framework-dependent executables (FDE) still rely on the presence of a shared system-wide version of .NET Core to run. Your app contains only your code and any third-party dependencies. Unlike framework-dependent deployments, FDEs are platform-specific.

This new deployment mode has the distinct advantage of building an executable instead of a library, which means you can run your app directly without invoking dotnet first.

Apps published as framework-dependent are cross-platform and don't include the .NET Core runtime. The user of your app is required to install the .NET Core runtime.

Publishing an app as framework-dependent produces a cross-platform binary as a dll file, and a platform-specific executable that targets your current platform. The dll is cross-platform while the executable isn't. For example, if you publish an app named word_reader and target Windows, a word_reader.exe executable is created along with word_reader.dll. When targeting Linux or macOS, a word_reader executable is created along with word_reader.dll.

## Advantages

### Small deployment

Only your app and its dependencies are distributed. The .NET Core runtime and libraries are installed by the user and all apps share the runtime.

### Cross-platform

Your app and any .NET-based library runs on other operating systems. You don't need to define a target platform for your app. For information about the .NET file format, see .NET Assembly File Format.

### Uses the latest patched runtime

The app uses the latest runtime (within the targeted major-minor family of .NET Core) installed on the target system. This means your app automatically uses the latest patched version of the .NET Core runtime. This default behavior can be overridden. For more information, see framework-dependent apps roll forward.

## Disadvantages

### Requires pre-installing the runtime

Your app can run only if the version of .NET Core your app targets is already installed on the host system. You can configure roll-forward behavior for the app to either require a specific version of .NET Core or allow a newer version of .NET Core. For more information, see framework-dependent apps roll forward.

### .NET Core may change

It is possible for the .NET Core runtime and libraries to be updated on the machine where the app is run. 

 - In rare cases, this may change the behavior of your app if you use the .NET Core libraries, which most apps do. 
 - You can configure how your app uses newer versions of .NET Core.

The following disadvantage only applies to .NET Core 2.1 SDK.

 - Use the dotnet command to start the app
 - Users must run the dotnet `<filename.dll>` command to start your app. 
 - .NET Core 2.1 SDK does not produce platform-specific executables for apps published framework-dependent.
