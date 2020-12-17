---
PermaID: 100005
Name: Visual Studio Integration
---

# Visual Studio Integration

Visual Studio 2017 version 15.3 and in some cases Visual Studio for Mac offer a number of significant enhancements for .NET Core developers.

## Retargeting .NET Core apps and .NET Standard libraries

If the .NET Core 2.0 SDK is installed, you can retarget .NET Core 1.x projects to .NET Core 2.0 and .NET Standard 1.x libraries to .NET Standard 2.0.

To retarget your project in Visual Studio, you open the Application tab of the project's properties dialog and change the Target framework value to .NET Core 2.0 or .NET Standard 2.0. 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/net-core-2-x/images/vs-integration-1.png">

You can also change it by right-clicking on the project and selecting the Edit *.csproj file option. 

```csharp
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.0</TargetFramework>
  </PropertyGroup>
</Project>
```

## Live Unit Testing support for .NET Core

Whenever you modify your code, Live Unit Testing automatically runs any affected unit tests in the background and displays the results and code coverage live in the Visual Studio environment. 

 - .NET Core 2.0 now supports **Live Unit Testing**. 
 - Previously, **Live Unit Testing** was available only for .NET Framework applications.

## Better support for multiple target frameworks

If you are building a project for multiple target frameworks, you can now select the target platform from the top-level menu. 

The following project targets **64-bit macOS X 10.11 (osx.10.11-x64)** and **64-bit** Windows 10/Windows Server 2016 (win10-x64). 

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/net-core-2-x/images/vs-integration-2.png">

You can select the target framework before selecting the project button, in this case, to run a debug build.

## Side-by-side support for .NET Core SDKs

You can now install the .NET Core SDK independently of Visual Studio. 

 - This makes it possible for a single version of Visual Studio to build projects that target different versions of .NET Core. 
 - Previously, Visual Studio and the .NET Core SDK were tightly coupled; a particular version of the SDK accompanied a particular version of Visual Studio.