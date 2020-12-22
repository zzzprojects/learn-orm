---
PermaID: 100016
Name: Sockets Improvements
---

# Sockets Improvements

In .NET Core, a new type `System.Net.Http.SocketsHttpHandler`, and a rewritten `System.Net.Http.HttpMessageHandler` are added that form the basis of higher-level networking APIs. 

 - `System.Net.Http.SocketsHttpHandler` is the basis of the `HttpClient` implementation. 
 - In previous versions of .NET Core, higher-level APIs were based on native networking implementations.

The sockets implementation introduced in .NET Core 2.1 has a number of advantages:

 - A significant performance improvement when compared with the previous implementation.
 - The elimination of platform dependencies, which simplifies deployment and servicing.
 - Consistent behavior across all .NET Core platforms.

If this change is undesirable, you can configure your application to use the older `System.Net.Http.HttpClientHandler` class instead in a number of ways:

By calling the AppContext.SetSwitch method as follows:

```csharp
AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);
```

By defining the `System.Net.Http.UseSocketsHttpHandler` switch in the `.netcore.runtimeconfig.json` configuration file:

```csharp
"runtimeOptions": {
  "configProperties": {
      "System.Net.Http.UseSocketsHttpHandler": false
  }
}
```

By defining an environment variable named `DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER` and setting it to either `false` or `0`.

## Windows

On Windows, you can also choose to use `System.Net.Http.WinHttpHandler`, which relies on a native implementation, or the `SocketsHttpHandler` class by passing an instance of the class to the `HttpClient` constructor.

## Linux and macOS

 - On Linux and macOS, you can only configure `HttpClient` on a per-process basis. 
 - On Linux, you need to deploy `libcurl` if you want to use the old `HttpClient` implementation.