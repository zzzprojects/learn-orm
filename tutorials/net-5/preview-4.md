---
PermaID: 100004
Name: Preview 4
---

# Preview 4

The following improvements are new in Preview 4 and not otherwise covered in the earlier highlights section.

## F# 5

Building on the F# 5 preview released earlier this year, the update to F# 5 includes support for consuming Default Interface Methods (DIMs) and some big performance improvements. Here’s a sneak peek at the DIMs support in F#:

```csharp
open CSharp

// You can implement the interface via a class
type MyType() =
    member _.M() = ()

    interface MyDim

let md = MyType() :> MyDim
printfn "DIM from C#: %d" md.Z

// You can also implement it via an object expression
let md' = { new MyDim }
printfn "DIM from C# but via Object Expression: %d" md'.Z
```

For more information, you can read the [F# 5 update for .NET 5 preview 4](https://devblogs.microsoft.com/dotnet/f-5-update-for-net-5-preview-4/).

## C# Source Generators Update

An update to the C# Source Generators preview is included in this iteration. 

 - Besides some bug fixes, it includes support for passing an `analyzerconfig`, which is essentially a list of key-value pairs, to a Source Generator. 
 - This lets your source generators work differently based on the input they receive. 
 - For example, you may want to generate source code differently if a consuming project targets .NET Framework vs. .NET 5. 
 - Using an `analyzerconfig` allows you to pass information like a consuming project's TFM to allow for exactly this scenario.

## Support for ICU on Windows

 - The ICU library provides Unicode and Globalization support for applications on Linux and macOS. 
 - This library can be used now on Windows and this change makes the behavior of globalization APIs such as culture-specific string comparison consistent between Windows 10 and other operating systems.

## Support for cgroup v2 (for containers)

.NET now has support for cgroup v2, which we expect will become an important container-related API in 2020 and beyond. 

 - Docker currently uses cgroup v1 which is already supported by .NET. 
 - In comparison, cgroup v2 is simpler, more efficient, and more secure than cgroup v1. 
 - You can learn more about cgroup and Docker resource limits from our 2019 Docker update. 
 - Linux distros and container runtimes are in the process of adding support for cgroup v2. 
 - .NET 5.0 will work correctly in cgroup v2 environments once they become more common.

## Reducing the Size of Container Images

Everyone always looking for opportunities to make .NET container images smaller and easier to use. 

 - In Preview 4, that dramatically reduces the size of the aggregate images you pull in multi-stage-build scenarios which is a very common pattern. 
 - We re-based the SDK image on top of the ASP.NET image instead of buildpack-deps.

This change has the following win for multi-stage builds.

Multi-stage build costs with Ubuntu 20.04 Focal:

| Pull Image       | Before         | After             |
|:-----------------|:---------------|:------------------|
| sdk:5.0-focal    | 268 MB         | 232 MB            |
| aspnet:5.0-focal | 64 MB          | 10 KB (manifest only) |

_Net download savings: 100 MB (-30%)_

Multi-stage build costs with Debian 10 Buster:

| Pull Image       | Before         | After             |
|:-----------------|:---------------|:------------------|
| sdk:5.0          | 280 MB         | 218 MB            |
| aspnet:5.0	   | 84 MB          | 4 KB (manifest only) |

_Net download savings: 146 MB (-40%)_

## .NET 5.0 will switch to the dotnet container repo

As part of the move to .NET as the product name, first, they publish .NET 5.0 Preview 4 and later images to the `mcr.microsoft.com/dotnet` family of repos, instead of `mcr.microsoft.com/dotnet/core`. 

 - Make sure to update your FROM statements and scripts accordingly. 
 - .NET Core 3.1 and 2.1 will continue to be published to `mcr.microsoft.com/dotnet/core`. 
