---
PermaID: 100004
Name: Using Declaration
---

# Using Declaration

In C#, programmers use the `using` statement for declaring disposable variables such as File I/O, databases, and web services, etc. It ensures that classes that implement the IDisposable interface call their dispose method.

 - The only downside is that adding a `using` statement to your code introduces a new scope block and indentation level. 
 - C# 8.0 using declarations eliminate that requirement and you no longer have to constrain your `using` statements with curly brackets. 
 - It guarantees that the `Dispose` method will be called, even if the code throws an exception.

In C# 8.0, a `using` declaration is a variable declaration preceded by the `using` keyword. It tells the compiler that the variable is declared and it should be disposed of at the end of the enclosing scope. 

Let's consider the following example in which the file is disposed of when the closing brace associated with the `using` statement is reached. 

```csharp
List<string> lines = new List<string>()
{
    "First line.",
    "Second line",
    "Third line."
};

using (var file = new StreamWriter("TestFile.txt"))
{
    foreach (string line in lines)
    {
        file.WriteLine(line);
    }
} // file is disposed here
```

Now let's implement the same example using the new using-declaration feature.

```csharp
public static void WriteToFileUsingDeclaration()
{
    List<string> lines = new List<string>()
    {
        "First line.",
        "Second line",
        "Third line."
    };

    using var file = new StreamWriter("TestFile.txt");
    
    foreach (string line in lines)
    {
        file.WriteLine(line);
    }
}// file is disposed here
``` 

In the above example, you can see that the file is disposed of when the closing brace for the method is reached. That's the end of the scope in which the file is declared.
