---
PermaID: 100002
Name: Simple Script
---

# Simple Script

The **CS-Script** allows you to execute either code fragments or entire class(es) definitions. A script can automatically access host types without any restrictions except types visibility (public vs. private). 

The **CS-Script** library provides different overloads of the `LoadCode` method that evaluates and loads C# code to the current AppDomain. Returns instance of the first class defined in the code.

The following example shows the evaluation of a simple script that contains a `Calculator` class and then accessing the script members dynamically.

```csharp
public static void Example1()
{
    dynamic calculator = CSScript.Evaluator.LoadCode(@"using System;
        public class Calculator
        {
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
        }"
    );

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