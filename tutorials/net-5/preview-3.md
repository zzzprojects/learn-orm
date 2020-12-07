---
PermaID: 100003
Name: Preview 3
---

# Preview 3

Here are some of the improvements in Preview 3.

## Code quality improvements in RyuJIT

Every release includes a set of changes that improve the machine code that the JIT generates, which is also known as "code quality". Better code quality means better application performance.

 - **[Vectorise BitArray for ARM64](https://github.com/dotnet/runtime/pull/33749):** The `BitArray` class was updated to include a hardware-accelerated implementation for ARM64 using ARM64 intrinsics. The performance improvements for `BitArray` are very significant.
 - **[Implement simple version of On Stack Replacement (OSR)](https://github.com/dotnet/runtime/pull/32969):** On-stack replacement (OSR) is a new capability that allows the code executed by currently running methods to be changed in the middle of method execution, while those methods are active "on stack". 
 - **[Dynamic generic dictionary expansion feature](https://github.com/dotnet/runtime/pull/32270):** Some uses of generics now have better performance based on improving the implementation of low-level dictionaries used by the runtime to store information about generic types and methods. 
 - **[Implement Vector.Ceiling / Vector.Floor](https://github.com/dotnet/runtime/pull/31993):** Implement Vector.Ceiling / Vector.Floor using x64 and ARM64 intrinsics, per API proposal.
 - **[JIT: allow CORINFO_HELP_READYTORUN_GENERIC_HANDLE to be optimized](https://github.com/dotnet/runtime/pull/34221):** Improves code quality for generics in Ready2Run images.
 - **[JIT: enable tail calls and copy omission for implicit by ref structs](https://github.com/dotnet/runtime/pull/33004):** Improves code quality for structs as arguments in “tail call” position calls.

## System.Text.Json improvements

 - **[Add support for preserve references on JSON](https://github.com/dotnet/runtime/pull/655):** Enables `ReferenceLoopHandling`, which is one of the key features of `JSON.NET` serialization.
 - **[Add new System.Net.Http.Json project/namespace](https://github.com/dotnet/runtime/pull/33459):** Adds new extension methods for HttpClient that allow serialization from/to JSON.
 - **[Add JsonConstructor and support for deserializing with parameterized ctors](https://github.com/dotnet/runtime/pull/33444):** Adds support for immutable classes and structs to JsonSerializer.
 - **[Add JsonIgnoreCondition & per-property ignore logic](https://github.com/dotnet/runtime/pull/34049):** Adds support for null value handling, which is another feature of JSON.NET serialization.

## .NET SDK Support for .NET Framework Assemblies

The .NET SDK will now auto-reference the `Microsoft.NETFramework.ReferenceAssemblies` NuGet package given a .NET Framework target framework in a project file. This change enables building .NET Framework projects on a machine without the required .NET Framework targeting pack installed. This improvement is specific to targeting packs and doesn’t account for other dependencies that a project may have.

## ASP.NET Core: Performance Improvements to HTTP/2

By significantly reducing allocations in the `HTTP/2` code path and adding support for HPack static compression of `HTTP/2` response headers in Kestrel, the 5.0.0-prevew3 release improves the performance of `HTTP/2`.
