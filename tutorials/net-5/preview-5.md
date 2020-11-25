---
PermaID: 100005
Name: Preview 5
---

# Preview 5


## RyuJIT improvements

The following improvements were made to the RyuJIT JIT compiler:

 - [New, much faster, portable implementation of tail-call helpers](https://github.com/dotnet/runtime/pull/341): This implements tail-call-via-help support for all platforms supported by the runtime. In this new mechanism, the JIT asks the runtime for help whenever it realizes it will need a helper to perform a tail-call, i.e. when it sees an explicit tail. prefixed call that it cannot make into a fast jump-based tail-call.
 - Continued ARM64 hardware intrinsics implementation progress
   - Implement ASIMD Extract Insert ExtractVector64 ExtractVector128
   - Implement ASIMD widening, narrowing, saturating intrinsics
   - Add VectorTableList and TableVectorExtension intrinsics
   - Add support of CreateScalarUnsafe() for arm64 intrinsic
   - ARM64 intrinsic support for Vector64.Create() and Vector128.Create()
   - Optimize BitOperations.PopCount() with arm64 intrinsics
 - Improved JIT speed in a case that was affecting regular expression compilation
 - Improved Intel architecture performance using new hardware intrinsics BSF/BSR.
 - Implement Vector{Size}.AllBitsSet

## Native exports

It enables exports for native binaries that call into .NET code in .NET 5.0. 

 - The building block of the feature is hosting API support for `UnmanagedCallersOnlyAttribute`.
 - It is a building-block for creating higher-level experiences that provides a more complete experience for publishing .NET components as native libraries. 

The native exports project enables you to:

 - Expose custom native exports.
 - Doesn't require a higher-level interop technology like COM.
 - Works cross-platform.

There are existing projects that enable similar scenarios, such as:

 - Unmanaged Exports
 - DllExport

## Expanding System.DirectoryServices.Protocols to Linux and macOS

In this iteration, the support of cross-platform is expanded in `System.DirectoryServices.Protocols`. In Preview 5, the support for Linux is added and for macOS, the support will be added in Preview 6. Support for windows was already available.

 - The `System.DirectoryServices.Protocols` is a lower-level API than `System.DirectoryServices` and enables more scenarios. 
 - `System.DirectoryServices` includes Windows-only concepts/implementations, so it was not an obvious choice to make cross-platform. 
 - Both API-sets enable controlling and interacting with a directory service server, like LDAP or Active Directory.

## Alpine 3.12

The support for Alpine 3.12, for .NET Core 3.1, and .NET 5 was added in this iteration. 

 - The maintainers of Alpine Linux announced the release of Alpine 3.12 on May 29th. 
 - We are working on adding support for new Linux distro versions more quickly and predictably than what we have done in the past. 
 - We have heard feedback that you must have access to .NET on new versions of Alpine, Debian, Ubuntu, and others as quickly as possible.
