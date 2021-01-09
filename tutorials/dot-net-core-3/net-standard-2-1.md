---
PermaID: 100000
Name: .NET Standard 2.1
---

# .NET Standard 2.1

.NET Standard is a formal specification of .NET APIs that are available on multiple .NET implementations. The motivation behind the .NET Standard was to establish greater uniformity in the .NET ecosystem. 

 - The various .NET implementations target specific versions of .NET Standard. 
 - Each .NET implementation version advertises the highest .NET Standard version it supports, a statement that means it also supports previous versions. 

.NET Core 3.0 implements .NET Standard 2.1. However, the default `dotnet new classlib` template generates a project that still targets .NET Standard 2.0. To target .NET Standard 2.1, edit your project file and change the `TargetFramework` property to `netstandard2.1` as shown below.

```csharp
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.1</TargetFramework>
  </PropertyGroup>

</Project>
```

To build .NET Standard libraries in Visual Studio, make sure you have Visual Studio 2019 or Visual Studio 2017 version 15.3 or later installed on Windows, or Visual Studio for Mac version 7.1 or later installed on macOS.

## APIs

The following are the newly added APIs in .NET Standard 2.1.

### Span<T>

 - In .NET Core 2.1, the `Span<T>` was added which is an array-like type that allows representing managed and unmanaged memory uniformly and supports slicing without copying. 
 - It allows managing buffers more efficiently, it can help in reducing allocations and copying. 
 - The `Span<T>` is a very fundamental type as it requires runtime and compiler support to be fully leveraged. 

### Foundational-APIs working with spans. 

 - While `Span<T>` is available as a .NET Standard compatible NuGet package `System.Memory` already, adding this package cannot extend the members of .NET Standard types that deal with spans. 
 - For example, .NET Core 2.1 added many APIs that allow working with spans, such as `Stream.Read(Span<Byte>)`. 
 - Part of the value proposition to add a span to .NET Standard is to add these companion APIs as well.

### Reflection Emit. 

 - To boost productivity, the .NET ecosystem has always made heavy use of dynamic features such as reflection and reflection emit. 
 - Emit is often used as a tool to optimize performance as well as a way to generate types on the fly for proxying interfaces. 
 - With .NET Standard 2.1, you will have access to Lightweight Code Generation (LCG) as well as Reflection Emit. 

### SIMD

 - .NET Framework and .NET Core had support for SIMD for a while now. 
 - We have leveraged them to speed up basic operations in the BCL, such as string comparisons. 
 - We have received quite a few requests to expose these APIs in .NET Standard as the functionality requires runtime support and thus cannot be provided meaningfully as a NuGet package.

### ValueTask and ValueTask<T>. 

 - In .NET Core 2.1, the biggest feature was improvements in our fundamentals to support high-performance scenarios, which also included making async/await more efficient. 
 - `ValueTask<T>` already exists and allows to return results if the operation is completed synchronously without having to allocate a new `Task<T>`. 
 - With .NET Core 2.1, this feature has been improved which made it useful to have a corresponding non-generic `ValueTask` that allows reducing allocations even for cases where the operation has to be completed asynchronously, a feature that types like Socket and NetworkStream now utilize. 
 - Exposing these APIs in .NET Standard 2.1 enables library authors to benefit from these improvements both, as a consumer, as well as a producer.

### DbProviderFactories 

 - In .NET Standard 2.0, we added almost all of the primitives in ADO.NET to allow O/R mappers and database implementers to communicate. 
 - The `DbProviderFactories` allows libraries and applications to utilize a specific ADO.NET provider without knowing any of its specific types at compile-time, by selecting among registered `DbProviderFactory` instances based on a name, which can be read from, for example, configuration settings.

### General Goodness

 - Since .NET Core was open sourced, we have added many small features across the base class libraries such as `System.HashCode` for combining hash codes or new overloads on `System.String`. 
 - There are about 800 new members in .NET Core and virtually all of them got added in .NET Standard 2.1.

## .NET Standard not Deprecated

.NET Standard is still needed for libraries that can be used by multiple .NET implementations. We recommend you target .NET Standard in the following scenarios:

 - Use `netstandard2.0` to share code between .NET Framework and all other implementations of .NET.
 - Use `netstandard2.1` to share code between Mono, Xamarin, and .NET Core 3.x.