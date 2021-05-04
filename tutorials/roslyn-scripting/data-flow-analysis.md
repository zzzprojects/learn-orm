---
PermaID: 100015
Name: Data Flow Analysis
---

# Data Flow Analysis

The `DataFlowAnalysis` class provides information about how data flows into and out of a region and you can also use it to inspect how variables are read and written within a given block of code.

The `DataFlowAnalysis` class exposes different properties about unsafe addresses, local variables captured, and much more.

| Properties               | Description                                                                                               |
| :------------------------| :---------------------------------------------------------------------------------------------------------|
| AlwaysAssigned           | The set of local variables for which a value is always assigned inside a region.
| Captured                 | The set of the local variables that have been referenced in anonymous functions within a region and therefore must be moved to a field of a frame class.
| CapturedInside           | The set of variables that are captured inside a region.
| CapturedOutside          | The set of variables that are captured outside a region.
| DataFlowsIn              | The set of local variables which are assigned a value outside a region that may be used inside the region.
| DataFlowsOut             | The set of local variables which are assigned a value inside a region that may be used outside the region.
| DefinitelyAssignedOnEntry| The set of local variables which are definitely assigned a value when a region is entered.
| DefinitelyAssignedOnExit | The set of local variables which are definitely assigned a value when a region is exited.
| ReadInside               | The set of local variables that are read inside a region.
| ReadOutside              | The set of the local variables that are read outside a region.
| Succeeded                | Returns true iff analysis was successful. Analysis can fail if the region does not properly span a single expression, a single statement, or a contiguous series of statements within the enclosing block.
| UnsafeAddressTaken       | The set of non-constant local variables and parameters that have had their address (or the address of one of their fields) taken.
| UsedLocalFunctions       | The set of local functions that are used.
| VariablesDeclared        | The set of local variables that are declared within a region. Note that the region must be bounded by a method's body or a field's initializer, so parameter symbols are never included in the result.
| WrittenInside            | The set of local variables that are written inside a region.
| WrittenOutside           | The set of local variables that are written outside a region.

Let's consider the following sample source code which contains variable declaration before the `for` loop and also inside the `for` loop.

```csharp
static void DataFlowAnalysisExample()
{
    var tree = CSharpSyntaxTree.ParseText(@"
        public class MyClass
        {
           public void TestMethod()
           {
                int[] outerArray = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
                for (int index = 0; index < 10; index++)
                {
                     int[] innerArray = new int[10] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18 };
                     index = index + 2;
                     outerArray[index – 1] = 5;
                }
           }
        }");

    var Mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);

    var compilation = CSharpCompilation.Create("MyCompilation",
        syntaxTrees: new List<SyntaxTree>() { tree }, references: new[] { Mscorlib });
    var model = compilation.GetSemanticModel(tree);

    var forStatement = tree.GetRoot().DescendantNodes().OfType<ForStatementSyntax>().Single();
    DataFlowAnalysis result = model.AnalyzeDataFlow(forStatement);

    foreach (var variable in result.VariablesDeclared)
    {
        Console.WriteLine(variable.Name);
    }            
}
```

Let's execute the above code and you will see the local variables defined inside the `for` loop as an output.

```csharp
index
innerArray
```
