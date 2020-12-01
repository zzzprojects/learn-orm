---
PermaID: 100011
Name: Allow or Write Numbers in Quotes
---

# Allow or Write Numbers in Quotes

Some serializers encode numbers as JSON strings (surrounded by quotes).

For example:

```csharp
{
    "Age": "40"
}
```

Instead of:

```csharp
{
    "Age": 40
}
```

To serialize numbers in quotes or accept numbers in quotes across the entire input object graph, set `JsonSerializerOptions.NumberHandling` as shown below.

```csharp
public class Customer
{
    public string Name { get; init; }
    public int Age { get; set; }
    public string Address { get; set; }
}

public static void Example()
{
    Customer customer = new()
    {
        Name = "Mark",
        Age = 40,
        Address = "22 Ashdown"
    };

    JsonSerializerOptions options = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
        WriteIndented = true
    };

    string customerJson = JsonSerializer.Serialize<Customer>(customer, options);

    Console.WriteLine($"Output JSON:\n{customerJson}");

    Customer customerDeserialized = JsonSerializer.Deserialize<Customer>(customerJson, options);

    Console.WriteLine($"Name: {customerDeserialized.Name}");
    Console.WriteLine($"Age: {customerDeserialized.Age}");
    Console.WriteLine($"Address: {customerDeserialized.Address}");
}
```

The above example will print the following output.

```csharp
Output JSON:
{
  "Name": "Mark",
  "Age": "40",
  "Address": "22 Ashdown"
}
Name: Mark
Age: 40
Address: 22 Ashdown
```

When you use `System.Text.Json` indirectly through ASP.NET Core, quoted numbers are allowed when deserializing because ASP.NET Core specifies [web default options](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializerdefaults?view=net-5.0#System_Text_Json_JsonSerializerDefaults_Web).

To allow or write quoted numbers for specific properties, fields, or types, use the [[JsonNumberHandling]](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonnumberhandlingattribute?view=net-5.0) attribute.