---
PermaID: 100006
Name: Preview 6
---

# Preview 6

Here are some of the improvements in Preview 6.

## Windows Forms

Visual Basic users are used to enforce that their applications are single-instanced (one instance launched at a time). 

 - This behavior is now available via `WindowsFormsApplicationBase.IsSingleInstance`. 
 - The Collapse Support is added to `ListViewGroup`, and this change makes it easier to manage a form with multiple `ListViewGroups`.

You can see the result shown below.

<img src="https://raw.githubusercontent.com/zzzprojects/learn-orm/master/tutorials/net-5/images/preview-6-1.png">

## RyuJIT code quality improvements

The RyuJIT team continues to add important improvements in each preview, specially with Preview 6. Let’s take a look:

 - General improvements
   - [Struct handling improvements](https://github.com/dotnet/runtime/pull/36146)
   - [Optimization to remove redundant zero initializations](https://github.com/dotnet/runtime/pull/36918)
 - [ARM64 hardware intrinsics implementation progress](https://github.com/dotnet/runtime/issues/33308)
   - [Implement Duplicate and DuplicateSelectedScalar](https://github.com/dotnet/runtime/pull/36144)
   - [ASIMD Shift Intrinsics](https://github.com/dotnet/runtime/pull/36830)
   - [Polynomial Multiply Long Intrinsics](https://github.com/dotnet/runtime/pull/36853)
   - [Optimize Vector64 and Vector128.Create methods](https://github.com/dotnet/runtime/pull/36267)
   - [Optimize ToScalar() and GetElement() to use arm64 intrinsic](https://github.com/dotnet/runtime/pull/36156)
   - [Optimize ToVector128, ToVector128Unsafe and Vector128.GetLower()](https://github.com/dotnet/runtime/pull/36732)
 - ARM64 generated code improvements: greatly reduced ARM64 code size
   - [Optimize call indirect for R2R, Arm and Arm64 scenarios](https://github.com/dotnet/runtime/pull/35675)
   - [Optimize virtual call stub for R2R and JIT](https://github.com/dotnet/runtime/pull/36817)

## Single file apps

The team has continuously improved the support of **Single-File Apps** in .NET 5. The goal was to enable publishing an app as one file for Windows, macOS, and Linux. 

 - As you know in Preview 4 that for Windows **single file** apps required a few extra runtime files. 
 - A new option is added to include native binaries and any additional content like images in the single-file. 
 - These files will be extracted upon first launch, and apps that target Linux and macOS don't need to use this option for native runtime binaries unless they want to use it for media or other content.

### Current limitations

 - On Linux, the singlefilehost with runtime components linked in is still to be implemented. Therefore, the runtime native binaries will be published as separate files (similar to Windows experience).
 - On Linux, ready-to-run assemblies embedded in a bundle are loaded like IL assemblies.

## Native hosted application

Over the years, you have seen a variety of hosting models for .NET in native applications. [@rseanhall](https://github.com/rseanhall) proposed and implemented [a novel new model](https://github.com/dotnet/runtime/issues/35465) for doing that.

 - It takes advantage of all the built-in application functionality offered by the .NET application hosting layer, specifically loading dependencies while enabling a custom entry point to be called from native code. 
 - That's perfect for a lot of scenarios, and that one can imagine becoming popular with developers that host .NET components from native applications that didn't exist before.

### Two primary PRs:

 - [Enable calling get_runtime_delegate from app context](https://github.com/dotnet/runtime/pull/37473)
 - [Implement hdt_get_function_pointer](https://github.com/dotnet/runtime/pull/37696)

## Removal of built-in WinRT support in .NET 5.0

Windows Runtime (WinRT) is the technology and ABI that new APIs are exposed within Windows. You can call those APIs via .NET code, similar to how you would with C++. 

 - Support for WinRT interop was added in .NET Core 3.0, as part of adding support for Windows desktop client frameworks (Windows Forms and WPF).
 - It has replaced the built-in WinRT support with the C#/WinRT toolchain, provided by the Windows team, in .NET 5.0. 
 - This change in WinRT interop is a breaking change, and .NET Core 3.x apps that use WinRT will need to be recompiled. 

The benefits are called out in Support WinRT APIs in .NET 5:

 - WinRT interop can be developed and improved separatly from the .NET runtime.
 - Makes WinRT interop symmetrical with interop systems provided for other operating systems, like iOS and Android.
 - Can take advantage of many other .NET features (AOT, C# features, IL linking).
 - Simplifies the .NET runtime codebase (removes 60k lines of code).
 - 
For more details, see the official docs issue at https://github.com/dotnet/docs/issues/18875.
 
## Platform support

The [.NET 5 – Supported OS versions](https://github.com/dotnet/core/blob/master/release-notes/5.0/5.0-supported-os.md) page is updated to capture the latest plans for platform support for .NET 5.0.

The package manager and container support aren't listed on that page. This information will be added before the release of .NET 5.0.

## ASP.NET Core 5.0

### Blazor WebAssembly template now included

The Blazor WebAssembly template is now included in the .NET 5 SDK along with the Blazor Server template. To create a Blazor WebAssembly project, simply run the `dotnet new blazorwasm` command.

### JSON extension methods for HttpRequest and HttpResponse

You can now easily read and write JSON data from an `HttpRequest` and `HttpResponse` using the new `ReadFromJsonAsync` and `WriteAsJsonAsync` extension methods. 

 - These extension methods use the `System.Text.Json` serializer to handle the JSON data. 
 - You can also check if a request has a JSON content type using the new `HasJsonContentType` extension method.

The JSON extension methods can be combined with endpoint routing to create JSON APIs in a programming style we call **route to code**. It is a new option for developers who want to create basic JSON APIs in a lightweight way. 

For example, a web app with only a handful of endpoints might choose to use a route to code rather than the full functionality of ASP.NET Core MVC.

```csharp

endpoints.MapGet("/weather/{city:alpha}", async context =>
{
    var city = (string)context.Request.RouteValues["city"];
    var weather = GetFromDatabase(city);

    await context.Response.WriteAsJsonAsync(weather);
});
```

## Extension method to allow anonymous access to an endpoint

You can now allow anonymous access to an endpoint using the simpler `AllowAnonymous` extension method when using endpoint routing.

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGet("/", async context =>
        {
            await context.Response.WriteAsync("Hello World!");
        })
        .AllowAnonymous();
    });
}
```
## Custom handling of authorization failures

Custom handling of authorization failures is now easier with the new `IAuthorizationMiddlewareResultHandler` interface that is invoked by the `AuthorizationMiddleware`. 

The default implementation remains the same, but a custom handler can be registered in DI allowing things like custom HTTP responses based on why authorization failed. 

The following example demonstrates the usage of the `IAuthorizationMiddlewareResultHandler`.

```csharp
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CustomAuthorizationFailureResponse.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;

namespace CustomAuthorizationFailureResponse.Authorization
{
    public class SampleAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly IAuthorizationMiddlewareResultHandler _handler;

        public SampleAuthorizationMiddlewareResultHandler()
        {
            _handler = new AuthorizationMiddlewareResultHandler();
        }

        public async Task HandleAsync(
            RequestDelegate requestDelegate,
            HttpContext httpContext,
            AuthorizationPolicy authorizationPolicy,
            PolicyAuthorizationResult policyAuthorizationResult)
        {
            // if the authorization was forbidden, let's use custom logic to handle that.
            if (policyAuthorizationResult.Forbidden && policyAuthorizationResult.AuthorizationFailure != null)
            {
                // as an example, let's return 404 if specific requirement has failed
                if (policyAuthorizationResult.AuthorizationFailure.FailedRequirements.Any(requirement => requirement is SampleRequirement))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await httpContext.Response.WriteAsync(Startup.CustomForbiddenMessage);

                    // return right away as the default implementation would overwrite the status code
                    return;
                }
                else if (policyAuthorizationResult.AuthorizationFailure.FailedRequirements.Any(requirement => requirement is SampleWithCustomMessageRequirement))
                {
                    // if other requirements failed, let's just use a custom message
                    // but we have to use OnStarting callback because the default handlers will want to modify i.e. status code of the response
                    // and modifications of the response are not allowed once the writing has started
                    var message = Startup.CustomForbiddenMessage;

                    httpContext.Response.OnStarting(() => httpContext.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes(message)).AsTask());
                }
            }

            await _handler.HandleAsync(requestDelegate, httpContext, authorizationPolicy, policyAuthorizationResult);
        }
    }
}
```

## SignalR Hub filters

Hub filters, called Hub pipelines in ASP.NET SignalR, is a feature that allows you to run code before and after Hub methods are called, similar to how middleware lets you run code before and after an HTTP request. Common uses include logging, error handling, and argument validation.

You can read more about these Hub filters on the [official documentation page](https://docs.microsoft.com/en-us/aspnet/core/signalr/hub-filters?view=aspnetcore-5.0).
