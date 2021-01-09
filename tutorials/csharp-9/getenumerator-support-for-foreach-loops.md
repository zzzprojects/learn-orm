---
PermaID: 100011
Name: GetEnumerator support for foreach loops
---

# GetEnumerator Support for Foreach Loops

In C#, if you want to iterate on a collection with the `foreach` loop, the collection must expose a public method `GetEnumerator()` which doesn't exist on `IEnumerator` and `IAsyncEnumerator` interfaces.

In C# 9.0, you can create an extension method that will allow you to iterate in foreach loops on those interfaces. Here is the simple extension method called `GetEnumerator()`.

```csharp
public static class Extensions
{
    public static IEnumerator<T> GetEnumerator<T>(this IEnumerator<T> enumerator) => enumerator;
}
```

Now you can use `IEnumerator<T>` in `foreach` loops as shown below.

```csharp
List<string> daysOfWeek = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

IEnumerator<string> daysOfWeekEnumerator = daysOfWeek.GetEnumerator();

foreach (var country in daysOfWeekEnumerator)
{
    Console.WriteLine($"{country} is a beautiful country");
}
```

As you can see that `daysOfWeek` exposes a public `GetEnumerator()` which is provided as an extension method and that is recognized by the `foreach` statement.

Before C# 9.0, when you try to iterate with a `foreach` loop on a collection type `IEnumerator<T>` or `IAsyncEnumerator<T>`, you will get the following error.

```csharp

Error CS1579 foreach statement cannot operate on variables of type 'IEnumerator<string>' because 'IEnumerator<string>' does not contain a public instance definition for 'GetEnumerator'
```
