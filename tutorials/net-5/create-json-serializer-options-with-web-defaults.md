---
PermaID: 100018
Name: Create JsonSerializerOptions with Web Defaults
---

# Create JsonSerializerOptions with Web Defaults

In web applicaitons, the following options have different defaults.

 - PropertyNameCaseInsensitive = true
 - JsonNamingPolicy = CamelCase
 - NumberHandling = AllowReadingFromString

The `JsonSerializerOptions` constructor lets you create a new instance with the default options that ASP.NET Core uses for web apps as shown below.

```csharp
public class Customer
{
    public string Name { get; init; }
    public int Age { get; set; }
    public string Address { get; set; }
};

public static void Example1()
{
    JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    Console.WriteLine($"PropertyNameCaseInsensitive: {options.PropertyNameCaseInsensitive}");
    Console.WriteLine($"JsonNamingPolicy: {options.PropertyNamingPolicy}");
    Console.WriteLine($"NumberHandling: {options.NumberHandling}");

    Customer customer = new()
    {
        Name = "Mark",
        Address = "22 wall street.",
        Age = 23
    };

    string json = JsonSerializer.Serialize<Customer>(customer, options);

    Console.WriteLine($"Output JSON: {json}");
}
```

The above example will print the following output.

```csharp
PropertyNameCaseInsensitive: True
JsonNamingPolicy: System.Text.Json.JsonCamelCaseNamingPolicy
NumberHandling: AllowReadingFromString
Output JSON: {
  "name": "Mark",
  "age": 23,
  "address": "22 wall street."
}
```