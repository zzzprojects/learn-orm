---
PermaID: 100002
Name: Preview 2
---

# Preview 2

.NET 5 Preview 2 contains a set of smaller features and performance improvements. In this iteration, ASP.NET Core and EF Core are also being released.

Here are some of the improvements in Preview 2.

## Code quality improvements in RyuJIT

Every release includes a set of changes that improve the machine code that the JIT generates which is also known as "code quality". Better code quality means better performance. In summary, about half of the following improvements are actual new optimizations and the other half are due to changing the flow of RyuJIT to enable existing optimizations to apply to more code patterns.

 - **[Use xmm for stack prolog](https://github.com/dotnet/runtime/pull/32538):** Change to x86/x64 prolog zeroing code.
 - **[Add ValueNumbering support for GT_SIMD and GT_HWINTRINSIC tree nodes](https://github.com/dotnet/runtime/pull/31834):** Enable the optimizer for SIMD and hardware intrinsic types.
 - **[Use GT_NULLCHECK for unconsumed indirections](https://github.com/dotnet/runtime/pull/32641):** Remove redundant null checks.
 - **[JIT: invoke nullable box optimizations earlier](https://github.com/dotnet/runtime/pull/32269):** Improve optimizations for `Nullable<T>`.
 - **[JIT: Optimize range checks for various array index patterns](https://github.com/dotnet/runtime/pull/1644):** Improvement in range check elimination.
 - **[RyuJIT: Optimize `obj.GetType() != typeof(X)` for sealed classes](https://github.com/dotnet/runtime/pull/32790):** Improvement to type check expression.
 - **[Eliminate duplicate zero initializations more aggressively](https://github.com/dotnet/runtime/pull/31960):** Better and broader approach for eliminating duplicate zero initializations.
 - **[Fix method and basic block flags used by early opts](https://github.com/dotnet/runtime/pull/2126):** Enables certain optimization to be used more often. For example, replacing array length with a constant now occurs much more often.

## Garbage Collector

 - **[Card mark stealing](https://github.com/dotnet/coreclr/pull/25986):** Server GC (on different threads) can now work-steal while marking gen0/1 objects held live by older generation objects. This means that ephemeral GC pauses are shorter for scenarios where some GC threads took much longer to mark than others.
 - **[Introducing Pinned Object Heap](https://github.com/dotnet/runtime/pull/32283):** Implemented part of the POH (Pinned Object Heap) feature – the part internal to GC. This new heap (essentially a peer to LOH) will allow the GC to manage pinned objects separately, and as a result, avoid the negative effects of pinned objects on the generational heaps.
 - **[Allow allocating large object from free list while background sweeping SOH](https://github.com/dotnet/runtime/pull/2103):** Enabled LOH allocations using the free list while BGC is sweeping SOH. Previously this was only using the end of segment space on LOH. This allowed for better heap usage.
 - **[Background GC suspension fixes](https://github.com/dotnet/coreclr/pull/27729):** Suspension fixes to reduce the time for both BGC and user threads to be suspended. This reduces the total time it takes to suspend managed threads before a GC can happen. 
 - **[Fix named cgroup handling in docker](https://github.com/dotnet/runtime/pull/980):** Added support to read limits from named cgroups. Previously we only read from the global one.