---
PermaID: 100007
Name: Preview 7
---

# Preview 7

Here are some of the improvements in Preview 7.

## Performance

Stephen Toub recently posted his [Performance Improvements in .NET 5](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-5/) post, the latest in his series. He covers around 250 performance-oriented pull requests, which reveal improvements that will even surprise people who follow .NET Core performance closely.

## System.Text.Json

The usability feature was added to the new JSON API, and the following features are new in Preview 7.

 - [Ability to ignore default values for value-type properties when serializing](https://github.com/dotnet/runtime/pull/36322/): Can be used to reduce serialization and wire costs.
 - [Ability to handle circular references when serializing](https://github.com/dotnet/runtime/pull/36829): API shape is now expected to be final.

## Garbage Collection (GC)

The GC now exposes detailed information of the most recent collection via the `GC.GetGCMemoryInfo` method, which returns a `GCMemoryInfo` struct. 

 - The `GCMemoryInfo` provides information about machine memory, heap memory, and the most recent collection, or most recent collection of the kind of GC you specify ephemeral full blocking, or background GC.
 - The most likely use cases for using this new API are for logging/monitoring or to indicate to a loader balancer that a machine should be taken out of rotation to request a full GC. 
 - It could also be used to avoid container hard-limits by reducing the size of caches.
 - Another small but impactful change was made to defer the expensive reset memory operation to low-memory situations. 
 - We expect these policy changes to lower the GC latency (and GC CPU usage in general).

## RyuJIT

RyuJIT is the assembly code generator for .NET, target both Intel and ARM chips. Most of the investment in RyuJIT is focused on performance.

 - General Improvements
   - [Enable eliding some bounds checks](https://github.com/dotnet/runtime/pull/36263)
   - [Optimize Enum.CompareTo after being rewritten in C#](https://github.com/dotnet/runtime/pull/37845): Performance is now at parity with previous C++ implementation.
   - [Improvement in register allocation for structs](https://github.com/dotnet/runtime/pull/36862): Enregister multireg lclVars
   - [Improvements for removal of redundant zero inits](https://github.com/dotnet/runtime/pull/36862)
   - [Tail duplication improvement](https://github.com/dotnet/runtime/pull/37038)
   - [Stack based structs copy CQ fix](https://github.com/dotnet/runtime/pull/37967)
   - [Clean up a dead field assignment after removing redundant zero initializations](https://github.com/dotnet/runtime/pull/37280)
 - [ARM64 hardware intrinsics & API optimization](https://github.com/dotnet/runtime/issues/33308)
   - [Implement majority of "by element" intrinsics](https://github.com/dotnet/runtime/pull/36916)
   - [Implement fcvtxn, fcvtxn2, sqabs, sqneg, suqadd, usqadd intrinsics](https://github.com/dotnet/runtime/pull/38010)
   - [Optimize SpanHelpers.IndexOf(byte), SpanHelpers.IndexOf(char)](https://github.com/dotnet/runtime/pull/37624)
   - [Optimize SpanHelpers.IndexOfAny(byte)](https://github.com/dotnet/runtime/pull/37934)
   - [Optimize WithLower, WithUpper, Create, AsInt64, AsUInt64, AsDouble](https://github.com/dotnet/runtime/pull/37139)
   - [Optimize AsVector, AsVector128, GetUpper, As and WithElement](https://github.com/dotnet/runtime/pull/37338)

## ASP.NET Core

The following updates are available in Preview 7.

 - Blazor WebAssembly apps now target .NET 5
 - Updated debugging requirements for Blazor WebAssembly
 - Blazor accessibility improvements
 - Blazor performance improvements
 - Certificate authentication performance improvements
 - Sending HTTP/2 PING frames
 - Support for additional endpoints types in the Kestrel sockets transport
 - Custom header decoding in Kestrel
 - Other minor improvements
