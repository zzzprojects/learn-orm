---
PermaID: 100010
Name: Expression Owner
---

# Expression Owner

The **Flee** library allows you to attach an expression to a class. The class to which the expression is attached is known as the expression owner. 

 - When an expression is attached, it behaves like an instance method of the owner class and has access to all the members.
 - You can reference the owner's instance members accessing fields and properties, which is faster than using variables.
 - By default, an expression will only allow access to the public members of its owner. 
 - You can use the `ExpressionOptions.OwnerMemberAccess` property to grant/deny access to the public and non-public members of the owner. 

Let's consider the following class, which we will use as an owner class. It contains a field, property, and some functions.

```csharp
class MyClass
{
    private int MyField;

    public int MyFunc(int value)
    {
        return 2 * value + 3;
    }

    public void SetFieldValue(int value)
    {
        MyField = value;
    }

    public int MyProperty
    {
        get { return 11; }
    }
}
```

You can use the above class in expression by passing its object to the `ExpressionContext` constructor as the owner and reference its members in the expression as shown below.

```csharp
public static void Example1()
{
    MyClass owner = new MyClass();
    ExpressionContext context = new ExpressionContext(owner);

    context.Options.OwnerMemberAccess = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic;

    IDynamicExpression e = context.CompileDynamic("MyFunc(Myfield + MyProperty)");
    object result = e.Evaluate();

    Console.WriteLine(result);
    // Create another instance of the owner
    MyClass owner2 = new MyClass();

    owner2.SetFieldValue(3);
    // Set it on the expression
    e.Owner = owner2;

    // Re-evaluate
    result = e.Evaluate();
    Console.WriteLine(result);
}
```

You can also use the `ExpressionOwnerMemberAccessAttribute` to explicitly set the accessibility of fields, properties, and methods on the owner. 

 - The setting in the attribute overrides the setting in the `ExpressionOptions`. 
 - You can deny access to all non-public members but allow access to a specific non-public member by tagging it with the attribute.

Let's add the following function to our owner class.

```csharp
[ExpressionOwnerMemberAccess(false)]
public int MyFunc1()
{
    return 1;
}
```

As you can see, we decorated the above function with `[ExpressionOwnerMemberAccess(false)]`, so this function will never be accessible in an expression because the `false` setting on the attribute will override the setting in the `ExpressionOptions`.
