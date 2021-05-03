---
PermaID: 100011
Name: Semantic Analysis
---

# Semantic Analysis

The Syntax API allows you to look at the structure of a program but sometimes, you will need more information about the semantics or meaning of a program. For example, with syntax APIs, you can't track down the references to members within your source code.

 - The semantic layer shows the real power of Roslyn but this power comes at a cost. 
 - When you query the semantic model, it is more expensive as compared to syntax trees because of compilation.

Let's consider a simple **Hello World** program to analyze.

```csharp
static void SemanticAnalysisExample1()
{
    SyntaxTree tree = CSharpSyntaxTree.ParseText(
@"using System;
using System.Collections.Generic;
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

    var root = (CompilationUnitSyntax)tree.GetRoot();

    var compilation = CSharpCompilation.Create("HelloWorld")
        .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
        .AddSyntaxTrees(tree);

    var model = compilation.GetSemanticModel(tree);

    var nameInfo = model.GetSymbolInfo(root.Usings[0].Name);

    var systemSymbol = (INamespaceSymbol)nameInfo.Symbol;

    var nsMembers = systemSymbol.GetNamespaceMembers();

    foreach (var ns in nsMembers)
    {
        Console.WriteLine(ns.Name);
    }
}
```

In the above code, first, it will parse the source code to the `SyntaxTree` and then create a compilation of the syntax tree. Let's execute the above code and it will enumerate the sub-namespaces of the `System` namespace and print their names to the console.

```csharp
Buffers
CodeDom
Collections
ComponentModel
Configuration
Diagnostics
Globalization
IO
Net
Numerics
Private
Reflection
Resources
Runtime
Security
StubHelpers
Text
Threading
```
