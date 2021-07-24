---
PermaID: 100007
Name: Inflector Methods
---

# Inflector Methods

## Pluralize

**Humanizer.Core** provides a `Pluralize()` extension method that pluralizes the provided input while considering irregular and uncountable words. 

```csharp
public static void Example1()
{
    List<string> list = new List<string>()
    {
        "Man",
        "Person",
        "Process",
        "Case"
    };

    foreach (var str in list)
    {
        Console.WriteLine("{0} => {1}", str, str.Pluralize());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
Man => Men
Person => People
Process => Processes
Case => Cases
```

## Singularize

**Humanizer.Core** provides a `Singularize()` extension method that singularizes the provided input while considering irregular and uncountable words.

```csharp
public static void Example2()
{
    List<string> list = new List<string>()
    {
        "Men",
        "People",
        "Months",
        "Factories"
    };

    foreach (var str in list)
    {
        Console.WriteLine("{0} => {1}", str, str.Singularize());
    }
}
```

Let's execute the above example and you will see the following output.

```csharp
Men => Man
People => Person
Months => Month
Factories => Factory
```

## ToQuantity

Sometimes you need to call `Singularize` and `Pluralize` to prefix a word with a number, for example, 2 mangos, "3 factories". **Humanizer.Core** provides a `ToQuantity` prefixes the provided word with the number and accordingly pluralizes or singularizes the word.

Let's consider the following simple example.

```csharp
public static void Example3()
{
    Console.WriteLine("factory".ToQuantity(0));
    Console.WriteLine("factory".ToQuantity(1));
    Console.WriteLine("factory".ToQuantity(5));
    Console.WriteLine("man".ToQuantity(1));
    Console.WriteLine("man".ToQuantity(3));
    Console.WriteLine("apple".ToQuantity(12));
    Console.WriteLine("mangos".ToQuantity(3));
    Console.WriteLine("Buildings".ToQuantity(1));
}
```

Let's execute the above example and you will see the following output.

```csharp
0 factories
1 factory
5 factories
1 man
3 men
12 apples
3 mangos
1 Building
```

It also allows you to pass a second argument to the `ToQuantity` to specify how you want the provided quantity to be outputted. The default value is `ShowQuantityAs.Numeric` which is what we saw above. The other two values are `ShowQuantityAs.Words` and `ShowQuantityAs.None`.

```csharp
public static void Example4()
{
    Console.WriteLine("factory".ToQuantity(5, ShowQuantityAs.Words));
    Console.WriteLine("man".ToQuantity(1, ShowQuantityAs.Words));
    Console.WriteLine("man".ToQuantity(3, ShowQuantityAs.None));
    Console.WriteLine("mangos".ToQuantity(3, ShowQuantityAs.Words));
}
```


Let's execute the above example and you will see the following output.

```csharp
five factories
one man
men
three mangos
```