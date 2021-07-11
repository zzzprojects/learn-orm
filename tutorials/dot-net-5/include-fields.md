---
PermaID: 100014
Name: Include Fields
---

# Include Fields

To include fields when serializing or deserializing, you can use the `JsonSerializerOptions.IncludeFields` global setting or the `[JsonInclude]` attribute. 

## JsonSerializerOptions.IncludeFields Global Setting

Determines whether fields are handled during serialization and deserialization. The default value is `false`.

The following example shows the usage of `JsonSerializerOptions.IncludeFields` global setting.

```csharp
public class Customer
{
    public string Name;
    public int Age;
    public string Address;
}

public static void Example1()
{
    var json = @"{""Name"":""Mark"",""Age"":40,""Address"":""22 Ashdown""} ";
    Console.WriteLine($"Input JSON: {json}");

    var options = new JsonSerializerOptions
    {
        IncludeFields = true,
    };

    var customer = JsonSerializer.Deserialize<Customer>(json, options);

    Console.WriteLine($"Name: {customer.Name}");
    Console.WriteLine($"Age: {customer.Age}");
    Console.WriteLine($"Address: {customer.Address}");

    var roundTrippedJson = JsonSerializer.Serialize<Customer>(customer, options);

    Console.WriteLine($"Output JSON: {roundTrippedJson}");
}
```

The above example will print the following output.

```csharp
Input JSON: {"Name":"Mark","Age":40,"Address":"22 Ashdown"}
Name: Mark
Age: 40
Address: 22 Ashdown
Output JSON: {"Name":"Mark","Age":40,"Address":"22 Ashdown"}
```

## JsonInclude Attribute

Indicates that the member should be included for serialization and deserialization.

The following example shows the usage of the `[JsonInclude]` attribute.

```csharp
public class Customer2
{
    [JsonInclude]
    public string Name;
    [JsonInclude]
    public int Age;
    [JsonInclude]
    public string Address;
}

public static void Example2()
{
    var json = @"{""Name"":""John"",""Age"":31,""Address"":""22 wall street""} ";
    Console.WriteLine($"Input JSON: {json}");

    var customer = JsonSerializer.Deserialize<Customer2>(json);

    Console.WriteLine($"Name: {customer.Name}");
    Console.WriteLine($"Age: {customer.Age}");
    Console.WriteLine($"Address: {customer.Address}");

    var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
    var roundTrippedJson = JsonSerializer.Serialize<Customer2>(customer, options);

    Console.WriteLine($"Output JSON: {roundTrippedJson}");
}
```

The above example will print the following output.

```csharp
Input JSON: {"Name":"John","Age":31,"Address":"22 wall street"}
Name: John
Age: 31
Address: 22 wall street
Output JSON: {"name":"John","age":31,"address":"22 wall street"}
```