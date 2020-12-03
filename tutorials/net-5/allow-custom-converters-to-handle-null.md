---
PermaID: 100016
Name: Allow Custom Converters to Handle Null
---

# Allow Custom Converters to Handle Null

By default, the serializer handles null values as follows.

## For reference types and `Nullable<T>` types

 - It does not pass null to custom converters on serialization.
 - It does not pass JsonTokenType.Null to custom converters on deserialization.
 - It returns a null instance on deserialization.
 - It writes null directly with the writer on serialization.

## For non-nullable value types:

 - It passes `JsonTokenType.Null` to custom converters on deserialization. 
 - If no custom converter is available, a JsonException exception is thrown by the internal converter for the type.

This null-handling behavior is primarily to optimize performance by skipping an extra call to the converter. In addition, it avoids forcing converters for nullable types to check for null at the start of every Read and Write method override.

To enable a custom converter to handle null for a reference or value type, override `JsonConverter<T>.HandleNull` to return `true` as shown below.

```csharp
public class AddressConverter : JsonConverter<string>
{
    public override bool HandleNull => true;

    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString() ?? "No address provided.";
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}

public class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    [JsonConverter(typeof(AddressConverter))]
    public string Address { get; set; }
}

public static void Example1()
{
    var json = @"{""Name"":""Mark"",""Age"":40,""Address"":null} ";
    Console.WriteLine($"Input JSON: {json}");

    Customer customer = JsonSerializer.Deserialize<Customer>(json);

    Console.WriteLine($"Name: {customer.Name}");
    Console.WriteLine($"Age: {customer.Age}");
    Console.WriteLine($"Address: {customer.Address}");
}
```

The above example will print the following output.

```csharp
Input JSON: {"Name":"Mark","Age":40,"Address":null}
Name: Mark
Age: 40
Address: No address provided.
```