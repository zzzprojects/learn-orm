---
PermaID: 100019
Name: Tiered Compilation Remains an Opt-in Feature
---

# Tiered Compilation Remains an Opt-in Feature

## What is the Tiered Compilation?

Tiered Compilation allows the .NET runtime to substitute different assembly code method implementations for the same method during an application lifetime to achieve higher performance. It currently achieves this in the following two ways.

 - [Startup](#startup)
 - [Steady-State](#steady-state)

### Startup 

 - Whenever code needs to be jitted, the runtime first generates a low-quality code body, then replaces it with a higher code quality version later if the method appears hot. 
 - The lower quality initial codegen saves JIT time, and these savings typically dominate the additional cost to run the lower quality code for a short time.

### Steady-State

 - If code loaded from ReadyToRun images appears hot, the runtime replaces it with jitted code, which is typically higher quality. 
 - At runtime, the JIT can observe the exact dependencies loaded and CPU instruction support, which allows it to generate superior code. 
 - In the future, it may also utilize profile-guided feedback, but it does not currently do so.

## Concept

Tiered compilation first divides all code into two buckets. 

 - Code that is eligible for tiering and code that is not. 
 - Code that is not eligible works as all code did before the tiered compilation feature. 

Eligible code can have two different variations called tiers.

### Tier0 

 - This is whatever code can be made available most quickly to first run a method. 
 - For methods that are precompiled in `ReadyToRun` images, the precompiled code is the **tier0** version. 
 - For methods that are not precompiled, the JIT generates code using minimal optimizations.

### Tier1

 - This is whatever code the runtime thinks will run faster than **Tier0**. 
 - Currently, it is equivalent to code that would be jitted for a method when tiered compilation is not in use.

When a method is first invoked, the **Tier0** version is produced first. Once it appears that the method is hot, then a **Tier1** version of the same method is produced and made active.

 - Most of the mechanics to make new code versions, configure them, and switch the active ones are handled by the `CodeVersionManager`. 
 - Tiered Compilation owns the policy to decide when to switch versions, the counters and timers that provide inputs to that policy, queues to track needed work, and the background threads used to do a compilation.

## Opt-in Feature

In .NET Core 2.1, the JIT compiler implemented a new compiler technology, tiered compilation, as an opt-in feature. 

 - The goal of tiered compilation is improved performance. 
 - One of the important tasks performed by the JIT compiler is optimizing code execution. 
 - However, For little-used code paths the compiler may spend more time optimizing code than the runtime spends executing unoptimized code. 
 
Tiered compilation introduces two stages in JIT compilation.

 - A first tier, which generates code as quickly as possible.
 - A second tier, which generates optimized code for those methods that are executed frequently. The second tier of compilation is performed in parallel for enhanced performance.

In .NET Core 2.2 Preview 2, the tiered compilation was enabled by default. However, the team is still not ready to enable tiered compilation by default. So in .NET Core 2.2, tiered compilation continues to be an opt-in feature. 

You can opt into a tiered compilation in either of two ways.

 - To use tiered compilation in all projects that use the .NET Core 2.1 SDK, set the following environment variable:

```csharp
COMPlus_TieredCompilation="1"
```

 - To use tiered compilation on a per-project basis, add the `<TieredCompilation>` property to the `<PropertyGroup>` section of the MSBuild project file as shown below.

```csharp
<PropertyGroup>
    <!-- other property definitions -->
    <TieredCompilation>true</TieredCompilation>
</PropertyGroup>
```
