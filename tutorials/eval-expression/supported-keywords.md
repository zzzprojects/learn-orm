---
PermaID: 100008
Name: Supported Keywords
---

# Supported Keywords

As you already know that apart from simple expression execution, the **Z.Expressions.Eval** allows you to execute and compile small scripts which contain methods and variables, etc. Scripts are nothing but just a series of expressions separated by `;` character and led by several additionals keywords.

Currently, all most all C# keywords are supported to use inside a script. The following example executes the script which contains multiple `if` and `elseif` statements.

```csharp
public static void Example1()
{
    string script = @"
        
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

    var result = Eval.Execute<string>(script, new { marks = 77 });
    Console.WriteLine("Grade: {0}", result);
}
``` 

Let's run the above code and you will see the following output.

```csharp
Grade: B
```

Now let's consider another example of a script that contains a `for` loop.

```csharp
public static void Example2()
{
    string script = @"  
        for(;i < 10; i++)
        {
            Console.WriteLine(i*i);
        }";


    var compiled = Eval.Compile<Action<int>>(script, "i");
    compiled(0);
}
```

Let's run the above code and you will see the following output.

```csharp
0
1
4
9
16
25
36
49
64
81
```