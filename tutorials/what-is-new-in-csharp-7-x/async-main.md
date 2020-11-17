---
PermaID: 100007
Name: Async Main
---

# Async Main

## What is Main Method?

The `Main` method is the entry point of a C# application. When the application is started, the `Main` method is the first method that is invoked.

 - The `Main` is declared inside a class or struct. 
 - It must be `static`, and it need not be public. 
 - The enclosing `class` or `struct` is not required to be `static`.
 - The return type of `Main` method can be either `void` or `int`.
 - It can have one parameter of a string array containing any command-line arguments.

Before C# 7.1, four overloaded versions were considered valid signatures for the Main method in C#, as shown below.

```csharp
static void Main();  
static int Main();  
static void Main(string[] args);  
static int Main(string[] args); 
```
From C# 7.1, it is also possible to define the `Main` method as `async` with any of the following additional overloads. 

```csharp
static Task Main();  
static Task < int > Main();  
static Task Main(string[] args);  
static Task < int > Main(string[] args); 
```

An `async Main` method enables you to use `await` in your `Main` method. Before C# 7.1, when you want to call the `async` method from the `Main` method, you need to add some boilerplate code, as shown below.

```csharp
static void Main(string[] args)
{
    var helloWorld = GetHelloWorldAsync().GetAwaiter().GetResult();
    Console.WriteLine(helloWorld);
}

static Task<string> GetHelloWorldAsync()
{
    return Task.FromResult("Hello Async World");
}
```

Now in C# 7.1, the syntax is simpler and easy to use only using the async main.

```csharp
static async Task Main(string[] args)
{
    var helloWorld = await GetHelloWorldAsync();
    Console.WriteLine(helloWorld);
}

static Task<string> GetHelloWorldAsync()
{
    return Task.FromResult("Hello Async World");
}
```

If your program returns an exit code, you can declare a `Main` method that returns a `Task<int>`.

```csharp
static async Task<int> Main()
{
    // This could also be replaced with the body
    // DoAsyncWork, including its await expressions:
    return await DoAsyncWork();
}
```
