---
PermaID: 100022
Name: HTTP/2 Support
---

# HTTP/2 Support

The `System.Net.Http.HttpClient` type supports the `HTTP/2` protocol. If `HTTP/2` is enabled, the `HTTP` protocol version is negotiated via `TLS/ALPN`, and `HTTP/2` is used if the server elects to use it.

The default protocol remains `HTTP/1.1`, but `HTTP/2` can be enabled in the following two different ways. 

You can set the `HTTP` request message to use `HTTP/2` as shown below.

```csharp
var client = new HttpClient() { BaseAddress = new Uri("https://localhost:5001") };

// HTTP/1.1 request
using (var response = await client.GetAsync("/"))
    Console.WriteLine(response.Content);

// HTTP/2 request
using (var request = new HttpRequestMessage(HttpMethod.Get, "/") { Version = new Version(2, 0) })
using (var response = await client.SendAsync(request))
    Console.WriteLine(response.Content);
```

You can also change `HttpClient` to use `HTTP/2` by default as shown below.

```csharp
var client = new HttpClient()
{
    BaseAddress = new Uri("https://localhost:5001"),
    DefaultRequestVersion = new Version(2, 0)
};

// HTTP/2 is default
using (var response = await client.GetAsync("/"))
    Console.WriteLine(response.Content);
```

## Use ASP.NET Core with HTTP/2

HTTP/2 is supported with ASP.NET Core in the following IIS deployment scenarios.

 - Windows Server 2016 or later / Windows 10 or later
 - IIS 10 or later
 - TLS 1.2 or later connection

When hosting out-of-process: Public-facing edge server connections use HTTP/2, but the reverse proxy connection to the Kestrel server uses HTTP/1.1.

 - For an in-process deployment when an `HTTP/2` connection is established, `HttpRequest.Protocol` reports `HTTP/2`. 
 - For an out-of-process deployment when an `HTTP/2` connection is established, `HttpRequest.Protocol` reports `HTTP/1.1`.

## Advanced HTTP/2 features to support gRPC

Additional HTTP/2 features in IIS support gRPC, including support for response trailers and sending, reset frames.

Requirements to run gRPC on IIS:

 - In-process hosting.
 - Windows 10, OS Build 20300.1000 or later. May require the use of Windows Insider Builds.
 - TLS 1.2 or later connection

## Trailers

HTTP Trailers are similar to HTTP Headers, except they are sent after the response body is sent. For IIS and HTTP.SYS, only HTTP/2 response trailers are supported.

```csharp
if (httpContext.Response.SupportsTrailers())
{
    httpContext.Response.DeclareTrailer("trailername");	

    // Write body
    httpContext.Response.WriteAsync("Hello world");

    httpContext.Response.AppendTrailer("trailername", "TrailerValue");
}
```

 - `SupportsTrailers` ensures that trailers are supported for the response.
 - `DeclareTrailer` adds the given trailer name to the Trailer response header. Declaring a response's trailers is optional, but recommended. If DeclareTrailer is called, it must be before the response headers are sent.
 - `AppendTrailer` appends the trailer.