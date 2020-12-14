---
PermaID: 100021
Name: Fast Built-in JSON Support
---

# Fast Built-in JSON Support

.NET users have largely relied on `Newtonsoft.Json` and other popular JSON libraries, which continue to be good choices. `Newtonsoft.Json` uses .NET strings as its base datatype, which is UTF-16 under the hood.

## System.Text.Json

The `System.Text.Json` is built-in as part of the shared framework for .NET Core 3.0 and later versions. 

 - It provides functionality for serializing to and deserializing from JavaScript Object Notation (JSON).
 - The library design emphasizes high performance and low memory allocation over an extensive feature set. 
 - The built-in UTF-8 support optimizes the process of reading and writing JSON text encoded as UTF-8, which is the most prevalent encoding for data on the web and files on disk.
 - The library also provides classes for working with an in-memory document object model (DOM). This feature enables random read-only access to the elements in a JSON file or string. 

For earlier framework versions, install the [System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package.

To serialize to UTF-8, call the `JsonSerializer.SerializeToUtf8Bytes` method as shown below.

```csharp
public class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
};

public static void Example1()
{
    Customer customer = new Customer()
    {
        Name = "Mark",
        Age = 40,
        Address = "22 Ashdown"
    };

    byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(customer);

    Console.WriteLine(jsonUtf8Bytes);
}
```

To pretty-print the JSON output, set `JsonSerializerOptions.WriteIndented` to `true` as shown below.

```csharp
public class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
};

public static void Example2()
{
    Customer customer = new Customer()
    {
        Name = "Mark",
        Age = 40,
        Address = "22 Ashdown"
    };

    var options = new JsonSerializerOptions
    {
        WriteIndented = true
    };
    var jsonUtf8Bytes = JsonSerializer.Serialize(customer, options);

    Console.WriteLine(jsonUtf8Bytes);
}
```