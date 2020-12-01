---
PermaID: 100010
Name: HttpClient and HttpContent Extension Methods
---

# HttpClient and HttpContent Extension Methods

Serializing and deserializing JSON payloads from the network are common operations. Extension methods on `HttpClient` and `HttpContent` let you do these operations in a single line of code. These extension methods use web defaults for `JsonSerializerOptions`.

The following example shows the usage of `HttpClientJsonExtensions.GetFromJsonAsync` and `HttpClientJsonExtensions.PostAsJsonAsync`.

```csharp
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}

public static async Task Example()
{
    using HttpClient client = new()
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
    };

    User user = await client.GetFromJsonAsync<User>("users/1");
    Console.WriteLine($"Id: {user.Id}");
    Console.WriteLine($"Name: {user.Name}");
    Console.WriteLine($"Username: {user.Username}");
    Console.WriteLine($"Email: {user.Email}");

    // Post a new user.
    HttpResponseMessage response = await client.PostAsJsonAsync("users", user);
    Console.WriteLine($"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
}
```

The above example will print the following output.

```csharp
Id: 1
Name: Leanne Graham
Username: Bret
Email: Sincere@april.biz
Success - Created
```

There are also extension methods for System.Text.Json on [HttpContent](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.json.httpcontentjsonextensions?view=net-5.0).