---
PermaID: 100010
Name: Syntax Tree Walker
---

# Syntax Tree Walker

The syntax tree approach works well when you are only interested in specific pieces of syntax such as methods, classes, and throw statements, etc. However, sometimes you will need to find all nodes of a specific type within a syntax tree. 

The `CSharpSyntaxWalker` class allows you to create your syntax walker that can visit all nodes, and tokens, etc. We can simply inherit from `CSharpSyntaxWalker` and override any particular method as per your requirements to visit all nodes within the tree. 

Now let's consider we have the following code to parse within a syntax tree.

```csharp
SyntaxTree tree = CSharpSyntaxTree.ParseText(
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
 
namespace Parent
{
    using Microsoft;
    using System.ComponentModel;
 
    namespace Child1
    {
        using Microsoft.Win32;
        using System.Runtime.InteropServices;
 
        class MyClass1 { }
    }
 
    namespace Child2
    {
        using System.CodeDom;
        using Microsoft.CSharp;
 
        class MyClass2 { }
    }
}");
```

As you can see that in the source text, we have `using` directives scattered across four different locations: the file-level, in the `parent` namespace, and in the two nested namespaces.

Let's add a class and replace the following code.

```csharp
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynDemo
{
    class UsingWalker : CSharpSyntaxWalker
    {
        public readonly List<UsingDirectiveSyntax> Usings = new List<UsingDirectiveSyntax>();

        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            if (node.Name.ToString() != "System" && !node.Name.ToString().StartsWith("System."))
            {
                this.Usings.Add(node);
            }
        }
    }
}
```

We have added a `public readonly` field in the `UsingWalker` class to store the `UsingDirectiveSyntax` nodes. In the `VisitUsingDirective` method, it will add a node to the `Usings` collection if `Name` doesn't refer to the `System` namespace or any of its descendant namespaces.

We can now create an instance of the `UsingWalker` class and use that instance to visit the root of the parsed tree and iterate over the `UsingDirectiveSyntax` nodes collected and print their names to the console.

```csharp
static void SyntaxWalkerExample()
{
    SyntaxTree tree = CSharpSyntaxTree.ParseText(
        @"using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using Microsoft.CodeAnalysis;
        using Microsoft.CodeAnalysis.CSharp;
         
        namespace Parent
        {
            using Microsoft;
            using System.ComponentModel;
         
            namespace Child1
            {
                using Microsoft.Win32;
                using System.Runtime.InteropServices;
         
                class MyClass1 { }
            }
         
            namespace Child2
            {
                using System.CodeDom;
                using Microsoft.CSharp;
         
                class MyClass2 { }
            }
        }");

    var root = (CompilationUnitSyntax)tree.GetRoot();

    var walker = new UsingWalker();
    walker.Visit(root);

    foreach (var directive in walker.Usings)
    {
        Console.WriteLine(directive.Name);
    }
}
```

Let's execute the above code and you will see the following output.

```csharp
Microsoft.CodeAnalysis
Microsoft.CodeAnalysis.CSharp
Microsoft
Microsoft.Win32
Microsoft.CodeAnalysis.CSharp.Scripting
Microsoft.CSharp
Microsoft.CodeAnalysis.CSharp.Syntax
Microsoft.CodeAnalysis.Scripting
```