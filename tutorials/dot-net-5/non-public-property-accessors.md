---
PermaID: 100013
Name: Non-public Property Accessors
---

# Non-public Property Accessors

To enable the use of a non-public property accessor, you can use the `[JsonInclude]` attribute.

 - It indicates that the member should be included for serialization and deserialization.
 - When applied to a property, it indicates that non-public getters and setters can be used for serialization and deserialization. 
 - Non-public properties are not supported.

The following shows the usage of the `[JsonInclude]` attribute.


```csharp
public class Customer
{
    public string Name { get; init; }

    [JsonInclude]
    public int Age { get; private set; }

    [JsonInclude]
    public string Address { private get; set; }
};

public static void Example1()
{
    string json = @"{""Name"":""Mark"",""Age"":33,""Address"":""22 ashdown""}";
    Console.WriteLine($"Input JSON: {json}");

    Customer customerDeserialized = JsonSerializer.Deserialize<Customer>(json);
    Console.WriteLine($"Name: {customerDeserialized.Name}");
    Console.WriteLine($"Age: {customerDeserialized.Age}");

    json = JsonSerializer.Serialize<Customer>(customerDeserialized);
    Console.WriteLine($"Output JSON: {json}");
}
```

The above example will print the following output.

```csharp
Input JSON: {"Name":"Mark","Age":33,"Address":"22 ashdown"}
Name: Mark
Age: 33
Output JSON: {"Name":"Mark","Age":33,"Address":"22 ashdown"}
```
