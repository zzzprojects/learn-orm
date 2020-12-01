---
PermaID: 100009
Name: Preserve References and Handle Circular References
---

# Preserve References and Handle Circular References

To preserve references and handle circular references, set `ReferenceHandler` to `Preserve`. This setting causes the following behavior:

 - **On Serialize:** When writing complex types, the serializer also writes metadata properties (`$id`, `$values`, and `$ref`).
 - **On Deserialize:** Metadata is expected (although not mandatory), and the deserializer tries to understand it.

The following code shows the usage of the `Preserve` setting.

```csharp
public class Employee
{
    public string Name { get; set; }
    public Employee Manager { get; set; }
    public List<Employee> DirectReports { get; set; }
}

public class Program
{
    public static void Main()
    {
        Employee tyler = new()
        {
            Name = "Tyler Stein"
        };

        Employee adrian = new()
        {
            Name = "Adrian King"
        };

        tyler.DirectReports = new List<Employee> { adrian };
        adrian.Manager = tyler;

        JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        string tylerJson = JsonSerializer.Serialize(tyler, options);
        Console.WriteLine($"Tyler serialized:\n{tylerJson}");

        Employee tylerDeserialized = JsonSerializer.Deserialize<Employee>(tylerJson, options);

        Console.WriteLine("Tyler is manager of Tyler's first direct report: ");
        Console.WriteLine(tylerDeserialized.DirectReports[0].Manager == tylerDeserialized);
    }
}
```

The above example will print the following output.

```csharp
Tyler serialized:
{
  "$id": "1",
  "Name": "Tyler Stein",
  "Manager": null,
  "DirectReports": {
    "$id": "2",
    "$values": [
      {
        "$id": "3",
        "Name": "Adrian King",
        "Manager": {
          "$ref": "1"
        },
        "DirectReports": null
      }
    ]
  }
}
Tyler is the manager of Tyler's first direct report:
True
```

You can not use this feature to preserve value types or immutable types. On deserialization, the instance of an immutable type is created after the entire payload is read. 

 - So it would be impossible to deserialize the same instance if a reference to it appears within the JSON payload.
 - For value types, immutable types, and arrays, no reference metadata is serialized. 
 - On deserialization, an exception is thrown if `$ref` or `$id` is found. 
 - However, value types ignore `$id` (and $values in the case of collections) to make it possible to deserialize payloads that were serialized by using `Newtonsoft.Json`. 
 - Newtonsoft.Json does serialize metadata for such types.

To determine if objects are equal, `System.Text.Json` uses `ReferenceEqualityComparer.Instance`, which uses reference equality `(Object.ReferenceEquals(Object, Object))` instead of value equality `(Object.Equals(Object)` when comparing two object instances.

For more information about how references are serialized and deserialized, see [ReferenceHandler.Preserve](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.serialization.referencehandler.preserve?view=net-5.0).

The [ReferenceResolver](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.serialization.referenceresolver?view=net-5.0) class defines the behavior of preserving references on serialization and deserialization. 