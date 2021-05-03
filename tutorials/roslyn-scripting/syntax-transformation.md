---
PermaID: 100012
Name: Syntax Transformation
---

# Syntax Transformation

As you know that syntax trees are immutable, so instead of modifying existing syntax trees, we need to create new trees using transformations when need to modify them.

Let's consider the following simple example code which contains various using statements at the top of the source code.

```csharp
using System;
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
}
```

As you can see that the last using statement is `Microsoft.CodeAnalysis;`, now we will replace this using statement with `Microsoft.CodeAnalysis.CSharp.Scripting;` using the transformation.

The following code first creates a `NameSyntax` node using the `IdentifierName` and `QualifiedName` methods for the using statement which we will replace.

```csharp
static void SyntaxTransformationExample()
{
    NameSyntax name = SyntaxFactory.IdentifierName("Microsoft");
    name = SyntaxFactory.QualifiedName(name, SyntaxFactory.IdentifierName("CodeAnalysis"));
    name = SyntaxFactory.QualifiedName(name, SyntaxFactory.IdentifierName("CSharp"));
    name = SyntaxFactory.QualifiedName(name, SyntaxFactory.IdentifierName("Scripting"));

    Console.WriteLine(name);

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

    var oldUsing = root.Usings[4];
    var newUsing = oldUsing.WithName(name);

    root = root.ReplaceNode(oldUsing, newUsing);

    Console.WriteLine(root);
}
```

Once the source code is parsed then we replaced the last using statement with the new one. Let's execute the above code and you will see the following output.

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

As you can see the last using statement is updated to `Microsoft.CodeAnalysis.CSharp.Scripting;`.
