---
PermaID: 100018
Name: Emit Compilation
---

# Emit Compilation

So far, we have discussed how to evaluate, analyze and manipulate source code. Now let's have a look at how to emit the compilation of your source code. You can emit it to either disk or memory. 

The following example emits the source code to the `output.exe` file. 
```csharp
static void EmitCompilationExample()
{
    SyntaxTree tree = CSharpSyntaxTree.ParseText(
        @"using System;
        using System.Collections;
        using System.Text;
         
        namespace HelloWorld
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Console.WriteLine(""Hello, World!"");
                }
            }
        }");

    var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);

    var compilation = CSharpCompilation.Create("MyCompilation",
        syntaxTrees: new[] { tree }, references: new[] { mscorlib });

    var emitResult = compilation.Emit("output.exe", "output.pdb");

    if (!emitResult.Success)
    {
        foreach (var diagnostic in emitResult.Diagnostics)
        {
            Console.WriteLine(diagnostic.ToString());
        }
    }
}
```

Let's execute the above code, and you will see that the `.exe` and `.pdb` files have been emitted to `Debug/bin/`. 

You can also emit the compilation of the source code to the memory and then execute it from memory, as shown below.

```csharp
static void EmitCompilationToMemoryExample()
{
    SyntaxTree tree = CSharpSyntaxTree.ParseText(
        @"using System;
        using System.Collections;
        using System.Text;
         
        namespace HelloWorld
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Console.WriteLine(""Hello, World!"");
                }
            }
        }");

    var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);

    var compilation = CSharpCompilation.Create("MyCompilation",
        syntaxTrees: new[] { tree }, references: new[] { mscorlib });

    var ms = new MemoryStream();
    var emitResult = compilation.Emit(ms);

    var ourAssembly = Assembly.Load(ms.ToArray());
    var type = ourAssembly.GetType("Program");

    type.InvokeMember("Main", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, null);
}
```
