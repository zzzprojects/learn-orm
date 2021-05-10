---
PermaID: 100003
Name: Script Expressions
---

# Script Expressions

Scripts are nothing but just a series of expressions separated by `;` character. The **CodingSeb.ExpressionEvaluator** gives you the ability to dynamically build C# script into a string, and evaluate it all inside your program by using the `ScriptEvaluate` method.

The following example evaluates the script, which contains multiple `if` and `elseif` statements.

```csharp
public static void Example1()
{
    string script = @"
        marks = 79;
        
        if ( marks >= 80)
        {
            return ""A"";
        }
        else if (marks >= 70)
        {
            return ""B"";
        }
        else if(marks >= 60)
        {
            return ""C"";
        }
        else if(marks >= 50)
        {
            return ""D"";
        }
        else
        {
            return ""F"";
        }";

    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.ScriptEvaluate(script));
}
``` 

Now let's consider another example of script that contains a `for` loop.

```csharp
public static void Example2()
{
    string script = @"
        result = """";
        
        for(i = 0; i < 10; i++)
        {
            result += $""{i*i},"";
        }
        
        result.Remove(result.Length - 1);";

    ExpressionEvaluator evaluator = new ExpressionEvaluator();
    Console.WriteLine(evaluator.ScriptEvaluate(script));
}
```
