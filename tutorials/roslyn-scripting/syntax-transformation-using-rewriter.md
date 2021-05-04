---
PermaID: 100013
Name: Syntax Transformation using Rewriter
---

# Syntax Transformation using Rewriter

The `SyntaxFactory` class provides a convenient way to transform individual branches of a syntax tree, but sometimes you will need to perform multiple transformations on a syntax tree. 

 - The `CSharpSyntaxRewriter` class is a subclass of SyntaxVisitor which can be used to apply a transformation to a specific type of SyntaxNode. 
 - You can also apply a set of transformations to multiple types of `SyntaxNode` wherever they appear in a syntax tree. 

The following example demonstrates the same behavior but this time we will be using the `CSharpSyntaxRewriter` class.

Let's add a class and replace the following code.

```csharp
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynDemo
{
    class UsingRewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitUsingDirective(UsingDirectiveSyntax node)
        {
            NameSyntax name = SyntaxFactory.IdentifierName("Microsoft");
            name = SyntaxFactory.QualifiedName(name, SyntaxFactory.IdentifierName("CodeAnalysis"));
            name = SyntaxFactory.QualifiedName(name, SyntaxFactory.IdentifierName("CSharp"));
            name = SyntaxFactory.QualifiedName(name, SyntaxFactory.IdentifierName("Scripting"));

            if (node.Name.ToString() == "Microsoft.CodeAnalysis")
            {
                var newNode = node.WithName(name);
                node = node.ReplaceNode(node, newNode);
            }

            return node;
        }
    }
}
```

As you can see that we are doing the same transformation but using the `CSharpSyntaxRewriter` class

```csharp
static void SyntaxTransformationRewriterExample()
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

    var root = (CompilationUnitSyntax)tree.GetRoot();

    var rewriter = new UsingRewriter();
    var result = rewriter.Visit(root);

    Console.WriteLine(result);
}
```

Once the source code is parsed then we replaced the last using directive with the new one. Let's execute the above code and you will see the following output.

```csharp
using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

As you can see the last using directive is updated to `Microsoft.CodeAnalysis.CSharp.Scripting;`.
