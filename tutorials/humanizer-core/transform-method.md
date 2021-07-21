---
PermaID: 100002
Name: Transform Method
---

# Transform Method

**Humanizer.Core** provides a `Transform()` string extension method that transforms a string using the provided transformers. Transformations are applied in the provided order.

Let's consider the following simple example that transforms a string to the various casing using `IStringTransformer` for letter casing.

```csharp
public static void Example1()
{
    string str = "My Test String";

    Console.WriteLine(str.Transform(To.TitleCase));
    Console.WriteLine(str.Transform(To.UpperCase));
    Console.WriteLine(str.Transform(To.LowerCase));
    Console.WriteLine(str.Transform(To.SentenceCase));
}
```

Let's execute the above example and you will see the following output.

```csharp
My test string
My Test String
my test string
```

The property passed as a parameter like `To.TitleCase` returns an instance of a private class that implements `IStringTransformer` and knows how to turn a string into a specified case.

The advantage of using the `Transform` method is that `IStringTransformer` is an interface you can implement in your codebase once and use it with the `Transform` method allowing for easy extension.
