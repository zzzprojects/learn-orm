---
PermaID: 100004
Name: Compile Multiple Statements
---

# Compile Multiple Statements

Scripts are nothing but just a series of expressions separated by `;` character. The **ExpressionEvaluator** gives you the ability to compile several statements into one function using the `ExpressionType` property of the `CompiledExpression` object.

The following example evaluates the script, which contains multiple `if` and `elseif` statements.


```csharp
public static void Example1()
{
    string script = @"
        
        if ( a.Marks >= 80)
        {
            a.Grade = 'A';
        }
        else if (a.Marks >= 70)
        {
            a.Grade = 'B';
        }
        else if(a.Marks >= 60)
        {
            a.Grade = 'C';
        }
        else if(a.Marks >= 50)
        {
            a.Grade = 'D';
        }
        else
        {
            a.Grade = 'F';
        }
        ";

    var myClass = new MyClass() { Marks = 79 };

    var register = new TypeRegistry();
    register.RegisterSymbol("a", myClass);

    var expression = new CompiledExpression(script) 
    { 
        TypeRegistry = register, 
        ExpressionType = CompiledExpressionType.StatementList 
    };    

    expression.Eval();
    Console.WriteLine("Grade: {0}", myClass.Grade);
}
``` 

Now let's execute the above code, and you will see the following output.

```csharp
Grade: B
```

To compile multiple statements, simply set the `ExpressionType` property to `CompiledExpressionType.StatementList` before any of the Eval or Compile methods are called.
