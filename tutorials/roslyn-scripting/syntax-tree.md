---
PermaID: 100009
Name: Syntax Tree
---

# Syntax Tree

The Syntax API exposes the syntax trees that are used by the compilers to understand C# and Visual Basic programs. 

 - The syntax trees are produced by the same parser that runs when a project is built. 
 - Every bit of information in a code file is represented in the tree, including things like comments or whitespace.

The following example shows the syntax tree of a simple hello world program.

```csharp
static void SyntaxTreeExample1()
{
    SyntaxTree tree = CSharpSyntaxTree.ParseText(
        @"using System;
        using System.Collections;
        using System.Linq;
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

    var firstMember = root.Members[0];
    var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
    var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];
    var mainDeclaration = (MethodDeclarationSyntax)programDeclaration.Members[0];
    var argsParameter = mainDeclaration.ParameterList.Parameters[0];
}
```

You can also explore the syntax tree using the query methods defined on `SyntaxNode`. You can use these methods with LINQ to quickly find things in a tree.

```csharp
static void SyntaxTreeExample2()
{
    SyntaxTree tree = CSharpSyntaxTree.ParseText(
        @"using System;
        using System.Collections;
        using System.Linq;
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

    var firstParameters = from methodDeclaration in root.DescendantNodes()
                            .OfType<MethodDeclarationSyntax>()
                          where methodDeclaration.Identifier.ValueText == "Main"
                          select methodDeclaration.ParameterList.Parameters.First();

    Console.WriteLine(firstParameters.FirstOrDefault());
}
```
