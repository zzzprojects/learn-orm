---
PermaID: 100001
Name: Default Executables
---

# Default Executables

By default, .NET Core now builds framework-dependent executables. This behavior is new for applications that use a globally installed version of .NET Core. 

 - Previously, only self-contained deployments would produce an executable.
 - During `dotnet build` or `dotnet publish`, an executable also known as the `appHost` is created that matches the environment and platform of the SDK you are using. 

You can expect the same things with these executables as you would other native executables, such as:

 - You can double-click on the executable.
 - You can launch the application from a command prompt directly, such as `myapp.exe` on Windows, and `./myapp` on Linux and macOS.

## Produce an executable

Executables are not cross-platform and are specific to an operating system and CPU architecture. When publishing your app and creating an executable, you can publish the app as self-contained or framework-dependent. 

 - Publishing an app as self-contained includes the .NET Core runtime with the app, and users of the app don't have to worry about installing .NET Core before running the app. 
 - Apps published as framework-dependent don't include the .NET Core runtime and libraries; only the app and 3rd-party dependencies are included.

The following commands produce an executable:

| Type                                                     | Command   |
|:---------------------------------------------------------|:----------|
| framework-dependent executable for the current platform. | dotnet publish |
| framework-dependent executable for a specific platform.  | dotnet publish -r <RID> --self-contained false  |
| self-contained executable.                               | dotnet publish -r <RID>  |

## Produce a cross-platform binary

Cross-platform binaries are created when you publish your app as framework-dependent, in the form of a `dll` file. The `dll` file is named after your project. For example, if you have an app named `word_reader`, a file named `word_reader.dll` is created. 

 - Apps published in this way are run with the `dotnet <filename.dll>` command and can be run on any platform.
 - Cross-platform binaries can be run on any operating system as long as the targeted .NET Core runtime is already installed. 
 - If the targeted .NET Core runtime isn't installed, the app may run using a newer runtime if the app is configured to roll-forward. 

The following command produces a cross-platform binary:

| Type                                                     | Command   |
|:---------------------------------------------------------|:----------|
| framework-dependent cross-platform binary.               | dotnet publish |