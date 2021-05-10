---
PermaID: 100012
Name: Syntax Transformation
---

# Syntax Transformation

As you know that syntax trees are immutable, so instead of modifying existing syntax trees, we need to create new trees using transformations when need to modify them.

The `SyntaxFactory` class provides factory methods to create `SyntaxNodes` for each kind of node, token, or trivia which we can use to create an instance of that type.

The `NameSyntax` is the base class for the following four types.

| Name                   | Description                                                                               |
| :----------------------| :----------------------------------------------------------------------------------------|
| IdentifierNameSyntax   |  It represents simple single identifier names like System and Microsoft.
| GenericNameSyntax      |  It represents a generic type or method name such as List.
| QualifiedNameSyntax    |  It represents a qualified name of the form <left-name>.<right-identifier-or-generic-name> such as System.IO.
| AliasQualifiedNameSyntax |  It represents a name using an assembly extern alias such a LibraryV2::Foo By composing these names together, you can create any name which can appear in the C# language.

Let's consider the following simple example code, which contains various using directives at the top of the source code.

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

As you can see, the last using directive is `Microsoft.CodeAnalysis;`, now we will replace this using directive with `Microsoft.CodeAnalysis.CSharp.Scripting;` using the transformation.

The following code first creates a `NameSyntax` node using the `IdentifierName` and `QualifiedName` methods for the using directive which we will replace.

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

Once the source code is parsed, then we replaced the last using directive with the new one. Let's execute the above code and you will see the following output.

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
