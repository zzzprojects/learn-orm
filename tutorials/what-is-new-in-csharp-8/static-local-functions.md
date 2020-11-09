---
PermaID: 100005
Name: Static Local Functions
---

# Static Local Functions

## What is Local Function?

A local function is defined as a nested method inside a containing member. It enables you to declare methods inside the context of another method.

 - It makes it easier for readers of the class to know that the local method is only called from the context in which it is declared.
 - It also gives you a better place to write methods that are called from only one location.

Its definition has the following syntax.

```csharp
<modifiers> <return-type> <method-name> <parameter-list>
```

Let's consider the following simple example.

```csharp
public static void AddExampleWithLocalFunction()
{
    int num1 = 4;
    int num2 = 10;

    Console.WriteLine(Add());

    int Add()
    {
        return num1 + num2;
    }
}
```

As you can see that local functions automatically capture the context of the enclosing scope to make any variables from the containing method available inside them.

In C# 8.0, you can create static local functions, a local function declared `static` cannot capture state from the enclosing scope. As a result, locals, parameters, and `this` from the enclosing scope are not available within a static local function.

 - A `static` local function cannot reference instance members from an implicit or explicit `this` or base reference. 
 - It may reference `static` members and `constant` definitions from the enclosing scope.
 - Accessibility rules for private members in the enclosing scope are the same for static and non-static local functions.

Let's consider the following simple example.

```csharp
public static void AddExampleWithStaticLocalFunction()
{
    Console.WriteLine(Add(4, 5));
    Console.WriteLine(Add(13, 39));
    Console.WriteLine(Add(71, 103));

    static int Add(int num1, int num2)
    {
        return num1 + num2;
    }
}
```

Static local functions have no access to the parent's scope. If you try to access any variable from enclosing scope in a static local function, you will get an error as shown in the following example.

```csharp
public static void StaticLocalFunction()
{
    int num = 40;

    Console.WriteLine(GetNumSquare());

    static int GetNumSquare()
    {
        return num * num;
    }
}
```

You will get the following compile-time error.

```csharp
Error CS8421: A static local function cannot contain a reference to 'num'.
```