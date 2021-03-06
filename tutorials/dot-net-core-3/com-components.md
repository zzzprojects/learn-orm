﻿---
PermaID: 100013
Name: COM Components
---

# COM Components

## Create COM Components

You can now create COM-callable managed components on Windows. 

 - This capability is critical to use .NET Core with COM add-in models and provide parity with .NET Framework.
 - Unlike .NET Framework where the `mscoree.dll` was used as the COM server, .NET Core will add a native launcher `dll` to the bin directory when you build your COM component.

### Build and Run

The project will only build and run on the Windows platform. You can build and run the example either by registering the COM server or by using registration-free COM.

### Registered COM

 - Install .NET Core 3.0 Preview 7 or later.
 - Navigate to the root directory and run `dotnet.exe build`.
 - Follow the instructions for COM server registration that were emitted during the build.
 - Navigate to `COMClient/` and run `dotnet.exe run`.

The program should output an estimated value of `π`.

### RegFree COM

 - Install .NET Core 3.0 Preview 7 or later.
 - Navigate to the root directory and run `dotnet.exe build /p:RegFree=True`.
 - If the Registered COM demo was previously run, the project should be cleaned first - `dotnet.exe clean`.
 - Run the generated binary directly. For example, `COMClient\bin\Debug\netcoreapp3.0\COMClient.exe`.

The program should output an estimated value of `π`.

### Note

 - The RegFree COM scenario requires a customized application manifest in the executing binary. 
 - This means that attempting to execute through `dotnet.exe` will not work and instead trigger a rebuild of the project.
 - Running the **Registered COM** first and then immediately following it by **RegFree COM** will not work, since the build system will not correctly rebuild all files (the simple property change is not detected as a reason for a full rebuild). 
 - To fix this, run `dotnet clean` between the two samples.

## Windows Native Interop

Windows offers a rich native API in the form of flat C APIs, COM, and WinRT. While .NET Core supports P/Invoke, .NET Core 3.0 adds the ability to CoCreate COM APIs and Activate WinRT APIs.

## MSIX Deployment

MSIX is a new Windows application package format. It can be used to deploy .NET Core 3.0 desktop applications to Windows 10. The Windows Application Packaging Project, available in Visual Studio 2019, allows you to create MSIX packages with self-contained .NET Core applications.

The .NET Core project file must specify the supported runtimes in the `<RuntimeIdentifiers>` property.

```csharp
<RuntimeIdentifiers>win-x86;win-x64</RuntimeIdentifiers>
```

