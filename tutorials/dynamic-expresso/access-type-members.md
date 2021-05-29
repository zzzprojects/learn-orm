---
PermaID: 100009
Name: Access Type Members
---

# Access Type Members

**Dynamic Expresso** allows you to access any member such as method, field, property, or constructor of any .NET type. You can also add additional types and use their members in your expression.

Let's consider the following class which contains a field, property, and methods.

```csharp
class MyClass
{
    public int MyField;
    public int MyProperty { get; set; }

    public int MyMethod(int value)
    {
        return 2 * value + 3;
    }

    public void SetFieldValue(int value)
    {
        MyField = value;
    }
}
```

The following example shows how to access the class members in your expression.
 
```csharp
public static void Example1()
{
    Interpreter interpreter = new Interpreter();
    interpreter.Reference(typeof(MyClass));

    interpreter.SetVariable("obj", new MyClass()
    {
        MyProperty = 10
    });

    string expression = "obj.MyMethod(obj.MyField + obj.MyProperty)";

    var result = interpreter.Eval(expression);
    Console.WriteLine(result);
}
```
