---
PermaID: 100017
Name: Copy JsonSerializerOptions
---

# Copy JsonSerializerOptions

`JsonSerializerOptions` provides options to be used with `JsonSerializer`. `JsonSerializer` provides functionality to serialize objects or value types to JSON and to deserialize JSON into objects or value types. 

The `JsonSerializerOptions` lets you create a new instance with the same options as an existing instance as shown below.

```csharp
public class Customer
{
    public string Name { get; init; }
    public int Age { get; set; }
    public string Address { get; set; }
};

public static void Example1()
{
    string json = @"{""Name"":""Mark"",""Age"":33,""Address"":""22 ashdown""}";
    Console.WriteLine($"Input JSON: {json}");

    Customer customerDeserialized = JsonSerializer.Deserialize<Customer>(json);
    Console.WriteLine($"Name: {customerDeserialized.Name}");
    Console.WriteLine($"Age: {customerDeserialized.Age}");

    JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };

    JsonSerializerOptions optionsCopy = new(options);

    json = JsonSerializer.Serialize<Customer>(customerDeserialized, optionsCopy);
    Console.WriteLine($"Output JSON: {json}");
}
```

The above example will print the following output.

```csharp
Input JSON: {"Name":"Mark","Age":33,"Address":"22 Ashdown"}
Name: Mark
Age: 33
Output JSON: {
  "Name": "Mark",
  "Age": 33,
  "Address": "22 Ashdown"
}
```