---
PermaID: 100006
Name: ReadyToRun Images
---

# ReadyToRun Images

.NET application startup time and latency can be improved by compiling your application assemblies in `ReadyToRun` (R2R) format. R2R is a form of ahead-of-time (AOT) compilation.

 - R2R binaries improve startup performance by reducing the amount of work the just-in-time (JIT) compiler needs to do as your application loads. 
 - The binaries contain similar native code compared to what the JIT would produce. 
 - However, R2R binaries are larger because they contain both intermediate language (IL) code, which is still needed for some scenarios, and the native version of the same code. 
 - R2R is only available when you publish an app that targets specific runtime environments (RID) such as Linux x64 or Windows x64.

To compile your project as `ReadyToRun`, the application must be published with the `PublishReadyToRun` property set to `true`.

To enable this, you can add the <PublishReadyToRun> setting to your project file and publish it.

```csharp
<PropertyGroup>
  <PublishReadyToRun>true</PublishReadyToRun>
</PropertyGroup>
```

Now run the following command to publish it.

```csharp
dotnet publish -c Release -r win-x64
```

You can also specify the `PublishReadyToRun` flag directly to the `dotnet publish` command, as shown below.

```csharp
dotnet publish -c Release -r win-x64 -p:PublishReadyToRun=true
```

## Impact of ReadyToRun Feature

Ahead-of-time compilation has a complex performance impact on application performance, which may be difficult to predict. 

 - In general, the size of an assembly will grow to between two to three times larger. 
 - This increase in the physical size of the file may reduce the performance of loading the assembly from disk, and increase a working set of the process. 
 - However, in return, the number of methods compiled at runtime is typically reduced substantially. 
 - The result is that most applications that have large amounts of code receive large performance benefits from enabling ReadyToRun. 
 - Applications with small amounts of code will likely not experience a significant improvement from enabling `ReadyToRun`, as the .NET runtime libraries have already been precompiled with `ReadyToRun`.

The startup improvement discussed here applies not only to the application startup but also to the first use of any code in the application. For instance, ReadyToRun can be used to reduce the response latency of the first use of Web API in an ASP.NET application.
