---
PermaID: 100005
Name: Delegates
---

# Delegates

The **CS-Script** allows you to compile method scripts into class-less delegates. It provides the `CreateDelegate` method that returns `MethodDelegate<T>`, which is semi-dynamic by nature.

The following example evaluates the script into a delegate.

```csharp
public static void Example1()
{
    var Print = CSScript.Evaluator.CreateDelegate(@"void Print(string message)
        {
            Console.WriteLine(message);
        }");

    Print("Hi, good morning...");
    Print("You are learning CS-Script.");
    Print("Bye...");
}
```

You can also use the strongly-typed version of the `CreateDelegate` method.

```csharp
public static void Example2()
{                      
    var Add = CSScript.Evaluator.CreateDelegate<int>(@"int Add(int a, int b)
        {
            return a + b;
        }");

    Console.WriteLine("Add(3, 2): {0}", Add(3, 2));
    Console.WriteLine("Add(13, 21): {0}", Add(13, 21));
    Console.WriteLine("Add(31, 12): {0}", Add(31, 12));
}
```

Let's execute the above code, and you will see the following output.

```csharp
Add(3, 2): 5
Add(13, 21): 34
Add(31, 12): 43
```

The `CreateDelegate` method returns `MethodDelegate<T>`, which is strongly typed by a return type and dynamically typed by method parameters.

```csharp
public delegate T MethodDelegate<T>(params object[] paramters);
```

CLR cannot distinguish between arguments of type `params object[]` and any other array. You will need to wrap the array as an object array when you pass the array args, as shown below.

```csharp
public static void Example3()
{
    var GetFirst = CSScript.Evaluator.CreateDelegate<string>(@"string GetFirst(string[] values)
        {
            return values[0];
        }");

    string[] months = { "Jan", "Feb", "Mar" };

    Console.WriteLine("The first element in an array: {0}", GetFirst(new object[] { months }));
}
```
