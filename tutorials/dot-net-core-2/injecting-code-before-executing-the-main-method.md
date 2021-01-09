---
PermaID: 100020
Name: Injecting Code Before Executing the Main Method
---

# Injecting Code Before Executing the Main Method

In .NET Core 2.2, you can use a startup hook to inject code before running an application's `Main` method. 

 - Startup hooks make it possible for a host to customize the behavior of applications after they have been deployed without needing to recompile or change the application.
 - We expect hosting providers to define custom configuration and policy, including settings that potentially influence the load behavior of the main entry point, such as the `System.Runtime.Loader.AssemblyLoadContext` behavior. 
 - The hook can be used to set up tracing or telemetry injection, to set up callbacks for handling, or to define other environment-dependent behavior. 
 - The hook is separate from the entry point so that the user code does not need to be modified.

This could be used with `AssemblyLoadContext` APIs to resolve dependencies, not on the TPA list from a shared location, similar to the GAC on a full framework. 

 - It could also be used to forcibly preload assemblies that are on the TPA list from a different location. 
 - Future changes to `AssemblyLoadContext` could make this easier to use by making the default load context or TPA list modifiable.

The `StartupHook` type is internal and in the global namespace, and the signature of the `Initialize` method is public static void `Initialize()`.

```csharp
internal class StartupHook
{
    public static void Initialize()
    {
        AssemblyLoadContext.Default.Resolving += SharedHostPolicy.SharedAssemblyResolver.LoadAssemblyFromSharedLocation;
    }
}

namespace SharedHostPolicy
{
    class SharedAssemblyResolver
    {
        public static Assembly LoadAssemblyFromSharedLocation(AssemblyLoadContext context, AssemblyName assemblyName)
        {
            string sharedAssemblyPath = ""; // find assemblyName in shared location...
            if (sharedAssemblyPath != null)
                return AssemblyLoadContext.Default.LoadFromAssemblyPath(sharedAssemblyPath);
            return null;
        }
    }
}
```
