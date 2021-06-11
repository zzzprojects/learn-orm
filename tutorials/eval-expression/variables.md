---
PermaID: 100003
Name: Variables
---

# Variables

The **Z.Expressions.Eval** library provides the following standard constants, which you can use directly in the expressions or script.

| Constant         | Value                | Type            |
| :----------------| :--------------------| :---------------|
| null             | C# null value        | N/A             |
| true             | C# true value        | Boolean         |
| false            | C# false value       | Boolean         |

You can also define your custom variables and specify them as a parameter to use in the expression in any of the following ways.

 - [Anonymous Type](#anonymous-type)
 - [Argument Position](#argument-position)
 - [Class Member](#class-member)
 - [Dictionary](#dictionary)

## Anonymous Type

You can specify variables that you want to use in the expression as an anonymous type. The following example adds two variables `a` and `b` and used them inside an expression using anonymous type.

```csharp
public static void Example1()
{
    string expression = "a*2 + b*3 - 3";
    int result = Eval.Execute<int>(expression, new { a = 10, b = 5 });
    Console.WriteLine("{0} = {1}", expression, result);
}
```

## Argument Position

You can also specify values directly as argument position parameters as shown below.

```csharp
public static void Example2()
{
    string expression = "{0}*2 + {1}*3 - 3";
    int result = Eval.Execute<int>(expression, 10, 5);
    Console.WriteLine("{0} = {1}", expression, result);
}
```

## Class Member

The **Z.Expressions.Eval** library allows you to use class members inside expression by passing the class object as a parameter.

```csharp
public static void Example3()
{
    string expression = "a*2 + b*3 - 3";
    dynamic expandoObject = new ExpandoObject();
    expandoObject.a = 10;
    expandoObject.b = 5;

    int result = Eval.Execute<int>(expression, expandoObject);
    Console.WriteLine("{0} = {1}", expression, result);
}
```

## Dictionary

You can also define your custom variables in a dictionary and pass the object as a parameter

```csharp
public static void Example4()
{
    string expression = "a*2 + b*3 - 3";

    var values = new Dictionary<string, object>() 
    { 
        { "a", 10 }, 
        { "b", 5 } 
    };

    int result = Eval.Execute<int>(expression, values);
    Console.WriteLine("{0} = {1}", expression, result);
}
```

