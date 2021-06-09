---
PermaID: 100005
Name: LINQ with Dynamic Expressions
---

# LINQ with Dynamic Expressions

The **Z.Expressions.Eval** library allows you to extend the `IEnumerable<T>` and `IQueryable<T>` interface with methods to use LINQ with dynamic expressions. 

 - It makes it possible and very easy by allowing dynamic queries with the same syntax as LINQ.
 - You can do everything dynamically with this library that you can do with LINQ. 
 - The C# dynamic expression is not interpreted but compiled into LINQ expression.

**Z.Expressions.Eval** library supports the following LINQ method that supports predicate with a dynamic C# expression.

 - Deferred
   - OrderByDescendingDynamic
   - OrderByDynamic
   - SelectDynamic
   - SelectMany
   - SkipWhile
   - TakeWhile
   - ThenByDescendingDynamic
   - ThenByDynamic
   - Where
 - Immediate
   - All
   - Any
   - Count
   - First
   - FirstOrDefault
   - Last
   - LastOrDefault
   - LongCount
   - Single
   - SingleOrDefault

The following example shows how to use a predicate using a string in the LINQ dynamic method.

```csharp
public static void Example1()
{
	var list = new List<char>() { 'a', 'b', 'c', 'd', 'e' };

	var myChar = list.WhereDynamic(c => "c == 'd'").FirstOrDefault();
	
	Console.WriteLine("Result: {0} ",myChar);
}
```

Let's consider another example where the list is sorted in descending order using the LINQ dynamic method. 

```csharp
public static void Example2()
{
	var list = new List<int>() { 3, 13, 9, 10, 2 };

	var newList = list.OrderByDescendingDynamic(i => "i").ToList();

     foreach (var item in newList)
     {
		Console.Write("{0}, ", item);
	}
}
```

You can also use the LINQ Dynamic feature in the `Eval.Execute` method as shown below.

```csharp
public static void Example3()
{
	var list = new List<int>() { 3, 13, 9, 10, 2, 71, 34, 51, 1, 4, 19, 7 };

	var newList = list.Execute<List<int>>("Where(i => i > 10).OrderByDescending(i => i).ToList()");

	foreach (var item in newList)
	{
		Console.Write("{0}, ", item);
	}

    Console.WriteLine("");
}
```

Let's run the above example and you will see the following output.

```csharp
71, 51, 34, 19, 13,
```
