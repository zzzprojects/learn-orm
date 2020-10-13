---
PermaID: 100009
Name: Methods
---

# Methods

A method is a code block that contains a series of statements. It is a basic part of a program and can solve a certain problem. 

 - A method consists of the program's logic and it is the place where the real job is done. 
 - It can be taken as a base unit for the whole program. 
 - It allows using a simple block, to build bigger programs, which resolve more complex and sophisticated problems.

In C#, every executed instruction is performed in the context of a method. A typical example of a method is the already known method `Main()`.

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to C# Tutorial.");
    }
}
```

The `Main` method is the entry point for every C# application and it's called by the common language runtime (CLR) when the program is started.

## Signatures

A method can be declared in a class, struct, or interface by specifying the following;

 - Access level such as `public` or `private`. 
 - Optional modifiers such as `abstract` or `sealed`. 
 - The return value. 
 - The name of the method, 
 - Method parameters. 
 
These parts together are the signature of the method.

```csharp
public virtual int Drive(int miles, int speed) 
{ 
    /* Method statements here */ 
    
    return 1; 
}
```

### Method Naming Conventions

It is recommended, when declaring a method, to follow the rules for method naming suggested by Microsoft.

- The name of a method must start with a capital letter.
- The PascalCase rule must be applied, i.e. each new word, that concatenates so to form the method name, must start with a capital letter.
- It is recommended that the method name must consist of a verb, or a verb and a noun.

These rules are not mandatory, but recommendable, here are some examples for well-named methods.

```csharp
Print
GetName
PlayMusic
SetUserName
```

## Method Parameters

The method may need additional information, which depends on the environment in which the method executes. The method definition specifies the names and types of any parameters that are required. 

 - When calling code calls the method, it provides concrete values called arguments for each parameter. 
 - The arguments must be compatible with the parameter type but the argument name used in the calling code doesn't have to be the same as the parameter named defined in the method.
 - The parameters are enclosed in parentheses and are separated by commas. Empty parentheses indicate that the method requires no parameters.

```csharp
public int Add(int a, int b)
{
    return a + b;
}

public int Subtract(int a, int b)
{
    return a - b;
}

public void Caller()
{
    int numA = 4;
    int numB = 32;

    int result1 = Add(numA, numB);
    int result2 = Subtract(numA, numB);
}
```
