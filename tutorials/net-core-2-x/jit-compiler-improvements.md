---
PermaID: 100012
Name: JIT Compiler Improvements
---

# JIT Compiler Improvements

.NET Core incorporates a new JIT compiler technology called tiered compilation which is also known as adaptive optimization that can significantly improve performance. Tiered compilation is an opt-in setting.

 - One of the important tasks performed by the JIT compiler is optimizing code execution. 
 - For little-used code paths, the compiler may spend more time optimizing code than the runtime spends running unoptimized code. 
 
Tiered compilation introduces two stages in JIT compilation.

 - A first tier, which generates code as quickly as possible.
 - A second tier, which generates optimized code for those methods that are executed frequently. The second tier of compilation is performed in parallel for enhanced performance.

You can opt into tiered compilation in the following ways.

To use tiered compilation in all projects that use the .NET Core 2.1 SDK, set the following environment variable:

```csharp
COMPlus_TieredCompilation="1"
```

To use tiered compilation on a per-project basis, add the <TieredCompilation> property to the <PropertyGroup> section of the MSBuild project file, as the following example shows:

```csharp
<PropertyGroup>
    <!-- other property definitions -->

    <TieredCompilation>true</TieredCompilation>
</PropertyGroup>
```