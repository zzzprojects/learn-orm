---
PermaID: 100003
Name: Switch Expressions
---

# Switch Expressions

The `switch` expression was introduced in C# 8.0, it provides `switch` like semantics in an expression context. 

 - In `switch` expressions, all the cases are expressions so it's a more 'lightweight' version.
 - It provides a concise syntax when the switch arms produce a value. 
 
The following example shows the structure of a switch expression.

```csharp
var input = 2;

var result = input switch
{
    1 => "Case 1",
    2 => "Case 2",
    3 => "Case 3",
    4 => "Case 4",
    _ => "default"
};

Console.WriteLine(result);
```

Let's implement the same functionality in the traditional `switch` statement and compared it with the new `switch` expressions.

```csharp
var input = 2;

string result;

switch (input)
{
    case 1:
        result = "Case 1";
        break;
    case 2:
        result = "Case 1";
        break;
    case 3:
        result = "Case 1";
        break;
    case 4: 
        result = "Case 1";
        break;
    default:
        result = "default";
        break;
}

Console.WriteLine(result);
``` 

You can see that the new `switch` expressions enable you to use more concise expression syntax. Now let's compare the new `switch` expressions with the traditional `switch` statement.

 - In the `switch` expressions, you can see that there is no `case`, `break` (or `return`) statement, so it means that these keywords are not necessary.
 - The variable comes before the `switch` keyword, the different order makes it visually easy to distinguish the `switch` expression from the `switch` statement. 
 - The `case` and `:` (colon) elements are replaced with the `=>` (arrow), it is nothing but expressions, everything after the arrow is an expression. 
 - The bodies are expressions, not statements.
 - You will also notice that there is no `default` keyword in the `switch` expressions, actually it is replaced with the `_` (underscore).

Let's consider another example that translates values from an `enum` representing visual directions.

```csharp
public enum Directions
{
    Up,
    Down,
    Right,
    Left
}

public static void Example2()
{
    var direction = Directions.Down;
    Console.WriteLine("Map view direction is {0}", direction);

    var orientation = direction switch
    {
        Directions.Up => "North",
        Directions.Right => "East",
        Directions.Down => "South",
        Directions.Left => "West",
        _ => throw new NotImplementedException(),
    };
    Console.WriteLine("Cardinal orientation is {0}", orientation);
}
```

The basic elements of a `switch` expression are as follows:

 - The **range expression:** In the above example, the variable direction is used as the range expression.
 - The **switch expression arms:** Each switch expression arm contains a pattern, an optional case guard, the `=>` token, and an expression.