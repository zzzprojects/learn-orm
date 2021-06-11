---
PermaID: 100017
Name: Symbol Visitor
---

# Symbol Visitor

The `SymbolVisitor` is equivalent to `SyntaxVisitor`, but it works at the symbol level. When you are using the `SymbolVisitor`, you must construct the scaffolding code to visit all the nodes, which is not the case when you are using the `CSharpSyntaxWalker` and `CSharpSyntaxRewriter`.

Let's add a class and replace the following code, which simply lists all the types available to a compilation.

```csharp
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynDemo
{
    class CustomSymbolVisitor : SymbolVisitor
    {
        public override void VisitNamespace(INamespaceSymbol symbol)
        {
            Console.WriteLine(symbol);

            foreach (var childSymbol in symbol.GetMembers())
            {
                childSymbol.Accept(this);
            }
        }

        public override void VisitNamedType(INamedTypeSymbol symbol)
        {
            Console.WriteLine(symbol);

            foreach (var childSymbol in symbol.GetTypeMembers())
            {
                childSymbol.Accept(this);
            }
        }
    }

}
```

We can now create an instance of the `CustomSymbolVisitor` class and use that instance to visit the compilation of the parsed tree and iterate over the `GlobalNamespace` as shown below.

```csharp
static void SymbolVisitorExample()
{
    SyntaxTree tree = CSharpSyntaxTree.ParseText(
        @"using System;
        using System.Collections;
        using System.Linq;
        using System.Text;
        using Microsoft.CodeAnalysis;
         
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

    var visitor = new CustomSymbolVisitor();
    visitor.Visit(compilation.GlobalNamespace);
}
```
