---
PermaID: 100005
Name: Define Variables On Demand
---

# Define Variables On Demand

In some cases, you may not be able to define an expression's variables when it is compiled. In such cases, you can use the on-demand variables. If an expression references a variable that doesn't exist in the expression's variables, **Flee** will raise the following two events.

 - **ResolveVariableType:** Specify the type for a variable. 
 - **ResolveVariableValue** Specify the value for a variable.

If the `ResolveVariableType` event is handled and a type is specified, Flee will then raise the `ResolveVariableValue` event every time the expression is evaluated. In that event, you have access to the variable's name and type and it is up to you to provide a compatible value.

The following example uses on-demand variables to ask the user for the value of each variable in the expression.

```csharp
public static void Example()
{
    ExpressionContext context = new ExpressionContext();

    context.Variables.ResolveVariableType += new EventHandler<ResolveVariableTypeEventArgs>(GetVariableType);
    context.Variables.ResolveVariableValue += new EventHandler<ResolveVariableValueEventArgs>(GetVariableValue);

    string expression = "(a + b) * 1.5";

    IDynamicExpression e = context.CompileDynamic(expression);

    object result = e.Evaluate();
    Console.WriteLine("The result is: {0}", result);
}

private static void GetVariableType(object sender, ResolveVariableTypeEventArgs e)
{
    e.VariableType = typeof(double);
}

private static void GetVariableValue(object sender, ResolveVariableValueEventArgs e)
{
    Console.Write("Enter value for variable '{0}' ({1}): ", e.VariableName, e.VariableType.Name);
    string value = Console.ReadLine();
    e.VariableValue = Convert.ChangeType(value, e.VariableType);
}
```

As you can see that two event handlers are defined, the `GetVariableType` specifies the type for a variable and `GetVariableValue` will ask the user to specify the value for that particular variable.

Let's execute the above code, and you will see the following output.

```csharp
Enter value for variable 'a' (Double): 3.5
Enter value for variable 'b' (Double): 4.0
The result is: 11.25
```