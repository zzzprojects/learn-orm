---
PermaID: 100012
Name: Windows Desktop
---

# Windows Desktop

.NET Core 3.0 supports Windows desktop applications using Windows Presentation Foundation (WPF) and Windows Forms. These frameworks also support using modern controls and Fluent styling from the Windows UI XAML Library (WinUI) via XAML islands.

The Windows Desktop component is part of the Windows .NET Core 3.0 SDK.

You can create a new WPF or Windows Forms app with the following dotnet commands:

```csharp
dotnet new wpf
dotnet new winforms
```

Visual Studio 2019 adds New Project templates for .NET Core 3.0 Windows Forms and WPF.

## .NET Core SDK Windows Installer

In .NET Core 3.0, the MSI installer for Windows has changed. The SDK installers will now upgrade SDK feature-band releases in place. 
 - Feature bands are defined in the hundreds of groups in the patch section of the version number. 
 - For example, 3.0.101 and 3.0.201 are versions in two different feature bands while 3.0.101 and 3.0.199 are in the same feature band. 
 - And, when .NET Core SDK 3.0.101 is installed, .NET Core SDK 3.0.100 will be removed from the machine if it exists. 
 - When .NET Core SDK 3.0.200 is installed on the same machine, .NET Core SDK 3.0.101 won't be removed.

## WinForms high DPI

.NET Core Windows Forms applications can set high DPI mode with `Application.SetHighDpiMode(HighDpiMode)`. The `SetHighDpiMode` method sets the corresponding high DPI mode unless the setting has been set by other means like `App.Manifest` or `P/Invoke` before `Application.Run`.

The possible highDpiMode values, as expressed by the `System.Windows.Forms.HighDpiMode` enum are as follows.  

 - **DpiUnaware**: The application window does not scale for DPI changes and always assumes a scale factor of 100%.
 - **SystemAware**: The window queries for the DPI of the primary monitor once and uses this for the application on all monitors.
 - **PerMonitor**: The window checks for DPI when it's created and adjusts the scale factor when the DPI changes.
 - **PerMonitorV2**: Similar to PerMonitor, but enables child window DPI change notification, improved scaling of comctl32 controls, and dialog scaling.
 - **DpiUnawareGdiScaled**: Similar to DpiUnaware, but improves the quality of GDI/GDI+ based content.