---
PermaID: 100015
Name: TLS 1.3 & OpenSSL 1.1.1 on Linux
---

# TLS 1.3 & OpenSSL 1.1.1 on Linux

.NET Core now takes advantage of **TLS 1.3** support in **OpenSSL 1.1.1**, when it is available in a given environment.

 - **TLS 1.3** improves the connection times and reduce round trips required between the client and the server.
 - It also improved security because of the removal of various obsolete and insecure cryptographic algorithms.

.NET Core 3.0 uses **OpenSSL 1.1.1**, **OpenSSL 1.1.0**, or **OpenSSL 1.0.2** on a Linux system. Windows and macOS do not yet support TLS 1.3. When **OpenSSL 1.1.1** is available, both `System.Net.Security.SslStream` and `System.Net.Http.HttpClient` types will use **TLS 1.3** by assuming both the client and server support **TLS 1.3**.

### SslStream

`SslStream` provides a stream used for client-server communication that uses the Secure Socket Layer (SSL) security protocol to authenticate the server and optionally the client.

### HttpClient

`HttpClient` provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.

## Example

The following C# 8.0 example demonstrates .NET Core 3.0 on Ubuntu 18.10 connecting to https://www.cloudflare.com:

```csharp
using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace whats_new
{
    public static class TLS
    {
        public static async Task ConnectCloudFlare()
        {
            var targetHost = "www.cloudflare.com";

            using TcpClient tcpClient = new TcpClient();

            await tcpClient.ConnectAsync(targetHost, 443);

            using SslStream sslStream = new SslStream(tcpClient.GetStream());

            await sslStream.AuthenticateAsClientAsync(targetHost);
            await Console.Out.WriteLineAsync($"Connected to {targetHost} with {sslStream.SslProtocol}");
        }
    }
}
```