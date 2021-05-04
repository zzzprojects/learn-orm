---
PermaID: 100016
Name: Control Flow Analysis
---

# Control Flow Analysis

The `ControlFlowAnalysis` class provides information about statements that transfer control in and out of a region. 

 - You can use control flow analysis to understand the various entry and exit points within a block of code. 
 - For example, if you are analyzing a method, you might want to know all the points at which you can return out of the method or in a `for` loop, you want to know all the places where it will break or continue.

Let's consider the following example, in which a `for` loop is analyzed.

```csharp
static void ControlFlowAnalysisExample()
{
    var tree = CSharpSyntaxTree.ParseText(@"
        class MyClass
        {
            void TestMethod()
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 2)
                        continue;
                    if (i == 7)
                        break;
                }
            }
        }
    ");

    var Mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
    var compilation = CSharpCompilation.Create("MyCompilation",
        syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
    var model = compilation.GetSemanticModel(tree);

    var firstFor = tree.GetRoot().DescendantNodes().OfType<ForStatementSyntax>().Single();
    ControlFlowAnalysis result = model.AnalyzeControlFlow(firstFor.Statement);

    foreach (var exitPoint in result.ExitPoints)
    {
        Console.WriteLine(exitPoint);
    }
}
```

Let's execute the above code and you will see the both `continue` and `break` statements are used inside the `for` loop as an output.

```csharp
continue;
break;
```
