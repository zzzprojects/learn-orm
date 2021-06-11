---
PermaID: 100003
Name: Interface Alignment
---

# Interface Alignment

CS-Script introduces a new script hosting model, known as Interface Alignment (duck-typing), an attractive alternative to the interface inheritance while loading/accessing scripts through interfaces. 

 - It allows manipulation with the script by aligning it to the appropriate interface. 
 - The important aspect of Interface Alignment is that the script execution is completely typesafe. 
 - The script does not have to implement the interface being used by the host application. 
 - The Interface Alignment is possible only as long as the object has all methods defined in the interface. 
 - It allows a high level of decoupling between the host and the script business logic without any type of safety compromise.

Let's consider the following simple interface.

```csharp
public interface ICalculator
{
    public int Add(int a, int b);
    public int Subtract(int a, int b);
    public int Multiply(int a, int b);
    public int Divide(int a, int b);        
}
```

The following example uses the class `Calculator` doesn't inherit from `ICalculator`. The script engine wraps the `calculator` object into a dynamically generated proxy of the `ICalculator` type.

```csharp
public static void Example1()
{
    string script = @"using System;
        class Calculator
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
        }";

    ICalculator calculator = CSScript.Evaluator.LoadCode<ICalculator>(script);

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
