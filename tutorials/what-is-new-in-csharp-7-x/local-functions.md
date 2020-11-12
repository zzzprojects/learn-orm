---
PermaID: 100001
Name: Local Functions
---

# Local Functions

## What is Local Function?

A local function is defined as a nested method inside a containing member. Local functions are `private` methods of a type that are nested in another member.

 - It makes it easier for readers of the class to know that the local method is only called from the context in which it is declared.
 - It also gives you a better place to write methods that are called from only one location.

In other words, a local function is a private function of a function whose scope is limited to that function in which it is created. It can be declared in and called from any of the following.

 - Methods, especially iterator methods and async methods
 - Constructors
 - Property accessors
 - Event accessors
 - Anonymous methods
 - Lambda expressions
 - Finalizers
 - Other local functions

## Syntax

Local functions make the intent of your code clear. Anyone reading your code can see that the method is not callable except by the containing method. You can declare the local functions using the following syntax.

```csharp
<modifiers> <return-type> <method-name> <parameter-list>
```

All local variables that are defined in the containing member, including its method parameters, are accessible in a non-static local function. An access modifier can not be included in a local function definition because all local functions are `private`.

Including an access modifier, such as the private keyword, generates the following compiler error.

```csharp
Error CS0106, "The modifier 'private' is not valid for this item."
```

Let's consider the following simple example of a local function where a local function `WriteMessage` is defined that is `private` to a `SimpleLoalFunctionExample` method.

```csharp
public static void SimpleLoalFunctionExample()
{
    WriteMessage("Hello!");
    WriteMessage("You are calling");
    WriteMessage("a local function");

    void WriteMessage(string message)
    {
        Console.WriteLine("The message is: {0}", message);
    }
}
```

It is the simplest form of a local function in which a `WriteMessage` function takes a `string` as a parameter and print that message to the console.

Local functions can access variables from enclosing scope of the containing method as shown in the below example.

```csharp
public static void AddExampleUsingLocalFunction()
{
    int num1 = 34;
    int num2 = 21;
    Console.WriteLine(AddNumbers());

    int AddNumbers()
    {
        return num1 + num2;
    }
}
```

As you can see that local functions automatically capture the context of the enclosing scope to make any variables from the containing method available inside them. The local variables called `num1` and `num2` are accessible for the function as they are defined inside the container function.

