---
PermaID: 100015
Name: Ignore Properties
---

# Ignore Properties

When serializing C# objects to JSON, by default, all public properties are serialized. If you don't want some of them to appear in the resulting JSON, you have the following options.

 - [Ignore Individual Properties](#ignore-individual-properties)
 - [Ignore All Read-only Properties](#ignore-all-read-only-properties)
 - [Ignore All Null-value Properties](#ignore-all-null-value-properties)
 - [Ignore All Default-value Properties](#ignore-all-default-value-properties)

## Ignore Individual Properties

To ignore individual properties, you can use the `[JsonIgnore]` attribute to prevents a property from being serialized or deserialized.

```csharp
public class Customer
{
    public string Name { get; set; }

    public int Age { get; set; }

    [JsonIgnore]
    public string? Address { get; set; }
};

public static void Example1()
{
    Customer customer = new()
    {
        Name = "Mark",
        Address = "22 wall street.",
        Age = 23
    };

    string json = JsonSerializer.Serialize<Customer>(customer);

    Console.WriteLine(json);
}
```

The above example will print the following output.

```csharp
{"Name":"Mark","Age":23}
```

You can also specify conditional exclusion by setting the [JsonIgnore] attribute's Condition property. The `JsonIgnoreCondition` enum provides the following options.

 - **Always:** The property is always ignored. If no Condition is specified, this option is assumed.
 - **Never:** The property is always serialized and deserialized, regardless of the `DefaultIgnoreCondition`, `IgnoreReadOnlyProperties`, and `IgnoreReadOnlyFields` global settings.
 - **WhenWritingDefault:** The property is ignored on serialization if it is a reference type `null`, a nullable value type `null`, or a value type default.
 - **WhenWritingNull:** The property is ignored on serialization if it is a reference type `null`, or a nullable value type `null`.

The following example shows the usage of the `[JsonIgnore]` attribute with a condition property.

```csharp
public class Customer2
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Name { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int Age { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Address { get; set; }
};

public static void Example2()
{
    Customer2 customer = new()
    {
        Name = default,
        Address = null,
        Age = default
    };

    string json = JsonSerializer.Serialize<Customer2>(customer);

    Console.WriteLine(json);
}
```

The above example will print the following output.

```csharp
{"Age":0}
```

## Ignore All Read-only Properties

A property is read-only if it contains a public getter but not a public setter. To ignore all read-only properties when serializing, set the `JsonSerializerOptions.IgnoreReadOnlyProperties` to `true` as shown below.

```csharp
public class Customer3
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
    public DateTime? DOB { get; private set; }

    public Customer3(string name, int age, string address, DateTime dob)
    {
        (Name, Age, Address, DOB) = (name, age, address, dob);
    }
};

public static void Example3()
{
    Customer3 customer = new("Mark", 31, "22 wall street.", DateTime.Now.AddYears(-29));

    var options = new JsonSerializerOptions
    {
        IgnoreReadOnlyProperties = true,
        WriteIndented = true
    };

    string json = JsonSerializer.Serialize<Customer3>(customer, options);

    Console.WriteLine(json);
}
```

The above example will print the following output.

```csharp
{
  "Name": "Mark",
  "Age": 31,
  "Address": "22 wall street."
}
```

This option applies only to serialization. During deserialization, read-only properties are ignored by default.


## Ignore All Null-value Properties

To ignore all null-value properties, set the `DefaultIgnoreCondition` property to `WhenWritingNull`, as shown below.

```csharp
public class Customer4
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string? Address { get; set; }
};

public static void Example4()
{
    Customer4 customer = new()
    {
        Name = "Mark",
        Address = null,
        Age = 23
    };

    JsonSerializerOptions options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };


    string json = JsonSerializer.Serialize<Customer4>(customer, options);

    Console.WriteLine(json);
}
```

The above example will print the following output.

```csharp
{"Name":"Mark","Age":23}
```

## Ignore All Default-value Properties

To prevent serialization of default values in value type properties, set the `DefaultIgnoreCondition` property to `WhenWritingDefault`, as shown below.


```csharp
public class Customer5
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string? Address { get; set; }
    public DateTime? DOB { get; set; }
};

public static void Example5()
{
    Customer5 customer = new()
    {
        Name = "Mark",
        Address = "11 wall street.",
        Age = 25,
        DOB = default
    };

    JsonSerializerOptions options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
    };


    string json = JsonSerializer.Serialize<Customer5>(customer, options);

    Console.WriteLine(json);
}
```

The above example will print the following output.

```csharp
{"Name":"Mark","Age":25,"Address":"11 wall street."}
```
