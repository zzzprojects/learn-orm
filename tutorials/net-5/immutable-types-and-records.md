---
PermaID: 100012
Name: Immutable Types and Records
---

# Immutable Types and Records

The `System.Text.Json` can use a parameterized constructor, makins it possible to deserialize an immutable class or struct. 

 - For a class, if the only constructor is a parameterized one, that constructor will be used. 
 - For a struct or a class with multiple constructors, specify the one to use by applying the `[JsonConstructor]` attribute. 
 - When the attribute is not used, a public parameterless constructor is always used if present. 
 - The attribute can only be used with public constructors. 
 
The following example uses the `[JsonConstructor]` attribute.

```csharp
public struct Customer
{
    public string Name { get; init; }
    public int Age { get; set; }
    public string Address { get; set; }

    [JsonConstructor]
    public Customer(string name, int age, string address)
    {
        (Name, Age, Address) = (name, age, address);
    }
}

public static void Example()
{
    var json = @"{""name"":""Mark"",""age"":40,""address"":""22 Ashdown""} ";
    Console.WriteLine($"Input JSON: {json}");

    var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

    var customer = JsonSerializer.Deserialize<Customer>(json, options);

    Console.WriteLine($"Name: {customer.Name}");
    Console.WriteLine($"Age: {customer.Age}");
    Console.WriteLine($"Address: {customer.Address}");

    var roundTrippedJson =
        JsonSerializer.Serialize<Customer>(customer, options);

    Console.WriteLine($"Output JSON: {roundTrippedJson}");
}
```

The above example will print the following output.

```csharp
Input JSON: {"name":"Mark","age":40,"address":"22 Ashdown"}
Name: Mark
Age: 40
Address: 22 Ashdown
Output JSON: {"name":"Mark","age":40,"address":"22 Ashdown"}
```

Records in C# 9 are also supported, as shown in the following example.

```csharp
public record Forecast(DateTime Date, int TemperatureC)
{
    public string? Summary { get; init; }
};

public static void Example2()
{
    Forecast forecast = new(DateTime.Now, 40)
    {
        Summary = "Hot!"
    };

    string forecastJson = JsonSerializer.Serialize<Forecast>(forecast);
    Console.WriteLine(forecastJson);
    Forecast? forecastObj = JsonSerializer.Deserialize<Forecast>(forecastJson);
    Console.WriteLine(forecastObj);
}
```

The above example will print the following output.

```csharp
{"Date":"2020-12-02T14:54:55.2052141+05:00","TemperatureC":40,"Summary":"Hot!"}
Forecast { Date = 12/2/2020 2:54:55 PM, TemperatureC = 40, Summary = Hot! }
```
