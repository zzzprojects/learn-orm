---
PermaID: 100005
Name: Top-Level Programs
---

# Top-Level Programs

In C# 9, a very intersting feature is introduced called **Top-level programs**. It is a simpler way to write your program on its top-level such as, `Program.cs` file.

Let's have a look into simple hello world example which you will see when you create a new console application from Visual Studio.

```csharp
using System;

namespace CSharp9Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }        
    }
}
```

It will just print the "Hello World!" to the screen and there is only one line of code that does anything. With top-level programs feature introduced in C# 9.0, you can remove all the unnecessary ceremony and use only a using statement and a single line which print the message to the console window as shown below.

```csharp
using System;

Console.WriteLine("Hello World!");
```

If you want a one-line program, you could remove the `using` directive and use the fully qualified type name as shown below.

```csharp
System.Console.WriteLine("Hello World!");
```

In your application, only one file uses top-level statements. If the compiler finds top-level statements in multiple source files, it’s an error. 

 - It is also an error if you combine top-level statements with a declared program entry point method, such as, a `Main` method. 
 - In a sense, you can think that one file contains the statements that would normally be in the `Main` method of a `Program` class.

The **Top-level programs** are C# language features and it doesn’t come down to Common Language Runtime (CLR). C# compiler produces `Program` class and `Main()` method like it was before.

## Main Method Argument

You will think how we can use `args` argument of `Main()` method? It is magically here and available in top-level programs as shown below.

```csharp
using System;

Console.WriteLine("Hello World!");

for (var i = 0; i < args.Length; i++)
{
    Console.WriteLine("{0}: {1}", i, args[i]);
}
``` 
