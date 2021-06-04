---
PermaID: 100007
Name: Debugging
---

# Debugging

All the three compiling engines support compiling services that are normalized via the common `Evaluator` interface, but some of the critical features only available in the dedicated Evaluators. 

 - The **CodeDom Evaluator** is a champion of all the compilers as no others can match its flexibility. 
 - It is the only compiler platform that supports script debugging.

To enable the debugging you will need to set the `DebugBuild` property to `true`.

```csharp
CSScript.EvaluatorConfig.DebugBuild = true;
```

You will also need to use the **CodeDom Evaluator** while using the debugging feature as shown below.

```csharp
CSScript.EvaluatorConfig.Engine = EvaluatorEngine.CodeDom;
```

The following example shows how to use debugging in your script.

```csharp
public static void Example1()
{
    CSScript.EvaluatorConfig.DebugBuild = true;
    CSScript.EvaluatorConfig.Engine = EvaluatorEngine.CodeDom;

    dynamic calculator = CSScript.Evaluator.LoadCode(@"using System;
        using System.Diagnostics;
        public class Calculator
        {
            public int Divide(int a, int b)
            {
                Debug.Assert(b == 0, ""The second argument can not be zero (0)."");
                return a / b;
            }
        }");

    Console.WriteLine("calculator.Divide(20, 4): {0}", calculator.Divide(20, 4));
    Console.WriteLine("calculator.Divide(30, 4): {0}", calculator.Divide(30, 4));
    Console.WriteLine("calculator.Divide(3, 0): {0}", calculator.Divide(3, 0));
}
```
