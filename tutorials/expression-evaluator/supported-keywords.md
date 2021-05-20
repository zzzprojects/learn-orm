---
PermaID: 100007
Name: Supported Keywords
---

# Supported Keywords

As you already know that apart from simple expression evaluation, the **ExpressionEvaluator** allows you to evaluate small scripts which contain methods and variables, etc. Scripts are nothing but just a series of expressions separated by `;` character and led by several additionals keywords.

Currently, the following keywords are supported to use inside a script.

| Type        | Keyword              | Description                                                      |
| :-----------| :--------------------| :----------------------------------------------------------------|
| Conditional | `if`                 | Identifies which statement to run based on the value of a Boolean expression. |
| Conditional | `else if`            | Identifies which statement to run based on the value of a Boolean expression. |
| Conditional | `else`               | Identifies which statement to run based on the value of a Boolean expression. |
| Loop      | `do`                 | Executes a statement or a block of statements while a specified Boolean expression evaluates to true. |
| Loop      | `for`	                | Executes a statement or a block of statements while a specified Boolean expression evaluates to true. |
| Loop      | `foreach`            | Executes a statement or a block of statements for each element in an instance of the type that implements the `IEnumerable` interface.
| Loop      | `while`              | Executes a statement or a block of statements while a specified Boolean expression evaluates to true. |
| Jump      | `break`              | Terminates the closest enclosing loop or switch statement in which it appears.          |
| Jump      | `continue`           | Passes control to the next iteration of the enclosing while, do, for, or foreach statement in which it appears. |
| Jump      | `return`             | Terminates execution of the method in which it appears and returns control to the calling method. |
| Exception | `throw`              | Signals the occurrence of an exception during program execution. |
| Exception | `try-catch`          | The try-catch statement consists of a try block followed by one or more catch clauses, which specify handlers for different exceptions. |
| Exception | `try-finally`        | The statements of a finally block run when control leaves a try statement. |
| Exception | `try-catch-finally` | A common usage of catch and finally together is to obtain and use resources in a try block, deal with exceptional circumstances in a catch block, and release the resources in the finally block. |

The following example evaluates the script which contains multiple `if` and `elseif` statements.

```csharp
class MyClass
{
    public int Marks { get; set; }
    public string Grade { get; set; }
}

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

Now let's consider another example of a script that contains a `for` loop.

```csharp
class ClassA
{
    public int i { get; set; }
    public int sum { get; set; }
}

public static void Example2()
{
    string script = @"
        
        for(a.i = 0; a.i < 10; a.i++)
        {
            a.sum += a.i;
        }";

    var myClass = new ClassA();

    var register = new TypeRegistry();
    register.RegisterSymbol("a", myClass);

    var expression = new CompiledExpression(script)
    {
        TypeRegistry = register,
        ExpressionType = CompiledExpressionType.StatementList
    };

    expression.Eval();
    Console.WriteLine("Sum: {0}", myClass.sum);
}
```
