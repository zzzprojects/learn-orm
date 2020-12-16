---
PermaID: 100001
Name: Retargeting to .NET Core 2.0
---

# Retargeting to .NET Core 2.0

If the .NET Core 2.0 SDK is installed, projects that target .NET Core 1.x can be retargeted to .NET Core 2.0.

To retarget to .NET Core 2.0, edit your project file by changing the value of the <TargetFramework> element (or the <TargetFrameworks> element if you have more than one target in your project file) from 1.x to 2.0:

```csharp
<PropertyGroup>
   <TargetFramework>netcoreapp2.0</TargetFramework>
</PropertyGroup>
```

You can also retarget .NET Standard libraries to .NET Standard 2.0 the same way:

```csharp
<PropertyGroup>
   <TargetFramework>netstandard2.0</TargetFramework>
</PropertyGroup>
```

## Migrate from ASP.NET Core 1.x to 2.0

Migrating your application to ASP.NET Core 2.0 enables you to take advantage of many new features and performance improvements.

 - Existing ASP.NET Core 1.x applications are based on version-specific project templates. 
 - As the ASP.NET Core framework evolves, so do the project templates and the starter code contained within them. 
 - In addition to updating the ASP.NET Core framework, you need to update the code for your application.

## Update .NET Core SDK version in global.json

If your solution relies upon a global.json file to target a specific .NET Core SDK version, update its version property to use the 2.0 version installed on your machine:

```csharp
{
  "sdk": {
    "version": "2.0.0"
  }
}
```

## Update package references

The `.csproj` file in a 1.x project lists each NuGet package used by the project.

In an ASP.NET Core 2.0 project targeting .NET Core 2.0, a single metapackage reference in the .csproj file replaces the collection of packages:

```csharp
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.All" Version="2.0.9" />
</ItemGroup>
```

All the features of ASP.NET Core 2.0 and Entity Framework Core 2.0 are included in the meta-package.

ASP.NET Core 2.0 projects targeting .NET Framework should continue to reference individual NuGet packages. Update the Version attribute of each <PackageReference /> node to 2.0.0.

For example, here's the list of <PackageReference /> nodes used in a typical ASP.NET Core 2.0 project targeting .NET Framework:

```csharp
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore" Version="2.0.0" />
  <PackageReference Include="Microsoft.AspNetCore.Authentication.Cookies" Version="2.0.0" />
  <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="2.0.0" />
  <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="2.0.0" />
  <PackageReference Include="Microsoft.AspNetCore.Mvc" Version="2.0.0" />
  <PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.ViewCompilation" Version="2.0.0" PrivateAssets="All" />
  <PackageReference Include="Microsoft.AspNetCore.StaticFiles" Version="2.0.0" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="2.0.0" PrivateAssets="All" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.0.0" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="2.0.0" PrivateAssets="All" />
  <PackageReference Include="Microsoft.VisualStudio.Web.BrowserLink" Version="2.0.0" />
  <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="2.0.0" PrivateAssets="All" />
</ItemGroup>
```