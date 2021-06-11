---
PermaID: 100004
Name: Execute Methods
---

# Execute Methods

The **CS-Script** allows you to compile code that only contains method(s). The Evaluator will wrap the method(s) code into a class definition with the name `DynamicClass`.

Let's consider the following simple script code, which contains only methods definition.

```csharp
public int Add(int a, int b)
{
    return a + b;
}

public int Subtract(int a, int b)
{
    return a - b;
}

public int Multiply(int a, int b)
{
    return a * b;
}

public int Divide(int a, int b)
{
    return a / b;
}
```

To evaluate code that only contains method(s), you can use the `Evaluator.LoadMethod` function is shown below.

```csharp
public static void Example1()
{
    string script = @"public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            return a / b;
        }
    ";

    dynamic calculator = CSScript.Evaluator.LoadMethod(script);

    Console.WriteLine("Add(10, 5): {0}", calculator.Add(10, 5));
    Console.WriteLine("Subtract(10, 5): {0}", calculator.Subtract(10, 5));
    Console.WriteLine("Multiply(10, 5): {0}", calculator.Multiply(10, 5));
    Console.WriteLine("Divide(10, 5): {0}", calculator.Divide(10, 5));
}
```

Let's execute the above code, and you will see the following output.

```csharp
Add(10, 5): 15
Subtract(10, 5): 5
Multiply(10, 5): 50
Divide(10, 5): 2
```
