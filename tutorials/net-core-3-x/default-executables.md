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