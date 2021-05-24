---
PermaID: 100011
Name: Arrays and Collections
---

# Arrays and Collections

The **Flee** library supports loading values from arrays and collections on the expression owner. 

 - You simply need to use square brackets (`[]`) after the variable and specify an index which can itself be another expression or variable. 
 - If the variable being indexed is an array, **Flee** will emit IL optimized for loading array elements. 
 - If the indexed variable is not an array, **Flee** will try to find a default indexer property and use it instead. 
 - If the variable being indexed is not an array and does not have a default indexer, **Flee** will throw an `ExpressionCompileException`.

Let's consider the following class which we will use as an owner class and it contains an array and collection.

```csharp
class MyClass
{
    public int[] MyArray;
    public List<int> MyList;

    public MyClass()
    {
        MyArray = new int[] { 1, 3, 5, 7, 9};

        MyList = new List<int>() {0, 2, 4, 6, 8, 10};
    }
}
```

The following code shows how to index array and collection variables on the expression owner.

```csharp
public static void Example1()
{
    MyClass owner = new MyClass();
    ExpressionContext context = new ExpressionContext(owner);
    context.Variables.Add("index", 2);

    string expression = "MyArray[3]";
    IGenericExpression<int> eGeneric = context.CompileGeneric<int>(expression);
    int result = eGeneric.Evaluate();
    Console.WriteLine("{0} = {1}", expression, result);

    expression = "MyList[index + 1]";
    eGeneric = context.CompileGeneric<int>(expression);
    result = eGeneric.Evaluate();
    Console.WriteLine("{0} = {1}", expression, result);
}
```

As you can see that we have defined an expression owner class with some array and collection members. Let's execute the above code, and you will see the following output.

```csharp
MyArray[3] = 7
MyList[index + 1] = 6
``` 
