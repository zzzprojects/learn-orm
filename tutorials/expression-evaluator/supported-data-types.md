---
PermaID: 100003
Name: Supported Data Types
---

# Supported Data Types

The primitive data types are predefined by the language and they are named by reserved keywords. They represent the basic types of the language.

The **ExpressionEvaluator** manages the following list of C# primary types.

 - object/Object
 - bool/Boolean
 - byte/Byte
 - char/Char
 - short/Int16
 - int/Int32
 - long/Int64
 - ushort/UInt16
 - uint/UInt32
 - ulong/UInt64
 - decimal/Decimal
 - double/Double
 - float/Single
 - string/String

The **ExpressionEvaluator** allows you to call static methods on these types from within your expression as shown below.

```csharp
public static void Example1()
{
    var expression = new CompiledExpression("float.Parse('13.98')");
    var result = expression.Eval();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```

You can add additional types by using the `TypeRegistry` class which contains the methods for registering types and symbols. After adding a type of symbol you will also need to set the `TypeRegistry` property of the `CompiledExpression` instance before the expression is parsed.

The following example registers the symbol **Guid** as the type `Guid`.

```csharp
public static void Example2()
{
    var registry = new TypeRegistry();
    registry.RegisterType("Guid", typeof(Guid));  
    var expression = new CompiledExpression("Guid.NewGuid()") { TypeRegistry = registry };
    var result = expression.Eval();
    Console.WriteLine("{0} ({1})", result, result.GetType());
}
```

You can also use your own data type using the same technique. Let's consider you have a simple class `Point3D` and you want to use the `Point3D` type in your expression.

```csharp
public static void Example4()
{
    var point = new Point3D() { X = 0.00, Y = 1.00, Z = 0.00 };
    string expressionStr = "point3D.Y + 10";
    var register = new TypeRegistry();
    register.RegisterSymbol("point3D", point);

    var expression = new CompiledExpression(expressionStr) { TypeRegistry = register };

    Console.WriteLine("Result: {0}", expression.Eval());
}

class Point3D
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}
```

Now when you run the above code you will see the following output.

```csharp
Result: 11
```

